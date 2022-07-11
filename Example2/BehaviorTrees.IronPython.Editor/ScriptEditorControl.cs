// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using FastColoredTextBoxNS;
using FastColoredTextBoxNS.Types;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BehaviorTrees.IronPython.Editor
{
	public partial class ScriptEditorControl : UserControl
	{
		public class OutputTraceListener : TraceListener
		{
			readonly TextBox outputTextBox;

			public OutputTraceListener(TextBox outputTextBox)
			{
				this.Name = "Trace";
				this.outputTextBox = outputTextBox;
			}

			public override void Write(string message)
			{
				outputTextBox.Text += message;
				if (outputTextBox.Text.Length > 0)
					outputTextBox.Text += Environment.NewLine;

				outputTextBox.SelectionStart = outputTextBox.Text.Length;
				outputTextBox.ScrollToCaret();
				outputTextBox.Refresh();
			}

			public override void WriteLine(string message)
			{
				Write(message + Environment.NewLine);
			}
		}

		public PythonScript Script { get; set; }

		public event EventHandler ScriptLoaded;
		public event EventHandler EditorClosing;

		//styles
		readonly TextStyle BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
		readonly TextStyle BoldStyle = new TextStyle(null, null, FontStyle.Bold | FontStyle.Underline);
		readonly TextStyle GrayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
		readonly TextStyle MagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
		readonly TextStyle GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);
		readonly TextStyle BrownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Italic);
		readonly TextStyle OrangeStyle = new TextStyle(Brushes.Orange, null, FontStyle.Regular);


		public ScriptEditorControl()
		{
			InitializeComponent();
		}

		public void LoadData(PythonScript data)
		{
			if (DesignMode)
				return;

			Script = data;
			pythonTextbox.Text = Script.Text;

			ScriptLoaded?.Invoke(this, EventArgs.Empty);

			Trace.Listeners.Add(new OutputTraceListener(outputTextBox));
		}

		public void ExecuteScript()
		{
			try
			{
				var script = new PythonScript(GetCodeToExecute());
				script.ExecuteScript();
				var pi = PythonInterpreter.Instance;
				Trace.Write(pi.GetOutput());
			}
			catch (Exception exc)
			{
				Trace.TraceWarning(exc.Message);
				return;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
					components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void SaveScript(bool mboxOutput)
		{
			try
			{
				Script.Text = pythonTextbox.Text;
			}
			catch (Exception exc)
			{
				Trace.TraceWarning(exc.Message);

				if (mboxOutput)
					MessageBox.Show(this, exc.Message, "Error", MessageBoxButtons.OK);
			}
		}

		private string GetCodeToExecute()
		{
			if (pythonTextbox.SelectedText.Length > 0)
				return pythonTextbox.SelectedText;
			else
				return pythonTextbox.Text;
		}

		private void HighlightingSetup(TextSelectionRange range)
		{
			range.ClearStyle(BlueStyle, BoldStyle, GrayStyle, MagentaStyle, GreenStyle, BrownStyle, OrangeStyle);

			range.SetStyle(MagentaStyle, @"(?<=def )(.*)(?=\()");
			range.SetStyle(GrayStyle, @"(\[desc\])(.*?)(\[\/desc\])", RegexOptions.Singleline);
			range.SetStyle(GreenStyle, @"#.*$", RegexOptions.Multiline);
			range.SetStyle(GrayStyle, @"^\s*(?<range>\[.+?\])\s*$", RegexOptions.Multiline);
			range.SetStyle(BoldStyle, @"\b(class|struct|enum|interface)\s+(?<range>\w+?)\b");
			range.SetStyle(BlueStyle, @"\b(elif|except|print|import|and|not|from |in |do |if|import *|def|abstract|as|self|bool|byte|case|catch|char|checked|class|const|pass|decimal|default|delegate|do|double|else|enum|event|explicit|extern|false|finally|fixed|float|for|foreach|goto|if|implicit|in|int|interface|internal|is|lock|long|namespace|new|null|object|operator|override|params|private|protected|public|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|virtual|void|volatile|while|add|alias|ascending|descending|dynamic|from|get|global|group|into|join|let|orderby|partial|remove|select|set|value|var|where|yield)\b|#region\b|#endregion\b");
			range.SetStyle(MagentaStyle, @"\b(True|False|None)");

			// folding markers. allow to collapse blocks
			range.ClearFoldingMarkers();
			range.SetFoldingMarkers("{", "}");
			range.SetFoldingMarkers(@"'''", @"'''");
			range.SetFoldingMarkers("\"\"\"", "\"\"\"", RegexOptions.Singleline | RegexOptions.RightToLeft);
		}

		private void PythonTextbox_TextChanged(object sender, TextChangedEventArgs e)
		{
			pythonTextbox.LeftBracket = '(';
			pythonTextbox.RightBracket = ')';
			pythonTextbox.LeftBracket2 = '\x0';
			pythonTextbox.RightBracket2 = '\x0';

			var range = (sender as FastColoredTextBox).Range;
			if (range != null)
				HighlightingSetup(range);
		}

		private void PythonTextbox_AutoIndentNeeded(object sender, AutoIndentEventArgs e)
		{
			if (Regex.IsMatch(e.LineText, ":$"))
				e.ShiftNextLines = pythonTextbox.TabLength;
			if (Regex.IsMatch(e.LineText, "return .*$"))
				e.ShiftNextLines = -pythonTextbox.TabLength;
		}

		private void ExecuteTSButton_Click(object sender, EventArgs e)
		{
			ExecuteScript();
		}

		private void SaveAndCloseTSButton_Click(object sender, EventArgs e)
		{
			SaveScript(false);
			EditorClosing?.Invoke(this, EventArgs.Empty);
		}

		private void SaveTSButton_Click(object sender, EventArgs e)
		{
			SaveScript(false);
		}

		private void CutTSButton_Click(object sender, EventArgs e)
		{
			pythonTextbox.Cut();
		}

		private void CopyTSButton_Click(object sender, EventArgs e)
		{
			pythonTextbox.Copy();
		}

		private void PasteTSButton_Click(object sender, EventArgs e)
		{
			pythonTextbox.Paste();
		}

		private void UndoTSButton_Click(object sender, EventArgs e)
		{
			pythonTextbox.Undo();
		}

		private void RedoTSButton_Click(object sender, EventArgs e)
		{
			pythonTextbox.Redo();
		}

		private void CutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			pythonTextbox.Cut();
		}

		private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			pythonTextbox.Copy();
		}

		private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			pythonTextbox.Paste();
		}

		private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			pythonTextbox.ClearSelected();
		}

		private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			pythonTextbox.SelectAll();
		}

		private void ExecuteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ExecuteTSButton_Click(null, null);
		}
	}
}
