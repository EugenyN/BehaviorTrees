// Copyright(c) 2015-2019 Eugeny Novikov. Code under MIT license.

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using BehaviorTrees.Engine;

namespace BehaviorTrees
{
	/// <summary>
	/// Node that can perform some delegate.
	/// </summary>
	[DataContract]
	[BTNode("Delegate", "Action", false)]
	public class DelegateAction : Node
	{
		Func<Entity, ExecutingStatus> _func;

		public DelegateAction(Func<Entity, ExecutingStatus> func)
		{
			_func = func;
		}

		public DelegateAction()
		{
		}

		protected override ExecutingStatus OnExecuted()
		{
			return _func(Owner);
		}
	}
}
