using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MrPlagueRaces.Common.Races._999998_Goblins
{
	public class Goblin : Race
	{
		public override int? LegacyId => 1;
		public override string RaceSelectIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/GoblinSelect");
		public override string RaceDisplayMaleIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/GoblinDisplayMale");
        public override string RaceDisplayFemaleIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/GoblinDisplayFemale");

		public override string RaceLore1 => "A race composed of traveling colonies, infamous for raiding and pillaging.";
		public override string RaceLore2 => "Goblins are incredibly intelligent, although their barbaric ways make many assume otherwise.";
		public override string RaceAbilityName => "";
		public override string RaceAbilityDescription => "";
		public override string RaceAdditionalNotesDescription => "";
		public override bool UsesCustomHurtSound => true;
        public override bool HasFemaleHurtSound => true;

		public override string RaceHealthDisplayText => "[c/FF4F64:-20%]";
		public override string RaceRegenerationDisplayText => "";
		public override string RaceManaDisplayText => "";
		public override string RaceManaRegenerationDisplayText => "";
		public override string RaceDefenseDisplayText => "";
		public override string RaceDamageReductionDisplayText => "";
		public override string RaceThornsDisplayText => "";
		public override string RaceLavaResistanceDisplayText => "";
		public override string RaceMeleeDamageDisplayText => "";
		public override string RaceRangedDamageDisplayText => "";
		public override string RaceMagicDamageDisplayText => "";
		public override string RaceSummonDamageDisplayText => "";
		public override string RaceMeleeSpeedDisplayText => "";
		public override string RaceArmorPenetrationDisplayText => "";
		public override string RaceBulletDamageDisplayText => "";
		public override string RaceRocketDamageDisplayText => "";
		public override string RaceManaCostDisplayText => "";
		public override string RaceMinionKnockbackDisplayText => "";
		public override string RaceMinionsDisplayText => "[c/34EB93:+1]";
		public override string RaceSentriesDisplayText => "[c/34EB93:+1]";
		public override string RaceMeleeCritChanceDisplayText => "";
		public override string RaceRangedCritChanceDisplayText => "";
		public override string RaceMagicCritChanceDisplayText => "";
		public override string RaceMiningSpeedDisplayText => "[c/34EB93:+10%]";
		public override string RaceBuildingSpeedDisplayText => "[c/34EB93:+10%]";
        public override string RaceBuildingWallSpeedDisplayText => "[c/34EB93:+10%]";
		public override string RaceBuildingRangeDisplayText => "";
		public override string RaceArrowDamageDisplayText => "";
		public override string RaceMovementSpeedDisplayText => "[c/34EB93:+10%]";
		public override string RaceJumpSpeedDisplayText => "";
        public override string RaceFallDamageResistanceDisplayText => "";
		public override string RaceAllDamageDisplayText => "[c/FF4F64:-10%]";
		public override string RaceFishingSkillDisplayText => "";
		public override string RaceAggroDisplayText => "";
		public override string RaceRunSpeedDisplayText => "";
        public override string RaceRunAccelerationDisplayText => "";

		public override string RaceGoodBiomesDisplayText => "None";
		public override string RaceBadBiomesDisplayText => "None";

		public override bool PreHurt(Player player, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{

			return true;
		}

		public override void ResetEffects(Player player)
		{
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();
			if (modPlayer.RaceStats)
			{
				player.statLifeMax2 -= (player.statLifeMax2 / 5);
				player.allDamage -= 0.1f;
				player.maxMinions += 1;
				player.maxTurrets += 1;
				player.moveSpeed += 0.1f;
				player.tileSpeed += 0.1f;
				player.wallSpeed += 0.1f;
				player.pickSpeed -= 0.1f;
			}
		}

		public override void PreUpdate(Player player, Mod mod)
		{
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
		}

		public override void ModifyDrawInfo(Player player, Mod mod, ref PlayerDrawInfo drawInfo)
		{
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();
			Item familiarshirt = new Item();
			familiarshirt.SetDefaults(ItemID.FamiliarShirt);

			Item familiarpants = new Item();
            familiarpants.SetDefaults(ItemID.FamiliarPants);
			if (!modPlayer.IsNewCharacter2)
			{
				player.skinColor = new Color(player.skinColor.R + 70, player.skinColor.G + 70, player.skinColor.B + 70);
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
				player.hairColor = new Color(58, 61, 53);
				player.skinColor = new Color(182, 215, 126);
				player.eyeColor = new Color(112, 42, 36);
				player.underShirtColor = new Color(150, 107, 112);
				player.pantsColor = new Color(104, 127, 148);
				player.shoeColor = new Color(110, 93, 89);
				player.skinVariant = 2;
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

			modPlayer.updatePlayerSprites("MrPlagueRaces/Content/RaceTextures/", "MrPlagueRaces/Content/RaceTextures/Goblin/", hideChestplate, hideLeggings, 0, 0, "Goblin", true);

		}
	}
}
