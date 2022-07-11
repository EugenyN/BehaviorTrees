// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using BehaviorTrees.Collections;
using BehaviorTrees.Engine;
using System.Drawing;

namespace BehaviorTrees.Example1
{
	public static class Example1
	{
		public static void Create()
		{
			var exampleBT = new TreeBuilder<Node>(new Sequence())
				.AddWithChild(new Loop(3))
					.AddWithChild(new Sequence())
						.Add(new Move(new Point(0, 0)))
						.Add(new Move(new Point(20, 0)))
						.AddWithChild(new Delay(2))
							.Add(new Move(new Point(0, 20)))
						.Up()
					.Up()
				.Up()
			.ToTree();

			Engine.Engine.Instance.LoadScene(new List<Entity> { new Entity("Actor1") },
				new BTScript("MovingTest", exampleBT));
		}
	}
}
