// https://www.codeproject.com/Articles/12592/Generic-Tree-T-in-C

using System.Collections;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace BehaviorTrees.Collections
{
	using System.ComponentModel;

	/// <summary>
	/// 
	/// </summary>
	public enum NodeEvent
	{
		ValueChanged,
		NodeChanged,
		ChildOrderChanged,
		ChildAdded,
		ChildRemoved,
		ChildsCleared,
	}


	/// <summary>
	/// EventArgs for changes in a TreeNode
	/// </summary>
	public class TreeEventArgs<T> : EventArgs where T : TreeNode<T>
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		/// <param name="change"></param>
		/// <param name="index"></param>
		public TreeEventArgs(T node, NodeEvent change, int index)
		{
			Node = node;
			Change = change;
			Index = index;
		}

		/// <summary>
		/// The Node for which the event occured.
		/// </summary>
		[Browsable(false)]
		public T Node;

		/// <summary>
		/// <list>
		///   <item>ValueChanged: A new value was assigned to node.Value. index is unused</item>
		///   <item>NodeChanged: The node itself has changed (e.g. another node was assigned) All child nodes may have changed, too</item>
		///   <item>ChildOrderChanged: the order of the elements of node.Childs has changed</item>
		///   <item>ChildAdded: a child node was added at position <c>index</c></item>
		///   <item>ChildRemoved: a child node was removed at position <c>index</c>.
		///         This notification is <b>not</b> sent when all items are removed using Clear
		///   </item>
		///   <item>ChildsCleared: all childs were removed.</item>
		/// </list>
		/// </summary>
		[Browsable(false)]
		public NodeEvent Change;

		/// <summary>
		/// Index of the child node affected. See the Change member for more information.
		/// </summary>
		[Browsable(false)]
		public int Index;
	}


	/// <summary>
	/// A TreeRoot object acts as source of tree node events. A single instance is associated
	/// with each tree (the Root property of all nodes of a tree return the same instance, nodes
	/// from different trees return different instances)
	/// </summary>
	/// <typeparam name="T">type of the data value at each tree node</typeparam>
	[DataContract]
	public class TreeRoot<T> where T : TreeNode<T>
	{
		private T _root;


		/// <summary>
		/// 
		/// </summary>
		[Browsable(false)]
		public T RootNode
		{
			get { return _root; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="root"></param>
		internal TreeRoot(TreeNode<T> root)
		{
			_root = (T)root;
		}

		/// <summary>
		/// signals that a new value was assigned to a given node. <br/>
		/// Note: if T is a reference type and modified indirectly, this event doesn't fire
		/// </summary>
		public event EventHandler<TreeEventArgs<T>> ValueChanged;

		/// <summary>
		/// signals that the Node structure has changed
		/// </summary>
		public event EventHandler<TreeEventArgs<T>> NodeChanged;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		public void SendValueChanged(T node)
		{
			if (ValueChanged != null)
				ValueChanged(this, new TreeEventArgs<T>(node, NodeEvent.ValueChanged, -1));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		/// <param name="change"></param>
		/// <param name="index"></param>
		public void SendNodeChanged(T node, NodeEvent change, int index)
		{
			if (NodeChanged != null)
				NodeChanged(this, new TreeEventArgs<T>(node, change, index));
		}
	}


	/// <summary>
	/// Represents a single Tree Node
	/// </summary>
	/// <typeparam name="T">Type of the Data Value at the node</typeparam>
	[DataContract]
	[Newtonsoft.Json.JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
	public class TreeNode<T> : IEnumerable<T> where T : TreeNode<T>
	{
		private T _parent;
		private TreeRoot<T> _root;
		private TreeNodeCollection<T> _nodes;


		/// <summary>
		/// 
		/// </summary>
		public TreeNode()
		{
			_root = new TreeRoot<T>(this);
		}

		/// <summary>
		/// Creates a new node as child of parent, and sets Value to value
		/// </summary>
		/// <param name="parent"></param>
		internal TreeNode(T parent)
		{
			InternalSetParent(parent);
		}


		/// <summary>
		/// returns the parent node, or null if this is a root node
		/// </summary>
		[Browsable(false)]
		public T Parent
		{
			get { return _parent; }
		}

		/// <summary>
		/// returns all siblings as a NodeList<T>. If this is a root node, the function returns null.
		/// </summary>
		[Browsable(false)]
		public TreeNodeCollection<T> Siblings
		{
			get { return _parent != null ? _parent.Nodes : null; }
		}

		/// <summary>
		/// Returns all child nodes as a NodeList. 
		/// <para><b>Implementation note:</b> Childs always returns a non-null collection. 
		/// This collection is created on demand at the first access. To avoid unnecessary 
		/// creation of the collection, use HasChilds to check if the node has any child nodes</para>
		/// </summary>
		[DataMember]
		[Browsable(false)]
		public TreeNodeCollection<T> Nodes
		{
			get
			{
				if (_nodes == null)
					_nodes = new TreeNodeCollection<T>(this);
				return _nodes;
			}
		}

		public bool ShouldSerializeNodes()
		{
			// don't serialize the Nodes property if collection is empty.
			return _nodes != null && _nodes.Count != 0;
		}

		/// <summary>
		/// The Root object this Node belongs to. never null
		/// </summary>
		[Browsable(false)]
		public TreeRoot<T> Root
		{
			get { return _root; }
		}

		/// <summary>
		/// returns true if the node has child nodes.
		/// See also Implementation Note under this.Childs
		/// </summary>
		[Browsable(false)]
		public bool HasChildren
		{
			get { return _nodes != null && _nodes.Count != 0; }
		}

		/// <summary>
		/// returns true if this node is a root node. (Equivalent to this.Parent==null)
		/// </summary>
		[Browsable(false)]
		public bool IsRoot
		{
			get { return _parent == null; }
		}

		/// <summary>
		/// 
		/// </summary>
		[Browsable(false)]
		public int Depth
		{
			get
			{
				int depth = 0;
				T node = _parent;
				while (node != null)
				{
					++depth;
					node = node._parent;
				}
				return depth;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		public bool IsAncestorOf(T node)
		{
			if (node.Root != Root)
				return false; // different trees

			T parent = node.Parent;
			while (parent != null && parent != this)
				parent = parent.Parent;

			return parent != null;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		public bool IsChildOf(T node)
		{
			return !IsAncestorOf(node);
		}

		/// <summary>
		/// Removes the current node and all child nodes recursively from it's parent.
		/// Throws an InvalidOperationException if this is a root node.
		/// </summary>
		public void Remove()
		{
			if (_parent == null)
				throw new InvalidOperationException("Cannot remove root node");
			Detach();
		}

		/// <summary>
		/// Detaches this node from it's parent. 
		/// Postcondition: this is a root node.
		/// </summary>
		/// <returns></returns>
		public T Detach()
		{
			if (_parent != null)
				Siblings.Remove((T)this);

			return (T)this;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public IEnumerator<T> GetEnumerator()
		{
			var queue = new Queue<T>();
			queue.Enqueue((T)this);
			while (0 < queue.Count)
			{
				T node = queue.Dequeue();
				foreach (T child in node.Nodes)
					queue.Enqueue(child);
				yield return node;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="match"></param>
		/// <returns></returns>
		public T Find(Predicate<T> match)
		{
			return Find((T)this, match);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		/// <param name="match"></param>
		/// <returns></returns>
		private T Find(T node, Predicate<T> match)
		{
			if (match(node))
				return node;

			foreach (var p in node.Nodes)
			{
				var fp = Find(p, match);
				if (fp != null)
					return fp;
			}

			return null;
		}

		/// <summary>
		/// 
		/// </summary>
		internal void InternalDetach()
		{
			_parent = null;
			SetRootLink(new TreeRoot<T>(this));

			OnDetach();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="parent"></param>
		internal void InternalSetParent(T parent)
		{
			_parent = parent;
			if (_parent != null)
				SetRootLink(parent.Root);

			OnSetParent(parent);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="root"></param>
		internal void SetRootLink(TreeRoot<T> root)
		{
			// assume sub trees are consistent
			if (_root == root)
				return;

			_root = root;
			if (HasChildren)
			{
				foreach (T n in Nodes)
					n.SetRootLink(root);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="parent"></param>
		protected virtual void OnSetParent(T parent)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		protected virtual void OnDetach()
		{
		}
	}


	/// <summary>
	/// Implements a collection of Tree Nodes (Node<T>)
	/// <para><b>Implementation Note:</b> The root of a data tree is always a Node<T>. You cannot
	/// create a standalone NodeList<T>.
	/// </para>
	/// </summary>
	/// <typeparam name="T">typeof the data value of each node</typeparam>
	[CollectionDataContract(ItemName = "Node")]
	public class TreeNodeCollection<T> : Collection<T> where T : TreeNode<T>
	{
		private readonly T _owner = null;

		/// <summary>
		/// The Node to which this collection belongs (this==Owner.Childs). 
		/// Never null.
		/// </summary>
		[Browsable(false)]
		public T Owner
		{
			get { return _owner; }
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="owner"></param>
		internal TreeNodeCollection(TreeNode<T> owner)
		{
			_owner = (T)owner ?? throw new ArgumentNullException(nameof(owner));
		}

		/// <summary>
		/// Adds a range of nodes created from a range of values
		/// </summary>
		/// <param name="range">range of values </param>
		public void AddRange(IEnumerable<T> range)
		{
			foreach (T value in range)
				Add(value);
		}

		/// <summary>
		/// Adds a range of nodes created from a range of values passed as parameters
		/// </summary>
		/// <param name="range">range of values </param>
		public void AddRange(params T[] args)
		{
			AddRange(args as IEnumerable<T>);
		}

		/// <summary>
		/// Inserts a range of nodes created from a range of values
		/// </summary>
		/// <param name="index">index where to start inserting. As with InsertAt, all values areaccepted</param>
		/// <param name="values">a range of values set for the nodes</param>
		public void InsertRangeAt(int index, IEnumerable<T> values)
		{
			foreach (T value in values)
			{
				Insert(index, value);
				++index;
			}
		}

		/// <summary>
		/// Inserts a new node before the specified node.
		/// </summary>
		/// <param name="insertPos">Existing node in front of which the new node is inserted</param>
		/// <param name="value">value for the new node</param>
		/// <returns>The newly created node</returns>
		public void InsertBefore(T insertPos, T value)
		{
			int index = IndexOf(insertPos);
			Insert(index, value);
		}

		/// <summary>
		/// Inserts a new node after the specified node
		/// </summary>
		/// <param name="insertPos">Existing node after which the new node is inserted</param>
		/// <param name="value">value for the new node</param>
		/// <returns>The newly created node</returns>
		public void InsertAfter(T insertPos, T value)
		{
			int index = IndexOf(insertPos) + 1;
			if (index == 0)
				index = Count;
			Insert(index, value);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <param name="item"></param>
		protected override void InsertItem(int index, T item)
		{
			item.InternalSetParent(_owner);
			base.InsertItem(index, item);

			SendOwnerNodeChanged(NodeEvent.ChildAdded, index);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <param name="item"></param>
		protected override void SetItem(int index, T item)
		{
			Items[index].InternalDetach();
			item.InternalSetParent(_owner);
			base.SetItem(index, item);

			SendOwnerNodeChanged(NodeEvent.NodeChanged, index);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		protected override void RemoveItem(int index)
		{
			Items[index].InternalDetach();

			base.RemoveItem(index);

			SendOwnerNodeChanged(NodeEvent.ChildRemoved, index);
		}

		/// <summary>
		/// 
		/// </summary>
		protected override void ClearItems()
		{
			foreach (var node in Items)
				node.InternalDetach();

			base.ClearItems();

			SendOwnerNodeChanged(NodeEvent.ChildsCleared, 0);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="changeHint"></param>
		/// <param name="index"></param>
		protected void SendOwnerNodeChanged(NodeEvent changeHint, int index)
		{
			if (_owner != null)
				_owner.Root.SendNodeChanged(Owner, changeHint, index);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="match"></param>
		/// <returns></returns>
		public T Find(Predicate<T> match)
		{
			foreach (T p in Items)
				if (match(p))
					return p;

			return null;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="match"></param>
		/// <returns></returns>
		public List<T> FindAll(Predicate<T> match)
		{
			var result = new List<T>();
			foreach (T p in Items)
				if (match(p))
					result.Add(p);

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public new IEnumerator<T> GetEnumerator()
		{
			foreach (var item in Items)
				yield return item;
		}
	}
}
