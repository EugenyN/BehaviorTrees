// Copyright(c) 2015-2019 Eugeny Novikov. Code under MIT license.

using System;
using System.Collections.Generic;
using System.Text;
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
