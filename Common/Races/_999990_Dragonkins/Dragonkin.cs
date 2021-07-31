using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MrPlagueRaces.Common.Races._999990_Dragonkins
{
	public class Dragonkin : Race
	{
        public override int? LegacyId => 4;
		public override string RaceEnvironmentIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/Environment/Environment_Desert");
		public override string RaceSelectIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/DragonkinSelect");
		public override string RaceDisplayMaleIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/DragonkinDisplayMale");
        public override string RaceDisplayFemaleIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/DragonkinDisplayFemale");

		public override string RaceLore1 => "Built for living in arid environments, the Dragonkin have high endurances.";
		public override string RaceLore2 => "Their culture heavily favors their warriors, with the weak and timid often being treated poorly.";
		public override string RaceAbilityName => "";
		public override string RaceAbilityDescription => "";
		public override string RaceAdditionalNotesDescription => "";
		public override bool UsesCustomHurtSound => true;
        public override bool HasFemaleHurtSound => true;

		public override string RaceHealthDisplayText => "[c/34EB93:+20%]";
		public override string RaceRegenerationDisplayText => "";
		public override string RaceManaDisplayText => "";
		public override string RaceManaRegenerationDisplayText => "";
		public override string RaceDefenseDisplayText => "[c/34EB93:+8]";
		public override string RaceDamageReductionDisplayText => "";
		public override string RaceThornsDisplayText => "";
		public override string RaceLavaResistanceDisplayText => "[c/34EB93:+60]";
		public override string RaceMeleeDamageDisplayText => "[c/34EB93:+10%]";
		public override string RaceRangedDamageDisplayText => "";
		public override string RaceMagicDamageDisplayText => "";
		public override string RaceSummonDamageDisplayText => "";
		public override string RaceMeleeSpeedDisplayText => "";
		public override string RaceArmorPenetrationDisplayText => "";
		public override string RaceBulletDamageDisplayText => "";
		public override string RaceRocketDamageDisplayText => "";
		public override string RaceManaCostDisplayText => "";
		public override string RaceMinionKnockbackDisplayText => "";
		public override string RaceMinionsDisplayText => "";
		public override string RaceSentriesDisplayText => "";
		public override string RaceMeleeCritChanceDisplayText => "";
		public override string RaceRangedCritChanceDisplayText => "";
		public override string RaceMagicCritChanceDisplayText => "";
		public override string RaceMiningSpeedDisplayText => "[c/FF4F64:-20%]";
		public override string RaceBuildingSpeedDisplayText => "[c/FF4F64:-10%]";
        public override string RaceBuildingWallSpeedDisplayText => "[c/FF4F64:-10%]";
		public override string RaceBuildingRangeDisplayText => "";
		public override string RaceArrowDamageDisplayText => "";
		public override string RaceMovementSpeedDisplayText => "";
		public override string RaceJumpSpeedDisplayText => "[c/FF4F64:-10%]";
        public override string RaceFallDamageResistanceDisplayText => "";
		public override string RaceAllDamageDisplayText => "";
		public override string RaceFishingSkillDisplayText => "";
		public override string RaceAggroDisplayText => "";
		public override string RaceRunSpeedDisplayText => "";
        public override string RaceRunAccelerationDisplayText => "";

		public override string RaceGoodBiomesDisplayText => "Desert";
		public override string RaceBadBiomesDisplayText => "Tundra";

		public override bool PreHurt(Player player, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{

			return true;
		}

		public override void Load(Player player) 
		{
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();
			if (modPlayer.RaceStats)
			{
				player.statLife += (player.statLifeMax2 / 5);
			}
		}

		public override void ResetEffects(Player player)
		{
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();
			if (modPlayer.RaceStats)
			{
				player.statLifeMax2 += (player.statLifeMax2 / 5);
				player.statDefense += 8;
				player.meleeDamage += 0.1f;
				player.pickSpeed += 0.2f;
				player.tileSpeed -= 0.1f;
				player.wallSpeed -= 0.1f;
				player.jumpSpeedBoost -= 0.1f;
				if (player.lavaMax == 0)
				{
					player.lavaMax += 60;
				}
				player.fireWalk = true;
			}
		}

		public override void PreUpdate(Player player, Mod mod)
		{
            var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();
			if (player.HasBuff(mod.BuffType("DetectHurt")) && (player.statLife != player.statLifeMax2))
			{
				if (player.Male || !HasFemaleHurtSound)
				{
					Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/" + this.Name + "_Hurt"));
				}
				else if (!player.Male && HasFemaleHurtSound)
				{
					Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/" + this.Name + "_Hurt_Female"));
				}
				else
				{
					Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Mushfolk_Hurt"));
				}
			}
			if (modPlayer.RaceStats)
			{
				player.buffImmune[24] = true;
				player.buffImmune[39] = true;
				player.buffImmune[153] = true;
				player.buffImmune[67] = true;

			}
		}

		public override void ModifyDrawInfo(Player player, Mod mod, ref PlayerDrawInfo drawInfo)
		{
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();
			Item familiarshirt = new Item();
			familiarshirt.SetDefaults(ItemID.FamiliarShirt);

			Item familiarpants = new Item();
			familiarpants.SetDefaults(ItemID.FamiliarPants);
			if (!modPlayer.IsNewCharacter1)
			{
				player.skinColor = new Color(player.skinColor.R + 60, player.skinColor.G + 60, player.skinColor.B + 60);
			}
            if (!modPlayer.IsNewCharacter1)
            {
                modPlayer.IsNewCharacter1 = true;
            }
			if (!modPlayer.IsNewCharacter2)
			{
				modPlayer.IsNewCharacter2 = true;
			}
			if (modPlayer.resetDefaultColors)
			{
				modPlayer.resetDefaultColors = false;
				player.hairColor = new Color(175, 163, 147);
				player.skinColor = new Color(202, 255, 208);
				player.eyeColor = new Color(255, 180, 92);
				player.shirtColor = new Color(119, 115, 157);
				player.underShirtColor = new Color(216, 156, 95);
				player.skinVariant = 8;
				if (player.armor[1].type < ItemID.IronPickaxe && player.armor[2].type < ItemID.IronPickaxe)
				{
					player.armor[1] = familiarshirt;
					player.armor[2] = familiarpants;
				}
			}
		}

		public override void ModifyDrawLayers(Player player, List<PlayerLayer> layers)
		{
			//applying the racial textures
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();

			bool hideChestplate = modPlayer.hideChestplate;
			bool hideLeggings = modPlayer.hideLeggings;

			modPlayer.updatePlayerSprites("MrPlagueRaces/Content/RaceTextures/", "MrPlagueRaces/Content/RaceTextures/Dragonkin/", hideChestplate, hideLeggings, 51, 0, "Dragonkin", false);

		}
	}
}
