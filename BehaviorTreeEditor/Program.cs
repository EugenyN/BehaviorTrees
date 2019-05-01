// Copyright(c) 2015-2019 Eugeny Novikov. Code under MIT license.

using System;
using System.Windows.Forms;
using BehaviorTreesEditor;

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
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new BTEditorForm());
		}
	}
}
