// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using BehaviorTreesEditor;
using System;
using System.Windows.Forms;

namespace BehaviorTreesExample
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			ApplicationConfiguration.Initialize();
			Application.Run(new BTEditorForm());
		}
	}
}
