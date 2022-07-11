// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

namespace BehaviorTrees.IronPython
{
	/// <summary>
	/// 
	/// </summary>
	public class CachedFunction
	{
		FnDesc _fnDesc;
		object _fn;

		public CachedFunction(FnDesc desc)
		{
			_fnDesc = desc;
		}

		public CachedFunction(string name, string body, List<FnArgDesc> args, bool isReturn)
		{
			_fnDesc.Name = name;
			_fnDesc.Body = body;
			_fnDesc.Arguments = args;
			_fnDesc.IsReturn = isReturn;
		}

		public CachedFunction(string body, List<FnArgDesc> args, bool isReturn)
			: this(CodeGenerator.GetUniqueName(), body, args, isReturn)
		{ }

		public object CallWithSelf(PythonObject pobj, params object[] parameters)
		{
			if (pobj == null)
				return null;

			if (_fn == null)
				_fn = pobj.AddFunction(_fnDesc);

			var result = pobj.CallFunction(_fn, parameters);
			return result;
		}

		public object Call(params object[] parameters)
		{
			var pi = PythonInterpreter.Instance;

			if (_fn == null)
			{
				var function = CodeGenerator.GenerateFunction(_fnDesc);
				pi.Execute(function);
				_fn = pi.GetVariable(_fnDesc.Name);
			}

			return pi.CallFunction(_fnDesc.Name, parameters);
		}
	}
}
