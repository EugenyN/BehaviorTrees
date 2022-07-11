// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using Newtonsoft.Json;
using System.Reflection;

namespace BehaviorTrees.Utils
{
	public static class Reflector
	{
		public static IEnumerable<Type> GetAllDerivedTypes(Type baseType, bool classOnly)
		{
			string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

			foreach (string dll in Directory.GetFiles(path, "*.dll"))
			{
				var types = GetAllDerivedTypes(Assembly.LoadFrom(dll), baseType, classOnly);
				foreach (var type in types)
					yield return type;
			}
		}

		public static IEnumerable<Type> GetAllDerivedTypes(Assembly assembly, Type baseType, bool classOnly)
		{
			foreach (var ti in assembly.GetExportedTypes())
			{
				if (classOnly && !ti.IsClass)
					continue;

				if (baseType.IsAssignableFrom(ti))
					yield return ti;
			}
		}

		static JsonSerializerSettings _serializerSettings;

		public static T Clone<T>(T obj) where T : class
		{
			if (_serializerSettings == null)
			{
				_serializerSettings = new JsonSerializerSettings();
				_serializerSettings.TypeNameHandling = TypeNameHandling.Auto;

#if DEBUG
				_serializerSettings.Formatting = Formatting.Indented;
#else
				_serializerSettings.Formatting = Formatting.None;
#endif
			}

			var serializedObj = JsonConvert.SerializeObject(obj, _serializerSettings);
			return (T)JsonConvert.DeserializeObject(serializedObj, obj.GetType(), _serializerSettings);
		}
	}
}
