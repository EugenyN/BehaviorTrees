# Behavior Trees

A simple C# example of Behavior Trees + Editor.

## Introduction

**Behavior Trees** (BT) is a simple, scalable, modular solution that represents complex AI-behaviors and provides easy-to-maintain and configure logic.

<img align="right" src="/Images/bt.png">

They have been widely used in robotics and gaming since mid 2000, in particular, such game engines as Unreal, Unity, CryEngine use BT. You can learn more about Behavior Trees at the following links:

* [Behavior tree (Wikipedia)](https://en.wikipedia.org/wiki/Behavior_tree_(artificial_intelligence,_robotics_and_control))
* [Designing AI Agents’ Behaviors with Behavior Trees](https://towardsdatascience.com/designing-ai-agents-behaviors-with-behavior-trees-b28aa1c3cf8a)
* [The Behavior Tree Starter Kit (A. Champandard and P. Dunstan)](https://www.gameaipro.com/GameAIPro/GameAIPro_Chapter06_The_Behavior_Tree_Starter_Kit.pdf)

## About project

This project demonstrates the concept and working principle of the Behavior Trees. Therefore, I tried to make it as simple and laconic as possible. You can fork, adapt and extend the project to suit your needs.

* The project includes **BehaviorTrees** library with the main types of nodes: actions, conditions, composites and decorators (20 in total) as well as auxiliary classes. You can add your nodes by inheriting from existing ones. You can use `ActionBase` base class to create custom actions and use `BaseEvent` base class to create custom events. Trees can be serialized in json.

* **BehaviorTreesEditor** allows you to edit trees with a simple TreeList control, to save, to load and to run trees.

![Behavior Trees](/Images/editor.png "Editor")

## Example 1

* **BehaviorTrees.Example1** contains simple example of the Behavior Tree with custom node `Move`:

```C#
[DataContract]
[BTNode("Move", "Example")]
public class Move : Node
{
    Point _position;
    bool _completed;

    [DataMember]
    public Point Position
    {
        get { return _position; }
        set {
            _position = value;
            Root.SendValueChanged(this);
        }
    }

    public Move(Point pos)
    {
        Position = pos;
    }

    public override string NodeParameters => $"Move To ({Position.X}, {Position.Y})";

    protected override void OnActivated()
    {
        base.OnActivated();
        Log.Write($"{Owner.Name} moving to {Position}");
        Task.Delay(1000).ContinueWith(_ => _completed = true);
    }

    protected override void OnDeactivated()
    {
        base.OnDeactivated();
        Log.Write($"{Owner.Name} moving completed ");
    }

    protected override ExecutingStatus OnExecuted()
    {
        return _completed ? ExecutingStatus.Success : ExecutingStatus.Running;
    }
}
```
BehaviorTrees.Example1 demonstrates Behavior Tree creation by using `TreeBuilder`:
```C#

var exampleBT = new TreeBuilder<Node>(new Sequence())
    .AddWithChild(new Loop(3))
        .AddWithChild(new Sequence())
            .Add(new Move(new Point(0, 0)))
            .Add(new Move(new Point(20, 0)))
            .AddWithChild(new Delay(2))
                .Add(new Move(new Point(0, 20)))
            .Up()
        .Up()
    .Up()
.ToTree();
```

## Example 2 - IronPython nodes

The library **BehaviorTrees.IronPython** is an example of scripting language integration into the Behavior Tree. As an example two nodes are added: `ScriptedAction` and `ScriptedCondition`. The script can be edited both with help of the PropertyGrid and using the syntax highlighting editor implemented in **BehaviorTrees.IronPython.Editor** project.

![Behavior Trees](/Images/ipeditor.png "IronPython nodes")

You can extend the example and add your own API, import your types, both from the host application and from other IronPython scripts. Based on this example you can integrate another scripting language you need.

## Build

* `net6.0` TFM is used for libraries and `net6.0-windows` for editors.
* Please rebuild the solution to execute post-build scripts that will copy the example libraries to the output directory.

## Third party in this project

* [TreeView with Columns](https://www.codeproject.com/Articles/23746/TreeView-with-Columns) by jkristia 
* [Generic Tree container](https://www.codeproject.com/Articles/12592/Generic-Tree-T-in-C) by peterchen 
* Visual Studio 2015 Image Library. [Microsoft Software License Terms](http://download.microsoft.com/download/0/6/0/0607D8EA-9BB7-440B-A36A-A24EB8C9C67E/Visual%20Studio%202015%20Image%20Library%20EULA.docx)
* [IronPython](https://github.com/IronLanguages/ironpython2/) and [FastColoredTextBox](https://github.com/PavelTorgashov/FastColoredTextBox) in Example 2

## Other Behavior Trees on Github

* [BehaviorTree.CPP](https://github.com/BehaviorTree/BehaviorTree.CPP) (C++)
* [BehaviorTree.js](https://github.com/Calamari/BehaviorTree.js) (JavaScript)
* [EntitiesBT](https://github.com/quabug/EntitiesBT) (Unity, DOTS)
* [Fluid Behavior Tree](https://github.com/ashblue/fluid-behavior-tree) (Unity)

## License

Copyright (c) 2015 Eugeny Novikov. Code under MIT license.