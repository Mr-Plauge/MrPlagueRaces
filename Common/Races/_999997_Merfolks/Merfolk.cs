using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MrPlagueRaces.Common.Races._999997_Merfolks
{
	public class Merfolk : Race
	{
        public override int? LegacyId => 5;
		public override string RaceEnvironmentIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/Environment/Environment_Ocean");
		public override string RaceSelectIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/MerfolkSelect");
		public override string RaceDisplayMaleIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/MerfolkDisplayMale");
        public override string RaceDisplayFemaleIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/MerfolkDisplayFemale");

		public override string RaceLore1 => "A race native to the ocean depths, having migrated to shores in recent times.";
		public override string RaceLore2 => "Although they are primarily built for living in water, Merfolk are also capable of traversing land.";
		public override string RaceAbilityName => "";
		public override string RaceAbilityDescription => "";
		public override string RaceAdditionalNotesDescription => "-Can breathe underwanter" +
		                                                         "\n-Unhindered by water" +
		                                                         "\n-Can swim in water" +
																 "\n-Attack Damage increases by [c/34EB93:+25%] in water" +
		                                                         "\n-Can't breathe on land";
		public override bool UsesCustomHurtSound => true;

		public override string RaceHealthDisplayText => "";
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
		public override string RaceMinionsDisplayText => "";
		public override string RaceSentriesDisplayText => "";
		public override string RaceMeleeCritChanceDisplayText => "";
		public override string RaceRangedCritChanceDisplayText => "";
		public override string RaceMagicCritChanceDisplayText => "";
		public override string RaceMiningSpeedDisplayText => "[c/34EB93:+10%]";
		public override string RaceBuildingSpeedDisplayText => "[c/34EB93:+25%]";
        public override string RaceBuildingWallSpeedDisplayText => "[c/34EB93:+25%]";
		public override string RaceBuildingRangeDisplayText => "[c/34EB93:+1]";
		public override string RaceArrowDamageDisplayText => "";
		public override string RaceMovementSpeedDisplayText => "";
		public override string RaceJumpSpeedDisplayText => "";
        public override string RaceFallDamageResistanceDisplayText => "";
		public override string RaceAllDamageDisplayText => "";
		public override string RaceFishingSkillDisplayText => "";
		public override string RaceAggroDisplayText => "";
		public override string RaceRunSpeedDisplayText => "";
        public override string RaceRunAccelerationDisplayText => "";

		public override string RaceGoodBiomesDisplayText => "Ocean";
		public override string RaceBadBiomesDisplayText => "None";

		public int merfolkBreathHurt;
		public int merfolkBreathControl = 7;
		public int merfolkBreathControl2 = 200;

		public override bool PreHurt(Player player, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{

			return true;
		}

		public override void PostItemCheck(Player player, Mod mod)
		{
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();
			if (!modPlayer.GotRaceItems)
			{
				player.QuickSpawnItem(mod.ItemType("Merfolk_Water_Generator"));
			}
		}

		public override void ResetEffects(Player player)
		{
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();
			if (modPlayer.RaceStats)
			{
				if (player.wet)
				{
					player.allDamage += 0.25f;
				}
				player.blockRange += 1;
				player.tileSpeed += 0.25f;
				player.wallSpeed += 0.25f;
				player.pickSpeed -= 0.1f;
				player.ignoreWater = true;
				player.merman = false;
				player.gills = false;
				player.accFlipper = true;
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
				if (player.dead)
				{
					merfolkBreathControl = 0;
					merfolkBreathControl2 = 200;
				}
				if (Collision.DrownCollision(player.position, player.width, player.height, player.gravDir) || player.armor[0].type == ItemID.FishBowl || Main.raining && modPlayer.ExposedToSky())
				{
					merfolkBreathControl = 0;
					if (merfolkBreathControl2 < 200)
					{
						merfolkBreathControl2 += 3;
					}
					if (merfolkBreathControl2 > 200)
					{
						merfolkBreathControl2 = 200;
					}
					player.breath = (merfolkBreathControl2 + 2);
					merfolkBreathHurt = 0;
				}
				else
				{
					merfolkBreathControl += 1;
					if (merfolkBreathControl >= 7)
					{
						merfolkBreathControl2 -= 1;
						merfolkBreathControl = 0;
					}
					player.breath = (merfolkBreathControl2 - 2);
				}
				if (player.breath == 0)
				{
					Main.PlaySound(SoundID.Drown, -1, -1, 1, 1f, 0f);
				}
				if (player.breath <= 0)
				{
					player.lifeRegenTime = 0;
					player.breath = 0;
					merfolkBreathHurt += 1;
					if (merfolkBreathHurt >= 7)
					{
						player.statLife -= 2;
						merfolkBreathHurt = 0;
					}
					if (player.statLife <= 0)
					{
						player.statLife = 0;
						switch (Main.rand.Next(8))
						{
							case 0:
								player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " is sleeping with the air-breathers."), 10.0, 0, false);
								break;
							case 1:
								player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " didn't make it to the water."), 10.0, 0, false);
								break;
							case 2:
								player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " was out of their element."), 10.0, 0, false);
								break;
							case 3:
								player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " suffocated."), 10.0, 0, false);
								break;
							case 4:
								player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " couldn't breathe."), 10.0, 0, false);
								break;
							case 5:
								player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " is food for the land dwellers."), 10.0, 0, false);
								break;
							case 6:
								player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " tried breathing air."), 10.0, 0, false);
								break;
							default:
								player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " had gills instead of lungs."), 10.0, 0, false);
								break;
						}
					}
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
			if (!modPlayer.IsNewCharacter1)
			{
				player.skinColor = new Color(player.skinColor.R + 40, player.skinColor.G + 40, player.skinColor.B + 40);
			}
            if (!modPlayer.IsNewCharacter1)
            {
                modPlayer.IsNewCharacter1 = true;
            }
			if (!modPlayer.IsNewCharacter2)
			{
				modPlayer.IsNewCharacter2 = true;
			}
			if (modPlayer.resetDefaultColors && Main.gameMenu)
			{
				modPlayer.resetDefaultColors = false;
				player.hairColor = new Color(94, 236, 135);
				player.skinColor = new Color(94, 236, 135);
				player.eyeColor = new Color(251, 57, 135);
				player.skinVariant = 0;
			}
			if (modPlayer.RaceStats)
			{
				if (Collision.DrownCollision(player.position, player.width, player.height, player.gravDir))
				{
					player.headRotation = player.velocity.Y * (float)player.direction * 0.1f;
					if ((double)player.headRotation < -0.3)
					{
						player.headRotation = -0.3f;
					}
					if ((double)player.headRotation > 0.3)
					{
						player.headRotation = 0.3f;
					}
				}
			}
		}

		public override void ModifyDrawLayers(Player player, List<PlayerLayer> layers)
		{
			//applying the racial textures
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();

			bool hideChestplate = modPlayer.hideChestplate;
			bool hideLeggings = modPlayer.hideLeggings;

			modPlayer.updatePlayerSprites("MrPlagueRaces/Content/RaceTextures/", "MrPlagueRaces/Content/RaceTextures/Merfolk/", hideChestplate, hideLeggings, 0, 0, "Merfolk", false);

		}
	}
}
