// Copyright(c) 2015-2019 Eugeny Novikov. Code under MIT license.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BehaviorTrees.IronPython.Design
{
	public interface IScriptEditorService
	{
		void ShowEditor(PythonScript data, ITypeDescriptorContext context);
	}
}
