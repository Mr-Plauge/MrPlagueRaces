using Terraria.ModLoader;

namespace MrPlagueRaces.Core.Loadables
{
	//Copied from 1.4 tML.
	public interface ILoadable
	{
		void Load(Mod mod);
		void Unload();
	}
}
