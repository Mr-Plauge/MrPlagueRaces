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
        public virtual string RaceDisplayName => null;
		public virtual bool UsesCustomHurtSound => false;
		public virtual bool UsesCustomDeathSound => false;
		public virtual bool HasFemaleHurt => false;
        public virtual int? LegacyId => null;
		public Mod mod { get; internal set; }

		public virtual string RaceSelectIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
		public virtual string RaceDisplayMaleIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/BlankDisplay");
        public virtual string RaceDisplayFemaleIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/BlankDisplay");

		public virtual string RaceLore1 => "";
        public virtual string RaceLore2 => "";
		public virtual string RaceAbilityName => "";
		public virtual string RaceAbilityDescription1 => "";
		public virtual string RaceAbilityDescription2 => "";
		public virtual string RaceAbilityDescription3 => "";
		public virtual string RaceAbilityDescription4 => "";
		public virtual string RaceAbilityDescription5 => "";
		public virtual string RaceAbilityDescription6 => "";
		public virtual string RaceAdditionalNotesDescription1 => "";
		public virtual string RaceAdditionalNotesDescription2 => "";
		public virtual string RaceAdditionalNotesDescription3 => "";
		public virtual string RaceAdditionalNotesDescription4 => "";
		public virtual string RaceAdditionalNotesDescription5 => "";
		public virtual string RaceAdditionalNotesDescription6 => "";

		public virtual string RaceHealthDisplayText => "";
		public virtual string RaceRegenerationDisplayText => "";
		public virtual string RaceManaDisplayText => "";
		public virtual string RaceManaRegenerationDisplayText => "";
		public virtual string RaceDefenseDisplayText => "";
		public virtual string RaceDamageReductionDisplayText => "";
		public virtual string RaceThornsDisplayText => "";
		public virtual string RaceLavaResistanceDisplayText => "";
		public virtual string RaceAllDamageDisplayText => "";
		public virtual string RaceMeleeDamageDisplayText => "";
		public virtual string RaceRangedDamageDisplayText => "";
		public virtual string RaceMagicDamageDisplayText => "";
		public virtual string RaceSummonDamageDisplayText => "";
		public virtual string RaceMeleeSpeedDisplayText => "";
		public virtual string RaceArmorPenetrationDisplayText => "";
		public virtual string RaceBulletDamageDisplayText => "";
		public virtual string RaceRocketDamageDisplayText => "";
		public virtual string RaceManaCostDisplayText => "";
		public virtual string RaceMinionKnockbackDisplayText => "";
		public virtual string RaceMinionsDisplayText => "";
		public virtual string RaceSentriesDisplayText => "";
		public virtual string RaceMeleeCritChanceDisplayText => "";
		public virtual string RaceRangedCritChanceDisplayText => "";
		public virtual string RaceMagicCritChanceDisplayText => "";
		public virtual string RaceMiningSpeedDisplayText => "";
		public virtual string RaceBuildingSpeedDisplayText => "";
		public virtual string RaceBuildingRangeDisplayText => "";
		public virtual string RaceBuildingWallSpeedDisplayText => "";
		public virtual string RaceArrowDamageDisplayText => "";
		public virtual string RaceMovementSpeedDisplayText => "";
		public virtual string RaceJumpSpeedDisplayText => "";
		public virtual string RaceFallDamageResistanceDisplayText => "";
		public virtual string RaceFishingSkillDisplayText => "";
		public virtual string RaceAggroDisplayText => "";
		public virtual string RaceRunSpeedDisplayText => "";
        public virtual string RaceRunAccelerationDisplayText => "";

		public virtual string RaceGoodBiomesDisplayText => "";
		public virtual string RaceBadBiomesDisplayText => "";
		public virtual string RaceDietDisplayText => "";
		public virtual string RaceTimeDisplayText => "";

		public virtual void Initialize(Player player) { }
		public virtual void ResetEffects(Player player) { }
		public virtual void Load(Player player) { }
		public virtual void Save(Player player) { }
		public virtual void PostItemCheck(Player player, Mod mod) { }
		public virtual void ProcessTriggers(Player player, Mod mod) { }
		public virtual void PreUpdate(Player player, Mod mod) { }
		public virtual void ModifyDrawInfo(Player player, Mod mod, ref PlayerDrawInfo drawInfo) { }
        public virtual void ModifyDrawLayers(Player player, List<PlayerLayer> layers) { }
		public virtual void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns) { }
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
