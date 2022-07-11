// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using BehaviorTrees.Engine;
using System.Runtime.Serialization;

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
