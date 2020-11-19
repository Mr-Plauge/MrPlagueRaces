using Microsoft.Xna.Framework.Graphics;
using MrPlagueRaces.Core.Loadables;
using Terraria;
using Terraria.ModLoader;

namespace MrPlagueRaces.Common.Systems
{
	//This system is used for swiftly and temporarily replacing player textures.
	public class RaceTextureSwapSystem : ILoadable
	{
		public static RaceTextureSwapSystem Instance => ModContent.GetInstance<RaceTextureSwapSystem>();

		//These refs exist so that there's less suffering in replacing fields when moving between 1.3 and 1.4.
		private static ref Texture2D[,] PlayerTextures => ref Main.playerTextures;
		private static ref Texture2D[] PlayerHairTextures => ref Main.playerHairTexture;
		private static ref Texture2D[] PlayerHairAltTextures => ref Main.playerHairAltTexture;

		private Texture2D[,] vanillaPlayerTextures;
		private Texture2D[] vanillaPlayerHairTextures;
		private Texture2D[] vanillaPlayerHairAltTextures;

		void ILoadable.Load(Mod mod)
		{
			ContentInstance.Register(this);

			vanillaPlayerTextures = PlayerTextures;
			vanillaPlayerHairTextures = PlayerHairTextures;
			vanillaPlayerHairAltTextures = PlayerHairAltTextures;
		}

		void ILoadable.Unload() => RestoreVanillaTextures(true);

		private void RestoreVanillaTextures(bool unload)
		{
			void Restore<T>(ref T vanillaBackup, ref T current) where T : class
			{
				if (vanillaBackup != null)
				{
					current = vanillaBackup;

					if (unload)
					{
						vanillaBackup = null;
					}
				}
			}

			Restore(ref vanillaPlayerTextures, ref PlayerTextures);
			Restore(ref vanillaPlayerHairTextures, ref PlayerHairTextures);
			Restore(ref vanillaPlayerHairAltTextures, ref PlayerHairAltTextures);
		}

		public static void RestoreVanillaTextures() => Instance.RestoreVanillaTextures(false);
	}
}
