// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using BehaviorTrees.Collections;
using System;
using System.Collections.Generic;
using CT = CommonTools;

namespace BehaviorTreesEditor
{
	/// <summary>
	/// 
	/// </summary>
	internal class TreeNodeCompare<T> : IComparer<T> where T : TreeNode<T>
	{
		readonly IComparer<T> _valueCompare;

		public TreeNodeCompare(IComparer<T> valueCompare)
		{
			_valueCompare = valueCompare;
		}

		public int Compare(T x, T y)
		{
			return _valueCompare.Compare(x, y);
		}
	}


	/// <summary>
	/// 
	/// </summary>
	public interface ITreeListNodeMapper<T> where T : TreeNode<T>
	{
		void UpdateNode(T dataNode, CT.Node treeNode, CT.TreeListView view);
		T GetNodeInfo(CT.Node treeNode);
	}


	/// <summary>
	/// 
	/// </summary>
	public class TreeLisNodeDefaultMapper<T> : ITreeListNodeMapper<T> where T : TreeNode<T>
	{
		public void UpdateNode(T dataNode, CT.Node treeNode, CT.TreeListView view)
		{
			treeNode.Tag = dataNode;
		}

		public T GetNodeInfo(CT.Node treeNode)
		{
			return (T)treeNode.Tag;
		}
	}


	/// <summary>
	/// 
	/// </summary>
	public class TreeListController<T> : IDisposable where T : TreeNode<T>
	{
		private CT.TreeListView _treeList;
		private T _data;
		private ITreeListNodeMapper<T> _nodeMapper;

		IComparer<T> _valueCompare;      // supplied by caller: compares node values
		IComparer<T> _nodeCompare;       // helper object: compares T<T>'s
		
		public T Data
		{
			get { return _data; }
		}

		public IComparer<T> AutoSortCompare
		{
			get { return _valueCompare; }
			set
			{
				if (_valueCompare == value) // avoid updating all items
					return;

				_valueCompare = value;
				_nodeCompare = (_valueCompare != null) ? new TreeNodeCompare<T>(_valueCompare) : null;

				UpdateAllNodes();
			}
		}

		public T SelectedNode
		{
			get { return GetDataNode(_treeList.FocusedNode); }
			set
			{
				var node = GetViewNode(value);
				if (node != null)
					_treeList.FocusedNode = node;
			}
		}

		public TreeListController(CT.TreeListView view, T data)
		{
			Construct(view, data, null);
		}

		public TreeListController(CT.TreeListView view, T data, ITreeListNodeMapper<T> nodeMapper)
		{
			Construct(view, data, nodeMapper);
		}

		private void Construct(CT.TreeListView view, T data, ITreeListNodeMapper<T> nodeMapper)
		{
			_treeList = view;
			_data = data;
			_nodeMapper = nodeMapper ?? new TreeLisNodeDefaultMapper<T>();

			UpdateAllNodes();

			_data.Root.NodeChanged += NodeChanged;
			_data.Root.ValueChanged += ValueChanged;
		}

		public T GetDataNode(CT.Node viewNode)
		{
			if (viewNode == null)
				return null;
			return _nodeMapper.GetNodeInfo(viewNode);
		}

		public CT.Node GetViewNode(T dataNode)
		{
			return FindTreeListNode(dataNode, _treeList.Nodes);
		}

		protected CT.Node FindTreeListNode(T dataNode, CT.NodeCollection where)
		{
			foreach (CT.Node viewNode in where)
			{
				if (viewNode.Tag == dataNode)
					return viewNode;

				var found = FindTreeListNode(dataNode, viewNode.Nodes);
				if (found != null)
					return found;
			}
			return null;
		}

		public void UpdateAllNodes()
		{
			UpdateNode(_data, true);
		}

		public void UpdateNode(T dataNode, bool recursive)
		{
			var selectedNode = SelectedNode;
			_treeList.BeginUpdate();
			UpdateNode(dataNode, GetViewNode(dataNode), recursive);
			_treeList.EndUpdate();
			SelectedNode = selectedNode;
		}

		public void UpdateNode(CT.Node viewNode, bool recursive)
		{
			var selectedNode = SelectedNode;
			_treeList.BeginUpdate();
			UpdateNode(GetDataNode(viewNode), viewNode, recursive);
			_treeList.EndUpdate();
			SelectedNode = selectedNode;
		}

		private void UpdateNode(T dataNode, CT.Node treeNode, bool recursive)
		{
			if (dataNode == _data) // special handling for "root node changed"
			{
				if (recursive)
					UpdateNodeList(dataNode.Nodes, _treeList.Nodes);
			}
			else
			{
				if (treeNode == null)
					return;
				_nodeMapper.UpdateNode(dataNode, treeNode, _treeList);

				if (recursive)
				{
					if (dataNode.HasChildren)
						UpdateNodeList(dataNode.Nodes, treeNode.Nodes);
					else
						treeNode.Nodes.Clear();
				}
			}
		}

		private void UpdateNodeList(TreeNodeCollection<T> dataNodes, CT.NodeCollection viewNodes)
		{
			var list = new List<T>(dataNodes);
			if (_nodeCompare != null)
				list.Sort(_nodeCompare);

			// update existing nodes
			int existing = Math.Min(list.Count, viewNodes.Count);

			for (int i = 0; i < existing; ++i)
				UpdateNode(list[i], viewNodes[i], true);

			// add items if necessary
			if (list.Count > viewNodes.Count)
			{
				for (int i = viewNodes.Count; i < list.Count; ++i)
				{
					CT.Node node = new CT.Node();
					viewNodes.Add(node);
					UpdateNode(list[i], node, true);
				}
			}
			else if (list.Count < viewNodes.Count)  // ..or else remove items if necessary
			{
				int removeCount = viewNodes.Count - list.Count;
				for (int i = 0; i < removeCount; ++i)
					viewNodes.Remove(viewNodes.NodeAtIndex(viewNodes.Count - 1));
			}
		}

		private void ValueChanged(object sender, TreeEventArgs<T> e)
		{
			UpdateNode(e.Node, false);
		}

		private void NodeChanged(object sender, TreeEventArgs<T> e)
		{
			UpdateNode(e.Node, true);
		}

		public void Dispose()
		{
			if (_data == null)
				return;

			_data.Root.NodeChanged -= NodeChanged;
			_data.Root.ValueChanged -= ValueChanged;
		}
	}
}
