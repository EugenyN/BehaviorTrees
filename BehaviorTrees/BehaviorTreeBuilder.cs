// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using BehaviorTrees.Engine;


namespace BehaviorTrees
{
	public class BehaviorTreeBuilder
	{
		public Node Node { get; protected internal set; }

		private readonly Stack<Node> _stack = new Stack<Node>();

		public BehaviorTreeBuilder()
		{ }

		public BehaviorTreeBuilder(Node node)
		{
			Node = node;
		}

		public Node Add(Node node)
		{
			Node.Nodes.Add(node);
			return node;
		}

		public void BeginSequence()
		{
			_stack.Push(Node);
			Node = Add(new Sequence());
		}

		public void EndSequence()
		{
			Node = _stack.Pop();
		}

		public TNode Remove<TNode>(TNode node) where TNode : Node
		{
			Node.Nodes.Remove(node);
			return node;
		}

		public TNode NoAdd<TNode>(TNode node) where TNode : Node
		{
			return Remove(node);
		}

		public ActionAction Do(ActionBase behavior)
		{
			ActionAction node = new ActionAction(behavior);
			Add(node);
			return node;
		}

		public ActionAction Do(ActionAction action)
		{
			Add(action);
			return action;
		}

		public Delay Delay(float seconds, Node behaviorAfterwards)
		{
			Delay node = new Delay(seconds, behaviorAfterwards);
			Add(node);
			return node;
		}

		public Delay Delay(float seconds)
		{
			return Delay(seconds, null);
		}
	}
}
