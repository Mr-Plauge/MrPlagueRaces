using Microsoft.Xna.Framework;
using MrPlagueRaces.Core.Loadables;
using MrPlagueRaces.UI;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace MrPlagueRaces
{
	internal enum MrPlagueRacesMessageType : byte
	{
		MrPlagueRacesPlayerSyncPlayer,
		MrPlagueRacesNonStopPartyChanged
	}

	public class MrPlagueRaces : Mod
	{
		public static ModHotKey RacialAbilityHotKey;

		public static int PreviousMenuMode { get; internal set; }

		internal FluftrodonPaintUIPanel FluftrodonPaintUIPanel;

		private UserInterface FluftrodonUserInterface;
		private MrPlagueRaceSelection _MrPlagueRaceSelection;
		private bool justWentRaceSelection;

		public override void Load()
		{
			LoadableManager.Autoload(this);

			RacialAbilityHotKey = RegisterHotKey("Racial Ability", "Mouse2");

			if (!Main.dedServ)
			{
				Main.OnTick += UpdateTick;

				_MrPlagueRaceSelection = new MrPlagueRaceSelection();
				FluftrodonPaintUIPanel = new FluftrodonPaintUIPanel();
				FluftrodonPaintUIPanel.Activate();

				FluftrodonUserInterface = new UserInterface();
				FluftrodonUserInterface.SetState(FluftrodonPaintUIPanel);
			}
		}

		public override void Unload()
		{
			LoadableManager.Unload();

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

			if (Main.menuMode == 2 && !justWentRaceSelection)
			{
				SetUIState(_MrPlagueRaceSelection);

				justWentRaceSelection = true;
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
			var msgType = (MrPlagueRacesMessageType)reader.ReadByte();

			switch (msgType) 
			{
				case MrPlagueRacesMessageType.MrPlagueRacesPlayerSyncPlayer:
					{
						byte playernumber = reader.ReadByte();
						var MrPlagueRacesPlayer = Main.player[playernumber].GetModPlayer<MrPlagueRacesPlayer>();
						int PlayerRace = reader.ReadInt32();

						MrPlagueRacesPlayer.PlayerRace = PlayerRace;
						MrPlagueRacesPlayer.RaceStats = reader.ReadBoolean();
						MrPlagueRacesPlayer.GotStatToggler = reader.ReadBoolean();
						MrPlagueRacesPlayer.GotLoreBook = reader.ReadBoolean();
						MrPlagueRacesPlayer.IsNewCharacter1 = reader.ReadBoolean();
						MrPlagueRacesPlayer.MrPlagueRacesNonStopParty = reader.ReadBoolean();

						break;
					}
				case MrPlagueRacesMessageType.MrPlagueRacesNonStopPartyChanged:
					{
						byte playernumber = reader.ReadByte();
						var MrPlagueRacesPlayer = Main.player[playernumber].GetModPlayer<MrPlagueRacesPlayer>();
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
					}
				default:
					Logger.WarnFormat("MrPlagueRaces: Something went wrong:", msgType);
					break;
			}
		}
	}
}
