// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System.Runtime.Serialization;


namespace BehaviorTrees
{
	/// <summary>
	/// The Sequence node, for instance, sequentially executes its children (its collection of
	/// nodes) in order. If all children succeeded we consider the Sequence itself to have succeeded.
	/// If, however, any of the children failed we immediately consider the Sequence itself to
	/// have failed, without proceeding to the next child node.
	/// </summary>
	[DataContract]
	[BTNode("Sequence", "Composite")]
	public class Sequence : Composite
	{
		int _step = 0;
		int _currentStep;
		Node _currentNode;

		/// <summary>
		/// Which node should be executed
		/// </summary>
		[DataMember]
		public int Step
		{
			get { return _step; }
			set
			{
				_step = value;
				Root.SendValueChanged(this);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override string NodeParameters
		{
			get { return "Step = " + _step; }
		}


		/// <summary>
		/// 
		/// </summary>
		public Sequence()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public Sequence(int step)
		{
			_step = step;
		}

		protected override void OnDeactivated()
		{
			base.OnDeactivated();
			foreach (var node in Nodes)
				node.Deactivate();
			_currentStep = _step;
		}

		protected override ExecutingStatus OnExecuted()
		{
			if (Nodes.Count == 0)
				return ExecutingStatus.Success;

			_currentNode = Nodes[_currentStep];

			var status = _currentNode.Execute();

			switch (status)
			{
				case ExecutingStatus.Success:
					_currentStep++;
					_currentNode = null;
					if (_currentStep >= Nodes.Count)
					{
						_currentStep = 0;
						return ExecutingStatus.Success;
					}
					else
					{
						return ExecutingStatus.Running;
					}
				case ExecutingStatus.Running:
					return ExecutingStatus.Running;
				case ExecutingStatus.Failure:
					return ExecutingStatus.Failure;
				default:
					throw new Exception();
			}
		}
	}
}
