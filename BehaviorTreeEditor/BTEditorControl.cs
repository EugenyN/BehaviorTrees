// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using BehaviorTrees;
using BehaviorTrees.Engine;
using BehaviorTrees.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace BehaviorTreesEditor
{
	public partial class BTEditorControl : UserControl
	{
		public BTEditorControl()
		{
			InitializeComponent();

			_engine.SceneLoaded += _engine_SceneLoaded;
			_engine.ExecutionCompleted += _engine_ExecutionCompleted;

			_nodeTypes = new List<Type>(GetNodeTypes());
		}

		readonly Engine _engine = Engine.Instance;

		BTScript _script;
		TreeListController<Node> _controller;
		readonly List<Type> _nodeTypes;

		public BTScript Script
		{
			get { return _script; }
			set { _script = value; }
		}

		public event EventHandler ScriptNameChanged;

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				UnloadData();
				_engine.SceneLoaded -= _engine_SceneLoaded;
				_engine.ExecutionCompleted -= _engine_ExecutionCompleted;
				if (components != null)
					components.Dispose();
			}
			base.Dispose(disposing);
		}


		public void LoadData(BTScript script)
		{
			if (_engine.IsDesignMode)
				return;

			UnloadData();

			_script = script;

			_controller = new TreeListController<Node>(
				behaviorTreeTL, _script.BehaviorTree, new BTNodeMapper());
			_controller.AutoSortCompare = null;

			if (behaviorTreeTL.Nodes.Count > 0)
				behaviorTreeTL.Nodes[0].ExpandAll();
			behaviorTreeTL.FocusedNode = null;
			behaviorTreeTL.FocusedNode = behaviorTreeTL.Nodes.FirstNode;

			ScriptNameChanged?.Invoke(this, EventArgs.Empty);
		}

		public void LoadEmpty()
		{
			_engine.LoadScene(new List<Entity> { new Entity("Actor1") },
				new BTScript("New Script", new Sequence()));
		}

		private void UnloadData()
		{
			_script = null;

			if (_controller != null)
				_controller.Dispose();
		}

		private void _engine_SceneLoaded(object sender, EventArgs e)
		{
			FillEntityComboBox();
			if (_engine.BTScript != null)
				LoadData(_engine.BTScript);
		}

		private void NewTSButton_Click(object sender, EventArgs e)
		{
			LoadEmpty();
		}

		private void ShowSaveFileDialog()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = Path.GetFileNameWithoutExtension(_script.FileName) + ".btree";
			saveFileDialog.Filter = "BT Scripts (*.btree)|*.btree|All files (*.*)|*.*";

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				_script.Save(saveFileDialog.FileName);
				ScriptNameChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		private void LoadTSButton_Click(object sender, EventArgs e)
		{
			using (var openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "BT Scripts (*.btree)|*.btree|All files (*.*)|*.*";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
					_script = BTScript.Load(openFileDialog.FileName);
			}

			_engine.LoadScene(new List<Entity> { new Entity("Actor1") }, _script);
		}

		private void SaveTSButton_ButtonClick(object sender, EventArgs e)
		{
			if (!_script.Saved)
				ShowSaveFileDialog();
			else
				_script.Save(_script.FileName);
		}

		private void SaveAsTSButton_Click(object sender, EventArgs e)
		{
			ShowSaveFileDialog();
		}

		private void ExecuteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			executeTSButton_Click(null, null);
		}

		private void BehaviorTreeTL_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right)
				return;

			if (_script == null)
				return;

			var hitNode = behaviorTreeTL.CalcHitNode(e.Location);
			BuildTreeViewMenu(hitNode);
			behaviorTreeCMS.Show(behaviorTreeTL, e.Location);
		}

		private void BehaviorTreeTL_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (_controller == null)
				return;

			if (behaviorTreeTL.NodesSelection.Count == 0)
				return;

			var treeNode = behaviorTreeTL.NodesSelection[0];
			var node = _controller.GetDataNode(treeNode);

			propertyGrid1.SelectedObject = node;
		}

		#region "Script Execution"

		public void ExecuteScript()
		{
			var ent = GetSelectedEntity();
			if (ent != null)
			{
				var instance = Reflector.Clone(_script.BehaviorTree);
				_engine.ExecuteScript(instance, ent);
				entityComboBox.Enabled = false;
				executeTSButton.Enabled = false;
			}
		}

		public void StopScript()
		{
			_engine.StopScript();
		}

		private void _engine_ExecutionCompleted(Node arg1, EventArgs arg2)
		{
			entityComboBox.Enabled = true;
			executeTSButton.Enabled = true;
		}

		private Entity GetSelectedEntity()
		{
			var name = (string)entityComboBox.SelectedItem;

			if (string.IsNullOrEmpty(name))
			{
				Log.Write("name == \"\"");
				return null;
			}

			var ent = _engine.Entities.FirstOrDefault(e => e.Name == name);

			if (ent == null)
			{
				Log.Write("ent == null");
				return null;
			}

			return ent;
		}

		private void FillEntityComboBox()
		{
			entityComboBox.Text = "";
			entityComboBox.Items.Clear();

			foreach (var ent in _engine.Entities)
			{
				if (ent != null)
					entityComboBox.Items.Add(ent.Name);
			}

			entityComboBox.SelectedIndex = 0;
		}

		private void executeTSButton_Click(object sender, EventArgs e)
		{
			ExecuteScript();
		}

		private void stopTSButton_Click(object sender, EventArgs e)
		{
			StopScript();
		}

		#endregion

		#region "Context menu"

		private void BuildTreeViewMenu(CommonTools.Node treeListNode)
		{
			behaviorTreeCMS.Items.Clear();

			var root = _controller.Data.Root.RootNode;
			var node = treeListNode != null ? treeListNode.Tag as Node : root;

			if (node is Composite || (node is Decorator && node.Nodes.Count == 0))
			{
				foreach (var type in _nodeTypes)
				{
					var nodeName = Node.GetName(type);
					var nodeType = Node.GetType(type);

					var items = GetMenuItem(behaviorTreeCMS.Items, nodeType);
					if (items == null)
						items = AddMenuItem(nodeType, null, null);

					AddMenuItem(items, nodeName, type, t => AddNewNode(t, node));
				}
			}

			if (node != root)
			{
				AddMenuItem("Remove Node", null, t => node.Remove());
			}
		}

		private void AddNewNode(Type type, Node parent)
		{
			var newNode = (Node)Activator.CreateInstance(type);
			parent.Nodes.Add(newNode);
			var viewNode = _controller.GetViewNode(parent);
			if (viewNode != null)
				viewNode.ExpandAll();
		}

		private static ToolStripItemCollection GetMenuItem(ToolStripItemCollection items, string itemName)
		{
			foreach (ToolStripMenuItem item in items)
			{
				if (item.Text == itemName)
					return item.DropDownItems;
			}
			return null;
		}

		private ToolStripItemCollection AddMenuItem(
			string name, Type type, Action<Type> action)
		{
			return AddMenuItem(behaviorTreeCMS.Items, name, type, action);
		}

		private static ToolStripItemCollection AddMenuItem(
			ToolStripItemCollection items, string name, Type type, Action<Type> action)
		{
			var menuItem = new ToolStripMenuItem(name);
			menuItem.Tag = type;
			if (action != null)
			{
				menuItem.MouseUp += (sender, e) =>
				{
					if (e.Button == MouseButtons.Left)
						action((Type)((ToolStripMenuItem)sender).Tag);
				};
			}
			items.Add(menuItem);
			return menuItem.DropDownItems;
		}

		private static IEnumerable<Type> GetNodeTypes()
		{
			foreach (var type in Reflector.GetAllDerivedTypes(typeof(Node), true))
			{
				var attr = type.GetCustomAttribute<BTNodeAttribute>();
				if (attr != null && attr.ShowInEditor)
					yield return type;
			}
		}

		#endregion
	}
}
