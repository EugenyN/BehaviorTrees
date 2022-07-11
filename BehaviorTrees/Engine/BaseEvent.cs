// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System.ComponentModel;
using System.Runtime.Serialization;

namespace BehaviorTrees.Engine
{
	/// <summary>
	/// 
	/// </summary>
	[DataContract]
	public abstract class BaseEvent : Component, IScriptedContextSupport
	{
		private IScriptedContext _scriptedContext;

		[Browsable(false)]
		public IScriptedContext ScriptedContext
		{
			get { return _scriptedContext; }
			set
			{
				if (_scriptedContext == value)
					return;

				_scriptedContext = value;

				OnScriptedContextChanged(_scriptedContext);
			}
		}

		public BaseEvent()
		{
		}

		public BaseEvent(string name)
			: base(name)
		{ }

		public virtual bool Check(BaseEvent e)
		{
			if (e == null)
				return false;
			return GetType() == e.GetType();
		}

		public virtual object[] GetArgs()
		{
			return new object[] { };
		}

		protected virtual void OnScriptedContextChanged(IScriptedContext context)
		{
		}
	}
}
