// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System.Runtime.Serialization;

namespace BehaviorTrees
{
	/// <summary>
	/// They contain a collection of nodes that are executed in a certain order. The nodes in this
	/// collection are referred to as children.
	/// </summary>
	[DataContract]
	public abstract class Composite : Node
	{
		public Composite()
		{ }
	}
}
