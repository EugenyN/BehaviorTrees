// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using BehaviorTrees.Utils;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace BehaviorTrees.IronPython
{
	/// <summary>
	/// Python interpreter.
	/// </summary>
	public sealed class PythonInterpreter : IDisposable
	{
		static PythonInterpreter _instance;

		public static PythonInterpreter Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PythonInterpreter();
					_instance.Initialization();
				}
				return _instance;
			}
		}

		readonly ScriptEngine _engine;
		readonly ObjectOperations _operations;
		Scope _defaultScope;
		MemoryStream _output;
		ASCIIEncoding _textEncoder;

		public ScriptEngine Engine
		{
			get { return _engine; }
		}

		public ObjectOperations Operations
		{
			get { return _operations; }
		}

		public string LanguageDisplayName
		{
			get { return _engine.Setup.DisplayName; }
		}

		public Version LanguageVersion
		{
			get { return _engine.LanguageVersion; }
		}

		private PythonInterpreter()
		{
			Log.Write("Interpreter initialization...");

			_engine = CreateEngine();
			//TODO: add custom search path for .py files
			//_engine.SetSearchPaths(new string[] { ScriptsPath });

			SetupOutput();

			_defaultScope = new Scope(_engine.CreateScope(), this);
			_operations = _defaultScope.CreateOperations();
		}

		private void Initialization()
		{
			try
			{
				// basic initialization
				//TODO: add external initialization script
				Execute("import clr");
				Execute("clr.AddReference(\"System\")");
				Execute("from System import *");
			}
			catch (Exception ex)
			{
				Log.Write(ex, "Interpreter initialization failed: '{0}'", ex.Message);
			}

			Log.Write("Interpreter initialization completed.");
		}

		private static ScriptEngine CreateEngine()
		{
			var setup = new ScriptRuntimeSetup();
			setup.LanguageSetups.Add(Python.CreateLanguageSetup(null));
			setup.DebugMode = true;
			var runtime = new ScriptRuntime(setup);
			return runtime.GetEngine("py");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pyfile"></param>
		/// <returns></returns>
		public object ExecuteFile(string pyfile)
		{
			return _defaultScope.ExecuteFile(pyfile);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pycode"></param>
		/// <returns></returns>
		public object ExecuteStatement(string pycode)
		{
			return _defaultScope.ExecuteStatement(pycode);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pycode"></param>
		/// <returns></returns>
		public object Execute(string pycode)
		{
			if (pycode == null)
				return null;
			return _defaultScope.Execute(pycode);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pycode"></param>
		/// <returns></returns>
		public object Evaluate(string pycode)
		{
			return _defaultScope.Evaluate(pycode);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="function"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		public object CallFunction(object function, params object[] args)
		{
			return _defaultScope.CallFunction(function, args);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="functionName"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		public object CallFunction(string functionName, params object[] args)
		{
			return _defaultScope.CallFunction(functionName, args);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public object GetVariable(string name)
		{
			return _defaultScope.GetVariable(name);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public void SetVariable(string name, object value)
		{
			_defaultScope.SetVariable(name, value);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public bool ContainsVariable(string name)
		{
			return _defaultScope.ContainsVariable(name);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		public void RemoveVariable(string name)
		{
			_defaultScope.RemoveVariable(name);
		}

		/// <summary>
		/// 
		/// </summary>
		private void SetupOutput()
		{
			_output = new MemoryStream();
			_textEncoder = new ASCIIEncoding();
			_engine.Runtime.IO.SetOutput(_output, _engine.Runtime.IO.InputEncoding);
			//_engine.Runtime.IO.SetErrorOutput(_output, _engine.Runtime.IO.InputEncoding);
		}

		/// <summary>
		/// Get string output from IronPythons MemoryStream standard out
		/// </summary>
		/// <returns></returns>
		public string GetOutput()
		{
			byte[] statementOutput = new byte[_output.Length];
			_output.Position = 0;
			_output.Read(statementOutput, 0, (int)_output.Length);
			_output.Position = 0;
			_output.SetLength(0);

			return _textEncoder.GetString(statementOutput);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="exc"></param>
		/// <returns></returns>
		public string FormatException(Exception exc)
		{
			var es = _engine.GetService<ExceptionOperations>();
			return es.FormatException(exc);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		public void ReloadModule(string name)
		{
			Execute(string.Format("reload(sys.modules[\"{0}\"])", name));
		}

		private Dictionary<string, object> GetScopeVariables()
		{
			return _defaultScope.GetVariablesForSave();
		}

		private void SetScopeVariables(Dictionary<string, object> scopeVars)
		{
			_defaultScope.SetSavedVariables(scopeVars);
		}

		public void SaveScopeVariables(string fileName)
		{
			var scopeVars = GetScopeVariables();
			if (scopeVars.Count == 0)
				return;

			using (var fs = new FileStream(fileName, FileMode.Create))
			{
				using (var xmlWriter = new XmlTextWriter(fs, System.Text.Encoding.UTF8))
				{
					xmlWriter.Formatting = Formatting.Indented;
					using (var writer = XmlDictionaryWriter.CreateDictionaryWriter(xmlWriter))
					{
						var serializer = new DataContractSerializer(typeof(Dictionary<string, object>));

						try
						{
							serializer.WriteObject(writer, scopeVars);
						}
						catch (Exception ex)
						{
							Log.Write(ex);
						}
					}
				}
			}
		}

		public void LoadScopeVariables(string fileName)
		{
			using (var fs = new FileStream(fileName, FileMode.Open))
			{
				using (var reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas()))
				{
					var serializer = new DataContractSerializer(typeof(Dictionary<string, object>));

					try
					{
						SetScopeVariables((Dictionary<string, object>)serializer.ReadObject(reader));
					}
					catch (Exception ex)
					{
						Log.Write(ex);
					}
				}
			}
		}

		public void Dispose()
		{
			if (_output != null)
				_output.Dispose();
		}
	}
}
