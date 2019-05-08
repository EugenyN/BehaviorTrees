// Copyright(c) 2015-2019 Eugeny Novikov. Code under MIT license.

using BehaviorTrees.Engine;
using BehaviorTrees.IronPython;
using BehaviorTrees.IronPython.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.Serialization;

namespace BehaviorTrees.IronPython
{
	/// <summary>
	/// Node that can perform some action.
	/// </summary>
	[DataContract]
	[BTNode("Script", "Action")]
	public class ScriptedAction : Node
	{
		string _action;
		CachedFunction _fn;

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		[Editor(typeof(ScriptUITypeEditor), typeof(UITypeEditor))]
		public string Action
		{
			get { return _action; }
			set 
			{
				if (_action == value)
					return;

				_action = value;
				_fn = new CachedFunction(_action, null, false);

				Root.SendValueChanged(this);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override string NodeParameters
		{
			get { return _action; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="action"></param>
		public ScriptedAction(string action)
		{
			Action = action;
		}

		/// <summary>
		/// 
		/// </summary>
		public ScriptedAction()
		{
			Action = "";
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="newOwner"></param>
		protected override void OnAttachedToOwner(Entity newOwner)
		{
			base.OnAttachedToOwner(newOwner);
			var po = PythonObject.CreateTempObj();
			po.SetMember("owner", Owner);
			Root.RootNode.ScriptedContext = po;
		}

		/// <summary>
		///
		/// </summary>
		/// <returns></returns>
		protected override ExecutingStatus OnExecuted()
		{
			_fn.CallWithSelf((PythonObject)ScriptedContext);
			return ExecutingStatus.Success;
		}
	}
}
