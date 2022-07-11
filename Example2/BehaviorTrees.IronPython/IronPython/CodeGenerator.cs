// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System.Text;


namespace BehaviorTrees.IronPython
{
	/// <summary>
	/// 
	/// </summary>
	public struct FnArgDesc
	{
		public string Name;
		public string Value;

		public FnArgDesc(string name, string value)
		{
			Name = name;
			Value = value;
		}

		public FnArgDesc(string name)
			: this(name, null)
		{ }
	}

	/// <summary>
	/// 
	/// </summary>
	public struct FnDesc
	{
		public string Name;
		public string Body;
		public List<FnArgDesc> Arguments;
		public bool IsReturn;

		public FnDesc(string name, string body, List<FnArgDesc> args, bool isReturn)
		{
			Name = name;
			Body = body;
			Arguments = args;
			IsReturn = isReturn;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public static class CodeGenerator
	{
		public static string GetUniqueName()
		{
			return "function_" + (byte)Guid.NewGuid().GetHashCode();
		}

		public static string GenerateFunction(FnDesc desc)
		{
			string args = GenerateFunctionArgs(desc.Arguments);
			string body = string.IsNullOrEmpty(desc.Body) ? "pass" : desc.Body;
			body = body.Replace("\n", "\n\t");
			string rtrn = desc.IsReturn ? "return " : "";
			string tabbed = string.Format("\t{0}{1}", rtrn, body);
			return string.Format("def {0}({1}):\n{2}", desc.Name, args, tabbed);
		}

		private static string GenerateFunctionArgs(List<FnArgDesc> args)
		{
			if (args == null || args.Count == 0)
				return "";

			var result = new StringBuilder();

			for (int i = 0; i < args.Count; i++)
			{
				result.Append(args[i].Name);
				if (!string.IsNullOrEmpty(args[i].Value))
					result.AppendFormat(" = {0}", args[i].Value);
				if (i < args.Count - 1)
					result.Append(", ");
			}

			return result.ToString();
		}
	}
}
