// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System.Runtime.Serialization;

namespace BehaviorTrees
{
	using System.ComponentModel;

	/// <summary>
	/// A decorator node is a node which adds some sort of functionality to another node,
	/// without knowing how that other node works or what it does.
	/// </summary>
	[DataContract]
	public abstract class Decorator : Node
	{
		[Browsable(false)]
		public Node Node
		{
			get { return Nodes.Count > 0 ? Nodes[0] : null; }
		}

		public Decorator()
		{ }

		public Decorator(Node child)
		{
			Nodes.Add(child);
		}

		protected override void OnDeactivated()
		{
			base.OnDeactivated();
			if (Node != null)
				Node.Deactivate();
		}
	}
}
