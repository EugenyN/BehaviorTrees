// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using BehaviorTrees.Engine;
using System.Runtime.Serialization;

namespace BehaviorTrees.IronPython
{
	[DataContract]
	public class PythonScript : Component
	{
		static readonly object[] EmptyArgs = Array.Empty<object>();

		bool _isGlobal;
		bool _isFunction;
		string _text;

		[DataMember(Name = "Script")]
		[System.ComponentModel.Browsable(false)]
		public string Text
		{
			get { return _text; }
			set
			{
				if (_text == value)
					return;

				_text = value;

				OnTextChanged(_text);
			}
		}

		[DataMember]
		public bool IsGlobal
		{
			get { return _isGlobal; }
			set { _isGlobal = value; }
		}

		[DataMember]
		public bool IsFunction
		{
			get { return _isFunction; }
			set { _isFunction = value; }
		}

		CachedFunction _fn;

		public PythonScript()
		{ }

		public PythonScript(string script)
		{
			Text = script;
		}

		public PythonScript(string script, bool isGlobal, bool isFunction)
		{
			IsGlobal = isGlobal;
			IsFunction = isFunction;
			Text = script;
		}

		public object Execute(object args)
		{
			object result;
			if (_isGlobal)
			{
				var pi = PythonInterpreter.Instance;
				if (_isFunction)
					result = pi.Evaluate(Text);
				else
					result = pi.Execute(Text);
			}
			else
			{
				var evnt = args as BaseEvent;
				if (evnt == null)
					result = _fn.Call(EmptyArgs);
				else
					result = _fn.Call(evnt.GetArgs());
			}
			return result;
		}

		public virtual void ExecuteScript()
		{
			Execute(null);
		}

		protected virtual void OnTextChanged(string text)
		{
			var argsDesc = new List<FnArgDesc>() {
				new FnArgDesc("_self", "None"),
				new FnArgDesc("_target", "None"),
				new FnArgDesc("_option", "None")
			};

			_fn = new CachedFunction(text, argsDesc, false);
		}
	}
}
