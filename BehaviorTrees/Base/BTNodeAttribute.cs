// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

namespace BehaviorTrees
{
	/// <summary>
	/// 
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class BTNodeAttribute : Attribute
	{
		public string Name { get; set; }
		public string Type { get; set; }
		public bool ShowInEditor { get; set; }

		public BTNodeAttribute(string name, string type, bool showInEditor)
		{
			Name = name;
			Type = type;
			ShowInEditor = showInEditor;
		}

		public BTNodeAttribute(string name, string type)
			: this(name, type, true)
		{
		}
	}
}
