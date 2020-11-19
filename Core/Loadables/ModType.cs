using Terraria.ModLoader;

namespace MrPlagueRaces.Core.Loadables
{
	//Copied from tML 1.4
	public abstract class ModType : ILoadable
	{
		public Mod Mod { get; private set; }

		public virtual string Name => GetType().Name;

		public string FullName => $"{Mod.Name}/{Name}";

		void ILoadable.Load(Mod mod)
		{
			Mod = mod;

			Load();
			Register();
		}

		public virtual void Load() { }
		public virtual void Unload() { }

		protected abstract void Register();
	}
}
