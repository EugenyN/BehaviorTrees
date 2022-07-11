// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using BehaviorTrees.Engine;
using BehaviorTrees.Utils;
using IronPython.Runtime;
using IronPython.Runtime.Types;
using Microsoft.Scripting.Hosting;
using System.Runtime.Serialization;

namespace BehaviorTrees.IronPython
{
	/// <summary>
	/// 
	/// </summary>
	[DataContract]
	public class PythonObject : IScriptedContext
	{
		PythonInterpreter _pi = PythonInterpreter.Instance;
		ObjectOperations _ops = PythonInterpreter.Instance.Operations;

		object _object;

		public object InnerObject
		{
			get { return _object; }
		}

		public static PythonObject CreateTempObj()
		{
			return new PythonObject();
		}

		private PythonObject()
		{
			_pi.Execute("class _TempObj(object): pass");
			var objectType = _pi.GetVariable("_TempObj");
			_object = _ops.Invoke(objectType);
		}

		public PythonObject(string type, params object[] parameters)
		{
			if (!_pi.ContainsVariable(type))
			{
				Log.Write("PythonObject constructor:  Type '" + type + "' is not found !");
				return;
			}

			var objectType = _pi.GetVariable(type);

			_object = (objectType == null ? null : _ops.Invoke(objectType, parameters));
		}

		public PythonObject(object type, params object[] parameters)
		{
			_object = _ops.Invoke(type, parameters);
		}

		public object AddFunction(string name, string body, List<FnArgDesc> args, bool returnValue)
		{
			return AddFunction(new FnDesc()
			{
				Name = name,
				Body = body,
				Arguments = args,
				IsReturn = returnValue
			});
		}

		public object AddFunction(FnDesc desc)
		{
			if (desc.Arguments == null)
				desc.Arguments = new List<FnArgDesc>();
			desc.Arguments.Insert(0, new FnArgDesc("self"));

			var function = CodeGenerator.GenerateFunction(desc);
			_pi.Execute(function);
			var fn = _pi.GetVariable(desc.Name);
			_pi.RemoveVariable(desc.Name);

			var method = new Method(fn, _object, DynamicHelpers.GetPythonType(_object));
			SetMember(desc.Name, method);
			return method;
		}

		public object CallFunction(string name, params object[] parameters)
		{
			var fn = _ops.GetMember(_object, name);
			return CallFunction(fn, parameters);
		}

		public object CallFunction(object fn, params object[] parameters)
		{
			return _ops.Invoke(fn, parameters);
		}

		public bool ContainsMember(string name)
		{
			return _ops.ContainsMember(_object, name);
		}

		public void SetMember(string name, object value)
		{
			_ops.SetMember(_object, name, value);
		}

		public object GetMember(string name)
		{
			return _ops.GetMember(_object, name);
		}

		public void RemoveMember(string name)
		{
			_ops.RemoveMember(_object, name);
		}
	}
}
