// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System.Runtime.Serialization;

namespace BehaviorTrees
{
	/// <summary>
	/// Execute decorated node after waiting certain amount of time.
	/// </summary>
	[DataContract]
	[BTNode("Delay", "Decorator")]
	public class Delay : Decorator
	{
		float _seconds;
		float _start = 0;


		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public float Seconds
		{
			get { return _seconds; }
			set
			{
				_seconds = value;
				Root.SendValueChanged(this);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override string NodeParameters
		{
			get { return "Seconds = " + _seconds; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="seconds"></param>
		/// <param name="node"></param>
		public Delay(float seconds, Node node)
			: base(node)
		{
			_seconds = seconds;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="seconds"></param>
		public Delay(float seconds)
		{
			_seconds = seconds;
		}

		/// <summary>
		/// 
		/// </summary>
		public Delay()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		protected override void OnActivated()
		{
			base.OnActivated();
			_start = 0;
		}

		protected override ExecutingStatus OnExecuted()
		{
			if (_start == 0)
			{
				_start = DateTime.Now.Second;
				return ExecutingStatus.Running;
			}

			if (DateTime.Now.Second - _start > _seconds)
			{
				if (Node == null)
					return ExecutingStatus.Success;

				var status = Node.Execute();

				if (status != ExecutingStatus.Running) // node done, reset
					_start = 0;

				return status;
			}
			return ExecutingStatus.Running;
		}
	}
}
