// Copyright(c) 2015-2019 Eugeny Novikov. Code under MIT license.

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using BehaviorTrees.Engine;

namespace BehaviorTrees
{
	/// <summary>
	/// Node that can check some condition.
	/// </summary>
	[DataContract]
	[BTNode("DelegateCondition", "Condition", false)]
	public class DelegateCondition : Condition
	{
		Func<Entity, bool> _condition;

		public DelegateCondition(Func<Entity, bool> condition)
		{
			_condition = condition;
		}

		public DelegateCondition()
		{
		}

		public DelegateCondition(Func<Entity, bool> condition, bool isInstant)
			: base(isInstant)
		{
			_condition = condition;
		}

		protected override bool OnCheck()
		{
			return _condition(Owner);
		}
	}
}
