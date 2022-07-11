// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System.Runtime.Serialization;

namespace BehaviorTrees
{
	/// <summary>
	/// Loops decorated subnode a number of times, or infinitely.
	/// </summary>
	[DataContract]
	[BTNode("Loop", "Decorator")]
	public class Loop : Decorator
	{
		int _counter = 0;
		int _count = 0;

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int Count
		{
			get { return _count; }
			set
			{
				_count = value;
				Root.SendValueChanged(this);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override string NodeParameters
		{
			get { return "Count = " + _count; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="count"></param>
		/// <param name="node"></param>
		public Loop(int count, Node node)
			: base(node)
		{
			_count = count;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		public Loop(Node node)
			: base(node)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public Loop(int count)
		{
			_count = count;
		}

		/// <summary>
		/// 
		/// </summary>
		public Loop()
		{ }

		protected override ExecutingStatus OnExecuted()
		{
			if (_counter == _count)
				return ExecutingStatus.Success;

			var status = Node.Execute();

			if (status == ExecutingStatus.Failure)
				return status;

			if (status == ExecutingStatus.Success)
				_counter++;

			return ExecutingStatus.Running;
		}
	}
}
