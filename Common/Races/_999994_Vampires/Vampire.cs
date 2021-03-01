using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using MrPlagueRaces.Content.Mounts;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Common.Races._999994_Vampires
{
	public class Vampire : Race
	{
        public override int? LegacyId => 10;
        public override string RaceEnvironmentIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/Environment/Environment_BloodMoon");
		public override string RaceEnvironmentOverlay1Icon => ($"MrPlagueRaces/Common/UI/RaceDisplay/BlankDisplay");
		public override string RaceEnvironmentOverlay2Icon => ($"MrPlagueRaces/Common/UI/RaceDisplay/BlankDisplay");
		public override string RaceSelectIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/VampireSelect");
		public override string RaceDisplayMaleIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/VampireDisplayMale");
        public override string RaceDisplayFemaleIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/VampireDisplayFemale");

		public override string RaceLore1 => "Bat-like creatures" + "\nthat are naturally" + "\ngifted with a form" + "\nof blood magic.";
		public override string RaceLore2 => "Vampires tend to live solitarily," + "\ntravelling at night or via caverns" + "\ndue to their sensitivity to the sun.";
		public override string RaceAbilityName => "Bat Transformation";
		public override string RaceAbilityDescription1 => "Press [c/34EB93:Racial Ability Hotkey] to become a bat. Grants flight, decreases your hitbox size, and increases your Movement Speed depending on equipped";
		public override string RaceAbilityDescription2 => "wings and boots.";
		public override string RaceAbilityDescription3 => "";
		public override string RaceAbilityDescription4 => "";
		public override string RaceAbilityDescription5 => "";
		public override string RaceAbilityDescription6 => "";
		public override string RaceAdditionalNotesDescription1 => "-Burns in sunlight";
		public override string RaceAdditionalNotesDescription2 => "";
		public override string RaceAdditionalNotesDescription3 => "";
		public override string RaceAdditionalNotesDescription4 => "";
		public override string RaceAdditionalNotesDescription5 => "";
		public override string RaceAdditionalNotesDescription6 => "";
		public override bool UsesCustomHurtSound => true;
        public override bool HasFemaleHurtSound => true;

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
		public override string RaceMiningSpeedDisplayText => "[c/34EB93:+20%]";
		public override string RaceBuildingSpeedDisplayText => "";
        public override string RaceBuildingWallSpeedDisplayText => "";
		public override string RaceBuildingRangeDisplayText => "";
		public override string RaceArrowDamageDisplayText => "";
		public override string RaceMovementSpeedDisplayText => "[c/34EB93:+10%]";
		public override string RaceJumpSpeedDisplayText => "";
        public override string RaceFallDamageResistanceDisplayText => "";
		public override string RaceAllDamageDisplayText => "";
		public override string RaceFishingSkillDisplayText => "";
		public override string RaceAggroDisplayText => "";
		public override string RaceRunSpeedDisplayText => "";
        public override string RaceRunAccelerationDisplayText => "";

		public override string RaceGoodBiomesDisplayText => "None";
		public override string RaceBadBiomesDisplayText => "None";

		public bool VampireTransformation;
		public bool VampireTransformationDust;
		public int vampireWingAnim;
		public int vampireWingFrame;
		public int vampireWalkAnim;

		public override bool PreHurt(Player player, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{

			return true;
		}

		public override void ResetEffects(Player player)
		{
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();
			if (modPlayer.RaceStats)
			{
				player.moveSpeed += 0.1f;
				player.pickSpeed -= 0.2f;
				player.lifeMagnet = true;
				if (MrPlagueRaces.RacialAbilityHotKey.JustPressed && MrPlagueRaces.RacialAbilityHotKey.Current)
				{
					player.controlMount = false;
					player.releaseMount = false;
				}
				if (VampireTransformation)
				{
					player.controlUseItem = false;
				}
			}
		}

		public override void ProcessTriggers(Player player, Mod mod)
		{
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();
			if (modPlayer.RaceStats)
			{
				if (MrPlagueRaces.RacialAbilityHotKey.Current)
				{
					player.AddBuff(mod.BuffType("VampireBat"), 2);
				}
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
				if (player.HasBuff(mod.BuffType("VampireBat")))
				{
					modPlayer.hideArmor = true;
					VampireTransformation = true;
					if (!VampireTransformationDust)
					{
						Main.PlaySound(SoundID.Item8, player.position);
						int num = Gore.NewGore(new Vector2(player.position.X, player.position.Y - 10f), player.velocity, 99);
						Main.gore[num].velocity *= 0.3f;
						num = Gore.NewGore(new Vector2(player.position.X, player.position.Y + (float)(player.height / 2) - 10f), player.velocity, 99);
						Main.gore[num].velocity *= 0.3f;
						num = Gore.NewGore(new Vector2(player.position.X, player.position.Y + (float)player.height - 10f), player.velocity, 99);
						Main.gore[num].velocity *= 0.3f;
						VampireTransformationDust = true;
					}
					player.mount.SetMount(ModContent.MountType<VampireRaceBat>(), player, false);
				}
				if (!player.HasBuff(mod.BuffType("VampireBat")))
				{
					modPlayer.hideArmor = false;
					VampireTransformation = false;
					if (VampireTransformationDust)
					{
						Main.PlaySound(SoundID.Item8, player.position);
						int num = Gore.NewGore(new Vector2(player.position.X, player.position.Y - 10f), player.velocity, 99);
						Main.gore[num].velocity *= 0.3f;
						num = Gore.NewGore(new Vector2(player.position.X, player.position.Y + (float)(player.height / 2) - 10f), player.velocity, 99);
						Main.gore[num].velocity *= 0.3f;
						num = Gore.NewGore(new Vector2(player.position.X, player.position.Y + (float)player.height - 10f), player.velocity, 99);
						Main.gore[num].velocity *= 0.3f;
						VampireTransformationDust = false;
					}
					if (player.mount.Type == ModContent.MountType<VampireRaceBat>())
					{
						player.mount.Dismount(player);
					}
				}
				if (modPlayer.ExposedToSunlight() && Main.myPlayer == player.whoAmI && !((player.inventory[player.selectedItem].type == ItemID.Umbrella) || (player.armor[0].type == ItemID.UmbrellaHat)))
				{
					player.AddBuff(mod.BuffType("VampireBurn"), 2);
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
                modPlayer.IsNewCharacter1 = true;
            }
			if (!modPlayer.IsNewCharacter2)
			{
				modPlayer.IsNewCharacter2 = true;
			}
			if (modPlayer.resetDefaultColors)
			{
				modPlayer.resetDefaultColors = false;
				player.hairColor = new Color(62, 54, 76);
				player.skinColor = new Color(244, 225, 195);
				player.eyeColor = new Color(239, 40, 147);
				player.shirtColor = new Color(61, 51, 65);
				player.underShirtColor = new Color(169, 71, 111);
				player.pantsColor = new Color(45, 31, 37);
				player.shoeColor = new Color(38, 38, 38);
				player.skinVariant = 3;
				if (player.armor[1].type < ItemID.IronPickaxe && player.armor[2].type < ItemID.IronPickaxe)
				{
					player.armor[1] = familiarshirt;
					player.armor[2] = familiarpants;
				}
			}
			if (modPlayer.RaceStats)
			{
				if (VampireTransformation)
				{
					Lighting.AddLight((int)(player.position.X + (float)(player.width / 2)) / 16, (int)(player.position.Y + (float)(player.height / 2)) / 16, 0.8f, 0.95f, 1f);
					if (player.direction == -1)
					{
						player.headRotation = -(player.velocity.X * (float)player.direction * 0.1f);
					}
					if (player.direction == 1)
					{
						player.headRotation = player.velocity.X * (float)player.direction * 0.1f;
					}
					if ((double)player.headRotation < -0.3)
					{
						player.headRotation = -0.3f;
					}
					if ((double)player.headRotation > 0.3)
					{
						player.headRotation = 0.3f;
					}
					if (player.bodyFrame.Height == player.bodyFrame.Height * 1)
					{
						player.bodyFrame.Y = player.bodyFrame.Height * 2;
					}
					if (player.controlLeft)
					{
						if (player.velocity.Y == 0)
						{
							vampireWalkAnim += 1;
							if ((vampireWalkAnim >= 0) && (vampireWalkAnim < 6))
							{
								player.bodyFrame.Y = player.bodyFrame.Height * 6;
							}

							if ((vampireWalkAnim >= 6) && (vampireWalkAnim < 12))
							{
								player.bodyFrame.Y = player.bodyFrame.Height * 7;
							}

							if ((vampireWalkAnim >= 12) && (vampireWalkAnim < 18))
							{
								player.bodyFrame.Y = player.bodyFrame.Height * 8;
							}

							if ((vampireWalkAnim >= 18) && (vampireWalkAnim < 24))
							{
								player.bodyFrame.Y = player.bodyFrame.Height * 9;
								vampireWalkAnim = 0;
							}
						}
					}
					if (player.controlRight)
					{
						if (player.velocity.Y == 0)
						{
							vampireWalkAnim += 1;
							if ((vampireWalkAnim >= 0) && (vampireWalkAnim < 6))
							{
								player.bodyFrame.Y = player.bodyFrame.Height * 6;
							}

							if ((vampireWalkAnim >= 6) && (vampireWalkAnim < 12))
							{
								player.bodyFrame.Y = player.bodyFrame.Height * 7;
							}

							if ((vampireWalkAnim >= 12) && (vampireWalkAnim < 18))
							{
								player.bodyFrame.Y = player.bodyFrame.Height * 8;
							}

							if ((vampireWalkAnim >= 18) && (vampireWalkAnim < 24))
							{
								player.bodyFrame.Y = player.bodyFrame.Height * 9;
								vampireWalkAnim = 0;
							}
						}
					}
					if (player.controlJump)
					{
						if (player.velocity.Y < 0)
						{
							vampireWingAnim += 1;
							if ((vampireWingAnim >= 0) && (vampireWingAnim < 6))
							{
								player.bodyFrame.Y = player.bodyFrame.Height * 2;
								vampireWingFrame = 1;
							}

							if ((vampireWingAnim >= 6) && (vampireWingAnim < 12))
							{
								player.bodyFrame.Y = player.bodyFrame.Height * 2;
								vampireWingFrame = 2;
							}

							if ((vampireWingAnim >= 12) && (vampireWingAnim < 18))
							{
								player.bodyFrame.Y = player.bodyFrame.Height * 2;
								vampireWingFrame = 3;
							}

							if ((vampireWingAnim >= 18) && (vampireWingAnim < 24))
							{
								player.bodyFrame.Y = player.bodyFrame.Height * 2;
								vampireWingFrame = 4;
								vampireWingAnim = 0;
								if (!player.dead)
								{
									Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Wing_Flap"));
								}
							}
						}
						else if (player.velocity.Y > 0)
						{
							player.bodyFrame.Y = player.bodyFrame.Height * 2;
							vampireWingAnim = 0;
							vampireWingFrame = 2;
						}
						else
						{
							player.bodyFrame.Y = player.bodyFrame.Height * 2;
							vampireWingAnim = 0;
							vampireWingFrame = -1;
						}
					}
					if (player.velocity.Y == 0)
					{
						vampireWingAnim = 0;
						vampireWingFrame = -1;
						if (!player.controlLeft && !player.controlRight)
							player.bodyFrame.Y = player.bodyFrame.Height * 2;
					}
					if (player.velocity.Y > 0)
					{
						player.bodyFrame.Y = player.bodyFrame.Height * 2;
						vampireWingFrame = 2;
					}
				}
			}
		}

		public override void ModifyDrawLayers(Player player, List<PlayerLayer> layers)
		{
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();

			if (VampireTransformation)
			{
				ModifyDrawLayersTransformed(player, layers);
				return;
			}

			bool hideChestplate = modPlayer.hideChestplate;
			bool hideLeggings = modPlayer.hideLeggings;

			Main.playerTextures[0, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Head");
			Main.playerTextures[0, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_2");
			Main.playerTextures[0, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes");
			Main.playerTextures[0, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Torso");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[0, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_1");
			}
			else
			{
				Main.playerTextures[0, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[0, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[0, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Shirt_1");
			}
			else
			{
				Main.playerTextures[0, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[0, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[0, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_1");
			}
			else
			{
				Main.playerTextures[0, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[0, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hand");
			Main.playerTextures[0, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[0, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_1");
				Main.playerTextures[0, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_1");
			}
			else
			{
				Main.playerTextures[0, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Legs");
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

			Main.playerTextures[1, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Head");
			Main.playerTextures[1, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_2");
			Main.playerTextures[1, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes");
			Main.playerTextures[1, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Torso");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[1, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Sleeves_2");
			}
			else
			{
				Main.playerTextures[1, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[1, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[1, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_2");
			}
			else
			{
				Main.playerTextures[1, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[1, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[1, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_2");
			}
			else
			{
				Main.playerTextures[1, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[1, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hand");
			Main.playerTextures[1, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[1, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_2");
				Main.playerTextures[1, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_2");
			}
			else
			{
				Main.playerTextures[1, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Legs");
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

			Main.playerTextures[2, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Head");
			Main.playerTextures[2, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_2");
			Main.playerTextures[2, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes");
			Main.playerTextures[2, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Torso");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[2, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Sleeves_3");
			}
			else
			{
				Main.playerTextures[2, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[2, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[2, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_3");
			}
			else
			{
				Main.playerTextures[2, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[2, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[2, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_3");
			}
			else
			{
				Main.playerTextures[2, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[2, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hand");
			Main.playerTextures[2, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[2, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_3");
				Main.playerTextures[2, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_3");
			}
			else
			{
				Main.playerTextures[2, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Legs");
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

			Main.playerTextures[3, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Head");
			Main.playerTextures[3, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_2");
			Main.playerTextures[3, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes");
			Main.playerTextures[3, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Torso");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[3, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Sleeves_4");
			}
			else
			{
				Main.playerTextures[3, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[3, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[3, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Shirt_4");
			}
			else
			{
				Main.playerTextures[3, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[3, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[3, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_4");
			}
			else
			{
				Main.playerTextures[3, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[3, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hand");
			Main.playerTextures[3, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[3, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_4");
				Main.playerTextures[3, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_4");
			}
			else
			{
				Main.playerTextures[3, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Legs");
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

			Main.playerTextures[8, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Head");
			Main.playerTextures[8, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_2");
			Main.playerTextures[8, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes");
			Main.playerTextures[8, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Torso");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[8, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Sleeves_9");
			}
			else
			{
				Main.playerTextures[8, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[8, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[8, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Shirt_9");
			}
			else
			{
				Main.playerTextures[8, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[8, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[8, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_9");
			}
			else
			{
				Main.playerTextures[8, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[8, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hand");
			Main.playerTextures[8, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[8, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_9");
				Main.playerTextures[8, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_9");
			}
			else
			{
				Main.playerTextures[8, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Legs");
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

			Main.playerTextures[4, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Head_Female");
			Main.playerTextures[4, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_2_Female");
			Main.playerTextures[4, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_Female");
			Main.playerTextures[4, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Torso_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[4, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Sleeves_5");
			}
			else
			{
				Main.playerTextures[4, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[4, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hands_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[4, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_5");
			}
			else
			{
				Main.playerTextures[4, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Body_Female");
			}

			Main.playerTextures[4, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Arm_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[4, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_5");
			}
			else
			{
				Main.playerTextures[4, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[4, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hand_Female");
			Main.playerTextures[4, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Legs_Female");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[4, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_5");
				Main.playerTextures[4, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_5");
			}
			else
			{
				Main.playerTextures[4, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Legs_Female");
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

			Main.playerTextures[5, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Head_Female");
			Main.playerTextures[5, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_2_Female");
			Main.playerTextures[5, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_Female");
			Main.playerTextures[5, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Torso_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[5, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Sleeves_6");
			}
			else
			{
				Main.playerTextures[5, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[5, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hands_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[5, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_6");
			}
			else
			{
				Main.playerTextures[5, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Body_Female");
			}

			Main.playerTextures[5, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Arm_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[5, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_6");
			}
			else
			{
				Main.playerTextures[5, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[5, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hand_Female");
			Main.playerTextures[5, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Legs_Female");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[5, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_6");
				Main.playerTextures[5, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_6");
			}
			else
			{
				Main.playerTextures[5, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Legs_Female");
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

			Main.playerTextures[6, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Head_Female");
			Main.playerTextures[6, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_2_Female");
			Main.playerTextures[6, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_Female");
			Main.playerTextures[6, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Torso_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[6, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Sleeves_7");
			}
			else
			{
				Main.playerTextures[6, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[6, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hands_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[6, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_7");
			}
			else
			{
				Main.playerTextures[6, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Body_Female");
			}

			Main.playerTextures[6, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Arm_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[6, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_7");
			}
			else
			{
				Main.playerTextures[6, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[6, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hand_Female");
			Main.playerTextures[6, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Legs_Female");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[6, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_7");
				Main.playerTextures[6, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_7");
			}
			else
			{
				Main.playerTextures[6, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Legs_Female");
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

			Main.playerTextures[7, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Head_Female");
			Main.playerTextures[7, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_2_Female");
			Main.playerTextures[7, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_Female");
			Main.playerTextures[7, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Torso_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[7, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_8");
			}
			else
			{
				Main.playerTextures[7, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[7, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hands_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[7, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Shirt_8");
			}
			else
			{
				Main.playerTextures[7, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Body_Female");
			}

			Main.playerTextures[7, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Arm_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[7, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_8");
			}
			else
			{
				Main.playerTextures[7, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[7, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hand_Female");
			Main.playerTextures[7, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Legs_Female");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[7, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_8");
				Main.playerTextures[7, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_8");
			}
			else
			{
				Main.playerTextures[7, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Legs_Female");
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

			Main.playerTextures[9, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Head_Female");
			Main.playerTextures[9, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_2_Female");
			Main.playerTextures[9, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_Female");
			Main.playerTextures[9, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Torso_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[9, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Sleeves_10");
			}
			else
			{
				Main.playerTextures[9, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[9, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hands_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[9, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_10");
			}
			else
			{
				Main.playerTextures[9, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Body_Female");
			}

			Main.playerTextures[9, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Arm_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[9, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_10");
			}
			else
			{
				Main.playerTextures[9, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[9, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hand");
			Main.playerTextures[9, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[9, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_10");
				Main.playerTextures[9, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_10");
			}
			else
			{
				Main.playerTextures[9, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Legs_Female");
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
				Main.playerHairTexture[i] = ModContent.GetTexture($"MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_{i + 1}");
				Main.playerHairAltTexture[i] = ModContent.GetTexture($"MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_{i + 1}");
			}
			Main.ghostTexture = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Ghost");
		}

		private void ModifyDrawLayersTransformed(Player player, List<PlayerLayer> layers)
		{
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();

			Main.playerTextures[0, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Head");
			Main.playerTextures[0, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

			if (vampireWingFrame == -1)
			{
				Main.playerTextures[0, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 0)
			{
				Main.playerTextures[0, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 1)
			{
				Main.playerTextures[0, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 2)
			{
				Main.playerTextures[0, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_2");
			}
			if (vampireWingFrame == 3)
			{
				Main.playerTextures[0, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_3");
			}
			if (vampireWingFrame == 4)
			{
				Main.playerTextures[0, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_4");
			}

			Main.playerTextures[0, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[0, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[0, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[0, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[0, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[0, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[0, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[0, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[0, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[0, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[0, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[0, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Head");
			Main.playerTextures[1, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

			if (vampireWingFrame == -1)
			{
				Main.playerTextures[1, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_Walk");
			}
			if (vampireWingFrame == 0)
			{
				Main.playerTextures[1, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 1)
			{
				Main.playerTextures[1, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 2)
			{
				Main.playerTextures[1, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_2");
			}
			if (vampireWingFrame == 3)
			{
				Main.playerTextures[1, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_3");
			}
			if (vampireWingFrame == 4)
			{
				Main.playerTextures[1, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_4");
			}

			Main.playerTextures[1, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Head");
			Main.playerTextures[2, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

			if (vampireWingFrame == -1)
			{
				Main.playerTextures[2, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_Walk");
			}
			if (vampireWingFrame == 0)
			{
				Main.playerTextures[2, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 1)
			{
				Main.playerTextures[2, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 2)
			{
				Main.playerTextures[2, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_2");
			}
			if (vampireWingFrame == 3)
			{
				Main.playerTextures[2, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_3");
			}
			if (vampireWingFrame == 4)
			{
				Main.playerTextures[2, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_4");
			}

			Main.playerTextures[2, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Head");
			Main.playerTextures[3, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

			if (vampireWingFrame == -1)
			{
				Main.playerTextures[3, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_Walk");
			}
			if (vampireWingFrame == 0)
			{
				Main.playerTextures[3, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 1)
			{
				Main.playerTextures[3, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 2)
			{
				Main.playerTextures[3, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_2");
			}
			if (vampireWingFrame == 3)
			{
				Main.playerTextures[3, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_3");
			}
			if (vampireWingFrame == 4)
			{
				Main.playerTextures[3, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_4");
			}

			Main.playerTextures[3, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Head");
			Main.playerTextures[8, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

			if (vampireWingFrame == -1)
			{
				Main.playerTextures[8, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_Walk");
			}
			if (vampireWingFrame == 0)
			{
				Main.playerTextures[8, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 1)
			{
				Main.playerTextures[8, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 2)
			{
				Main.playerTextures[8, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_2");
			}
			if (vampireWingFrame == 3)
			{
				Main.playerTextures[8, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_3");
			}
			if (vampireWingFrame == 4)
			{
				Main.playerTextures[8, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_4");
			}

			Main.playerTextures[8, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Head");
			Main.playerTextures[4, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

			if (vampireWingFrame == -1)
			{
				Main.playerTextures[4, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_Walk");
			}
			if (vampireWingFrame == 0)
			{
				Main.playerTextures[4, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 1)
			{
				Main.playerTextures[4, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 2)
			{
				Main.playerTextures[4, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_2");
			}
			if (vampireWingFrame == 3)
			{
				Main.playerTextures[4, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_3");
			}
			if (vampireWingFrame == 4)
			{
				Main.playerTextures[4, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_4");
			}

			Main.playerTextures[4, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Head");
			Main.playerTextures[5, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

			if (vampireWingFrame == -1)
			{
				Main.playerTextures[5, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_Walk");
			}
			if (vampireWingFrame == 0)
			{
				Main.playerTextures[5, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 1)
			{
				Main.playerTextures[5, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 2)
			{
				Main.playerTextures[5, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_2");
			}
			if (vampireWingFrame == 3)
			{
				Main.playerTextures[5, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_3");
			}
			if (vampireWingFrame == 4)
			{
				Main.playerTextures[5, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_4");
			}

			Main.playerTextures[5, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Head");
			Main.playerTextures[6, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

			if (vampireWingFrame == -1)
			{
				Main.playerTextures[6, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_Walk");
			}
			if (vampireWingFrame == 0)
			{
				Main.playerTextures[6, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 1)
			{
				Main.playerTextures[6, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 2)
			{
				Main.playerTextures[6, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_2");
			}
			if (vampireWingFrame == 3)
			{
				Main.playerTextures[6, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_3");
			}
			if (vampireWingFrame == 4)
			{
				Main.playerTextures[6, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_4");
			}

			Main.playerTextures[6, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Head");
			Main.playerTextures[7, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

			if (vampireWingFrame == -1)
			{
				Main.playerTextures[7, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_Walk");
			}
			if (vampireWingFrame == 0)
			{
				Main.playerTextures[7, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 1)
			{
				Main.playerTextures[7, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 2)
			{
				Main.playerTextures[7, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_2");
			}
			if (vampireWingFrame == 3)
			{
				Main.playerTextures[7, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_3");
			}
			if (vampireWingFrame == 4)
			{
				Main.playerTextures[7, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_4");
			}

			Main.playerTextures[7, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Head");
			Main.playerTextures[9, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

			if (vampireWingFrame == -1)
			{
				Main.playerTextures[9, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_Walk");
			}
			if (vampireWingFrame == 0)
			{
				Main.playerTextures[9, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 1)
			{
				Main.playerTextures[9, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 2)
			{
				Main.playerTextures[9, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_2");
			}
			if (vampireWingFrame == 3)
			{
				Main.playerTextures[9, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_3");
			}
			if (vampireWingFrame == 4)
			{
				Main.playerTextures[9, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_4");
			}

			Main.playerTextures[9, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

			if ((vampireWingFrame == -1 || vampireWingFrame == 0) && !(player.bodyFrame.Y == player.bodyFrame.Height * 8 || player.bodyFrame.Y == player.bodyFrame.Height * 9))
			{
				for (int i = 0; i < 133; i++)
				{
					Main.playerHairTexture[i] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
					Main.playerHairAltTexture[i] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				}
			}
			if ((vampireWingFrame == -1 || vampireWingFrame == 0) && (player.bodyFrame.Y == player.bodyFrame.Height * 8 || player.bodyFrame.Y == player.bodyFrame.Height * 9) && !player.dead)
			{
				for (int i = 0; i < 133; i++)
				{
					Main.playerHairTexture[i] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
					Main.playerHairAltTexture[i] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				}
			}
			if (vampireWingFrame == 1 && !player.dead)
			{
				for (int i = 0; i < 133; i++)
				{
					Main.playerHairTexture[i] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
					Main.playerHairAltTexture[i] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				}
			}
			if (vampireWingFrame == 2 && !player.dead)
			{
				for (int i = 0; i < 133; i++)
				{
					Main.playerHairTexture[i] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
					Main.playerHairAltTexture[i] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				}
			}
			if (vampireWingFrame == 3 && !player.dead)
			{
				for (int i = 0; i < 133; i++)
				{
					Main.playerHairTexture[i] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
					Main.playerHairAltTexture[i] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				}
			}
			if (vampireWingFrame == 4 && !player.dead)
			{
				for (int i = 0; i < 133; i++)
				{
					Main.playerHairTexture[i] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
					Main.playerHairAltTexture[i] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				}
			}

			if (player.dead)
			{
				for (int i = 0; i < 133; i++)
				{
					Main.playerHairTexture[i] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
					Main.playerHairAltTexture[i] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				}
			}
		}
	}
}
