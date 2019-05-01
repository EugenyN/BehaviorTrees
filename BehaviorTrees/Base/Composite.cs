// Copyright(c) 2015-2019 Eugeny Novikov. Code under MIT license.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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
