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

		public override string RaceLore1 => "A bird-like race," + "\nwell known for their" + "\nagility and uncanny" + "\nprecision.";
		public override string RaceLore2 => "Kenku culture was influenced by" + "\nthe steampunk fad, likely having" + "\nbeen introduced by Humans.";
		public override string RaceAbilityName => "";
		public override string RaceAbilityDescription1 => "";
		public override string RaceAbilityDescription2 => "";
		public override string RaceAbilityDescription3 => "";
		public override string RaceAbilityDescription4 => "";
		public override string RaceAbilityDescription5 => "";
		public override string RaceAbilityDescription6 => "";
		public override string RaceAdditionalNotesDescription1 => "-Can fly short distances without wings";
		public override string RaceAdditionalNotesDescription2 => "";
		public override string RaceAdditionalNotesDescription3 => "";
		public override string RaceAdditionalNotesDescription4 => "";
		public override string RaceAdditionalNotesDescription5 => "";
		public override string RaceAdditionalNotesDescription6 => "";
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
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();

			bool hideChestplate = modPlayer.hideChestplate;
			bool hideLeggings = modPlayer.hideLeggings;

			Main.playerTextures[0, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Head");
			Main.playerTextures[0, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Eyes_2");
			Main.playerTextures[0, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Eyes");

			if (kenkuWingFrame == -1)
			{
				Main.playerTextures[0, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso");
			}
			if (kenkuWingFrame == 0)
			{
				Main.playerTextures[0, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso");
			}
			if (kenkuWingFrame == 1)
			{
				Main.playerTextures[0, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_1");
			}
			if (kenkuWingFrame == 2)
			{
				Main.playerTextures[0, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_2");
			}
			if (kenkuWingFrame == 3)
			{
				Main.playerTextures[0, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_3");
			}
			if (kenkuWingFrame == 4)
			{
				Main.playerTextures[0, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_4");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[0, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_1");
			}
			else
			{
				Main.playerTextures[0, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[0, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[0, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Shirt_1");
			}
			else
			{
				Main.playerTextures[0, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[0, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[0, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_1");
			}
			else
			{
				Main.playerTextures[0, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[0, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Hand");
			Main.playerTextures[0, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[0, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_1");
				Main.playerTextures[0, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_1");
			}
			else
			{
				Main.playerTextures[0, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[0, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[0, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_1_2");
			}
			else
			{
				Main.playerTextures[0, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[0, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_1_2");
			}
			else
			{
				Main.playerTextures[0, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[1, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Head");
			Main.playerTextures[1, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Eyes_2");

			if (kenkuWingFrame == -1)
			{
				Main.playerTextures[1, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso");
			}
			if (kenkuWingFrame == 0)
			{
				Main.playerTextures[1, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso");
			}
			if (kenkuWingFrame == 1)
			{
				Main.playerTextures[1, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_1");
			}
			if (kenkuWingFrame == 2)
			{
				Main.playerTextures[1, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_2");
			}
			if (kenkuWingFrame == 3)
			{
				Main.playerTextures[1, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_3");
			}
			if (kenkuWingFrame == 4)
			{
				Main.playerTextures[1, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_4");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[1, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Sleeves_2");
			}
			else
			{
				Main.playerTextures[1, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[1, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[1, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_2");
			}
			else
			{
				Main.playerTextures[1, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[1, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[1, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_2");
			}
			else
			{
				Main.playerTextures[1, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[1, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Hand");
			Main.playerTextures[1, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[1, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_2");
				Main.playerTextures[1, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_2");
			}
			else
			{
				Main.playerTextures[1, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[1, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[1, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_2_2");
			}
			else
			{
				Main.playerTextures[1, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[1, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_2_2");
			}
			else
			{
				Main.playerTextures[1, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[2, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Head");
			Main.playerTextures[2, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Eyes_2");
			Main.playerTextures[2, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Eyes");

			if (kenkuWingFrame == -1)
			{
				Main.playerTextures[2, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso");
			}
			if (kenkuWingFrame == 0)
			{
				Main.playerTextures[2, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso");
			}
			if (kenkuWingFrame == 1)
			{
				Main.playerTextures[2, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_1");
			}
			if (kenkuWingFrame == 2)
			{
				Main.playerTextures[2, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_2");
			}
			if (kenkuWingFrame == 3)
			{
				Main.playerTextures[2, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_3");
			}
			if (kenkuWingFrame == 4)
			{
				Main.playerTextures[2, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_4");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[2, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Sleeves_3");
			}
			else
			{
				Main.playerTextures[2, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[2, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[2, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_3");
			}
			else
			{
				Main.playerTextures[2, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[2, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[2, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_3");
			}
			else
			{
				Main.playerTextures[2, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[2, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Hand");
			Main.playerTextures[2, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[2, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_3");
				Main.playerTextures[2, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_3");
			}
			else
			{
				Main.playerTextures[2, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[2, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[2, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_3_2");
			}
			else
			{
				Main.playerTextures[2, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[2, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_3_2");
			}
			else
			{
				Main.playerTextures[2, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[3, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Head");
			Main.playerTextures[3, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Eyes_2");
			Main.playerTextures[3, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Eyes");

			if (kenkuWingFrame == -1)
			{
				Main.playerTextures[3, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso");
			}
			if (kenkuWingFrame == 0)
			{
				Main.playerTextures[3, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso");
			}
			if (kenkuWingFrame == 1)
			{
				Main.playerTextures[3, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_1");
			}
			if (kenkuWingFrame == 2)
			{
				Main.playerTextures[3, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_2");
			}
			if (kenkuWingFrame == 3)
			{
				Main.playerTextures[3, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_3");
			}
			if (kenkuWingFrame == 4)
			{
				Main.playerTextures[3, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_4");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[3, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_4");
			}
			else
			{
				Main.playerTextures[3, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[3, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[3, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Shirt_4");
			}
			else
			{
				Main.playerTextures[3, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[3, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[3, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_4");
			}
			else
			{
				Main.playerTextures[3, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[3, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Hand");
			Main.playerTextures[3, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[3, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_4");
				Main.playerTextures[3, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_4");
			}
			else
			{
				Main.playerTextures[3, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[3, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[3, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_4_2");
			}
			else
			{
				Main.playerTextures[3, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[3, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_4_2");
			}
			else
			{
				Main.playerTextures[3, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[8, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Head");
			Main.playerTextures[8, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Eyes_2");
			Main.playerTextures[8, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Eyes");

			if (kenkuWingFrame == -1)
			{
				Main.playerTextures[8, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso");
			}
			if (kenkuWingFrame == 0)
			{
				Main.playerTextures[8, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso");
			}
			if (kenkuWingFrame == 1)
			{
				Main.playerTextures[8, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_1");
			}
			if (kenkuWingFrame == 2)
			{
				Main.playerTextures[8, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_2");
			}
			if (kenkuWingFrame == 3)
			{
				Main.playerTextures[8, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_3");
			}
			if (kenkuWingFrame == 4)
			{
				Main.playerTextures[8, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_4");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[8, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Sleeves_9");
			}
			else
			{
				Main.playerTextures[8, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[8, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[8, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_9");
			}
			else
			{
				Main.playerTextures[8, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[8, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[8, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_9");
			}
			else
			{
				Main.playerTextures[8, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[8, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Hand");
			Main.playerTextures[8, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[8, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_9");
				Main.playerTextures[8, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_9");
			}
			else
			{
				Main.playerTextures[8, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[8, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[8, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_9_2");
			}
			else
			{
				Main.playerTextures[8, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[8, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_9_2");
			}
			else
			{
				Main.playerTextures[8, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[4, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Head_Female");
			Main.playerTextures[4, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Eyes_2_Female");
			Main.playerTextures[4, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Eyes_Female");

			if (kenkuWingFrame == -1)
			{
				Main.playerTextures[4, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Female");
			}
			if (kenkuWingFrame == 0)
			{
				Main.playerTextures[4, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Female");
			}
			if (kenkuWingFrame == 1)
			{
				Main.playerTextures[4, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_1_Female");
			}
			if (kenkuWingFrame == 2)
			{
				Main.playerTextures[4, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_2_Female");
			}
			if (kenkuWingFrame == 3)
			{
				Main.playerTextures[4, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_3_Female");
			}
			if (kenkuWingFrame == 4)
			{
				Main.playerTextures[4, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_4_Female");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[4, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_5");
			}
			else
			{
				Main.playerTextures[4, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[4, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Hands_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[4, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Shirt_5");
			}
			else
			{
				Main.playerTextures[4, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[4, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Arm_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[4, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_5");
			}
			else
			{
				Main.playerTextures[4, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[4, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Hand_Female");
			Main.playerTextures[4, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Legs_Female");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[4, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_5");
				Main.playerTextures[4, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_5");
			}
			else
			{
				Main.playerTextures[4, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[4, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[4, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_5_2");
			}
			else
			{
				Main.playerTextures[4, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[4, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_5_2");
			}
			else
			{
				Main.playerTextures[4, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[5, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Head_Female");
			Main.playerTextures[5, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Eyes_2_Female");
			Main.playerTextures[5, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Eyes_Female");

			if (kenkuWingFrame == -1)
			{
				Main.playerTextures[5, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Female");
			}
			if (kenkuWingFrame == 0)
			{
				Main.playerTextures[5, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Female");
			}
			if (kenkuWingFrame == 1)
			{
				Main.playerTextures[5, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_1_Female");
			}
			if (kenkuWingFrame == 2)
			{
				Main.playerTextures[5, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_2_Female");
			}
			if (kenkuWingFrame == 3)
			{
				Main.playerTextures[5, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_3_Female");
			}
			if (kenkuWingFrame == 4)
			{
				Main.playerTextures[5, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_4_Female");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[5, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Sleeves_6");
			}
			else
			{
				Main.playerTextures[5, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[5, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Hands_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[5, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_6");
			}
			else
			{
				Main.playerTextures[5, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[5, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Arm_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[5, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_6");
			}
			else
			{
				Main.playerTextures[5, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[5, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Hand_Female");
			Main.playerTextures[5, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Legs_Female");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[5, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_6");
				Main.playerTextures[5, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_6");
			}
			else
			{
				Main.playerTextures[5, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[5, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[5, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_6_2");
			}
			else
			{
				Main.playerTextures[5, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[5, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_6_2");
			}
			else
			{
				Main.playerTextures[5, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[6, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Head_Female");
			Main.playerTextures[6, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Eyes_2_Female");
			Main.playerTextures[6, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Eyes_Female");

			if (kenkuWingFrame == -1)
			{
				Main.playerTextures[6, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Female");
			}
			if (kenkuWingFrame == 0)
			{
				Main.playerTextures[6, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Female");
			}
			if (kenkuWingFrame == 1)
			{
				Main.playerTextures[6, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_1_Female");
			}
			if (kenkuWingFrame == 2)
			{
				Main.playerTextures[6, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_2_Female");
			}
			if (kenkuWingFrame == 3)
			{
				Main.playerTextures[6, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_3_Female");
			}
			if (kenkuWingFrame == 4)
			{
				Main.playerTextures[6, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_4_Female");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[6, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Sleeves_7");
			}
			else
			{
				Main.playerTextures[6, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[6, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Hands_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[6, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_7");
			}
			else
			{
				Main.playerTextures[6, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[6, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Arm_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[6, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_7");
			}
			else
			{
				Main.playerTextures[6, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[6, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Hand_Female");
			Main.playerTextures[6, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Legs_Female");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[6, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_7");
				Main.playerTextures[6, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_7");
			}
			else
			{
				Main.playerTextures[6, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[6, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[6, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_7_2");
			}
			else
			{
				Main.playerTextures[6, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[6, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_7_2");
			}
			else
			{
				Main.playerTextures[6, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[7, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Head_Female");
			Main.playerTextures[7, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Eyes_2_Female");
			Main.playerTextures[7, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Eyes_Female");

			if (kenkuWingFrame == -1)
			{
				Main.playerTextures[7, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Female");
			}
			if (kenkuWingFrame == 0)
			{
				Main.playerTextures[7, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Female");
			}
			if (kenkuWingFrame == 1)
			{
				Main.playerTextures[7, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_1_Female");
			}
			if (kenkuWingFrame == 2)
			{
				Main.playerTextures[7, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_2_Female");
			}
			if (kenkuWingFrame == 3)
			{
				Main.playerTextures[7, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_3_Female");
			}
			if (kenkuWingFrame == 4)
			{
				Main.playerTextures[7, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_4_Female");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[7, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_8");
			}
			else
			{
				Main.playerTextures[7, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[7, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Hands_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[7, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Shirt_8");
			}
			else
			{
				Main.playerTextures[7, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[7, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Arm_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[7, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_8");
			}
			else
			{
				Main.playerTextures[7, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[7, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Hand_Female");
			Main.playerTextures[7, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Legs_Female");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[7, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_8");
				Main.playerTextures[7, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_8");
			}
			else
			{
				Main.playerTextures[7, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[7, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[7, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_8_2");
			}
			else
			{
				Main.playerTextures[7, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[7, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_8_2");
			}
			else
			{
				Main.playerTextures[7, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[9, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Head_Female");
			Main.playerTextures[9, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Eyes_2_Female");
			Main.playerTextures[9, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Eyes_Female");

			if (kenkuWingFrame == -1)
			{
				Main.playerTextures[9, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Female");
			}
			if (kenkuWingFrame == 0)
			{
				Main.playerTextures[9, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Female");
			}
			if (kenkuWingFrame == 1)
			{
				Main.playerTextures[9, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_1_Female");
			}
			if (kenkuWingFrame == 2)
			{
				Main.playerTextures[9, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_2_Female");
			}
			if (kenkuWingFrame == 3)
			{
				Main.playerTextures[9, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_3_Female");
			}
			if (kenkuWingFrame == 4)
			{
				Main.playerTextures[9, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Torso_Flight_4_Female");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[9, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Sleeves_10");
			}
			else
			{
				Main.playerTextures[9, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[9, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Hands_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[9, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_10");
			}
			else
			{
				Main.playerTextures[9, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[9, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Arm_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[9, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_10");
			}
			else
			{
				Main.playerTextures[9, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[9, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Hand_Female");
			Main.playerTextures[9, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Legs_Female");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[9, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_10");
				Main.playerTextures[9, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_10");
			}
			else
			{
				Main.playerTextures[9, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[9, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[9, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_10_2");
			}
			else
			{
				Main.playerTextures[9, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[9, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_10_2");
			}
			else
			{
				Main.playerTextures[9, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			for (int i = 0; i < 133; i++)
			{
				Main.playerHairTexture[i] = ModContent.GetTexture($"MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerHairAltTexture[i] = ModContent.GetTexture($"MrPlagueRaces/Content/RaceTextures/Blank");
			}
			Main.ghostTexture = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kenku/Kenku_Ghost");
		}
	}
}
