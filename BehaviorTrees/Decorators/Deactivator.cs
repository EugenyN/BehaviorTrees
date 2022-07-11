// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System.Runtime.Serialization;

namespace BehaviorTrees
{
	/// <summary>
	/// Returns Success without subnode execution. Can be used for temporary disabling nodes.
	/// </summary>
	[DataContract]
	[BTNode("Deactivator", "Decorator")]
	public class Deactivator : Decorator
	{
		ExecutingStatus _status;

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public ExecutingStatus Status
		{
			get { return _status; }
			set
			{
				_status = value;
				Root.SendValueChanged(this);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override string NodeParameters
		{
			get { return "Result = " + _status; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		public Deactivator(Node node)
			: base(node)
		{
			_status = ExecutingStatus.Success;
		}

		/// <summary>
		/// 
		/// </summary>
		public Deactivator()
		{
			_status = ExecutingStatus.Success;
		}

		/// <summary>
		/// Returns result, without subnode execution.
		/// </summary>
		protected override ExecutingStatus OnExecuted()
		{
			return _status;
		}
	}
}
