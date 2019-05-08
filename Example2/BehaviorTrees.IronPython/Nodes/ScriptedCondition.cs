// Copyright(c) 2015-2019 Eugeny Novikov. Code under MIT license.

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
using BehaviorTrees.IronPython;
using BehaviorTrees.IronPython.Design;
using System.Drawing.Design;
using BehaviorTrees.Engine;

namespace BehaviorTrees.IronPython
{
	/// <summary>
	/// Node that can check some condition.
	/// </summary>
	[DataContract]
	[BTNode("ScriptedCondition", "Condition")]
	public class ScriptedCondition : Condition
	{
		string _condition;
		CachedFunction _fn;

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		[Editor(typeof(ScriptUITypeEditor), typeof(UITypeEditor))]
		public string Condition
		{
			get { return _condition; }
			set
			{
				if (_condition == value)
					return;

				_condition = value;
				_fn = new CachedFunction(_condition, null, true);

				Root.SendValueChanged(this);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override string NodeParameters
		{
			get { return _condition; }
		}

		/// <summary>
		/// 
		/// </summary>
		public ScriptedCondition()
		{
			Condition = "";
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="condition"></param>
		public ScriptedCondition(string condition)
		{
			Condition = condition;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="condition"></param>
		/// <param name="isInstant"></param>
		public ScriptedCondition(string condition, bool isInstant)
			: base(isInstant)
		{
			Condition = condition;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="newOwner"></param>
		protected override void OnAttachedToOwner(Entity newOwner)
		{
			base.OnAttachedToOwner(newOwner);
			var po = PythonObject.CreateTempObj();
			po.SetMember("owner", Owner);
			Root.RootNode.ScriptedContext = po;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected override bool OnCheck()
		{
			return (bool)_fn.CallWithSelf((PythonObject)ScriptedContext);
		}
	}
}
