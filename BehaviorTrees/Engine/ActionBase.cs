// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System.Diagnostics;
using System.Runtime.Serialization;

namespace BehaviorTrees.Engine
{
	[DataContract]
	public abstract class ActionBase : Component, IScriptedContextSupport
	{
		protected bool _isFinishing;
		protected bool _isEnabled;
		protected IScriptedContext _scriptedContext;

		/// <summary>
		/// 
		/// </summary>
		[System.ComponentModel.Browsable(false)]
		public IScriptedContext ScriptedContext
		{
			get { return _scriptedContext; }
			set
			{
				if (_scriptedContext != value)
				{
					_scriptedContext = value;
					OnScriptedContextChanged(_scriptedContext);
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool IsEnabled
		{
			get { return _isEnabled; }
			protected set { _isEnabled = value; }
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public ActionBase GetAction()
		{
			return this;
		}


		/// <summary>
		/// 
		/// </summary>
		public ActionBase()
			: this(null)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		public ActionBase(string name)
			: base(name)
		{
			_isFinishing = false;

			IsEnabled = true;
		}


		/// <summary>
		/// 
		/// </summary>
		public ExecutingStatus Execute()
		{
			if (_isFinishing)
			{
				Deactivate();
				return ExecutingStatus.Success;
			}

			if (!IsEnabled)
				return ExecutingStatus.Success;

			if (!IsActive)
				Activate();

			if (_isFinishing)
			{
				Deactivate();
				return ExecutingStatus.Success;
			}

			if (!IsActive)
				return ExecutingStatus.Failure;

			var status = OnExecuted();

			if (status != ExecutingStatus.Running)
			{
				Deactivate();
				return status;
			}

			if (_isFinishing)
			{
				Deactivate();
				return ExecutingStatus.Success;
			}

			return ExecutingStatus.Running;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public bool Update()
		{
			Debug.Assert(IsActive);

			var status = Execute();
			return IsActive && status == ExecutingStatus.Running;
		}

		/// <summary>
		/// 
		/// </summary>
		protected void MarkAsFinishing()
		{
			_isFinishing = true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected virtual ExecutingStatus OnExecuted()
		{
			// avoid first/activation update.
			if (Owner == null)
				return ExecutingStatus.Running;

			return ExecutingStatus.Success;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		protected virtual void OnScriptedContextChanged(IScriptedContext context)
		{
		}
	}
}