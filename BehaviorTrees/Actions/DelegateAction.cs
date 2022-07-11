// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using BehaviorTrees.Engine;
using System.Runtime.Serialization;

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
