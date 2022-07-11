// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System.Runtime.Serialization;

namespace BehaviorTrees
{
	/// <summary>
	/// Node that can check some condition.
	/// </summary>
	[DataContract]
	public abstract class Condition : Node
	{
		protected bool _isInstant;

		/// <summary>
		/// Using instant conditional checks.
		/// </summary>
		[DataMember]
		public bool IsInstant
		{
			get { return _isInstant; }
			set
			{
				_isInstant = value;
				if (Root != null)
					Root.SendValueChanged(this);
			}
		}

		public Condition()
			: this(true)
		{ }

		public Condition(bool isInstant)
		{
			_isInstant = isInstant;
		}

		protected abstract bool OnCheck();

		protected override ExecutingStatus OnExecuted()
		{
			if (!OnCheck())
				return ExecutingStatus.Failure;
			return _isInstant ? ExecutingStatus.Success : ExecutingStatus.Running;
		}
	}
}
