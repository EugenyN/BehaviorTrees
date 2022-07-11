// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System.Runtime.Serialization;

namespace BehaviorTrees
{
	/// <summary>
	/// Always Success.
	/// </summary>
	[DataContract]
	[BTNode("Succeed", "Action")]
	public class SucceedAction : Node
	{
		public SucceedAction()
		{
		}

		protected override ExecutingStatus OnExecuted()
		{
			return ExecutingStatus.Success;
		}
	}
}
