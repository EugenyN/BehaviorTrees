// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using BehaviorTrees.Utils;

namespace BehaviorTrees.Engine
{
	public sealed class Engine
	{
		private static Engine _instance;

		public static Engine Instance
		{
			get
			{
				if (_instance == null)
					_instance = new Engine();
				return _instance;
			}
		}

		private Engine()
		{ }

		public Action<object, EventArgs> SceneLoaded { get; set; }
		public Action<Node, EventArgs> ExecutionCompleted { get; set; }

		public bool IsDesignMode { get; internal set; }
		public List<Entity> Entities { get; set; } = new List<Entity>();
		public BTScript BTScript { get; set; }

		Node _currentTree;
		CancellationTokenSource _executionToken;

		public void LoadScene(IEnumerable<Entity> entities, BTScript script)
		{
			Entities.Clear();
			Entities.AddRange(entities);
			BTScript = script;

			SceneLoaded?.Invoke(this, EventArgs.Empty);
		}

		public void ExecuteScript(Node behaviorTree, Entity entity)
		{
			_currentTree = behaviorTree;
			_currentTree.Owner = entity;

			_executionToken = new CancellationTokenSource();

			Task.Run(() =>
			{
				while (!_executionToken.IsCancellationRequested &&
						_currentTree.Execute() == ExecutingStatus.Running)
				{ }
			}, _executionToken.Token).ContinueWith((t) =>
			{
				if (t.IsFaulted)
				{
					Exception ex = t.Exception;
					while (ex is AggregateException && ex.InnerException != null)
						ex = ex.InnerException;
					Log.Write("The script execution failed: " + ex.Message);
				}
				else if (t.IsCanceled)
				{
					Log.Write("The script execution cancelled !");
				}
				else
				{
					Log.Write("The script is executed successfully !");
				}

				if (!t.IsFaulted)
					_currentTree.Deactivate();
				ExecutionCompleted?.Invoke(_currentTree, EventArgs.Empty);
				_currentTree = null;

			}, TaskScheduler.FromCurrentSynchronizationContext());
		}

		public void StopScript()
		{
			if (_currentTree == null)
			{
				Log.Write("_current == null");
				return;
			}

			_executionToken.Cancel();
		}
	}
}