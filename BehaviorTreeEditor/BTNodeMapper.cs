// Copyright(c) 2015-2019 Eugeny Novikov. Code under MIT license.

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
			treeNode.ImageId = dataNode.ImageListIndex;

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