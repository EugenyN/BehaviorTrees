// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using BehaviorTrees.Engine;
using System.Runtime.Serialization;

namespace BehaviorTrees
{
	/// <summary>
	/// Node that can perform some action.
	/// </summary>
	[DataContract]
	[BTNode("Action", "Action")]
	public class ActionAction : Node
	{
		ActionBase _action;

		[DataMember(Name = "Behavior")]
		public ActionBase Action
		{
			get { return _action; }
			set
			{
				if (_action == value)
					return;

				_action = value.GetAction();

				if (_action != null)
					_action.Owner = Owner;

				Root.SendValueChanged(this);
			}
		}

		public override string NodeParameters
		{
			get
			{
				if (Action != null)
					return Action.ToString();
				else
					return "Action = ???";
			}
		}

		public ActionAction()
		{
		}

		public ActionAction(ActionBase action)
		{
			Action = action.GetAction();
		}

		protected override void OnAttachedToOwner(Entity newOwner)
		{
			base.OnAttachedToOwner(newOwner);

			if (_action != null && newOwner != null)
				_action.Owner = newOwner;
		}

		protected override void OnDetachedFromOwner(Entity previousOwner)
		{
			base.OnDetachedFromOwner(previousOwner);

			if (_action != null)
				_action.Owner = null;
		}

		protected override void OnActivated()
		{
			base.OnActivated();
			_action.Execute();
		}

		protected override void OnDeactivated()
		{
			base.OnDeactivated();
			_action.Deactivate();
		}

		protected override ExecutingStatus OnExecuted()
		{
			if (_action.IsActive)
				return ExecutingStatus.Running;

			return ExecutingStatus.Success;
		}
	}
}
