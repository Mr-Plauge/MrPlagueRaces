using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using MrPlagueRaces.Common.UI;

namespace MrPlagueRaces.Common.Races.Fluftrodons
{
	public class Fluftrodon : Race
	{
		public override int? LegacyId => 11;
		public static int FluftrodonPaintTileMode = -1;
		public static int FluftrodonPaintWallMode = -1;
		public static int FluftrodonPaintColor = 0;
		public bool FluftrodonPaintUI;
		public bool FluftrodonPaintUIPositionSet;

		public override bool PreHurt(Player player, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			playSound = false;

			return true;
		}

		public override void PostItemCheck(Player player, Mod mod)
		{
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();
			if (!modPlayer.GotLoreBook)
			{
				modPlayer.GotLoreBook = true;
				player.QuickSpawnItem(mod.ItemType("Race_Lore_Book_Fluftrodon"));
			}
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
				if (player.Male)
				{
					Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Fluftrodon_Hurt"));
				}
				else
				{
					Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Fluftrodon_Hurt_Female"));
				}
			}
			if (modPlayer.RaceStats)
			{
				if (FluftrodonPaintUI)
				{
					FluftrodonPaintUIPanel.Visible = true;
				}
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
			if (modPlayer.resetDefaultColors)
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
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();

			bool hideChestplate = modPlayer.hideChestplate;
			bool hideLeggings = modPlayer.hideLeggings;

			Main.playerTextures[0, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Head");
			Main.playerTextures[0, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Eyes_2");
			Main.playerTextures[0, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Eyes");
			Main.playerTextures[0, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Torso");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[0, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Sleeves_1");
			}
			else
			{
				Main.playerTextures[0, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_BackHand");
			}
			Main.playerTextures[0, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Hands");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[0, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Shirt_1");
			}
			else
			{
				Main.playerTextures[0, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			Main.playerTextures[0, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Arm");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[0, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Sleeve_1");
			}
			else
			{
				Main.playerTextures[0, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Torso_2");
			}
			Main.playerTextures[0, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Hand");
			Main.playerTextures[0, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Legs");
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[0, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_1");
				Main.playerTextures[0, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_1");
			}
			else
			{
				Main.playerTextures[0, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[0, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Legs_2");
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
			Main.playerTextures[1, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Head");
			Main.playerTextures[1, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Eyes_2");
			Main.playerTextures[1, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Eyes");
			Main.playerTextures[1, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Torso");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[1, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Sleeves_2");
			}
			else
			{
				Main.playerTextures[1, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_BackHand");
			}
			Main.playerTextures[1, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Hands");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[1, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_2");
			}
			else
			{
				Main.playerTextures[1, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			Main.playerTextures[1, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Arm");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[1, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Sleeve_2");
			}
			else
			{
				Main.playerTextures[1, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Torso_2");
			}
			Main.playerTextures[1, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Hand");
			Main.playerTextures[1, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Legs");
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[1, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_2");
				Main.playerTextures[1, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_2");
			}
			else
			{
				Main.playerTextures[1, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[1, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Legs_2");
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
			Main.playerTextures[2, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Head");
			Main.playerTextures[2, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Eyes_2");
			Main.playerTextures[2, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Eyes");
			Main.playerTextures[2, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Torso");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[2, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Sleeves_3");
			}
			else
			{
				Main.playerTextures[2, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_BackHand");
			}
			Main.playerTextures[2, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Hands");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[2, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_3");
			}
			else
			{
				Main.playerTextures[2, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			Main.playerTextures[2, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Arm");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[2, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Sleeve_3");
			}
			else
			{
				Main.playerTextures[2, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Torso_2");
			}
			Main.playerTextures[2, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Hand");
			Main.playerTextures[2, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Legs");
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[2, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_3");
				Main.playerTextures[2, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_3");
			}
			else
			{
				Main.playerTextures[2, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[2, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Legs_2");
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
			Main.playerTextures[3, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Head");
			Main.playerTextures[3, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Eyes_2");
			Main.playerTextures[3, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Eyes");
			Main.playerTextures[3, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Torso");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[3, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Sleeves_4");
			}
			else
			{
				Main.playerTextures[3, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_BackHand");
			}
			Main.playerTextures[3, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Hands");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[3, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Shirt_4");
			}
			else
			{
				Main.playerTextures[3, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			Main.playerTextures[3, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Arm");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[3, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Sleeve_4");
			}
			else
			{
				Main.playerTextures[3, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Torso_2");
			}
			Main.playerTextures[3, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Hand");
			Main.playerTextures[3, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Legs");
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[3, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_4");
				Main.playerTextures[3, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_4");
			}
			else
			{
				Main.playerTextures[3, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[3, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Legs_2");
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
			Main.playerTextures[8, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Head");
			Main.playerTextures[8, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Eyes_2");
			Main.playerTextures[8, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Eyes");
			Main.playerTextures[8, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Torso");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[8, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Sleeves_9");
			}
			else
			{
				Main.playerTextures[8, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_BackHand");
			}
			Main.playerTextures[8, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Hands");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[8, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Shirt_9");
			}
			else
			{
				Main.playerTextures[8, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			Main.playerTextures[8, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Arm");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[8, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Sleeve_9");
			}
			else
			{
				Main.playerTextures[8, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Torso_2");
			}
			Main.playerTextures[8, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Hand");
			Main.playerTextures[8, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Legs");
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[8, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_9");
				Main.playerTextures[8, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_9");
			}
			else
			{
				Main.playerTextures[8, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[8, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Legs_2");
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
			Main.playerTextures[4, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Head_Female");
			Main.playerTextures[4, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Eyes_2_Female");
			Main.playerTextures[4, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Eyes_Female");
			Main.playerTextures[4, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Torso_Female");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[4, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Sleeves_5");
			}
			else
			{
				Main.playerTextures[4, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_BackHand");
			}
			Main.playerTextures[4, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Hands_Female");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[4, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_5");
			}
			else
			{
				Main.playerTextures[4, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			Main.playerTextures[4, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Arm_Female");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[4, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Sleeve_5");
			}
			else
			{
				Main.playerTextures[4, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Torso_2");
			}
			Main.playerTextures[4, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Hand_Female");
			Main.playerTextures[4, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Legs_Female");
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[4, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_5");
				Main.playerTextures[4, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_5");
			}
			else
			{
				Main.playerTextures[4, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[4, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Legs_2");
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
			Main.playerTextures[5, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Head_Female");
			Main.playerTextures[5, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Eyes_2_Female");
			Main.playerTextures[5, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Eyes_Female");
			Main.playerTextures[5, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Torso_Female");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[5, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Sleeves_6");
			}
			else
			{
				Main.playerTextures[5, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_BackHand");
			}
			Main.playerTextures[5, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Hands_Female");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[5, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_6");
			}
			else
			{
				Main.playerTextures[5, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			Main.playerTextures[5, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Arm_Female");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[5, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Sleeve_6");
			}
			else
			{
				Main.playerTextures[5, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Torso_2");
			}
			Main.playerTextures[5, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Hand_Female");
			Main.playerTextures[5, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Legs_Female");
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[5, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_6");
				Main.playerTextures[5, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_6");
			}
			else
			{
				Main.playerTextures[5, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[5, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Legs_2");
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
			Main.playerTextures[6, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Head_Female");
			Main.playerTextures[6, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Eyes_2_Female");
			Main.playerTextures[6, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Eyes_Female");
			Main.playerTextures[6, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Torso_Female");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[6, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Sleeves_7");
			}
			else
			{
				Main.playerTextures[6, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_BackHand");
			}
			Main.playerTextures[6, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Hands_Female");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[6, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_7");
			}
			else
			{
				Main.playerTextures[6, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			Main.playerTextures[6, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Arm_Female");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[6, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Sleeve_7");
			}
			else
			{
				Main.playerTextures[6, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Torso_2");
			}
			Main.playerTextures[6, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Hand_Female");
			Main.playerTextures[6, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Legs_Female");
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[6, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_7");
				Main.playerTextures[6, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_7");
			}
			else
			{
				Main.playerTextures[6, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[6, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Legs_2");
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
			Main.playerTextures[7, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Head_Female");
			Main.playerTextures[7, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Eyes_2_Female");
			Main.playerTextures[7, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Eyes_Female");
			Main.playerTextures[7, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Torso_Female");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[7, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Sleeves_8");
			}
			else
			{
				Main.playerTextures[7, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_BackHand");
			}
			Main.playerTextures[7, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Hands_Female");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[7, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Shirt_8");
			}
			else
			{
				Main.playerTextures[7, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			Main.playerTextures[7, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Arm_Female");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[7, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Sleeve_8");
			}
			else
			{
				Main.playerTextures[7, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Torso_2");
			}
			Main.playerTextures[7, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Hand_Female");
			Main.playerTextures[7, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Legs_Female");
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[7, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_8");
				Main.playerTextures[7, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_8");
			}
			else
			{
				Main.playerTextures[7, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[7, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Legs_2");
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
			Main.playerTextures[9, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Head_Female");
			Main.playerTextures[9, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Eyes_2_Female");
			Main.playerTextures[9, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Eyes_Female");
			Main.playerTextures[9, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Torso_Female");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[9, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Sleeves_10");
			}
			else
			{
				Main.playerTextures[9, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_BackHand");
			}
			Main.playerTextures[9, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Hands_Female");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[9, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_10");
			}
			else
			{
				Main.playerTextures[9, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			Main.playerTextures[9, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Arm_Female");
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[9, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Sleeve_10");
			}
			else
			{
				Main.playerTextures[9, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Torso_2");
			}
			Main.playerTextures[9, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Hand");
			Main.playerTextures[9, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Legs");
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[9, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_10");
				Main.playerTextures[9, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_10");
			}
			else
			{
				Main.playerTextures[9, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[9, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Legs_2");
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
			Main.playerHairTexture[0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_1");
			Main.playerHairTexture[1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_2");
			Main.playerHairTexture[2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_3");
			Main.playerHairTexture[3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_4");
			Main.playerHairTexture[4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_5");
			Main.playerHairTexture[5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_6");
			Main.playerHairTexture[6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_7");
			Main.playerHairTexture[7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_8");
			Main.playerHairTexture[8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_9");
			Main.playerHairTexture[9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_10");
			Main.playerHairTexture[10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_11");
			Main.playerHairTexture[11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_12");
			Main.playerHairTexture[12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_13");
			Main.playerHairTexture[13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_14");
			Main.playerHairTexture[14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_15");
			Main.playerHairTexture[15] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_16");
			Main.playerHairTexture[16] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_17");
			Main.playerHairTexture[17] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_18");
			Main.playerHairTexture[18] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_19");
			Main.playerHairTexture[19] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_20");
			Main.playerHairTexture[20] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_21");
			Main.playerHairTexture[21] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_22");
			Main.playerHairTexture[22] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_23");
			Main.playerHairTexture[23] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_24");
			Main.playerHairTexture[24] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_25");
			Main.playerHairTexture[25] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_26");
			Main.playerHairTexture[26] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_27");
			Main.playerHairTexture[27] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_28");
			Main.playerHairTexture[28] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_29");
			Main.playerHairTexture[29] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_30");
			Main.playerHairTexture[30] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_31");
			Main.playerHairTexture[31] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_32");
			Main.playerHairTexture[32] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_33");
			Main.playerHairTexture[33] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_34");
			Main.playerHairTexture[34] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_35");
			Main.playerHairTexture[35] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_36");
			Main.playerHairTexture[36] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_37");
			Main.playerHairTexture[37] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_38");
			Main.playerHairTexture[38] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_39");
			Main.playerHairTexture[39] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_40");
			Main.playerHairTexture[40] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_41");
			Main.playerHairTexture[41] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_42");
			Main.playerHairTexture[42] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_43");
			Main.playerHairTexture[43] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_44");
			Main.playerHairTexture[44] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_45");
			Main.playerHairTexture[45] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_46");
			Main.playerHairTexture[46] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_47");
			Main.playerHairTexture[47] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_48");
			Main.playerHairTexture[48] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_49");
			Main.playerHairTexture[49] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_50");
			Main.playerHairTexture[50] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_Hair_51");
			Main.playerHairTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[52] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[53] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[54] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[55] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[56] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[57] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[58] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[59] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[60] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[61] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[62] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[63] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[64] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[65] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[66] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[67] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[68] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[69] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[70] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[71] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[72] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[73] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[74] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[75] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[76] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[77] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[78] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[79] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[80] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[81] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[82] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[83] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[84] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[85] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[86] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[87] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[88] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[89] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[90] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[91] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[92] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[93] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[94] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[95] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[96] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[97] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[98] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[99] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[100] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[101] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[102] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[103] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[104] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[105] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[106] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[107] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[108] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[109] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[110] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[111] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[112] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[113] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[114] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[115] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[116] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[117] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[118] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[119] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[120] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[121] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[122] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[123] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[124] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[125] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[126] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[127] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[128] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[129] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[130] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[131] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[132] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairTexture[133] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[15] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[16] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[17] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[18] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[19] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[20] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[21] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[22] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[23] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[24] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[25] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[26] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[27] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[28] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[29] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[30] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[31] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[32] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[33] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[34] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[35] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[36] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[37] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[38] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[39] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[40] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[41] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[42] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[43] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[44] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[45] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[46] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[47] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[48] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[49] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[50] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[52] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[53] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[54] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[55] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[56] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[57] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[58] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[59] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[60] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[61] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[62] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[63] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[64] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[65] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[66] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[67] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[68] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[69] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[70] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[71] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[72] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[73] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[74] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[75] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[76] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[77] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[78] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[79] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[80] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[81] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[82] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[83] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[84] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[85] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[86] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[87] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[88] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[89] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[90] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[91] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[92] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[93] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[94] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[95] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[96] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[97] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[98] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[99] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[100] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[101] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[102] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[103] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[104] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[105] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[106] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[107] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[108] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[109] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[110] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[111] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[112] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[113] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[114] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[115] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[116] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[117] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[118] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[119] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[120] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[121] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[122] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[123] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[124] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[125] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[126] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[127] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[128] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[129] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[130] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[131] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[132] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.playerHairAltTexture[133] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Hair/Fluftrodon_HairAlt");
			Main.ghostTexture = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Fluftrodon/Fluftrodon_Ghost");
		}
	}
}
