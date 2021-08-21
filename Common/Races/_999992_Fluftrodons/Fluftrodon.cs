using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using MrPlagueRaces.Common.UI;

namespace MrPlagueRaces.Common.Races._999992_Fluftrodons
{
	public class Fluftrodon : Race
	{
        public override int? LegacyId => 11;
		public override string RaceSelectIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/FluftrodonSelect");
		public override string RaceDisplayMaleIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/FluftrodonDisplayMale");
        public override string RaceDisplayFemaleIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/FluftrodonDisplayFemale");

		public override string RaceLore1 => "Oddly raptor-like in appearance, the Fluftrodons greatly value the arts.";
		public override string RaceLore2 => "Their history is baffling, seeming to suggest they abruptly popped into existence out of nowhere.";
		public override string RaceAbilityName => "Paint";
		public override string RaceAbilityDescription => "Press [c/34EB93:Racial Ability Hotkey] to toggle a painting UI. You can paint whilst it is active.";
		public override string RaceAdditionalNotesDescription => "Movement Speed and Jump Height increase by [c/34EB93:+15%] and [c/34EB93:+10%] when at full health";
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
		public override string RaceBuildingSpeedDisplayText => "[c/34EB93:+50%]";
        public override string RaceBuildingWallSpeedDisplayText => "[c/34EB93:+50%]";
		public override string RaceBuildingRangeDisplayText => "[c/34EB93:+2]";
		public override string RaceArrowDamageDisplayText => "";
		public override string RaceMovementSpeedDisplayText => "";
		public override string RaceJumpSpeedDisplayText => "";
        public override string RaceFallDamageResistanceDisplayText => "";
		public override string RaceAllDamageDisplayText => "[c/FF4F64:-15%]";
		public override string RaceFishingSkillDisplayText => "";
		public override string RaceAggroDisplayText => "";
		public override string RaceRunSpeedDisplayText => "";
        public override string RaceRunAccelerationDisplayText => "";

		public override string RaceGoodBiomesDisplayText => "None";
		public override string RaceBadBiomesDisplayText => "None";

		public static int FluftrodonPaintTileMode = -1;
		public static int FluftrodonPaintWallMode = -1;
		public static int FluftrodonPaintColor = 0;
		public bool FluftrodonPaintUI;
		public bool FluftrodonPaintUIPositionSet;

		public override bool PreHurt(Player player, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{

			return true;
		}

		public override void ResetEffects(Player player)
		{
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();
			if (modPlayer.RaceStats)
			{
				player.allDamage -= 0.15f;
				if (player.statLife >= player.statLifeMax2)
				{
					player.moveSpeed += 0.15f;
					player.jumpSpeedBoost += 0.1f;
				}
				player.pickSpeed -= 0.2f;
				player.blockRange += 2;
				player.tileSpeed += 0.5f;
				player.wallSpeed += 0.5f;
				if (FluftrodonPaintUI)
				{
					player.controlUseItem = false;
				}
			}
		}

		public override void ProcessTriggers(Player player, Mod mod)
		{
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();
			if (MrPlagueRaces.RacialAbilityHotKey.JustPressed)
			{
				if (!FluftrodonPaintUI)
				{
					FluftrodonPaintUI = true;
					Main.PlaySound(SoundID.MenuOpen, -1, -1, 1, 1f, 0f);
					FluftrodonPaintUIPositionSet = true;
				}
				else if (FluftrodonPaintUI)
				{
					FluftrodonPaintUI = false;
					Main.PlaySound(SoundID.MenuClose, -1, -1, 1, 1f, 0f);
					FluftrodonPaintUIPositionSet = true;
				}
			}
			if (MrPlagueRaces.RacialAbilityHotKey.JustReleased)
			{
				FluftrodonPaintUIPositionSet = false;
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
				if (FluftrodonPaintUI)
				{
					FluftrodonPaintUIPanel.Visible = true;
				}
				if (FluftrodonPaintUI && Main.mouseLeft)
				{
					if (FluftrodonPaintTileMode == 1 && Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.tile[Player.tileTargetX, Player.tileTargetY].color() != (byte)FluftrodonPaintColor && player.position.X / 16f - (float)Player.tileRangeX - (float)player.blockRange <= (float)Player.tileTargetX && (player.position.X + (float)player.width) / 16f + (float)Player.tileRangeX + (float)player.blockRange >= (float)Player.tileTargetX && player.position.Y / 16f - (float)Player.tileRangeY - (float)player.blockRange <= (float)Player.tileTargetY && (player.position.Y + (float)player.height) / 16f + (float)Player.tileRangeY + (float)player.blockRange >= (float)Player.tileTargetY)
					{
						WorldGen.paintTile(Player.tileTargetX, Player.tileTargetY, (byte)FluftrodonPaintColor, true);
					}
					else if (FluftrodonPaintTileMode == 2 && Main.tile[Player.tileTargetX, Player.tileTargetY].active() && Main.tile[Player.tileTargetX, Player.tileTargetY].color() != 0 && player.position.X / 16f - (float)Player.tileRangeX - (float)player.blockRange <= (float)Player.tileTargetX && (player.position.X + (float)player.width) / 16f + (float)Player.tileRangeX + (float)player.blockRange >= (float)Player.tileTargetX && player.position.Y / 16f - (float)Player.tileRangeY - (float)player.blockRange <= (float)Player.tileTargetY && (player.position.Y + (float)player.height) / 16f + (float)Player.tileRangeY + (float)player.blockRange >= (float)Player.tileTargetY)
					{
						WorldGen.paintTile(Player.tileTargetX, Player.tileTargetY, 0, true);
					}
					if (FluftrodonPaintWallMode == 1 && Main.tile[Player.tileTargetX, Player.tileTargetY].wallColor() != (byte)FluftrodonPaintColor && player.position.X / 16f - (float)Player.tileRangeX - (float)player.blockRange <= (float)Player.tileTargetX && (player.position.X + (float)player.width) / 16f + (float)Player.tileRangeX + (float)player.blockRange >= (float)Player.tileTargetX && player.position.Y / 16f - (float)Player.tileRangeY - (float)player.blockRange <= (float)Player.tileTargetY && (player.position.Y + (float)player.height) / 16f + (float)Player.tileRangeY + (float)player.blockRange >= (float)Player.tileTargetY)
					{
						WorldGen.paintWall(Player.tileTargetX, Player.tileTargetY, (byte)FluftrodonPaintColor, true);
					}
					else if (FluftrodonPaintWallMode == 2 && Main.tile[Player.tileTargetX, Player.tileTargetY].wallColor() != 0 && player.position.X / 16f - (float)Player.tileRangeX - (float)player.blockRange <= (float)Player.tileTargetX && (player.position.X + (float)player.width) / 16f + (float)Player.tileRangeX + (float)player.blockRange >= (float)Player.tileTargetX && player.position.Y / 16f - (float)Player.tileRangeY - (float)player.blockRange <= (float)Player.tileTargetY && (player.position.Y + (float)player.height) / 16f + (float)Player.tileRangeY + (float)player.blockRange >= (float)Player.tileTargetY)
					{
						WorldGen.paintWall(Player.tileTargetX, Player.tileTargetY, 0, true);
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
			drawInfo.drawAltHair = true;
			player.underShirtColor = player.hairColor;
			player.shoeColor = player.hairColor;
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
				player.hairColor = new Color(123, 125, 192);
				player.skinColor = new Color(170, 199, 233);
				player.eyeColor = new Color(58, 76, 102);
				player.underShirtColor = new Color(132, 152, 188);
				player.shoeColor = new Color(132, 152, 188);
				player.skinVariant = 1;
			}
		}

		public override void ModifyDrawLayers(Player player, List<PlayerLayer> layers)
		{
			//applying the racial textures
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();

			bool hideChestplate = modPlayer.hideChestplate;
			bool hideLeggings = modPlayer.hideLeggings;

			modPlayer.updatePlayerSprites("MrPlagueRaces/Content/RaceTextures/", "MrPlagueRaces/Content/RaceTextures/Fluftrodon/", hideChestplate, hideLeggings, 51, 0, "Fluftrodon", false);

		}
	}
}
