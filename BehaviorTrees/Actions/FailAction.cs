// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System.Runtime.Serialization;

namespace BehaviorTrees
{
	/// <summary>
	/// Always Failure.
	/// </summary>
	[DataContract]
	[BTNode("Fail", "Action")]
	public class FailAction : Node
	{
		public FailAction()
		{
		}

		protected override ExecutingStatus OnExecuted()
		{
			return ExecutingStatus.Failure;
		}
	}
}
