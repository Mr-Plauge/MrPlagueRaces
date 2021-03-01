using Microsoft.Xna.Framework.Graphics;
using MrPlagueRaces.Core.Loadables;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MrPlagueRaces.Common.Races
{
	public abstract class Race : ModType
	{
		//private Texture2D[] hairTextures;
		//private Texture2D[] hairTexturesAlt;

		public int Id { get; internal set; }

		public virtual int? LegacyId => null;

		public virtual void ResetEffects(Player player) { }
		public virtual void Load(Player player) { }
		public virtual void Save(Player player) { }
		public virtual void PostItemCheck(Player player, Mod mod) { }
		public virtual void ProcessTriggers(Player player, Mod mod) { }
		public virtual void PreUpdate(Player player, Mod mod) { }
		public virtual void ModifyDrawInfo(Player player, Mod mod, ref PlayerDrawInfo drawInfo) { }
		public virtual void ModifyDrawLayers(Player player, List<PlayerLayer> layers) { }
		public virtual bool PreHurt(Player player, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) => true;
		public virtual bool PreKill(Player player, Mod mod, double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) => true;

		protected override void Register()
		{
			RaceLoader.AddRace(this);
			ContentInstance.Register(this);
		}

		private void ApplyTextureSwaps()
		{

		}
	}
}
