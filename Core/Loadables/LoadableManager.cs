using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;

namespace MrPlagueRaces.Core.Loadables
{
	//Based on 1.4 tML
	public static class LoadableManager
	{
		private static IList<ILoadable> content;

		public static void Autoload(Mod mod)
		{
			content = new List<ILoadable>();

			foreach (var type in mod.GetType().Assembly.GetTypes())
			{
				if (type.IsAbstract || !typeof(ILoadable).IsAssignableFrom(type) || type.GetConstructor(new Type[0]) == null)
				{
					continue;
				}

				var autoload = AutoloadAttribute.GetValue(type);

				if (autoload.NeedsAutoloading)
				{
					AddContent(mod, (ILoadable)Activator.CreateInstance(type));
				}
			}
		}

		public static void Unload()
		{
			if (content != null)
			{
				foreach (var loadable in content.Reverse())
				{
					loadable.Unload();
				}

				content.Clear();

				content = null;
			}
		}

		public static void AddContent(Mod mod, ILoadable instance)
		{
			instance.Load(mod);

			content.Add(instance);
			//ContentInstance.Register(instance); //Normally, we would have this line, but 1.3 already calls it, so having it everywhere would cause clashes.
		}
	}
}
