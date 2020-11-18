using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.UI;
using Terraria.ModLoader;
using MrPlagueRaces.UI;
using MrPlagueRaces.Buffs;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces
{
	internal enum MrPlagueRacesMessageType : byte
	{
		MrPlagueRacesPlayerSyncPlayer,
		MrPlagueRacesNonStopPartyChanged
	}

	public class MrPlagueRaces : Mod
	{
		private UserInterface FluftrodonUserInterface;
		public static ModHotKey RacialAbilityHotKey;
		private MrPlagueRaceSelection _MrPlagueRaceSelection;
		private bool justWentRaceSelection = false;
		internal FluftrodonPaintUIPanel FluftrodonPaintUIPanel;

		public override void Load()
		{
			RacialAbilityHotKey = RegisterHotKey("Racial Ability", "Mouse2");
			if (!Main.dedServ)
			{
				_MrPlagueRaceSelection = new MrPlagueRaceSelection();
				Main.OnTick += UpdateTick;
				FluftrodonPaintUIPanel = new FluftrodonPaintUIPanel();
				FluftrodonPaintUIPanel.Activate();
				FluftrodonUserInterface = new UserInterface();
				FluftrodonUserInterface.SetState(FluftrodonPaintUIPanel);
			}
		}

		public override void Unload()
		{
			RacialAbilityHotKey = null;
            if (!Main.dedServ)
            {
                _MrPlagueRaceSelection = null;
                Main.OnTick -= UpdateTick;
			}
		}

		private void UpdateTick()
		{
			if (Main.menuMode == 1)
			{
				justWentRaceSelection = false;
			}
			if (Main.menuMode == 2)
			{
				if (justWentRaceSelection == false)
                {
					SetUIState(_MrPlagueRaceSelection);
					justWentRaceSelection = true;
				}
			}
		}

		private static void SetUIState(UIState uiState)
		{
			Main.menuMode = 888;
			Main.MenuUI.SetState(uiState);
		}

		public override void UpdateUI(GameTime gameTime)
		{
			if (FluftrodonPaintUIPanel.Visible)
			{
				FluftrodonUserInterface?.Update(gameTime);
			}
		}
		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (mouseTextIndex != -1)
			{
				layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer("MrPlagueRaces: Fluftrodon Paint UI", delegate 
				{
						if (FluftrodonPaintUIPanel.Visible)
						{
							FluftrodonUserInterface.Draw(Main.spriteBatch, new GameTime());
						}
						return true;
				},
				InterfaceScaleType.UI));
			}
		}

		public override void HandlePacket(BinaryReader reader, int whoAmI) 
		{
			MrPlagueRacesMessageType msgType = (MrPlagueRacesMessageType)reader.ReadByte();
			switch (msgType) 
			{
				case MrPlagueRacesMessageType.MrPlagueRacesPlayerSyncPlayer:
					byte playernumber = reader.ReadByte();
					MrPlagueRacesPlayer MrPlagueRacesPlayer = Main.player[playernumber].GetModPlayer<MrPlagueRacesPlayer>();
					int PlayerRace = reader.ReadInt32();
					MrPlagueRacesPlayer.PlayerRace = PlayerRace;
					MrPlagueRacesPlayer.RaceStats = reader.ReadBoolean();
					MrPlagueRacesPlayer.GotStatToggler = reader.ReadBoolean();
					MrPlagueRacesPlayer.GotLoreBook = reader.ReadBoolean();
					MrPlagueRacesPlayer.IsNewCharacter1 = reader.ReadBoolean();
					MrPlagueRacesPlayer.MrPlagueRacesNonStopParty = reader.ReadBoolean();
					break;
				case MrPlagueRacesMessageType.MrPlagueRacesNonStopPartyChanged:
					playernumber = reader.ReadByte();
					MrPlagueRacesPlayer = Main.player[playernumber].GetModPlayer<MrPlagueRacesPlayer>();
					MrPlagueRacesPlayer.MrPlagueRacesNonStopParty = reader.ReadBoolean();
					if (Main.netMode == NetmodeID.Server) 
					{
						var packet = GetPacket();
						packet.Write((byte)MrPlagueRacesMessageType.MrPlagueRacesNonStopPartyChanged);
						packet.Write(playernumber);
						packet.Write(MrPlagueRacesPlayer.MrPlagueRacesNonStopParty);
						packet.Send(-1, playernumber);
					}
					break;
				default:
					Logger.WarnFormat("MrPlagueRaces: Something went wrong:", msgType);
					break;
			}
		}
		public static int PreviousMenuMode { get; internal set; }
	}
}