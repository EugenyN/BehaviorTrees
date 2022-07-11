// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System.Runtime.Serialization;


namespace BehaviorTrees
{
	/// <summary>
	/// The Selector will succeed as soon as a child node succeeds.
	/// The Selector will fail if all child nodes were tried and all of them failed.
	/// </summary>
	[DataContract]
	[BTNode("Selector", "Composite")]
	public class Selector : Composite
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
		public Selector()
		{
		}

		public Selector(int step)
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
					return ExecutingStatus.Success;
				case ExecutingStatus.Running:
					return ExecutingStatus.Running;
				case ExecutingStatus.Failure:
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
				default:
					throw new Exception();
			}
		}
	}
}
