using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MrPlagueRaces.Common.Races._999989_Kobolds
{
	public class Kobold : Race
	{
        public override int? LegacyId => 8;
        public override string RaceEnvironmentIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/Environment/Environment_Caverns");
		public override string RaceEnvironmentOverlay1Icon => ($"MrPlagueRaces/Common/UI/RaceDisplay/BlankDisplay");
		public override string RaceEnvironmentOverlay2Icon => ($"MrPlagueRaces/Common/UI/RaceDisplay/BlankDisplay");
		public override string RaceSelectIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/KoboldSelect");
		public override string RaceDisplayMaleIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/KoboldDisplayMale");
        public override string RaceDisplayFemaleIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/KoboldDisplayFemale");

		public override string RaceLore1 => "Often reclusive, the reptilian Kobolds are talented diggers and orefinders.";
		public override string RaceLore2 => "They are adapted for living far below the surface, notably having similar biology to the Dragonkin.";
		public override string RaceAbilityName => "Oresense";
		public override string RaceAbilityDescription => "Press [c/34EB93:Racial Ability Hotkey] to detect nearby ores.";
		public override string RaceAdditionalNotesDescription => "-Has [c/34EB93:Night Vision]" +
																  "\n-Stats decrease in sunlight ([c/FF4F64:-4] Defense, [c/FF4F64:-20%] Attack Damage, [c/FF4F64:-50%] Jump Height)";
		public override bool UsesCustomHurtSound => true;
        public override bool HasFemaleHurtSound => true;

		public override string RaceHealthDisplayText => "[c/FF4F64:-10%]";
		public override string RaceRegenerationDisplayText => "";
		public override string RaceManaDisplayText => "";
		public override string RaceManaRegenerationDisplayText => "";
		public override string RaceDefenseDisplayText => "[c/FF4F64:-4]";
		public override string RaceDamageReductionDisplayText => "";
		public override string RaceThornsDisplayText => "";
		public override string RaceLavaResistanceDisplayText => "";
		public override string RaceMeleeDamageDisplayText => "[c/FF4F64:-10%]";
		public override string RaceRangedDamageDisplayText => "[c/34EB93:+5%]";
		public override string RaceMagicDamageDisplayText => "[c/34EB93:+5%]";
		public override string RaceSummonDamageDisplayText => "[c/34EB93:+5%]";
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
		public override string RaceMiningSpeedDisplayText => "[c/34EB93:+60%]";
		public override string RaceBuildingSpeedDisplayText => "";
        public override string RaceBuildingWallSpeedDisplayText => "";
		public override string RaceBuildingRangeDisplayText => "";
		public override string RaceArrowDamageDisplayText => "";
		public override string RaceMovementSpeedDisplayText => "[c/34EB93:+5%]";
		public override string RaceJumpSpeedDisplayText => "";
        public override string RaceFallDamageResistanceDisplayText => "";
		public override string RaceAllDamageDisplayText => "";
		public override string RaceFishingSkillDisplayText => "";
		public override string RaceAggroDisplayText => "";
		public override string RaceRunSpeedDisplayText => "";
        public override string RaceRunAccelerationDisplayText => "";

		public override string RaceGoodBiomesDisplayText => "Underground, Caverns";
		public override string RaceBadBiomesDisplayText => "Surface";

		public override bool PreHurt(Player player, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{

			return true;
		}

        public override void ResetEffects(Player player)
        {
            var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();
            if (modPlayer.RaceStats)
            {
                player.statLifeMax2 -= (player.statLifeMax2 / 10);
                player.statDefense -= 4;
                player.meleeDamage -= 0.1f;
                player.rangedDamage += 0.05f;
                player.magicDamage += 0.05f;
                player.minionDamage += 0.05f;
                player.moveSpeed += 0.05f;
                player.pickSpeed -= 0.6f;
                player.nightVision = true;
            }
        }

		public override void ProcessTriggers(Player player, Mod mod)
		{
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();
			if (modPlayer.RaceStats)
			{
				if (MrPlagueRaces.RacialAbilityHotKey.Current)
				{
					int spelunkerradius = 30;
					if ((player.Center - Main.player[Main.myPlayer].Center).Length() < (float)(Main.screenWidth + spelunkerradius * 16))
					{
						int playerX = (int)player.Center.X / 16;
						int playerY = (int)player.Center.Y / 16;
						int num3;
						for (int playerX2 = playerX - spelunkerradius; playerX2 <= playerX + spelunkerradius; playerX2 = num3 + 1)
						{
							for (int playerY2 = playerY - spelunkerradius; playerY2 <= playerY + spelunkerradius; playerY2 = num3 + 1)
							{
								if (Main.rand.Next(4) == 0)
								{
									Vector2 vector16 = new Vector2((float)(playerX - playerX2), (float)(playerY - playerY2));
									if (vector16.Length() < (float)spelunkerradius && playerX2 > 0 && playerX2 < Main.maxTilesX - 1 && playerY2 > 0 && playerY2 < Main.maxTilesY - 1 && Main.tile[playerX2, playerY2] != null && Main.tile[playerX2, playerY2].active())
									{
										bool flag3 = false;
										if (Main.tile[playerX2, playerY2].type == 185 && Main.tile[playerX2, playerY2].frameY == 18)
										{
											if (Main.tile[playerX2, playerY2].frameX >= 576 && Main.tile[playerX2, playerY2].frameX <= 882)
											{
												flag3 = true;
											}
										}
										else if (Main.tile[playerX2, playerY2].type == 186 && Main.tile[playerX2, playerY2].frameX >= 864 && Main.tile[playerX2, playerY2].frameX <= 1170)
										{
											flag3 = true;
										}
										if (flag3 || Main.tileSpelunker[(int)Main.tile[playerX2, playerY2].type] || (Main.tileAlch[(int)Main.tile[playerX2, playerY2].type] && Main.tile[playerX2, playerY2].type != 82))
										{
											int spelunkerdust = Dust.NewDust(new Vector2((float)(playerX2 * 16), (float)(playerY2 * 16)), 16, 16, 204, 0f, 0f, 150, default(Color), 0.3f);
											Main.dust[spelunkerdust].fadeIn = 0.75f;
											Dust dust = Main.dust[spelunkerdust];
											dust.velocity *= 0.1f;
											Main.dust[spelunkerdust].noLight = true;
										}
									}
								}
								num3 = playerY2;
							}
							num3 = playerX2;
						}
					}
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
				Lighting.AddLight((int)(player.position.X + (float)(player.width / 2)) / 16, (int)(player.position.Y + (float)(player.height / 2)) / 16, 1f, 1f, 1f);
				if (modPlayer.ExposedToSunlight() && Main.myPlayer == player.whoAmI && !((player.inventory[player.selectedItem].type == ItemID.Umbrella) || (player.armor[0].type == ItemID.UmbrellaHat)))
				{
					player.AddBuff(mod.BuffType("KoboldSunlight"), 2);
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
				player.hairColor = new Color(237, 180, 164);
				player.skinColor = new Color(193, 93, 93);
				player.eyeColor = new Color(243, 168, 53);
				player.shirtColor = new Color(175, 151, 114);
				player.underShirtColor = new Color(119, 112, 147);
				player.skinVariant = 2;
				if (player.armor[1].type < ItemID.IronPickaxe)
				{
					player.armor[1] = familiarshirt;
				}
			}
		}

		public override void ModifyDrawLayers(Player player, List<PlayerLayer> layers)
		{
			//applying the racial textures
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();

			bool hideChestplate = modPlayer.hideChestplate;
			bool hideLeggings = modPlayer.hideLeggings;

			modPlayer.updatePlayerSprites("MrPlagueRaces/Content/RaceTextures/", "MrPlagueRaces/Content/RaceTextures/Kobold/", hideChestplate, hideLeggings, 51, 0, "Kobold", false);

		}
	}
}
