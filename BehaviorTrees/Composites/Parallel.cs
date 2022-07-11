// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System.Runtime.Serialization;

namespace BehaviorTrees
{
	/// <summary>
	/// 
	/// </summary>
	public enum SuccessPolicy
	{
		First,
		One,
		All
	}

	/// <summary>
	/// A parallel node will run it's children at the same time.
	/// </summary>
	[DataContract]
	[BTNode("Parallel", "Composite")]
	public class Parallel : Composite
	{
		protected SuccessPolicy _successPolicy;


		[DataMember]
		public SuccessPolicy SuccessPolicy
		{
			get { return _successPolicy; }
			set { _successPolicy = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public Parallel()
			: this(SuccessPolicy.All)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="policy"></param>
		public Parallel(SuccessPolicy policy)
		{
			_successPolicy = policy;
		}

		/// <summary>
		/// 
		/// </summary>
		protected override void OnDeactivated()
		{
			base.OnDeactivated();
			foreach (var node in Nodes)
				node.Deactivate();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected override ExecutingStatus OnExecuted()
		{
			ExecutingStatus status;
			bool allSuccess = true;

			foreach (Node node in Nodes)
			{
				status = node.Execute();
				if (status == ExecutingStatus.Failure)
					return ExecutingStatus.Failure;

				if (status == ExecutingStatus.Success)
				{
					if (_successPolicy == SuccessPolicy.One)
					{
						return ExecutingStatus.Success;
					}

					if (_successPolicy == SuccessPolicy.First)
					{
						if (node == Nodes[0])
							return ExecutingStatus.Success;
					}
				}

				if (status == ExecutingStatus.Running)
					allSuccess = false;
			}

			if (_successPolicy == SuccessPolicy.All)
			{
				if (allSuccess)
					return ExecutingStatus.Success;
			}

			return ExecutingStatus.Running;
		}
	}
}
