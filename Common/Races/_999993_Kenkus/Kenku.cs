using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MrPlagueRaces.Common.Races._999993_Kenkus
{
	public class Kenku : Race
	{
        public override int? LegacyId => 2;
		public override string RaceSelectIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/KenkuSelect");
		public override string RaceDisplayMaleIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/KenkuDisplayMale");
        public override string RaceDisplayFemaleIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/KenkuDisplayFemale");

		public override string RaceLore1 => "A bird-like race, well known for their agility and uncanny precision.";
		public override string RaceLore2 => "Kenku culture was influenced by the steampunk fad, likely having been introduced by Humans.";
		public override string RaceAbilityName => "";
		public override string RaceAbilityDescription => "";
		public override string RaceAdditionalNotesDescription => "-Can fly short distances without wings";
		public override bool UsesCustomHurtSound => true;
		public override bool UsesCustomDeathSound => true;

		public override string RaceHealthDisplayText => "[c/FF4F64:-20%]";
		public override string RaceRegenerationDisplayText => "";
		public override string RaceManaDisplayText => "";
		public override string RaceManaRegenerationDisplayText => "";
		public override string RaceDefenseDisplayText => "[c/FF4F64:-8]";
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
		public override string RaceMeleeCritChanceDisplayText => "[c/34EB93:+10]";
		public override string RaceRangedCritChanceDisplayText => "[c/34EB93:+10]";
		public override string RaceMagicCritChanceDisplayText => "[c/34EB93:+10]";
		public override string RaceMiningSpeedDisplayText => "";
		public override string RaceBuildingSpeedDisplayText => "";
        public override string RaceBuildingWallSpeedDisplayText => "";
		public override string RaceBuildingRangeDisplayText => "";
		public override string RaceArrowDamageDisplayText => "";
		public override string RaceMovementSpeedDisplayText => "";
		public override string RaceJumpSpeedDisplayText => "";
        public override string RaceFallDamageResistanceDisplayText => "";
		public override string RaceAllDamageDisplayText => "[c/34EB93:+15%]";
		public override string RaceFishingSkillDisplayText => "";
		public override string RaceAggroDisplayText => "";
		public override string RaceRunSpeedDisplayText => "";
        public override string RaceRunAccelerationDisplayText => "";

		public override string RaceGoodBiomesDisplayText => "None";
		public override string RaceBadBiomesDisplayText => "None";

		public int kenkuWingAnim;
		public int kenkuWingFrame;
		public int kenkuWingTime = 40;
		public int kenkuFallDamagePrevention;

		public override bool PreHurt(Player player, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{

			return true;
		}

		public override bool PreKill(Player player, Mod mod, double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/" + this.Name + "_Killed"));
			return true;
		}

		public override void ResetEffects(Player player)
		{
            var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();
			if (modPlayer.RaceStats)
			{
				player.statLifeMax2 -= (player.statLifeMax2 / 5);
				player.statDefense -= 8;
				player.allDamage += 0.15f;
				player.magicCrit += 10;
				player.rangedCrit += 10;
				player.meleeCrit += 10;
				player.moveSpeed += 0.25f;
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
				player.wingTimeMax += 100;
				if ((player.wingsLogic == 0) && player.velocity.Y != 0 && (kenkuWingTime > 0))
				{
					if (player.controlJump)
					{
						if (player.velocity.Y != 0)
						{
							if (!(player.velocity.Y < -5))
							{
								player.velocity.Y -= 1;
							}
							kenkuWingTime -= 1;
						}
					}
				}
				if (player.velocity.Y == 0 && !player.mount._active)
				{
					kenkuWingTime = 40;
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
				player.eyeColor = new Color(player.eyeColor.R - 250, player.eyeColor.G - 250, player.eyeColor.B - 250);
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
			if (modPlayer.resetDefaultColors)
			{
				modPlayer.resetDefaultColors = false;
				player.hairColor = new Color(146, 137, 220);
				player.skinColor = new Color(176, 167, 250);
				player.eyeColor = new Color(105, 41, 12);
				player.shirtColor = new Color(201, 162, 162);
				player.underShirtColor = new Color(158, 85, 105);
				player.skinVariant = 0;
				if (player.armor[1].type < ItemID.IronPickaxe)
				{
					player.armor[1] = familiarshirt;
				}
			}
            if (modPlayer.RaceStats)
            {
                if (kenkuFallDamagePrevention < 0)
                {
                    kenkuFallDamagePrevention = 0;
                }
                if (player.wingsLogic == 0 && !player.mount.Active)
                {
                    player.wings = 0;
                    if (player.controlJump)
                    {
                        kenkuFallDamagePrevention = 2;
                        if (player.velocity.Y < 0)
                        {
                            kenkuWingAnim += 1;
                            if ((kenkuWingAnim >= 0) && (kenkuWingAnim < 6))
                            {
                                if (!(player.itemAnimation > 0))
                                {
                                    player.bodyFrame.Y = player.bodyFrame.Height * 6;
                                }
                                kenkuWingFrame = 1;
                            }
                            if ((kenkuWingAnim >= 6) && (kenkuWingAnim < 12))
                            {
                                if (!(player.itemAnimation > 0))
                                {
                                    player.bodyFrame.Y = player.bodyFrame.Height * 6;
                                }
                                kenkuWingFrame = 2;
                            }
                            if ((kenkuWingAnim >= 12) && (kenkuWingAnim < 18))
                            {
                                if (!(player.itemAnimation > 0))
                                {
                                    player.bodyFrame.Y = player.bodyFrame.Height * 6;
                                }
                                kenkuWingFrame = 3;
                            }
                            if ((kenkuWingAnim >= 18) && (kenkuWingAnim < 24))
                            {
                                if (!(player.itemAnimation > 0))
                                {
                                    player.bodyFrame.Y = player.bodyFrame.Height * 6;
                                }
                                kenkuWingFrame = 4;
                                kenkuWingAnim = 0;
                                if (!player.dead)
                                {
                                    Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Wing_Flap"));
                                }
                            }
                        }
                        else if (player.velocity.Y > 0)
                        {
                            if (!(player.itemAnimation > 0))
                            {
                                player.bodyFrame.Y = player.bodyFrame.Height * 6;
                            }
                            kenkuWingAnim = 0;
                            kenkuWingFrame = 3;
                        }
                        else
                        {
                            kenkuWingAnim = 0;
                            kenkuWingFrame = -1;
                        }
                    }
                    else
                    {
                        kenkuWingAnim = 0;
                        kenkuWingFrame = -1;
                    }
                    if (player.velocity.Y == 0)
                    {
                        kenkuFallDamagePrevention -= 1;
                    }
                }
                if (kenkuFallDamagePrevention > 0)
                {
                    player.noFallDmg = true;
                }
            }
			else if (!modPlayer.RaceStats)
            {
                kenkuWingAnim = 0;
				kenkuWingFrame = 0;
			}
		}

		public override void ModifyDrawLayers(Player player, List<PlayerLayer> layers)
		{
			//applying the racial textures
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();

			bool hideChestplate = modPlayer.hideChestplate;
			bool hideLeggings = modPlayer.hideLeggings;

			modPlayer.updatePlayerSprites("MrPlagueRaces/Content/RaceTextures/", "MrPlagueRaces/Content/RaceTextures/Kenku/", hideChestplate, hideLeggings, 0, 0, "Kenku", false);

		}
	}
}
