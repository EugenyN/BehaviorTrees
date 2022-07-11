// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System.Runtime.Serialization;

namespace BehaviorTrees
{
	/// <summary>
	/// Executes infinitely regardless of the result.
	/// </summary>
	[DataContract]
	[BTNode("RepeatAlways", "Decorator")]
	public class RepeatAlways : Decorator
	{

		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		public RepeatAlways(Node node)
			: base(node)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public RepeatAlways()
		{ }

		protected override ExecutingStatus OnExecuted()
		{
			Node.Execute();
			return ExecutingStatus.Running;
		}
	}
}
