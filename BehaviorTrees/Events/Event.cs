// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using BehaviorTrees.Engine;
using System.Runtime.Serialization;

namespace BehaviorTrees
{
	/// <summary>
	/// 
	/// </summary>
	[DataContract]
	[BTNode("Event", "Event")]
	public class EventNode : Node
	{
		EventManager _em = EventManager.Instance;
		BaseEvent _event;
		bool _success;

		[DataMember]
		public BaseEvent Event
		{
			get { return _event; }
			set
			{
				if (_event == value)
					return;

				_event = value;

				if (_event != null && Owner != null)
					_event.Owner = Owner;

				if (Root != null)
					Root.SendValueChanged(this);
			}
		}

		public override string NodeParameters
		{
			get { return _event != null ? _event.ToString() : ""; }
		}

		public EventNode(BaseEvent evnt)
		{
			_event = evnt;
		}

		public EventNode()
		{
		}

		protected override void OnAttachedToOwner(Entity newOwner)
		{
			base.OnAttachedToOwner(newOwner);

			if (_event != null && newOwner != null)
				_event.Owner = newOwner;
		}

		protected override void OnDetachedFromOwner(Entity previousOwner)
		{
			base.OnDetachedFromOwner(previousOwner);

			if (_event != null)
				_event.Owner = null;
		}

		protected override void OnScriptedContextChanged(IScriptedContext context)
		{
			base.OnScriptedContextChanged(context);
			if (_event != null)
				_event.ScriptedContext = ScriptedContext;
		}

		protected override void OnActivated()
		{
			base.OnActivated();
			_em.EventTriggered += EventRaised;
			_success = false;
		}

		protected override void OnDeactivated()
		{
			base.OnDeactivated();
			_em.EventTriggered -= EventRaised;
		}

		private void EventRaised(object sender, BaseEventArgs e)
		{
			if (_success)
				return;

			_success = _event.Check(e.Event);
		}

		protected override ExecutingStatus OnExecuted()
		{
			if (_success)
				return ExecutingStatus.Success;

			return ExecutingStatus.Running;
		}
	}
}
