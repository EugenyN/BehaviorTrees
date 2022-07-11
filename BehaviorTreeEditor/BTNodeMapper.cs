// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using BehaviorTrees;
using CT = CommonTools;

namespace BehaviorTreesEditor
{
	/// <summary>
	/// 
	/// </summary>
	public class BTNodeMapper : ITreeListNodeMapper<Node>
	{
		public void UpdateNode(Node dataNode, CT.Node treeNode, CT.TreeListView view)
		{
			treeNode.Tag = dataNode;
			treeNode.ImageId = dataNode.NodeType switch
			{
				"Action" => 0,
				"Composite" => 1,
				"Condition" => 2,
				"Decorator" => 3,
				"Trigger" => 4,
				_ => 0
			};;

			var nameColumn = view.Columns["Name"];
			treeNode[nameColumn.Index] = dataNode.NodeName;

			var typeColumn = view.Columns["Type"];
			treeNode[typeColumn.Index] = dataNode.NodeType;

			var paramsColumn = view.Columns["Parameters"];
			treeNode[paramsColumn.Index] = dataNode.NodeParameters;
		}
		
		public Node GetNodeInfo(CT.Node treeNode)
		{
			return (Node)treeNode.Tag;
		}
	}
}