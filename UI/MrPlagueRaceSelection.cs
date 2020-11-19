using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.UI;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Elements;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.UI
{
	public class MrPlagueRaceSelection : UIState
	{
		public UIPanel MrPlagueRaceBackground;
		UITextPanel<string> MrPlagueRaceNameDisplay = new UITextPanel<string>("");
		UITextPanel<string> MrPlagueRaceStatDisplay1 = new UITextPanel<string>("");
		UITextPanel<string> MrPlagueRaceStatDisplay2 = new UITextPanel<string>("");
		UITextPanel<string> MrPlagueRaceStatDisplay3 = new UITextPanel<string>("");
		UITextPanel<string> MrPlagueRaceStatDisplay4 = new UITextPanel<string>("");
		UITextPanel<string> MrPlagueRaceStatDisplayTEST = new UITextPanel<string>("");
		public int PlayerRace2 = -1;

		public override void OnInitialize()
		{
			this.Width.Set(Main.screenWidth, 0);
			this.Height.Set(Main.screenHeight, 0);
			this.Top.Set(0, 0);
			this.Left.Set(0, 0);

			MrPlagueRaceBackground = new UIPanel();
			MrPlagueRaceBackground.HAlign = 0.5f;
			MrPlagueRaceBackground.VAlign = 0.4f;
			MrPlagueRaceBackground.Width.Set(650, 0);
			MrPlagueRaceBackground.Height.Set(300, 0);
			MrPlagueRaceBackground.BackgroundColor = new Color(33, 43, 79) * 0.8f;
			Append(MrPlagueRaceBackground);

			UIPanel MrPlagueRaceDisplayBackground = new UIPanel();
			MrPlagueRaceDisplayBackground.Width.Set(64, 0);
			MrPlagueRaceDisplayBackground.Height.Set(76, 0);
			MrPlagueRaceDisplayBackground.Left.Set(5 + 178, 0);
			MrPlagueRaceDisplayBackground.Top.Set(129 - 114, 0);
			MrPlagueRaceBackground.Append(MrPlagueRaceDisplayBackground);

			UIPanel MrPlagueRaceStatDisplayBackground = new UIPanel();
			MrPlagueRaceStatDisplayBackground.Width.Set(413, 0);
			MrPlagueRaceStatDisplayBackground.Height.Set(120, 0);
			MrPlagueRaceStatDisplayBackground.Left.Set(5 + 16 - 13, 0);
			MrPlagueRaceStatDisplayBackground.Top.Set(129 - 28 + 50, 0);
			MrPlagueRaceBackground.Append(MrPlagueRaceStatDisplayBackground);

			UITextPanel<string> SelectRace = new UITextPanel<string>("Select Race", 0.8f, true);
			SelectRace.HAlign = 0.5f;
			SelectRace.VAlign = 0.4f;
			SelectRace.Top.Set(-130f, 0);
			SelectRace.BackgroundColor = new Color(73, 94, 171);
			Append(SelectRace);

			UITextPanel<string> MrPlagueRaceSelectionBackButton = new UITextPanel<string>("Back", 0.7f, true);
			MrPlagueRaceSelectionBackButton.HAlign = 0.5f;
			MrPlagueRaceSelectionBackButton.VAlign = 0.4f;
			MrPlagueRaceSelectionBackButton.Width.Set(315f, 0f);
			MrPlagueRaceSelectionBackButton.Height.Set(50f, 0f);
			MrPlagueRaceSelectionBackButton.Left.Set(-167, 0);
			MrPlagueRaceSelectionBackButton.Top.Set(+215, 0);
			MrPlagueRaceSelectionBackButton.OnMouseOver += new UIElement.MouseEvent(this.FadedMouseOver);
			MrPlagueRaceSelectionBackButton.OnMouseOut += new UIElement.MouseEvent(this.FadedMouseOut);
			MrPlagueRaceSelectionBackButton.OnClick += new MouseEvent(MrPlagueRaceSelectionBack);
			Append(MrPlagueRaceSelectionBackButton);

			UITextPanel<string> MrPlagueRaceSelectionProceedButton = new UITextPanel<string>("Proceed", 0.7f, true);
			MrPlagueRaceSelectionProceedButton.HAlign = 0.5f;
			MrPlagueRaceSelectionProceedButton.VAlign = 0.4f;
			MrPlagueRaceSelectionProceedButton.Width.Set(315f, 0f);
			MrPlagueRaceSelectionProceedButton.Height.Set(50f, 0f);
			MrPlagueRaceSelectionProceedButton.Left.Set(+168, 0);
			MrPlagueRaceSelectionProceedButton.Top.Set(+215, 0);
			MrPlagueRaceSelectionProceedButton.OnMouseOver += new UIElement.MouseEvent(this.FadedMouseOver);
			MrPlagueRaceSelectionProceedButton.OnMouseOut += new UIElement.MouseEvent(this.FadedMouseOut);
			MrPlagueRaceSelectionProceedButton.OnClick += new MouseEvent(MrPlagueRaceSelectionProceed);
			Append(MrPlagueRaceSelectionProceedButton);

			MrPlagueRaceNameDisplay = new UITextPanel<string>("");
			MrPlagueRaceNameDisplay.Width.Set(413, 0);
			MrPlagueRaceNameDisplay.Height.Set(40, 0);
			MrPlagueRaceNameDisplay.Left.Set(5 + 16 - 13, 0);
			MrPlagueRaceNameDisplay.Top.Set(129 - 28, 0);
			MrPlagueRaceBackground.Append(MrPlagueRaceNameDisplay);

			MrPlagueRaceStatDisplay1 = new UITextPanel<string>("");
			MrPlagueRaceStatDisplay1.Width.Set(413, 0);
			MrPlagueRaceStatDisplay1.Height.Set(120, 0);
			MrPlagueRaceStatDisplay1.Left.Set(5 + 16 - 13, 0);
			MrPlagueRaceStatDisplay1.Top.Set(129 - 28 + 50, 0);
			MrPlagueRaceStatDisplay1.BackgroundColor = Color.Transparent;
			MrPlagueRaceStatDisplay1.BorderColor = Color.Transparent;
			MrPlagueRaceBackground.Append(MrPlagueRaceStatDisplay1);

			MrPlagueRaceStatDisplay2 = new UITextPanel<string>("");
			MrPlagueRaceStatDisplay2.Width.Set(413, 0);
			MrPlagueRaceStatDisplay2.Height.Set(120, 0);
			MrPlagueRaceStatDisplay2.Left.Set(5 + 16 - 13, 0);
			MrPlagueRaceStatDisplay2.Top.Set(129 - 28 + 50 + 25, 0);
			MrPlagueRaceStatDisplay2.BackgroundColor = Color.Transparent;
			MrPlagueRaceStatDisplay2.BorderColor = Color.Transparent;
			MrPlagueRaceBackground.Append(MrPlagueRaceStatDisplay2);

			MrPlagueRaceStatDisplay3 = new UITextPanel<string>("");
			MrPlagueRaceStatDisplay3.Width.Set(413, 0);
			MrPlagueRaceStatDisplay3.Height.Set(120, 0);
			MrPlagueRaceStatDisplay3.Left.Set(5 + 16 - 13, 0);
			MrPlagueRaceStatDisplay3.Top.Set(129 - 28 + 50 + 50, 0);
			MrPlagueRaceStatDisplay3.BackgroundColor = Color.Transparent;
			MrPlagueRaceStatDisplay3.BorderColor = Color.Transparent;
			MrPlagueRaceBackground.Append(MrPlagueRaceStatDisplay3);

			MrPlagueRaceStatDisplay4 = new UITextPanel<string>("");
			MrPlagueRaceStatDisplay4.Width.Set(413, 0);
			MrPlagueRaceStatDisplay4.Height.Set(120, 0);
			MrPlagueRaceStatDisplay4.Left.Set(5 + 16 - 13, 0);
			MrPlagueRaceStatDisplay4.Top.Set(129 - 28 + 50 + 75, 0);
			MrPlagueRaceStatDisplay4.BackgroundColor = Color.Transparent;
			MrPlagueRaceStatDisplay4.BorderColor = Color.Transparent;
			MrPlagueRaceBackground.Append(MrPlagueRaceStatDisplay4);

			Texture2D BlankRaceIcon = ModContent.GetTexture("MrPlagueRaces/UI/BlankRaceButton");
			Texture2D HumanRaceIcon = ModContent.GetTexture("MrPlagueRaces/UI/HumanRaceButton");
			MrPlagueRaceButton HumanRaceButton = new MrPlagueRaceButton(HumanRaceIcon);
			HumanRaceButton.Width.Set(40, 0);
			HumanRaceButton.Height.Set(40, 0);
			HumanRaceButton.Left.Set(5 + 434, 0);
			HumanRaceButton.Top.Set(129 - 124, 0);
			HumanRaceButton.OnClick += new MouseEvent(HumanRaceClicked);
			MrPlagueRaceBackground.Append(HumanRaceButton);

			Texture2D GoblinRaceIcon = ModContent.GetTexture("MrPlagueRaces/UI/GoblinRaceButton");
			MrPlagueRaceButton GoblinRaceButton = new MrPlagueRaceButton(GoblinRaceIcon);
			GoblinRaceButton.Width.Set(40, 0);
			GoblinRaceButton.Height.Set(40, 0);
			GoblinRaceButton.Left.Set(5 + 50 + 434, 0);
			GoblinRaceButton.Top.Set(129 - 124, 0);
			GoblinRaceButton.OnClick += new MouseEvent(GoblinRaceClicked);
			MrPlagueRaceBackground.Append(GoblinRaceButton);

			Texture2D KenkuRaceIcon = ModContent.GetTexture("MrPlagueRaces/UI/KenkuRaceButton");
			MrPlagueRaceButton KenkuRaceButton = new MrPlagueRaceButton(KenkuRaceIcon);
			KenkuRaceButton.Width.Set(40, 0);
			KenkuRaceButton.Height.Set(40, 0);
			KenkuRaceButton.Left.Set(5 + 100 + 434, 0);
			KenkuRaceButton.Top.Set(129 - 124, 0);
			KenkuRaceButton.OnClick += new MouseEvent(KenkuRaceClicked);
			MrPlagueRaceBackground.Append(KenkuRaceButton);

			Texture2D TabaxiRaceIcon = ModContent.GetTexture("MrPlagueRaces/UI/TabaxiRaceButton");
			MrPlagueRaceButton TabaxiRaceButton = new MrPlagueRaceButton(TabaxiRaceIcon);
			TabaxiRaceButton.Width.Set(40, 0);
			TabaxiRaceButton.Height.Set(40, 0);
			TabaxiRaceButton.Left.Set(5 + 150 + 434, 0);
			TabaxiRaceButton.Top.Set(129 - 124, 0);
			TabaxiRaceButton.OnClick += new MouseEvent(TabaxiRaceClicked);
			MrPlagueRaceBackground.Append(TabaxiRaceButton);

			Texture2D DragonkinRaceIcon = ModContent.GetTexture("MrPlagueRaces/UI/DragonkinRaceButton");
			MrPlagueRaceButton DragonkinRaceButton = new MrPlagueRaceButton(DragonkinRaceIcon);
			DragonkinRaceButton.Width.Set(40, 0);
			DragonkinRaceButton.Height.Set(40, 0);
			DragonkinRaceButton.Left.Set(5 + 434, 0);
			DragonkinRaceButton.Top.Set(129 + 50 - 124, 0);
			DragonkinRaceButton.OnClick += new MouseEvent(DragonkinRaceClicked);
			MrPlagueRaceBackground.Append(DragonkinRaceButton);

			Texture2D MerfolkRaceIcon = ModContent.GetTexture("MrPlagueRaces/UI/MerfolkRaceButton");
			MrPlagueRaceButton MerfolkRaceButton = new MrPlagueRaceButton(MerfolkRaceIcon);
			MerfolkRaceButton.Width.Set(40, 0);
			MerfolkRaceButton.Height.Set(40, 0);
			MerfolkRaceButton.Left.Set(5 + 50 + 434, 0);
			MerfolkRaceButton.Top.Set(129 + 50 - 124, 0);
			MerfolkRaceButton.OnClick += new MouseEvent(MerfolkRaceClicked);
			MrPlagueRaceBackground.Append(MerfolkRaceButton);

			Texture2D MushfolkRaceIcon = ModContent.GetTexture("MrPlagueRaces/UI/MushfolkRaceButton");
			MrPlagueRaceButton MushfolkRaceButton = new MrPlagueRaceButton(MushfolkRaceIcon);
			MushfolkRaceButton.Width.Set(40, 0);
			MushfolkRaceButton.Height.Set(40, 0);
			MushfolkRaceButton.Left.Set(5 + 100 + 434, 0);
			MushfolkRaceButton.Top.Set(129 + 50 - 124, 0);
			MushfolkRaceButton.OnClick += new MouseEvent(MushfolkRaceClicked);
			MrPlagueRaceBackground.Append(MushfolkRaceButton);

			Texture2D DerpkinRaceIcon = ModContent.GetTexture("MrPlagueRaces/UI/DerpkinRaceButton");
			MrPlagueRaceButton DerpkinRaceButton = new MrPlagueRaceButton(DerpkinRaceIcon);
			DerpkinRaceButton.Width.Set(40, 0);
			DerpkinRaceButton.Height.Set(40, 0);
			DerpkinRaceButton.Left.Set(5 + 150 + 434, 0);
			DerpkinRaceButton.Top.Set(129 + 50 - 124, 0);
			DerpkinRaceButton.OnClick += new MouseEvent(DerpkinRaceClicked);
			MrPlagueRaceBackground.Append(DerpkinRaceButton);

			Texture2D KoboldRaceIcon = ModContent.GetTexture("MrPlagueRaces/UI/KoboldRaceButton");
			MrPlagueRaceButton KoboldRaceButton = new MrPlagueRaceButton(KoboldRaceIcon);
			KoboldRaceButton.Width.Set(40, 0);
			KoboldRaceButton.Height.Set(40, 0);
			KoboldRaceButton.Left.Set(5 + 434, 0);
			KoboldRaceButton.Top.Set(129 + 100 - 124, 0);
			KoboldRaceButton.OnClick += new MouseEvent(KoboldRaceClicked);
			MrPlagueRaceBackground.Append(KoboldRaceButton);

			Texture2D SkeletonRaceIcon = ModContent.GetTexture("MrPlagueRaces/UI/SkeletonRaceButton");
			MrPlagueRaceButton SkeletonRaceButton = new MrPlagueRaceButton(SkeletonRaceIcon);
			SkeletonRaceButton.Width.Set(40, 0);
			SkeletonRaceButton.Height.Set(40, 0);
			SkeletonRaceButton.Left.Set(5 + 50 + 434, 0);
			SkeletonRaceButton.Top.Set(129 + 100 - 124, 0);
			SkeletonRaceButton.OnClick += new MouseEvent(SkeletonRaceClicked);
			MrPlagueRaceBackground.Append(SkeletonRaceButton);

			Texture2D VampireRaceIcon = ModContent.GetTexture("MrPlagueRaces/UI/VampireRaceButton");
			MrPlagueRaceButton VampireRaceButton = new MrPlagueRaceButton(VampireRaceIcon);
			VampireRaceButton.Width.Set(40, 0);
			VampireRaceButton.Height.Set(40, 0);
			VampireRaceButton.Left.Set(5 + 100 + 434, 0);
			VampireRaceButton.Top.Set(129 + 100 - 124, 0);
			VampireRaceButton.OnClick += new MouseEvent(VampireRaceClicked);
			MrPlagueRaceBackground.Append(VampireRaceButton);

			Texture2D FluftrodonRaceIcon = ModContent.GetTexture("MrPlagueRaces/UI/FluftrodonRaceButton");
			MrPlagueRaceButton FluftrodonRaceButton = new MrPlagueRaceButton(FluftrodonRaceIcon);
			FluftrodonRaceButton.Width.Set(40, 0);
			FluftrodonRaceButton.Height.Set(40, 0);
			FluftrodonRaceButton.Left.Set(5 + 150 + 434, 0);
			FluftrodonRaceButton.Top.Set(129 + 100 - 124, 0);
			FluftrodonRaceButton.OnClick += new MouseEvent(FluftrodonRaceClicked);
			MrPlagueRaceBackground.Append(FluftrodonRaceButton);

			MrPlagueRaceButton Placeholder5RaceButton = new MrPlagueRaceButton(BlankRaceIcon);
			Placeholder5RaceButton.Width.Set(40, 0);
			Placeholder5RaceButton.Height.Set(40, 0);
			Placeholder5RaceButton.Left.Set(5 + 434, 0);
			Placeholder5RaceButton.Top.Set(129 + 50 + 100 - 124, 0);
			MrPlagueRaceBackground.Append(Placeholder5RaceButton);

			MrPlagueRaceButton Placeholder6RaceButton = new MrPlagueRaceButton(BlankRaceIcon);
			Placeholder6RaceButton.Width.Set(40, 0);
			Placeholder6RaceButton.Height.Set(40, 0);
			Placeholder6RaceButton.Left.Set(5 + 50 + 434, 0);
			Placeholder6RaceButton.Top.Set(129 + 50 + 100 - 124, 0);
			MrPlagueRaceBackground.Append(Placeholder6RaceButton);

			MrPlagueRaceButton Placeholder7RaceButton = new MrPlagueRaceButton(BlankRaceIcon);
			Placeholder7RaceButton.Width.Set(40, 0);
			Placeholder7RaceButton.Height.Set(40, 0);
			Placeholder7RaceButton.Left.Set(5 + 100 + 434, 0);
			Placeholder7RaceButton.Top.Set(129 + 50 + 100 - 124, 0);
			MrPlagueRaceBackground.Append(Placeholder7RaceButton);

			MrPlagueRaceButton Placeholder8RaceButton = new MrPlagueRaceButton(BlankRaceIcon);
			Placeholder8RaceButton.Width.Set(40, 0);
			Placeholder8RaceButton.Height.Set(40, 0);
			Placeholder8RaceButton.Left.Set(5 + 150 + 434, 0);
			Placeholder8RaceButton.Top.Set(129 + 50 + 100 - 124, 0);
			MrPlagueRaceBackground.Append(Placeholder8RaceButton);

			MrPlagueRaceButton Placeholder9RaceButton = new MrPlagueRaceButton(BlankRaceIcon);
			Placeholder9RaceButton.Width.Set(40, 0);
			Placeholder9RaceButton.Height.Set(40, 0);
			Placeholder9RaceButton.Left.Set(5 + 434, 0);
			Placeholder9RaceButton.Top.Set(129 + 200 - 124, 0);
			MrPlagueRaceBackground.Append(Placeholder9RaceButton);

			MrPlagueRaceButton Placeholder10RaceButton = new MrPlagueRaceButton(BlankRaceIcon);
			Placeholder10RaceButton.Width.Set(40, 0);
			Placeholder10RaceButton.Height.Set(40, 0);
			Placeholder10RaceButton.Left.Set(5 + 50 + 434, 0);
			Placeholder10RaceButton.Top.Set(129 + 200 - 124, 0);
			MrPlagueRaceBackground.Append(Placeholder10RaceButton);

			MrPlagueRaceButton Placeholder11RaceButton = new MrPlagueRaceButton(BlankRaceIcon);
			Placeholder11RaceButton.Width.Set(40, 0);
			Placeholder11RaceButton.Height.Set(40, 0);
			Placeholder11RaceButton.Left.Set(5 + 100 + 434, 0);
			Placeholder11RaceButton.Top.Set(129 + 200 - 124, 0);
			MrPlagueRaceBackground.Append(Placeholder11RaceButton);

			MrPlagueRaceButton Placeholder12RaceButton = new MrPlagueRaceButton(BlankRaceIcon);
			Placeholder12RaceButton.Width.Set(40, 0);
			Placeholder12RaceButton.Height.Set(40, 0);
			Placeholder12RaceButton.Left.Set(5 + 150 + 434, 0);
			Placeholder12RaceButton.Top.Set(129 + 200 - 124, 0);
			MrPlagueRaceBackground.Append(Placeholder12RaceButton);
		}

		private void FadedMouseOver(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
			((UIPanel)evt.Target).BackgroundColor = new Color(73, 94, 171);
		}

		private void FadedMouseOut(UIMouseEvent evt, UIElement listeningElement)
		{
			((UIPanel)evt.Target).BackgroundColor = new Color(63, 82, 151) * 0.7f;
		}

		public void MrPlagueRaceSelectionProceed(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			Main.PlaySound(SoundID.MenuOpen, -1, -1, 1, 1f, 0f);
			MrPlagueRacesPlayer.PlayerRaceStatic = PlayerRace2;
			Main.menuMode = 2;
			PlayerRace2 = -1;
		}

		public void MrPlagueRaceSelectionBack(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			Main.PlaySound(SoundID.MenuClose, -1, -1, 1, 1f, 0f);
			Main.menuMode = 1;
			PlayerRace2 = -1;
		}

		public void HumanRaceClicked(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			Main.PlaySound(SoundID.MenuOpen, -1, -1, 1, 1f, 0f);
			PlayerRace2 = 0;
		}

		public void GoblinRaceClicked(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			Main.PlaySound(SoundID.MenuOpen, -1, -1, 1, 1f, 0f);
			PlayerRace2 = 1;
		}

		public void KenkuRaceClicked(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			Main.PlaySound(SoundID.MenuOpen, -1, -1, 1, 1f, 0f);
			PlayerRace2 = 2;
		}

		public void TabaxiRaceClicked(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			Main.PlaySound(SoundID.MenuOpen, -1, -1, 1, 1f, 0f);
			PlayerRace2 = 3;
		}

		public void DragonkinRaceClicked(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			Main.PlaySound(SoundID.MenuOpen, -1, -1, 1, 1f, 0f);
			PlayerRace2 = 4;
		}

		public void MerfolkRaceClicked(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			Main.PlaySound(SoundID.MenuOpen, -1, -1, 1, 1f, 0f);
			PlayerRace2 = 5;
		}

		public void MushfolkRaceClicked(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			Main.PlaySound(SoundID.MenuOpen, -1, -1, 1, 1f, 0f);
			PlayerRace2 = 6;
		}

		public void DerpkinRaceClicked(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			Main.PlaySound(SoundID.MenuOpen, -1, -1, 1, 1f, 0f);
			PlayerRace2 = 7;
		}

		public void KoboldRaceClicked(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			Main.PlaySound(SoundID.MenuOpen, -1, -1, 1, 1f, 0f);
			PlayerRace2 = 8;
		}

		public void SkeletonRaceClicked(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			Main.PlaySound(SoundID.MenuOpen, -1, -1, 1, 1f, 0f);
			PlayerRace2 = 9;
		}
		public void VampireRaceClicked(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			Main.PlaySound(SoundID.MenuOpen, -1, -1, 1, 1f, 0f);
			PlayerRace2 = 10;
		}
		public void FluftrodonRaceClicked(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			Main.PlaySound(SoundID.MenuOpen, -1, -1, 1, 1f, 0f);
			PlayerRace2 = 11;
		}

		protected override void DrawChildren(SpriteBatch spriteBatch)
		{
			CalculatedStyle MrPlagueRaceInnerDimension = MrPlagueRaceBackground.GetInnerDimensions();
			var _RaceDisplay = RaceDisplay();
			float RaceDisplayTextureScaleX = 1f;
			float RaceDisplayTextureScaleY = 1f;
			if (_RaceDisplay.Width > 64)
			{
				RaceDisplayTextureScaleX = 64 / _RaceDisplay.Width;
			}

			if (_RaceDisplay.Height > 76)
			{
				RaceDisplayTextureScaleY = 76 / _RaceDisplay.Height;
			}

			base.DrawChildren(spriteBatch);
			Vector2 RaceDisplayTexturePostion = new Vector2((64 / 2 - _RaceDisplay.Width * RaceDisplayTextureScaleX / 2), (76 / 2 - RaceDisplay().Height * RaceDisplayTextureScaleY / 2));
			spriteBatch.Draw(_RaceDisplay, new Vector2(MrPlagueRaceInnerDimension.X + 183f, MrPlagueRaceInnerDimension.Y + 15f) + RaceDisplayTexturePostion, null, Color.White, 0f, Vector2.Zero, new Vector2(RaceDisplayTextureScaleX, RaceDisplayTextureScaleY), SpriteEffects.None, 1f);
		}

		private Texture2D RaceDisplay()
		{
			switch (PlayerRace2)
			{
				case 0:
					return ModContent.GetTexture("MrPlagueRaces/UI/HumanRaceDisplay");
				case 1:
					return ModContent.GetTexture("MrPlagueRaces/UI/GoblinRaceDisplay");
				case 2:
					return ModContent.GetTexture("MrPlagueRaces/UI/KenkuRaceDisplay");
				case 3:
					return ModContent.GetTexture("MrPlagueRaces/UI/TabaxiRaceDisplay");
				case 4:
					return ModContent.GetTexture("MrPlagueRaces/UI/DragonkinRaceDisplay");
				case 5:
					return ModContent.GetTexture("MrPlagueRaces/UI/MerfolkRaceDisplay");
				case 6:
					return ModContent.GetTexture("MrPlagueRaces/UI/MushfolkRaceDisplay");
				case 7:
					return ModContent.GetTexture("MrPlagueRaces/UI/DerpkinRaceDisplay");
				case 8:
					return ModContent.GetTexture("MrPlagueRaces/UI/KoboldRaceDisplay");
				case 9:
					return ModContent.GetTexture("MrPlagueRaces/UI/SkeletonRaceDisplay");
				case 10:
					return ModContent.GetTexture("MrPlagueRaces/UI/VampireRaceDisplay");
				case 11:
					return ModContent.GetTexture("MrPlagueRaces/UI/FluftrodonRaceDisplay");
				default:
					return ModContent.GetTexture("MrPlagueRaces/UI/BlankRaceDisplay");
			}
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			if (PlayerRace2 == -1)
			{
				PlayerRace2 = Main.rand.Next(11);
			}
			if (PlayerRace2 == 0)
			{
				MrPlagueRaceNameDisplay.SetText("Human");
				MrPlagueRaceStatDisplay1.SetText($"No stat changes" + "\n                                                      ");
				MrPlagueRaceStatDisplay2.SetText($"" + "\n                                                      ");
				MrPlagueRaceStatDisplay3.SetText($"" + "\n                                                      ");
				MrPlagueRaceStatDisplay4.SetText($"" + "\n                                                      ");
			}
			else if (PlayerRace2 == 1)
			{
				MrPlagueRaceNameDisplay.SetText("Goblin");
				MrPlagueRaceStatDisplay1.SetText($"[c/34EB93:+1] Minions, [c/34EB93:+1] Turrets, [c/34EB93:+10%] Movement Speed" + "\n                                                      ");
				MrPlagueRaceStatDisplay2.SetText($"[c/34EB93:+10%] Placement Speed, [c/34EB93:+10%] Mining Speed" + "\n                                                      ");
				MrPlagueRaceStatDisplay3.SetText($"[c/EB3449:-20%] Health, [c/EB3449:-10%] Damage" + "\n                                                      ");
				MrPlagueRaceStatDisplay4.SetText($"" + "\n                                                      ");
			}
			else if (PlayerRace2 == 2)
			{
				MrPlagueRaceNameDisplay.SetText("Kenku");
				MrPlagueRaceStatDisplay1.SetText($"[c/34EB93:+15%] Damage, [c/34EB93:+10%] Crit Chance, [c/34EB93:Can Fly]" + "\n                                                      ");
				MrPlagueRaceStatDisplay2.SetText($"[c/34EB93:+25%] Movement Speed, [c/34EB93:+50%] Flight Time" + "\n                                                      ");
				MrPlagueRaceStatDisplay3.SetText($"[c/EB3449:-25%] Health, [c/EB3449:-8] Defense" + "\n                                                      ");
				MrPlagueRaceStatDisplay4.SetText($"" + "\n                                                      ");
			}
			else if (PlayerRace2 == 3)
			{
				MrPlagueRaceNameDisplay.SetText("Tabaxi");
				MrPlagueRaceStatDisplay1.SetText($"[c/34EB93:+40%] Movement Speed, [c/34EB93:+35%] Jump Speed" + "\n                                                      ");
				MrPlagueRaceStatDisplay2.SetText($"[c/34EB93:+25%] Placement Speed, [c/34EB93:+25%] Mining Speed" + "\n                                                      ");
				MrPlagueRaceStatDisplay3.SetText($"[c/EB3449:-4] Defense, [c/EB3449:-10%] Damage" + "\n                                                      ");
				MrPlagueRaceStatDisplay4.SetText($"" + "\n                                                      ");
			}
			else if (PlayerRace2 == 4)
			{
				MrPlagueRaceNameDisplay.SetText("Dragonkin");
				MrPlagueRaceStatDisplay1.SetText($"[c/34EB93:+20%] Health, [c/34EB93:+8] Defense, [c/34EB93:+10%] Melee Damage" + "\n                                                      ");
				MrPlagueRaceStatDisplay2.SetText($"[c/34EB93:+2] Seconds of Lava Immunity" + "\n                                                      ");
				MrPlagueRaceStatDisplay3.SetText($"[c/EB3449:-10%] Jump Speed" + "\n                                                      ");
				MrPlagueRaceStatDisplay4.SetText($"[c/EB3449:-10%] Placement Speed, [c/EB3449:-10%] Mining Speed" + "\n                                                      ");
			}
			else if (PlayerRace2 == 5)
			{
				MrPlagueRaceNameDisplay.SetText("Merfolk");
				MrPlagueRaceStatDisplay1.SetText($"[c/34EB93:+25%] Damage when wet, [c/34EB93:Can breathe in water]" + "\n                                                      ");
				MrPlagueRaceStatDisplay2.SetText($"[c/34EB93:+25%] Placement Speed, [c/34EB93:+10%] Mining Speed" + "\n                                                      ");
				MrPlagueRaceStatDisplay3.SetText($"[c/EB3449:Can't breathe in air, except during rain]" + "\n                                                      ");
				MrPlagueRaceStatDisplay4.SetText($"" + "\n                                                      ");
			}
			else if (PlayerRace2 == 6)
			{
				MrPlagueRaceNameDisplay.SetText("Mushfolk");
				MrPlagueRaceStatDisplay1.SetText($"[c/34EB93:+10%] Health, [c/34EB93:+2] Minions, [c/34EB93:+10%] Movement Speed" + "\n                                                      ");
				MrPlagueRaceStatDisplay2.SetText($"[c/34EB93:All nearby Allies are healed by you]" + "\n                                                      ");
				MrPlagueRaceStatDisplay3.SetText($"[c/EB3449:-15%] Damage" + "\n                                                      ");
				MrPlagueRaceStatDisplay4.SetText($"" + "\n                                                      ");
			}
			else if (PlayerRace2 == 7)
			{
				MrPlagueRaceNameDisplay.SetText("Derpkin");
				MrPlagueRaceStatDisplay1.SetText($"[c/34EB93:+10%] Damage, [c/34EB93:+25%] Movement Speed" + "\n                                                      ");
				MrPlagueRaceStatDisplay2.SetText($"[c/34EB93:+60%] Jump Speed, [c/34EB93:Can Autojump]" + "\n                                                      ");
				MrPlagueRaceStatDisplay3.SetText($"[c/EB3449:-20%] Health, [c/EB3449:-4] Defense" + "\n                                                      ");
				MrPlagueRaceStatDisplay4.SetText($"" + "\n                                                      ");
			}
			else if (PlayerRace2 == 8)
			{
				MrPlagueRaceNameDisplay.SetText("Kobold");
				MrPlagueRaceStatDisplay1.SetText($"[c/34EB93:+5%] Nonmelee Damage, [c/34EB93:+5%] Movement Speed" + "\n                                                      ");
				MrPlagueRaceStatDisplay2.SetText($"[c/34EB93:Press Racial Ability to see ores]" + "\n                                                      ");
				MrPlagueRaceStatDisplay3.SetText($"[c/34EB93:+60%] Mining Speed, [c/EB3449:-10%] Health, [c/EB3449:-4] Defense" + "\n                                                      ");
				MrPlagueRaceStatDisplay4.SetText($"[c/EB3449:-10%] Melee Damage, [c/EB3449:Becomes weak in Sunlight]" + "\n                                                      ");
			}
			else if (PlayerRace2 == 9)
			{
				MrPlagueRaceNameDisplay.SetText("Skeleton");
				MrPlagueRaceStatDisplay1.SetText($"[c/34EB93:+20%] Magic Damage, [c/34EB93:+15%] Movement Speed" + "\n                                                      ");
				MrPlagueRaceStatDisplay2.SetText($"[c/34EB93:+50] Mana, [c/34EB93:Can breathe in water]" + "\n                                                      ");
				MrPlagueRaceStatDisplay3.SetText($"[c/34EB93:Immune to Bleeding, Suffocation, and Poison]" + "\n                                                      ");
				MrPlagueRaceStatDisplay4.SetText($"[c/EB3449:-25%] Health, [c/EB3449:-4] defense" + "\n                                                      ");
			}
			else if (PlayerRace2 == 10)
			{
				MrPlagueRaceNameDisplay.SetText("Vampire");
				MrPlagueRaceStatDisplay1.SetText($"[c/34EB93:Press Racial Ability to become a Bat]" + "\n                                                      ");
				MrPlagueRaceStatDisplay2.SetText($"[c/34EB93:+5%] Movement Speed, [c/34EB93:+10%] Mining Speed" + "\n                                                      ");
				MrPlagueRaceStatDisplay3.SetText($"[c/34EB93:Increased Heart Pickup Range]" + "\n                                                      ");
				MrPlagueRaceStatDisplay4.SetText($"[c/EB3449:Burns in Sunlight, Cannot use items as a Bat]" + "\n                                                      ");
			}
			else if (PlayerRace2 == 11)
			{
				MrPlagueRaceNameDisplay.SetText("Fluftrodon");
				MrPlagueRaceStatDisplay1.SetText($"[c/34EB93:Press Racial Ability to paint]" + "\n                                                      ");
				MrPlagueRaceStatDisplay2.SetText($"[c/34EB93:+15%] Movement Speed, [c/34EB93:+10%] Jump Speed" + "\n                                                      ");
				MrPlagueRaceStatDisplay3.SetText($"[c/34EB93:+20%] Mining Speed, [c/34EB93:+50%] Placement Speed" + "\n                                                      ");
				MrPlagueRaceStatDisplay4.SetText($"[c/34EB93:+2] Placement Range, [c/EB3449:-15%] Damage" + "\n                                                      ");
			}
			else
			{
				MrPlagueRaceNameDisplay.SetText("Error");
				MrPlagueRaceStatDisplay1.SetText($"Error (please report to MrPlague!)" + "\n                                                      ");
				MrPlagueRaceStatDisplay2.SetText($"Error (please report to MrPlague!)" + "\n                                                      ");
				MrPlagueRaceStatDisplay3.SetText($"Error (please report to MrPlague!)" + "\n                                                      ");
				MrPlagueRaceStatDisplay4.SetText($"Error (please report to MrPlague!)" + "\n                                                      ");
			}
			Recalculate();
		}
	}
}