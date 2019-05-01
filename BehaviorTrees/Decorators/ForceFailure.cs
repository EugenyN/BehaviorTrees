// Copyright(c) 2015-2019 Eugeny Novikov. Code under MIT license.

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace BehaviorTrees
{
	/// <summary>
	/// Forced returns Failure, ignoring the result of the node, which is decorated.
	/// </summary>
	[DataContract]
	[BTNode("ForceFailure", "Decorator")]
	public class ForceFailure : Decorator
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		public ForceFailure(Node node)
			: base(node)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public ForceFailure()
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <returns>ExecutingStatus.Failure</returns>
		protected override ExecutingStatus OnExecuted()
		{
			Node.Execute();
			return ExecutingStatus.Failure;
		}
	}
}
