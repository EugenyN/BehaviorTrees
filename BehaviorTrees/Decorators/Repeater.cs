// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System.Runtime.Serialization;

namespace BehaviorTrees
{
	/// <summary>
	/// Execute decorated node a specified amount of times, returning Running.
	/// </summary>
	[DataContract]
	[BTNode("Repeater", "Decorator")]
	public class Repeater : Decorator
	{
		int _counter = 0;
		int _amount = 0;

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int Amount
		{
			get { return _amount; }
			set
			{
				_amount = value;
				Root.SendValueChanged(this);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override string NodeParameters
		{
			get { return "Amount = " + _amount; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="amount"></param>
		/// <param name="node"></param>
		public Repeater(int amount, Node node)
			: base(node)
		{
			_amount = amount;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		public Repeater(Node node)
			: base(node)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public Repeater()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected override ExecutingStatus OnExecuted()
		{
			if (_amount != 0)
			{
				if (_counter + 1 >= _amount)
					// last execution
					return Node.Execute();
			}

			var status = Node.Execute();
			if (status == ExecutingStatus.Failure)
				return status;

			_counter++;
			return ExecutingStatus.Running;
		}
	}
}
