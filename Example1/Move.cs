// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using BehaviorTrees.Utils;
using System.Drawing;
using System.Runtime.Serialization;

namespace BehaviorTrees.Example1
{
	[DataContract]
	[BTNode("Move", "Example")]
	public class Move : Node
	{
		Point _position;
		bool _completed;

		[DataMember]
		public Point Position
		{
			get { return _position; }
			set
			{
				_position = value;
				Root.SendValueChanged(this);
			}
		}

		public Move()
		{ }

		public Move(Point pos)
		{
			Position = pos;
		}

		public override string NodeParameters => $"Move To ({Position.X}, {Position.Y})";

		protected override void OnActivated()
		{
			base.OnActivated();
			Log.Write($"{Owner.Name} moving to {Position}");
			Task.Delay(1000).ContinueWith(_ => _completed = true);
		}

		protected override void OnDeactivated()
		{
			base.OnDeactivated();
			Log.Write($"{Owner.Name} moving completed ");
		}

		protected override ExecutingStatus OnExecuted()
		{
			return _completed ? ExecutingStatus.Success : ExecutingStatus.Running;
		}
	}
}
