// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using BehaviorTrees.Utils;

namespace BehaviorTrees.Engine
{
	/// <summary>
	///	
	/// </summary>
	public class BaseEventArgs : EventArgs
	{
		public BaseEvent Event;

		public BaseEventArgs(BaseEvent evnt)
		{
			Event = evnt;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class EventManager
	{
		readonly Dictionary<string, Type> _eventTypeByID = new Dictionary<string, Type>();

		static EventManager _instance;

		public event EventHandler<BaseEventArgs> EventTriggered;

		public static EventManager Instance
		{
			get
			{
				if (_instance == null)
					_instance = new EventManager();
				return _instance;
			}
		}


		private EventManager()
		{
			SetupEvents();
		}

		private void SetupEvents()
		{
			try
			{
				var types = Reflector.GetAllDerivedTypes(typeof(BaseEvent), true);
				foreach (var et in types)
					_eventTypeByID.Add(et.Name, et);
			}
			catch (Exception exc)
			{
				Log.Write("EventManager.SetupEvents: " + exc);
			}
		}

		public bool GetEventType(string eventTypeID, out Type eventType)
		{
			if (string.IsNullOrEmpty(eventTypeID))
			{
				eventType = null;
				return false;
			}
			return _eventTypeByID.TryGetValue(eventTypeID, out eventType);
		}

		public BaseEvent CreateEvent(string eventTypeID, params object[] args)
		{
			if (GetEventType(eventTypeID, out var eventType))
				return Activator.CreateInstance(eventType, args) as BaseEvent;

			return null;
		}

		public virtual bool TriggerEvent(BaseEvent evnt)
		{
			if (evnt == null)
				return false;

			EventTriggered?.Invoke(this, new BaseEventArgs(evnt));

			return true;
		}

		public virtual bool TriggerEvent(string eventTypeID, params object[] args)
		{
			var evnt = CreateEvent(eventTypeID, args);
			if (evnt == null)
				return false;

			return TriggerEvent(evnt);
		}
	}
}

