// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using BehaviorTrees.Engine;
using System.Runtime.Serialization;


namespace BehaviorTrees
{
	/// <summary>
	/// 
	/// </summary>
	[DataContract]
	[BTNode("EventCondition", "Condition")]
	public class EventCondition : Condition
	{
		EventManager _em = EventManager.Instance;
		bool _success;
		BaseEvent _event;

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

		public EventCondition(BaseEvent evnt)
		{
			Event = evnt;
		}

		public EventCondition()
		{
			_success = false;
		}

		protected override void OnRootActivated()
		{
			base.OnRootActivated();

			_em.EventTriggered += EventRaised;

			_success = false;
		}

		protected override void OnRootDeactivated()
		{
			base.OnRootDeactivated();

			_em.EventTriggered -= EventRaised;
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

		protected override bool OnCheck()
		{
			return _success;
		}

		private void EventRaised(object sender, BaseEventArgs e)
		{
			if (_success)
				return;

			if (_event == null)
				return;

			_success = _event.Check(e.Event);
		}
	}
}
