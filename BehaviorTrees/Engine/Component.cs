// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using BehaviorTrees.Utils;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace BehaviorTrees.Engine
{
	/// <summary>
	/// 
	/// </summary>
	[DataContract]
	public class Component
	{
		protected string _name;
		protected bool _isActive;
		protected bool _isInitialized;

		public event EventHandler Initialized;
		public event EventHandler Activated;
		public event EventHandler Deactivated;

		private Entity _owner;

		[Browsable(false)]
		[Category("Component")]
		public Entity Owner
		{
			get { return _owner; }
			set
			{
				if (_owner == value)
					return;

				var old = _owner;
				_owner = value;
				OnOwnerChanged(old, _owner);
			}
		}

		/// <summary>
		/// Gets or sets the Name of the Spatial.
		/// </summary>
		[Category("Component")]
		[DataMember]
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>
		/// Is attached to scene.
		/// </summary>
		[Category("Component")]
		public bool IsActive
		{
			get { return _isActive; }
			set
			{
				if (value)
					Activate();
				else
					Deactivate();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Category("Component")]
		public bool IsInitialized
		{
			get { return _isInitialized; }
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		[Category("Component")]
		[Browsable(false)]
		public int Version { get; set; }

		/// <summary>
		/// 
		/// </summary>
		protected virtual int RequiredVersion
		{
			get { return 1; }
		}


		/// <summary>
		/// 
		/// </summary>
		public Component()
			: this(string.Empty)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		public Component(string name)
		{
			Name = string.IsNullOrEmpty(name) ? GetType().Name : name;
			_isInitialized = false;
		}


		/// <summary>
		/// 
		/// </summary>
		public void Initialize()
		{
			if (_isInitialized)
				return;

			_isInitialized = true;

			try
			{
				OnInitialized();
				Initialized?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception e)
			{
				Log.Write(e, "Component.Initialize() failed to intialize component '{0}'.", this);
			}
		}

		/// <summary>
		/// Called once when first adding to the scene.
		/// </summary>
		protected virtual void OnInitialized()
		{
			int minRequiredVersion = RequiredVersion;
			if (Version < minRequiredVersion)
			{
				OnConstructed();
				Version = minRequiredVersion;
			}
		}

		/// <summary>
		/// Called once when the object is created and is not called during deserialization.
		/// </summary>
		protected virtual void OnConstructed()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public void Activate()
		{
			if (!_isInitialized)
				Initialize();

			if (!_isInitialized)
				return;

			if (_isActive)
				return;

			_isActive = true;

			try
			{
				OnActivated();
				Activated?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				_isActive = false;
				Log.Write(ex, "Component.Activate() failed with exception: '{0}'", this);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		protected virtual void OnActivated()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public void Deactivate()
		{
			if (!_isActive)
				return;

			_isActive = false;

			try
			{
				OnDeactivated();
				Deactivated?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				Log.Write(ex, "Component.Deactivate() failed with exception: '{0}'", this);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		protected virtual void OnDeactivated()
		{
		}

		protected virtual void OnOwnerChanged(Entity oldOwner, Entity newOwner)
		{
		}

	}
}
