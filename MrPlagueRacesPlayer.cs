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
using MrPlagueRaces.Common.Races._999999_Humans;
using MrPlagueRaces.Common.Races._999991_Vampires;

namespace MrPlagueRaces
{
	public class MrPlagueRacesPlayer : ModPlayer
	{
		public static int PlayerRaceStatic = -1;
		public static Race StaticRace;
		public Race race;
		public bool MrPlagueRacesNonStopParty;
		public bool RaceStats = true;
		public bool GotStatToggler;
		public bool GotRaceItems;
		public bool hideArmor;
		public bool hideHelmet;
		public bool hideChestplate;
        public bool hideLeggings;
        public bool MrPlagueRaceInfo;
        public int MrPlagueRaceInfoMouseX = 0;
		public int MrPlagueRaceInfoMouseY = 0;

        public bool IsNewCharacter1;
		public bool IsNewCharacter2;

		public bool resetDefaultColors = true;

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
				{ "GotRaceItems", GotRaceItems },
				{ "IsNewCharacter1", IsNewCharacter1 },
				{ "IsNewCharacter2", IsNewCharacter2 }
			};
		}

        public override void Load(TagCompound tag)
        {
            resetDefaultColors = false;
			if ((tag.ContainsKey("Race") && RaceLoader.TryGetRace(tag.GetString("Race"), out var loadedRace)) || (tag.ContainsKey("PlayerRace") && RaceLoader.TryGetRaceFromLegacyId(tag.GetInt("PlayerRace"), out loadedRace)))
            {
                race = loadedRace;
            }
			RaceStats = tag.GetBool("RaceStats");
            GotStatToggler = tag.GetBool("GotStatToggler");
            GotRaceItems = tag.GetBool("GotRaceItems");
            IsNewCharacter1 = tag.GetBool("IsNewCharacter1");
			IsNewCharacter2 = tag.GetBool("IsNewCharacter2");
			race.Load(player);
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
			packet.Write(GotRaceItems);
            packet.Write(IsNewCharacter1);
			packet.Write(IsNewCharacter2);
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
			if (MrPlagueRaceInfo && MrPlagueRaceInformation.IsBeingHoveredOver)
			{
				player.controlUseItem = false;
			}
			race.ResetEffects(player);
		}

		public override void PostItemCheck()
		{
			race.PostItemCheck(player, mod);
			if (!GotStatToggler)
            {
                GotStatToggler = true;
                RaceStats = true;
                player.QuickSpawnItem(mod.ItemType("Stat_Toggler"));
            }
			if (!GotRaceItems)
			{
				GotRaceItems = true;
				player.QuickSpawnItem(mod.ItemType("Race_Info_Tablet"));
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

		public bool ExposedToSky()
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

		public bool ExposedToSunlight()
		{
			Vampire _Vampire = ModContent.GetInstance<Vampire>();
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
			if (!_Vampire.VampireTransformation)
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
			if (Main.menuMode == 2)
            {
                race = StaticRace;
            }
			race.ModifyDrawInfo(player, mod, ref drawInfo);
		}

		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			race.ProcessTriggers(player, mod);
		}

		public override void PreUpdate()
		{
            if (!(race is Common.Races._999989_Fluftrodons.Fluftrodon))
            {
                FluftrodonPaintUIPanel.Visible = false;
            }
            if (MrPlagueRaceInfo)
            {
                MrPlagueRaceInformation.Visible = true;
            }
			race.PreUpdate(player, mod);
		}

		public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
            player.AddBuff(mod.BuffType("DetectHurt"), 1);
			if (race.UsesCustomHurtSound)
			{
				playSound = false;
			}
			return race.PreHurt(player, pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
		}

		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			if (race.UsesCustomDeathSound)
			{
                playSound = false;
			}
			return race.PreKill(player, mod, damage, hitDirection, pvp, ref playSound, ref genGore, ref damageSource);
		}

		public override void ModifyDrawLayers(List<PlayerLayer> layers) 
		{
            race.ModifyDrawLayers(player, layers);
			if (race == null)
            {
				for (int i = 0; i < 9; i++)
				{
					Main.playerTextures[i, 0] = ModContent.GetTexture($"Terraria/Player_{i}_0");
					Main.playerTextures[i, 1] = ModContent.GetTexture($"Terraria/Player_{i}_1");
					Main.playerTextures[i, 2] = ModContent.GetTexture($"Terraria/Player_{i}_2");
					Main.playerTextures[i, 3] = ModContent.GetTexture($"Terraria/Player_{i}_3");
					Main.playerTextures[i, 4] = ModContent.GetTexture($"Terraria/Player_{i}_4");
					Main.playerTextures[i, 5] = ModContent.GetTexture($"Terraria/Player_{i}_5");
					Main.playerTextures[i, 6] = ModContent.GetTexture($"Terraria/Player_{i}_6");
					Main.playerTextures[i, 7] = ModContent.GetTexture($"Terraria/Player_{i}_7");
					Main.playerTextures[i, 8] = ModContent.GetTexture($"Terraria/Player_{i}_8");
					Main.playerTextures[i, 9] = ModContent.GetTexture($"Terraria/Player_{i}_9");
					Main.playerTextures[i, 10] = ModContent.GetTexture($"Terraria/Player_{i}_10");
					Main.playerTextures[i, 11] = ModContent.GetTexture($"Terraria/Player_{i}_11");
					Main.playerTextures[i, 12] = ModContent.GetTexture($"Terraria/Player_{i}_12");
					Main.playerTextures[i, 13] = ModContent.GetTexture($"Terraria/Player_{i}_13");
					Main.playerTextures[i, 14] = ModContent.GetTexture($"Terraria/Player_{i}_14");
				}
				for (int i = 0; i < 133; i++)
				{
					Main.playerHairTexture[i] = ModContent.GetTexture($"Terraria/Player_Hair_{i + 1}");
					Main.playerHairAltTexture[i] = ModContent.GetTexture($"Terraria/Player_HairAlt_{i + 1}");
				}
				Main.ghostTexture = ModContent.GetTexture("Terraria/Ghost");
			}
		}
	}
}