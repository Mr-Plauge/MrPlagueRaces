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

		public override string RaceLore1 => "Bat-like creatures that are naturally gifted with a form of blood magic.";
		public override string RaceLore2 => "Vampires tend to live solitarily, travelling at night or via caverns due to their sensitivity to the sun.";
		public override string RaceAbilityName => "Bat Transformation";
		public override string RaceAbilityDescription => "Press [c/34EB93:Racial Ability Hotkey] to become a bat. Grants flight, decreases your hitbox size, and increases your Movement Speed depending on equipped wings and boots.";
		public override string RaceAdditionalNotesDescription => "-Burns in sunlight";
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
								player.bodyFrame.Y = player.bodyFrame.Height * 1;
							}

							if ((vampireWalkAnim >= 6) && (vampireWalkAnim < 12))
							{
								player.bodyFrame.Y = player.bodyFrame.Height * 1;
							}

							if ((vampireWalkAnim >= 12) && (vampireWalkAnim < 18))
							{
								player.bodyFrame.Y = player.bodyFrame.Height * 2;
							}

							if ((vampireWalkAnim >= 18) && (vampireWalkAnim < 24))
							{
								player.bodyFrame.Y = player.bodyFrame.Height * 2;
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
								player.bodyFrame.Y = player.bodyFrame.Height * 1;
							}

							if ((vampireWalkAnim >= 6) && (vampireWalkAnim < 12))
							{
								player.bodyFrame.Y = player.bodyFrame.Height * 1;
							}

							if ((vampireWalkAnim >= 12) && (vampireWalkAnim < 18))
							{
								player.bodyFrame.Y = player.bodyFrame.Height * 2;
							}

							if ((vampireWalkAnim >= 18) && (vampireWalkAnim < 24))
							{
								player.bodyFrame.Y = player.bodyFrame.Height * 2;
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
								player.bodyFrame.Y = player.bodyFrame.Height * 6;
							}

							if ((vampireWingAnim >= 6) && (vampireWingAnim < 12))
							{
								player.bodyFrame.Y = player.bodyFrame.Height * 7;
							}

							if ((vampireWingAnim >= 12) && (vampireWingAnim < 18))
							{
								player.bodyFrame.Y = player.bodyFrame.Height * 8;
							}

							if ((vampireWingAnim >= 18) && (vampireWingAnim < 24))
							{
								player.bodyFrame.Y = player.bodyFrame.Height * 9;
								vampireWingAnim = 0;
								if (!player.dead)
								{
									Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Wing_Flap"));
								}
							}
						}
						else if (player.velocity.Y > 0)
						{
							player.bodyFrame.Y = player.bodyFrame.Height * 3;
							vampireWingAnim = 0;
						}
						else
						{
							player.bodyFrame.Y = player.bodyFrame.Height * 3;
							vampireWingAnim = 0;
						}
					}
					if (player.velocity.Y == 0)
					{
						vampireWingAnim = 0;
						if (!player.controlLeft && !player.controlRight)
							player.bodyFrame.Y = player.bodyFrame.Height * 1;
					}
					if (player.velocity.Y > 0)
					{
						player.bodyFrame.Y = player.bodyFrame.Height * 3;
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

			if (VampireTransformation)
			{
				modPlayer.updatePlayerSprites("MrPlagueRaces/Content/RaceTextures/", "MrPlagueRaces/Content/RaceTextures/VampireBat/", hideChestplate, hideLeggings, 0, 0, "VampireBat", false, true);
			}
			else
			{
				modPlayer.updatePlayerSprites("MrPlagueRaces/Content/RaceTextures/", "MrPlagueRaces/Content/RaceTextures/Vampire/", hideChestplate, hideLeggings, 133, 133, "Vampire", true);
			}
		}
	}
}
