// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using BehaviorTrees.Utils;
using IronPython.Runtime;
using IronPython.Runtime.Operations;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using System.Diagnostics;

namespace BehaviorTrees.IronPython
{
	/// <summary>
	/// 
	/// </summary>
	public class Scope
	{
		PythonInterpreter _pi;
		ScriptEngine _engine;
		ScriptScope _scope;

		public Scope(ScriptScope scope, PythonInterpreter pi)
		{
			_pi = pi;
			_engine = _pi.Engine;
			_scope = scope;
		}

		public object ExecuteFile(string file)
		{
			return Execute(_engine.CreateScriptSourceFromFile(file));
		}

		public object ExecuteStatement(string code)
		{
			return Execute(_engine.CreateScriptSourceFromString(code, SourceCodeKind.SingleStatement));
		}

		public object Execute(string code)
		{
			return (code != null ? Execute(_engine.CreateScriptSourceFromString(code, SourceCodeKind.Statements)) : null);
		}

		public object Evaluate(string code)
		{
			return Execute(_engine.CreateScriptSourceFromString(code, SourceCodeKind.Expression));
		}

		[DebuggerNonUserCode]
		private object Execute(ScriptSource source)
		{
			try
			{
				return source.Execute(_scope);
			}
			catch (Exception ex)
			{
				var wrapper = new Exception(_pi.FormatException(ex), ex);
				Log.Write(wrapper, "Execute failed: '{0}'", wrapper.Message);
				throw wrapper;
			}
		}

		public object CallFunction(object function, params object[] args)
		{
			try
			{
				return PythonCalls.Call(function, args);
			}
			catch (Exception ex)
			{
				Log.Write(ex, "Call function failed: '{0}'", ex.Message);
				throw new Exception(_pi.FormatException(ex), ex);
			}
		}

		public object CallFunction(string functionName, params object[] args)
		{
			var fn = _scope.GetVariable<PythonFunction>(functionName);

			if (fn == null /*|| fn.Closure == null*/)
				throw new Exception("Function with name '" + functionName + "' not found!");

			return CallFunction(fn, args);
		}

		public object GetVariable(string name)
		{
			try
			{
				return _scope.GetVariable(name);
			}
			catch (Exception)
			{
				return null;
			}
		}

		public void SetVariable(string name, object value)
		{
			_scope.SetVariable(name, value);
		}

		public bool ContainsVariable(string name)
		{
			return _scope.ContainsVariable(name);
		}

		public void RemoveVariable(string name)
		{
			_scope.RemoveVariable(name);
		}

		public ObjectOperations CreateOperations()
		{
			return _engine.CreateOperations(_scope);
		}

		public Dictionary<string, object> GetVariablesForSave()
		{
			var vars = new Dictionary<string, object>();

			foreach (var item in _scope.GetItems())
			{
				Type type = item.Value.GetType();
				bool sysKey = item.Key.StartsWith("__");
				if (type.IsPrimitive || type == typeof(string) && !sysKey)
					vars.Add(item.Key, item.Value);
			}

			return vars;
		}

		public void SetSavedVariables(Dictionary<string, object> vars)
		{
			foreach (var v in vars)
				_scope.SetVariable(v.Key, v.Value);
		}
	}
}
