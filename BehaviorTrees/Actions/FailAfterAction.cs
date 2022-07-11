// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System.Runtime.Serialization;

namespace BehaviorTrees
{
	/// <summary>
	/// Return Failure after several iterations.
	/// </summary>
	[DataContract]
	[BTNode("FailAfter", "Action")]
	public class FailAfterAction : Node
	{
		int _counter;
		int _after;

		/// <summary>
		/// The number of iterations after which Failure will be returned.
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

		public FailAfterAction()
		{
		}

		protected override ExecutingStatus OnExecuted()
		{
			if (_counter == _after)
				return ExecutingStatus.Failure;

			_counter++;

			return ExecutingStatus.Running;
		}
	}
}
