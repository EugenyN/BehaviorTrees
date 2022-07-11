// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace BehaviorTrees
{
	/// <summary>
	/// 
	/// </summary>
	[DataContract]
	public class BTScript
	{
		[DataMember]
		public Node BehaviorTree { get; private set; }
		public string FileName { get; set; }
		public bool Saved { get; set; }

		public BTScript(string name, Node behaviorTree)
		{
			BehaviorTree = behaviorTree;
			FileName = name;
		}

		public void Save(string fileName)
		{
			using (var file = File.CreateText(fileName))
			{
				var serializer = JsonSerializer.Create(new JsonSerializerSettings
				{
					TypeNameHandling = TypeNameHandling.Auto,
					ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
					Formatting = Formatting.Indented
				});

				serializer.Serialize(file, this);
			}

			FileName = fileName;
			Saved = true;
		}

		public static BTScript Load(string fileName)
		{
			using (var file = File.OpenText(fileName))
			{
				var serializer = new JsonSerializer();
				serializer.TypeNameHandling = TypeNameHandling.Auto;
				var script = (BTScript)serializer.Deserialize(file, typeof(BTScript));
				script.Saved = true;
				script.FileName = fileName;
				return script;
			}
		}
	}
}
