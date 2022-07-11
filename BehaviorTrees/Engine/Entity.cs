// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using BehaviorTrees.Utils;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace BehaviorTrees.Engine
{
	[DataContract]
	public class Entity : Component
	{
		private Dictionary<Type, Component> _components;

		[DataMember]
		[JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Replace)]
		protected Dictionary<Type, Component> Components
		{
			get { return _components; }
			set
			{
				_components = value;

				if (_components != null)
				{
					foreach (var component in _components.Values)
						component.Owner = this;
				}
			}
		}

		public Entity()
		{
		}

		public Entity(string name)
			: base(name)
		{
		}

		public T Clone<T>() where T : Entity
		{
			var obj = Reflector.Clone<T>((T)this);
			obj.Version = 0;
			return obj;
		}

		protected override void OnActivated()
		{
			base.OnActivated();

			if (_components == null)
				return;

			foreach (var component in Components.Values)
				component.Activate();
		}

		protected override void OnDeactivated()
		{
			base.OnDeactivated();

			if (_components == null)
				return;

			foreach (var component in Components.Values)
				component.Deactivate();
		}

		public T GetComponent<T>() where T : Component
		{
			if (_components == null)
				return null;

			Component component;
			if (_components.TryGetValue(typeof(T), out component))
				return (T)component;
			return null;
		}

		public T AddComponent<T>() where T : Component, new()
		{
			return AddComponent(new T());
		}

		public T AddComponent<T>(T component) where T : Component
		{
			if (_components == null)
				_components = new Dictionary<Type, Component>();

			component.Owner = this;
			_components.Add(typeof(T), component);
			return component;
		}

		public bool RemoveComponent<T>() where T : Component
		{
			if (_components == null)
				return false;

			var component = GetComponent<T>();
			if (component != null)
			{
				component.Owner = null;
				return _components.Remove(typeof(T));
			}

			return false;
		}
	}
}
