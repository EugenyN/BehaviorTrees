// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System.Runtime.Serialization;

namespace BehaviorTrees
{
	/// <summary>
	/// Return Succeed after several iterations.
	/// </summary>
	[DataContract]
	[BTNode("SucceedAfter", "Action")]
	public class SucceedAfterAction : Node
	{
		int _counter;
		int _after;

		/// <summary>
		/// The number of iterations after which Succeed will be returned.
		/// </summary>
		[DataMember]
		public int After
		{
			get { return _after; }
			set
			{
				_after = value;
				Root.SendValueChanged(this);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override string NodeParameters
		{
			get { return "After = " + _after; }
		}

		public SucceedAfterAction()
		{
		}

		protected override ExecutingStatus OnExecuted()
		{
			if (_counter == _after)
				return ExecutingStatus.Success;

			_counter++;

			return ExecutingStatus.Running;
		}
	}
}
