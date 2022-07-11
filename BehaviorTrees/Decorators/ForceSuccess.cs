// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System.Runtime.Serialization;

namespace BehaviorTrees
{
	/// <summary>
	/// Forced returns Success, ignoring the result of the node, which is decorated.
	/// </summary>
	[DataContract]
	[BTNode("ForceSuccess", "Decorator")]
	public class ForceSuccess : Decorator
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		public ForceSuccess(Node node)
			: base(node)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public ForceSuccess()
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <returns>ExecutingStatus.Success</returns>
		protected override ExecutingStatus OnExecuted()
		{
			Node.Execute();
			return ExecutingStatus.Success;
		}
	}
}
