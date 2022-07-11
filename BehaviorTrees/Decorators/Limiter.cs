// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System.Runtime.Serialization;

namespace BehaviorTrees
{
	/// <summary>
	/// Execute decorated node a specified amount of times and then returns Success.
	/// </summary>
	[DataContract]
	[BTNode("Limiter", "Decorator")]
	public class Limiter : Decorator
	{
		int _limit;
		int _counter = 0;


		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int Limit
		{
			get { return _limit; }
			set
			{
				_limit = value;
				Root.SendValueChanged(this);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override string NodeParameters
		{
			get { return "Limit = " + _limit; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="limit"></param>
		/// <param name="node"></param>
		public Limiter(int limit, Node node)
			: base(node)
		{
			_limit = limit;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="limit"></param>
		public Limiter(int limit)
		{
			_limit = limit;
		}

		/// <summary>
		/// 
		/// </summary>
		public Limiter()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected override ExecutingStatus OnExecuted()
		{
			if (_counter >= _limit)
				return ExecutingStatus.Success;

			_counter++;

			return Node.Execute();
		}
	}
}
