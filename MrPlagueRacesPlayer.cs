using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using MrPlagueRaces.Content.Mounts;
using MrPlagueRaces.Common.UI;
using MrPlagueRaces.Common.Races;
using MrPlagueRaces.Common.Races.Humans;

namespace MrPlagueRaces
{
	public class MrPlagueRacesPlayer : ModPlayer
	{
		public static int PlayerRaceStatic = -1;
		public static int FluftrodonPaintTileMode = -1;
		public static int FluftrodonPaintWallMode = -1;
		public static int FluftrodonPaintColor = 0;

		public Race race;
		public bool MrPlagueRacesNonStopParty;
		//public int PlayerRace = -1;
		public bool RaceStats = true;
		public bool GotStatToggler;
		public bool GotLoreBook;
		public bool hideArmor;
		public bool hideHelmet;
		public bool hideChestplate;
		public bool hideLeggings;
		public int kenkuWingAnim;
		public int kenkuWingFrame;
		public int kenkuWingTime = 40;
		public int kenkuFallDamagePrevention;
		public int merfolkBreathHurt;
		public int merfolkBreathControl = 7;
		public int merfolkBreathControl2 = 200;
		public bool mushfolkHideCap;
		public bool VampireTransformation;
		public bool VampireTransformationDust;
		public int vampireWingAnim;
		public int vampireWingFrame;
		public int vampireWalkAnim ;
		public bool FluftrodonPaintUI;
		public bool IsNewCharacter1;
		public bool FluftrodonPaintUIPositionSet;
		private bool resetDefaultColors = true;

		public override void Initialize()
		{
			race = ModContent.GetInstance<Human>();
		}

		public override TagCompound Save()
		{
			return new TagCompound
			{
				{ "Race", race.FullName },
				{ "RaceStats", RaceStats },
				{ "GotStatToggler", GotStatToggler },
				{ "GotLoreBook", GotLoreBook },
				{ "IsNewCharacter1", IsNewCharacter1 }
			};
		}

		public override void Load(TagCompound tag)
		{
			resetDefaultColors = false;

			if ((tag.ContainsKey("Race") && RaceLoader.TryGetRace(tag.GetString("Race"), out var loadedRace)) //Type name
			|| (tag.ContainsKey("PlayerRace") && RaceLoader.TryGetRaceFromLegacyId(tag.GetInt("PlayerRace"), out loadedRace))) //Legacy Id
			{
				race = loadedRace;
			}

			RaceStats = tag.GetBool("RaceStats");
			GotStatToggler = tag.GetBool("GotStatToggler");
			GotLoreBook = tag.GetBool("GotLoreBook");
			IsNewCharacter1 = tag.GetBool("IsNewCharacter1");

			race.Load(player, tag);

			if (race is Common.Races.Dragonkins.Dragonkin)
			{
				player.statLife += 25;
			}

			if (race is Common.Races.Mushfolks.Mushfolk)
			{
				player.statLife += 20;
			}
		}
		
		public override void clientClone(ModPlayer clientClone) 
		{
			MrPlagueRacesPlayer clone = clientClone as MrPlagueRacesPlayer;
			clone.MrPlagueRacesNonStopParty = MrPlagueRacesNonStopParty;
		}

		public override void SyncPlayer(int toWho, int fromWho, bool newPlayer) 
		{
			ModPacket packet = mod.GetPacket();
			packet.Write((byte)MrPlagueRacesMessageType.MrPlagueRacesPlayerSyncPlayer);
			packet.Write((byte)player.whoAmI);
			packet.Write(race.Id);
			packet.Write(RaceStats);
			packet.Write(GotStatToggler);
			packet.Write(GotLoreBook);
			packet.Write(IsNewCharacter1);
			packet.Write(MrPlagueRacesNonStopParty);
			packet.Send(toWho, fromWho);
		}

		public override void SendClientChanges(ModPlayer clientPlayer) 
		{
			MrPlagueRacesPlayer clone = clientPlayer as MrPlagueRacesPlayer;
			if (clone.MrPlagueRacesNonStopParty != MrPlagueRacesNonStopParty) 
			{
				var packet = mod.GetPacket();
				packet.Write((byte)MrPlagueRacesMessageType.MrPlagueRacesNonStopPartyChanged);
				packet.Write((byte)player.whoAmI);
				packet.Write(MrPlagueRacesNonStopParty);
				packet.Send();
			}
		}

		public override void ResetEffects()
		{
			if (RaceStats)
			{
				race.ResetEffects(player);

				if (race is Common.Races.Goblins.Goblin)
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
				if (race is Common.Races.Kenkus.Kenku)
				{
					player.statLifeMax2 -= (player.statLifeMax2 / 5);
					player.statDefense -= 8;
					player.allDamage += 0.15f;
					player.magicCrit += 10;
					player.rangedCrit += 10;
					player.meleeCrit += 10;
					player.moveSpeed += 0.25f;
					player.wingTimeMax += player.wingTimeMax / 2;
				}
				if (race is Common.Races.Tabaxis.Tabaxi)
				{
					player.statDefense -= 4;
					player.allDamage -= 0.1f;
					player.moveSpeed += 0.4f;
					player.tileSpeed += 0.25f;
					player.wallSpeed += 0.25f;
					player.pickSpeed -= 0.25f;
					if (player.spikedBoots <= 0)
					{
						player.spikedBoots = 1;
					}
					player.jumpSpeedBoost += 0.35f;
					player.nightVision = true;
					if (player.statLife <= (player.statLifeMax2 / 4))
					{
						player.noFallDmg = true;
						player.dangerSense = true;
					}
					player.accFlipper = true;
				}
				if (race is Common.Races.Dragonkins.Dragonkin)
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
				if (race is Common.Races.Merfolks.Merfolk)
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
				if (race is Common.Races.Mushfolks.Mushfolk)
				{
					player.statLifeMax2 += (player.statLifeMax2 / 10);
					player.allDamage -= 0.15f;
					player.maxMinions += 2;
					player.moveSpeed += 0.1f;
				}
				if (race is Common.Races.Derpkins.Derpkin)
				{
					player.statLifeMax2 -= (player.statLifeMax2 / 10);
					player.statDefense -= 4;
					player.allDamage += 0.1f;
					player.moveSpeed += 0.25f;
					player.jumpSpeedBoost += 0.6f;
					player.autoJump = true;
				}
				if (race is Common.Races.Kobolds.Kobold)
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
				if (race is Common.Races.Skeletons.Skeleton)
				{
					player.statLifeMax2 -= (player.statLifeMax2 / 4);
					player.statDefense -= 4;
					player.magicDamage += 0.2f;
					player.statManaMax2 += 50;
					player.moveSpeed += 0.15f;
					player.gills = true;
				}
				if (race is Common.Races.Vampires.Vampire)
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
				if (race is Common.Races.Fluftrodons.Fluftrodon)
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
		}

		public override void PostItemCheck()
		{
			if (!GotStatToggler)
			{
				GotStatToggler = true;
				RaceStats = true;
				player.QuickSpawnItem(mod.ItemType("Stat_Toggler"));
			}
			if (!GotLoreBook)
			{
				if (race is Common.Races.Humans.Human)
				{
					GotLoreBook = true;
					player.QuickSpawnItem(mod.ItemType("Race_Lore_Book_Human"));
				}
				if (race is Common.Races.Goblins.Goblin)
				{
					GotLoreBook = true;
					player.QuickSpawnItem(mod.ItemType("Race_Lore_Book_Goblin"));
				}
				if (race is Common.Races.Kenkus.Kenku)
				{
					GotLoreBook = true;
					player.QuickSpawnItem(mod.ItemType("Race_Lore_Book_Kenku"));
				}
				if (race is Common.Races.Tabaxis.Tabaxi)
				{
					GotLoreBook = true;
					player.QuickSpawnItem(mod.ItemType("Race_Lore_Book_Tabaxi"));
				}
				if (race is Common.Races.Dragonkins.Dragonkin)
				{
					GotLoreBook = true;
					player.QuickSpawnItem(mod.ItemType("Race_Lore_Book_Dragonkin"));
				}
				if (race is Common.Races.Merfolks.Merfolk)
				{
					GotLoreBook = true;
					player.QuickSpawnItem(mod.ItemType("Race_Lore_Book_Merfolk"));
					player.QuickSpawnItem(mod.ItemType("Merfolk_Water_Generator"));
				}
				if (race is Common.Races.Mushfolks.Mushfolk)
				{
					GotLoreBook = true;
					player.QuickSpawnItem(mod.ItemType("Race_Lore_Book_Mushfolk"));
				}
				if (race is Common.Races.Derpkins.Derpkin)
				{
					GotLoreBook = true;
					player.QuickSpawnItem(mod.ItemType("Race_Lore_Book_Derpkin"));
				}
				if (race is Common.Races.Kobolds.Kobold)
				{
					GotLoreBook = true;
					player.QuickSpawnItem(mod.ItemType("Race_Lore_Book_Kobold"));
				}
				if (race is Common.Races.Skeletons.Skeleton)
				{
					GotLoreBook = true;
					player.QuickSpawnItem(mod.ItemType("Race_Lore_Book_Skeleton"));
				}
				if (race is Common.Races.Vampires.Vampire)
				{
					GotLoreBook = true;
					player.QuickSpawnItem(mod.ItemType("Race_Lore_Book_Vampire"));
				}
				if (race is Common.Races.Fluftrodons.Fluftrodon)
				{
					GotLoreBook = true;
					player.QuickSpawnItem(mod.ItemType("Race_Lore_Book_Fluftrodon"));
				}
			}
		}

		private void HideArmor()
		{
			player.head = -1;
			player.body = -1;
			player.legs = -1;
			player.handon = -1;
			player.handoff = -1;
			player.back = -1;
			player.front = -1;
			player.shoe = -1;
			player.waist = -1;
			player.shield = -1;
			player.neck = -1;
			player.face = -1;
			player.balloon = -1;
			player.wings = -1;
		}
		private void HideHelmet()
		{
			player.head = -1;
		}
		private void HideChestplate()
		{
			player.body = -1;
		}
		private void HideLeggings()
		{
			player.legs = -1;
		}

		public override void FrameEffects()
		{
			if (hideArmor)
			{
				HideArmor();
			}
			if (hideHelmet)
			{
				HideHelmet();
			}
			if (hideChestplate)
			{
				HideChestplate();
			}
			if (hideLeggings)
			{
				HideLeggings();
			}
		}

		bool ExposedToSky()
		{
			bool hasCeilingTile = false;
			Point playerTileCoordinate = player.Center.ToTileCoordinates();
			Vector2 playerLocation = new Vector2(player.Center.X / 16, player.Center.Y / 16);
			for (int i = 0; i < 60; i++)
			{
				Tile ceilingTile = Main.tile[(int)playerLocation.X, (int)playerLocation.Y];
				if (ceilingTile != null && Main.tileSolid[ceilingTile.type] && ceilingTile.nactive())
				{
					hasCeilingTile = true;
				}
				if (playerLocation.Y > 0)
				{
					playerLocation.Y -= 1;
				}
			}
			return !(playerTileCoordinate.Y <= Main.maxTilesY - 200 && (double)playerTileCoordinate.Y > Main.rockLayer) && !hasCeilingTile;
		}

		bool ExposedToSunlight()
		{
			Tile[] smallWallTiles = new Tile[2];
			Point playerTilePointSmall = (Main.LocalPlayer.position / 16).ToPoint();
			smallWallTiles[0] = Framing.GetTileSafely(playerTilePointSmall.X, playerTilePointSmall.Y);
			smallWallTiles[1] = Framing.GetTileSafely(playerTilePointSmall.X + 1, playerTilePointSmall.Y);
			bool behindSmallWall = false;
			foreach (var tile in smallWallTiles)
			{
				if (tile.wall > 0)
				{
					behindSmallWall = true;
				}
				else
				{
					behindSmallWall = false;
					break;
				}
			}
			Tile[] wallTiles = new Tile[6];
			Point playerTilePoint = (Main.LocalPlayer.position / 16).ToPoint();
			wallTiles[0] = Framing.GetTileSafely(playerTilePoint.X, playerTilePoint.Y);
			wallTiles[1] = Framing.GetTileSafely(playerTilePoint.X, playerTilePoint.Y + 1);
			wallTiles[2] = Framing.GetTileSafely(playerTilePoint.X, playerTilePoint.Y + 2);
			wallTiles[3] = Framing.GetTileSafely(playerTilePoint.X + 1, playerTilePoint.Y);
			wallTiles[4] = Framing.GetTileSafely(playerTilePoint.X + 1, playerTilePoint.Y + 1);
			wallTiles[5] = Framing.GetTileSafely(playerTilePoint.X + 1, playerTilePoint.Y + 2);
			bool behindWall = false;
			foreach (var tile in wallTiles)
			{
				if (tile.wall > 0)
				{
					behindWall = true;
				}
				else
				{
					behindWall = false;
					break;
				}
			}
			Tile[] largeWallTiles = new Tile[36];
			Point playerTilePointLarge = (Main.LocalPlayer.position / 16).ToPoint();
			largeWallTiles[0] = Framing.GetTileSafely(playerTilePointLarge.X, playerTilePointLarge.Y - 15);
			largeWallTiles[1] = Framing.GetTileSafely(playerTilePointLarge.X, playerTilePointLarge.Y - 14);
			largeWallTiles[2] = Framing.GetTileSafely(playerTilePointLarge.X, playerTilePointLarge.Y - 13);
			largeWallTiles[3] = Framing.GetTileSafely(playerTilePointLarge.X, playerTilePointLarge.Y - 12);
			largeWallTiles[4] = Framing.GetTileSafely(playerTilePointLarge.X, playerTilePointLarge.Y - 11);
			largeWallTiles[5] = Framing.GetTileSafely(playerTilePointLarge.X, playerTilePointLarge.Y - 10);
			largeWallTiles[6] = Framing.GetTileSafely(playerTilePointLarge.X, playerTilePointLarge.Y - 9);
			largeWallTiles[7] = Framing.GetTileSafely(playerTilePointLarge.X, playerTilePointLarge.Y - 8);
			largeWallTiles[8] = Framing.GetTileSafely(playerTilePointLarge.X, playerTilePointLarge.Y - 7);
			largeWallTiles[9] = Framing.GetTileSafely(playerTilePointLarge.X, playerTilePointLarge.Y - 6);
			largeWallTiles[10] = Framing.GetTileSafely(playerTilePointLarge.X, playerTilePointLarge.Y - 5);
			largeWallTiles[11] = Framing.GetTileSafely(playerTilePointLarge.X, playerTilePointLarge.Y - 4);
			largeWallTiles[12] = Framing.GetTileSafely(playerTilePointLarge.X, playerTilePointLarge.Y - 3);
			largeWallTiles[13] = Framing.GetTileSafely(playerTilePointLarge.X, playerTilePointLarge.Y - 2);
			largeWallTiles[14] = Framing.GetTileSafely(playerTilePointLarge.X, playerTilePointLarge.Y - 1);
			largeWallTiles[15] = Framing.GetTileSafely(playerTilePointLarge.X, playerTilePointLarge.Y);
			largeWallTiles[16] = Framing.GetTileSafely(playerTilePointLarge.X, playerTilePointLarge.Y + 1);
			largeWallTiles[17] = Framing.GetTileSafely(playerTilePointLarge.X, playerTilePointLarge.Y + 2);
			largeWallTiles[18] = Framing.GetTileSafely(playerTilePointLarge.X + 1, playerTilePointLarge.Y - 15);
			largeWallTiles[19] = Framing.GetTileSafely(playerTilePointLarge.X + 1, playerTilePointLarge.Y - 14);
			largeWallTiles[20] = Framing.GetTileSafely(playerTilePointLarge.X + 1, playerTilePointLarge.Y - 13);
			largeWallTiles[21] = Framing.GetTileSafely(playerTilePointLarge.X + 1, playerTilePointLarge.Y - 12);
			largeWallTiles[22] = Framing.GetTileSafely(playerTilePointLarge.X + 1, playerTilePointLarge.Y - 11);
			largeWallTiles[23] = Framing.GetTileSafely(playerTilePointLarge.X + 1, playerTilePointLarge.Y - 10);
			largeWallTiles[24] = Framing.GetTileSafely(playerTilePointLarge.X + 1, playerTilePointLarge.Y - 9);
			largeWallTiles[25] = Framing.GetTileSafely(playerTilePointLarge.X + 1, playerTilePointLarge.Y - 8);
			largeWallTiles[26] = Framing.GetTileSafely(playerTilePointLarge.X + 1, playerTilePointLarge.Y - 7);
			largeWallTiles[27] = Framing.GetTileSafely(playerTilePointLarge.X + 1, playerTilePointLarge.Y - 6);
			largeWallTiles[28] = Framing.GetTileSafely(playerTilePointLarge.X + 1, playerTilePointLarge.Y - 5);
			largeWallTiles[29] = Framing.GetTileSafely(playerTilePointLarge.X + 1, playerTilePointLarge.Y - 4);
			largeWallTiles[30] = Framing.GetTileSafely(playerTilePointLarge.X + 1, playerTilePointLarge.Y - 3);
			largeWallTiles[31] = Framing.GetTileSafely(playerTilePointLarge.X + 1, playerTilePointLarge.Y - 2);
			largeWallTiles[32] = Framing.GetTileSafely(playerTilePointLarge.X + 1, playerTilePointLarge.Y - 1);
			largeWallTiles[33] = Framing.GetTileSafely(playerTilePointLarge.X + 1, playerTilePointLarge.Y);
			largeWallTiles[34] = Framing.GetTileSafely(playerTilePointLarge.X + 1, playerTilePointLarge.Y + 1);
			largeWallTiles[35] = Framing.GetTileSafely(playerTilePointLarge.X + 1, playerTilePointLarge.Y + 2);
			bool behindLargeWall = false;
			foreach (var tile in largeWallTiles)
			{
				if (tile.wall > 0)
				{
					behindLargeWall = true;
				}
				else
				{
					behindLargeWall = false;
					break;
				}
			}
			bool hasCeilingTile = false;
			Vector2 playerLocation = new Vector2(player.Center.X / 16, player.Center.Y / 16);
			for (int i = 0; i < 60; i++)
			{
				Tile ceilingTile = Main.tile[(int)playerLocation.X, (int)playerLocation.Y];
				if (ceilingTile != null && Main.tileSolid[ceilingTile.type] && ceilingTile.nactive())
				{
					hasCeilingTile = true;
				}
				if (playerLocation.Y > 0)
				{
					playerLocation.Y -= 1;
				}
			}
			bool hasCeilingAbove = false;
			if (behindLargeWall || hasCeilingTile)
			{
				hasCeilingAbove = true;
			}
			else
			{
				hasCeilingAbove = false;
			}
			if (!VampireTransformation)
			{
				return (!hasCeilingAbove || !behindWall) && !((double)player.Center.Y > Main.worldSurface * 16.0) && Main.dayTime && !(Collision.DrownCollision(player.position, player.width, player.height, player.gravDir));
			}
			else
			{
				return (!hasCeilingAbove || !behindSmallWall) && !((double)player.Center.Y > Main.worldSurface * 16.0) && Main.dayTime && !(Collision.DrownCollision(player.position, player.width, player.height, player.gravDir));
			}
		}

		public override void ModifyDrawInfo(ref PlayerDrawInfo drawInfo)
		{
			Item familiarshirt = new Item();
			familiarshirt.SetDefaults(ItemID.FamiliarShirt);

			Item familiarpants = new Item();
			familiarpants.SetDefaults(ItemID.FamiliarPants);

			if (player.armor[0].type == mod.ItemType("AInvisibleHead") && player.armor[10].type < ItemID.IronPickaxe || player.armor[10].type == mod.ItemType("AInvisibleHead"))
			{
				hideHelmet = true;
				player.head = -1;
			}
			else
			{
				hideHelmet = false;
			}
			if (player.armor[1].type == mod.ItemType("BInvisibleBody") && player.armor[11].type < ItemID.IronPickaxe || player.armor[11].type == mod.ItemType("BInvisibleBody"))
			{
				hideChestplate = true;
				player.body = -1;
			}
			else
			{
				hideChestplate = false;
			}
			if (player.armor[2].type == mod.ItemType("CInvisibleLegs") && player.armor[12].type < ItemID.IronPickaxe || player.armor[12].type == mod.ItemType("CInvisibleLegs"))
			{
				hideLeggings = true;
				player.legs = -1;
			}
			else
			{
				hideLeggings = false;
			}

			if (race is Common.Races.Kenkus.Kenku && !IsNewCharacter1)
			{
				player.eyeColor = new Color(player.eyeColor.R - 250, player.eyeColor.G - 250, player.eyeColor.B - 250);
				player.skinColor = new Color(player.skinColor.R + 40, player.skinColor.G + 40, player.skinColor.B + 40);
			}
			if (race is Common.Races.Tabaxis.Tabaxi && !IsNewCharacter1)
			{
				player.hairColor = new Color(239, 119, 157);
				player.eyeColor = new Color(102, 255, 157);
				player.skinColor = new Color(player.skinColor.R + 40, player.skinColor.G + 40, player.skinColor.B + 40);
			}
			if (race is Common.Races.Dragonkins.Dragonkin && !IsNewCharacter1)
			{
				player.skinColor = new Color(player.skinColor.R + 60, player.skinColor.G + 60, player.skinColor.B + 60);
			}
			if (race is Common.Races.Merfolks.Merfolk && !IsNewCharacter1)
			{
				player.skinColor = new Color(player.skinColor.R + 40, player.skinColor.G + 40, player.skinColor.B + 40);
			}
			if (race is Common.Races.Mushfolks.Mushfolk && !IsNewCharacter1)
			{
				player.hairColor = new Color(player.hairColor.R - 40, player.hairColor.G - 40, player.hairColor.B - 40);
				player.eyeColor = new Color(player.eyeColor.R - 40, player.eyeColor.G - 40, player.eyeColor.B - 40);
			}
			if (!IsNewCharacter1)
			{
				IsNewCharacter1 = true;
			}

			if (resetDefaultColors)
			{
				resetDefaultColors = false;

				if (race is Common.Races.Humans.Human)
				{
					player.hairColor = new Color(200, 81, 57);
					player.skinColor = new Color(243, 131, 102);
					player.eyeColor = new Color(85, 82, 99);
					player.shirtColor = new Color(190, 160, 125);
					player.underShirtColor = new Color(140, 157, 207);
					player.pantsColor = new Color(255, 225, 158);
					player.shoeColor = new Color(160, 84, 60);
					player.skinVariant = 0;
					if (player.armor[1].type < ItemID.IronPickaxe && player.armor[2].type < ItemID.IronPickaxe)
					{
						player.armor[1] = familiarshirt;
						player.armor[2] = familiarpants;
					}
				}
				else if (race is Common.Races.Goblins.Goblin)
				{
					player.hairColor = new Color(58, 61, 53);
					player.skinColor = new Color(147, 144, 86);
					player.eyeColor = new Color(112, 42, 36);
					player.underShirtColor = new Color(130, 98, 116);
					player.pantsColor = new Color(111, 100, 97);
					player.shoeColor = new Color(110, 93, 89);
					player.skinVariant = 2;
					if (player.armor[1].type < ItemID.IronPickaxe && player.armor[2].type < ItemID.IronPickaxe)
					{
						player.armor[1] = familiarshirt;
						player.armor[2] = familiarpants;
					}
				}
				else if (race is Common.Races.Kenkus.Kenku)
				{
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
				else if (race is Common.Races.Tabaxis.Tabaxi)
				{
					player.hairColor = new Color(239, 119, 157);
					player.skinColor = new Color(207, 183, 127);
					player.eyeColor = new Color(102, 255, 157);
					player.shirtColor = new Color(141, 100, 62);
					player.underShirtColor = new Color(109, 83, 69);
					player.skinVariant = 3;
					if (player.armor[1].type < ItemID.IronPickaxe && player.armor[2].type < ItemID.IronPickaxe)
					{
						player.armor[1] = familiarshirt;
						player.armor[2] = familiarpants;
					}
				}
				else if (race is Common.Races.Dragonkins.Dragonkin)
				{
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
				else if (race is Common.Races.Merfolks.Merfolk)
				{
					player.hairColor = new Color(94, 236, 135);
					player.skinColor = new Color(94, 236, 135);
					player.eyeColor = new Color(251, 57, 135);
					player.skinVariant = 0;
				}
				else if (race is Common.Races.Mushfolks.Mushfolk)
				{
					player.hairColor = new Color(104, 138, 233);
					player.skinColor = new Color(222, 209, 184);
					player.eyeColor = new Color(104, 138, 233);
					player.skinVariant = 0;
				}
				else if (race is Common.Races.Derpkins.Derpkin)
				{
					player.hairColor = new Color(82, 179, 255);
					player.skinColor = new Color(82, 179, 255);
					player.eyeColor = new Color(99, 122, 207);
					player.skinVariant = 0;
				}
				else if (race is Common.Races.Kobolds.Kobold)
				{
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
				else if (race is Common.Races.Skeletons.Skeleton)
				{
					player.hairColor = new Color(208, 195, 151);
					player.skinColor = new Color(208, 195, 151);
					player.eyeColor = new Color(226, 77, 127);
					player.shirtColor = new Color(157, 107, 107);
					player.underShirtColor = new Color(157, 107, 107);
					player.pantsColor = new Color(188, 158, 127);
					player.shoeColor = new Color(95, 81, 69);
					player.skinVariant = 0;
					if (player.armor[1].type < ItemID.IronPickaxe && player.armor[2].type < ItemID.IronPickaxe)
					{
						player.armor[1] = familiarshirt;
						player.armor[2] = familiarpants;
					}
				}
				else if (race is Common.Races.Vampires.Vampire)
				{
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
				else if (race is Common.Races.Fluftrodons.Fluftrodon)
				{
					player.hairColor = new Color(123, 125, 192);
					player.skinColor = new Color(170, 199, 233);
					player.eyeColor = new Color(58, 76, 102);
					player.underShirtColor = new Color(132, 152, 188);
					player.shoeColor = new Color(132, 152, 188);
					player.skinVariant = 1;
				}
			}
			if (race is Common.Races.Tabaxis.Tabaxi || race is Common.Races.Fluftrodons.Fluftrodon)
			{
				drawInfo.drawAltHair = true;
			}
			if (race is Common.Races.Mushfolks.Mushfolk && drawInfo.drawHair)
			{
				mushfolkHideCap = false;
			}
			if (race is Common.Races.Mushfolks.Mushfolk && !drawInfo.drawHair)
			{
				mushfolkHideCap = true;
			}
			if (RaceStats)
			{
				if (race is Common.Races.Kenkus.Kenku)
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
										Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Kenku_Wing_Flap"));
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

				if (race is Common.Races.Merfolks.Merfolk && (Collision.DrownCollision(player.position, player.width, player.height, player.gravDir)))
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
				if (race is Common.Races.Vampires.Vampire && VampireTransformation)
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
									Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Kenku_Wing_Flap"));
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
				if (race is Common.Races.Fluftrodons.Fluftrodon)
				{
					player.underShirtColor = player.hairColor;
					player.shoeColor = player.hairColor;
				}
			}
		}

		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			if (RaceStats)
			{
				if (MrPlagueRaces.RacialAbilityHotKey.JustPressed)
				{
					if (race is Common.Races.Fluftrodons.Fluftrodon)
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
				}
				if (MrPlagueRaces.RacialAbilityHotKey.JustReleased)
				{
					if (race is Common.Races.Fluftrodons.Fluftrodon)
					{
						FluftrodonPaintUIPositionSet = false;
					}
				}
				if (MrPlagueRaces.RacialAbilityHotKey.Current)
				{
					if (race is Common.Races.Kobolds.Kobold)
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
					if (race is Common.Races.Vampires.Vampire)
					{
						player.AddBuff(mod.BuffType("VampireBat"), 2);
					}
				}
			}
		}

		public override void OnRespawn(Player player)
		{
			if (RaceStats)
			{
			}
		}

		public override void PreUpdate()
		{
			if (player.HasBuff(mod.BuffType("DetectHurt")) && (player.statLife != player.statLifeMax2))
			{
				if (player.Male)
				{
					if (race is Common.Races.Goblins.Goblin)
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Goblin_Hurt"));
					}
					else if (race is Common.Races.Kenkus.Kenku)
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Kenku_Hurt"));
					}
					else if (race is Common.Races.Tabaxis.Tabaxi)
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Tabaxi_Hurt"));
					}
					else if (race is Common.Races.Dragonkins.Dragonkin)
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Dragonkin_Hurt"));
					}
					else if (race is Common.Races.Merfolks.Merfolk)
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Merfolk_Hurt"));
					}
					else if (race is Common.Races.Mushfolks.Mushfolk)
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Mushfolk_Hurt"));
					}
					else if (race is Common.Races.Derpkins.Derpkin)
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Derpkin_Hurt"));
					}
					else if (race is Common.Races.Kobolds.Kobold)
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Kobold_Hurt"));
					}
					else if (race is Common.Races.Skeletons.Skeleton)
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Skeleton_Hurt"));
					}
					else if (race is Common.Races.Vampires.Vampire)
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Vampire_Hurt"));
					}
					else if (race is Common.Races.Fluftrodons.Fluftrodon)
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Fluftrodon_Hurt"));
					}
					else
					{

					}
				}
				else
				{
					if (race is Common.Races.Goblins.Goblin)
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Goblin_Hurt_Female"));
					}
					else if (race is Common.Races.Kenkus.Kenku)
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Kenku_Hurt"));
					}
					else if (race is Common.Races.Tabaxis.Tabaxi)
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Tabaxi_Hurt_Female"));
					}
					else if (race is Common.Races.Dragonkins.Dragonkin)
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Dragonkin_Hurt_Female"));
					}
					else if (race is Common.Races.Merfolks.Merfolk)
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Merfolk_Hurt"));
					}
					else if (race is Common.Races.Mushfolks.Mushfolk)
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Mushfolk_Hurt"));
					}
					else if (race is Common.Races.Derpkins.Derpkin)
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Derpkin_Hurt_Female"));
					}
					else if (race is Common.Races.Kobolds.Kobold)
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Kobold_Hurt_Female"));
					}
					else if (race is Common.Races.Skeletons.Skeleton)
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Skeleton_Hurt"));
					}
					else if (race is Common.Races.Vampires.Vampire)
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Vampire_Hurt_Female"));
					}
					else if (race is Common.Races.Fluftrodons.Fluftrodon)
					{
						Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Fluftrodon_Hurt_Female"));
					}
					else
					{

					}
				}
			}
			if (RaceStats)
			{
				if (race is Common.Races.Kenkus.Kenku)
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

				if (race is Common.Races.Dragonkins.Dragonkin)
				{
					player.buffImmune[24] = true;
					player.buffImmune[39] = true;
					player.buffImmune[153] = true;
					player.buffImmune[67] = true;
				}

				if (race is Common.Races.Merfolks.Merfolk)
				{
					if (player.dead)
					{
						merfolkBreathControl = 0;
						merfolkBreathControl2 = 200;
					}
					if (Collision.DrownCollision(player.position, player.width, player.height, player.gravDir) || player.armor[0].type == ItemID.FishBowl || Main.raining && ExposedToSky())
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

				if (race is Common.Races.Mushfolks.Mushfolk)
				{
					if (!player.dead)
					{
						Projectile.NewProjectile((player.position.X + 10), (player.position.Y + 15), 0, 0, mod.ProjectileType("MushfolkHeal"), 0, 0f, player.whoAmI);
					}
				}
				if (race is Common.Races.Kobolds.Kobold)
				{
					Lighting.AddLight((int)(player.position.X + (float)(player.width / 2)) / 16, (int)(player.position.Y + (float)(player.height / 2)) / 16, 0.8f, 0.95f, 1f);
					if (ExposedToSunlight() && Main.myPlayer == player.whoAmI && !((player.inventory[player.selectedItem].type == ItemID.Umbrella) || (player.armor[0].type == ItemID.UmbrellaHat)))
					{
						player.AddBuff(mod.BuffType("KoboldSunlight"), 2);
					}
				}

				if (race is Common.Races.Skeletons.Skeleton)
				{
					player.buffImmune[20] = true;
					player.buffImmune[70] = true;
					player.buffImmune[30] = true;
					player.breath = 300;
				}
				if (race is Common.Races.Vampires.Vampire)
				{
					if (player.HasBuff(mod.BuffType("VampireBat")))
					{
						hideArmor = true;
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
						hideArmor = false;
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
					if (ExposedToSunlight() && Main.myPlayer == player.whoAmI && !((player.inventory[player.selectedItem].type == ItemID.Umbrella) || (player.armor[0].type == ItemID.UmbrellaHat)))
					{
						player.AddBuff(mod.BuffType("VampireBurn"), 2);
					}
				}
				if (race is Common.Races.Fluftrodons.Fluftrodon)
				{
					if (FluftrodonPaintUI)
					{
						FluftrodonPaintUIPanel.Visible = true;
					}
					if (!FluftrodonPaintUI)
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
		}

		public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			player.AddBuff(mod.BuffType("DetectHurt"), 1);

			return race.PreHurt(player, pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
		}

		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			if (playSound)
			{
				if (race is Common.Races.Kenkus.Kenku)
				{
					playSound = false;
					Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Kenku_Killed"));
				}
				else if (race is Common.Races.Mushfolks.Mushfolk)
				{
					playSound = false;
					Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Mushfolk_Killed"));
				}
				else if (race is Common.Races.Derpkins.Derpkin)
				{
					playSound = false;
					Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Derpkin_Killed"));
				}
				else if (race is Common.Races.Skeletons.Skeleton)
				{
					playSound = false;
					Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Skeleton_Killed"));
				}
				else
				{
					playSound = true;
				}

			}
			return true;
		}

		public override void ModifyDrawLayers(List<PlayerLayer> layers) 
		{
			race.ModifyDrawLayers(player, layers);
		}
	}
}