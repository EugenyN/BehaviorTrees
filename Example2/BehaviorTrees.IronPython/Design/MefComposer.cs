// Copyright(c) 2015-2019 Eugeny Novikov. Code under MIT license.

using System.ComponentModel.Composition.Hosting;

namespace BehaviorTrees.IronPython.Design
{
	// MefComposer for dependency inversion

	public class MefComposer
	{
		private static CompositionContainer container;

		public static CompositionContainer Container
		{
			get {
				if (container == null)
				{
					var aggregateCatalog = new AggregateCatalog(
						new DirectoryCatalog(".", "*.dll"),
						new DirectoryCatalog(".", "*.exe"));

					container = new CompositionContainer(aggregateCatalog, true);
				}
				return container;
			}
		}

		public static T GetExportedValue<T>()
		{
			return Container.GetExportedValue<T>();
		}
	}
}
