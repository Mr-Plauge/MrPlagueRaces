using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.UI;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Elements;
using MrPlagueRaces.Common.Races._999992_Fluftrodons;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Common.UI
{
	public class FluftrodonPaintUIPanel : UIState
	{
		public UIPanel FluftrodonPaintUIPanelBackground;
		public static bool Visible;
		public int FluftrodonPaintTileMode2 = 1;
		public int FluftrodonPaintWallMode2 = 1;
		public int FluftrodonPaintColor2 = 1;
		UITextPanel<string> FluftrodonPaintUIBrushText = new UITextPanel<string>("");
		UITextPanel<string> FluftrodonPaintUIColorText = new UITextPanel<string>("");
		UITextPanel<string> FluftrodonPaintUIRollerText = new UITextPanel<string>("");

		public override void OnInitialize()
		{
			Width.Set(Main.screenWidth, 0);
			Height.Set(Main.screenHeight, 0);
			Top.Set(0, 0);
			Left.Set(0, 0);

			FluftrodonPaintUIPanelBackground = new UIPanel();
			FluftrodonPaintUIPanelBackground.Width.Set(200, 0);
			FluftrodonPaintUIPanelBackground.Height.Set(200, 0);
			FluftrodonPaintUIPanelBackground.BackgroundColor = new Color(0, 0, 0) * 0f;
			FluftrodonPaintUIPanelBackground.BorderColor = new Color(0, 0, 0) * 0f;
			Append(FluftrodonPaintUIPanelBackground);

			Texture2D FluftrodonPaintUIBrushIcon = GetTexture("MrPlagueRaces/Common/UI/FluftrodonPaintUIBrush");
			Texture2D FluftrodonPaintUIBrush_ActiveIcon = GetTexture("MrPlagueRaces/Common/UI/FluftrodonPaintUIBrush_Active");
			MrPlagueRaceButton FluftrodonPaintUIBrush = new MrPlagueRaceButton(FluftrodonPaintUIBrushIcon, FluftrodonPaintUIBrush_ActiveIcon);
			FluftrodonPaintUIBrush.Width.Set(40, 0);
			FluftrodonPaintUIBrush.Height.Set(40, 0);
			FluftrodonPaintUIBrush.Left.Set(-5 - 40 + 43, 0);
			FluftrodonPaintUIBrush.Top.Set(0, 0);
			FluftrodonPaintUIBrush.OnClick += new MouseEvent(FluftrodonPaintUIBrushToggle);
			FluftrodonPaintUIPanelBackground.Append(FluftrodonPaintUIBrush);

			FluftrodonPaintUIBrushText = new UITextPanel<string>("");
			FluftrodonPaintUIBrushText.Width.Set(80, 0);
			FluftrodonPaintUIBrushText.Height.Set(40, 0);
			FluftrodonPaintUIBrushText.Left.Set(-5 - 40 + 25, 0);
			FluftrodonPaintUIBrushText.Top.Set(30, 0);
			FluftrodonPaintUIBrushText.BackgroundColor = Color.Transparent;
			FluftrodonPaintUIBrushText.BorderColor = Color.Transparent;
			FluftrodonPaintUIPanelBackground.Append(FluftrodonPaintUIBrushText);

            Texture2D FluftrodonPaintUIColorIcon = GetTexture("MrPlagueRaces/Common/UI/FluftrodonPaintUIColor");
			Texture2D FluftrodonPaintUIColor_ActiveIcon = GetTexture("MrPlagueRaces/Common/UI/FluftrodonPaintUIColor_Active");
			MrPlagueRaceButton FluftrodonPaintUIColor = new MrPlagueRaceButton(FluftrodonPaintUIColorIcon, FluftrodonPaintUIColor_ActiveIcon);
			FluftrodonPaintUIColor.Width.Set(40, 0);
			FluftrodonPaintUIColor.Height.Set(40, 0);
			FluftrodonPaintUIColor.Left.Set(25 + 43, 0);
			FluftrodonPaintUIColor.Top.Set(0, 0);
			FluftrodonPaintUIColor.OnClick += new MouseEvent(FluftrodonPaintUIColorToggle);
			FluftrodonPaintUIPanelBackground.Append(FluftrodonPaintUIColor);

			FluftrodonPaintUIColorText = new UITextPanel<string>("");
			FluftrodonPaintUIColorText.Width.Set(80, 0);
			FluftrodonPaintUIColorText.Height.Set(40, 0);
			FluftrodonPaintUIColorText.Left.Set(-5 - 40 + 95, 0);
			FluftrodonPaintUIColorText.Top.Set(30, 0);
			FluftrodonPaintUIColorText.BackgroundColor = Color.Transparent;
			FluftrodonPaintUIColorText.BorderColor = Color.Transparent;
			FluftrodonPaintUIPanelBackground.Append(FluftrodonPaintUIColorText);

            Texture2D FluftrodonPaintUIRollerIcon = GetTexture("MrPlagueRaces/Common/UI/FluftrodonPaintUIRoller");
			Texture2D FluftrodonPaintUIRoller_ActiveIcon = GetTexture("MrPlagueRaces/Common/UI/FluftrodonPaintUIRoller_Active");
			MrPlagueRaceButton FluftrodonPaintUIRoller = new MrPlagueRaceButton(FluftrodonPaintUIRollerIcon, FluftrodonPaintUIRoller_ActiveIcon);
			FluftrodonPaintUIRoller.Width.Set(40, 0);
			FluftrodonPaintUIRoller.Height.Set(40, 0);
			FluftrodonPaintUIRoller.Left.Set(55 + 40 + 43, 0);
			FluftrodonPaintUIRoller.Top.Set(0, 0);
			FluftrodonPaintUIRoller.OnClick += new MouseEvent(FluftrodonPaintUIRollerToggle);
			FluftrodonPaintUIPanelBackground.Append(FluftrodonPaintUIRoller);

			FluftrodonPaintUIRollerText = new UITextPanel<string>("");
			FluftrodonPaintUIRollerText.Width.Set(80, 0);
			FluftrodonPaintUIRollerText.Height.Set(40, 0);
			FluftrodonPaintUIRollerText.Left.Set(55 + 40 + 25, 0);
			FluftrodonPaintUIRollerText.Top.Set(30, 0);
			FluftrodonPaintUIRollerText.BackgroundColor = Color.Transparent;
			FluftrodonPaintUIRollerText.BorderColor = Color.Transparent;
			FluftrodonPaintUIPanelBackground.Append(FluftrodonPaintUIRollerText);
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

		public void FluftrodonPaintUIBrushToggle(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			Main.PlaySound(SoundID.MenuOpen, -1, -1, 1, 1f, 0f);
			if (FluftrodonPaintTileMode2 == 0)
			{
				FluftrodonPaintTileMode2 = 1;
			}
			else if (FluftrodonPaintTileMode2 == 1)
			{
				FluftrodonPaintTileMode2 = 2;
			}
			else if (FluftrodonPaintTileMode2 == 2)
			{
				FluftrodonPaintTileMode2 = 0;
			}
		}

		public void FluftrodonPaintUIRollerToggle(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			Main.PlaySound(SoundID.MenuOpen, -1, -1, 1, 1f, 0f);
			if (FluftrodonPaintWallMode2 == 0)
			{
				FluftrodonPaintWallMode2 = 1;
			}
			else if (FluftrodonPaintWallMode2 == 1)
			{
				FluftrodonPaintWallMode2 = 2;
			}
			else if (FluftrodonPaintWallMode2 == 2)
			{
				FluftrodonPaintWallMode2 = 0;
			}
		}

		public void FluftrodonPaintUIColorToggle(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			Main.PlaySound(SoundID.MenuOpen, -1, -1, 1, 1f, 0f);
			if (FluftrodonPaintColor2 < 12)
			{
				FluftrodonPaintColor2 += 1;
			}
			else if (FluftrodonPaintColor2 == 12)
			{
				FluftrodonPaintColor2 = 25;
			}
			else if (FluftrodonPaintColor2 == 25)
			{
				FluftrodonPaintColor2 = 27;
			}
			else if (FluftrodonPaintColor2 == 27)
			{
				FluftrodonPaintColor2 = 26;
			}
			else if (FluftrodonPaintColor2 == 26)
			{
				FluftrodonPaintColor2 = 28;
			}
			else if (FluftrodonPaintColor2 == 28)
			{
				FluftrodonPaintColor2 = 1;
			}
			else
			{
				FluftrodonPaintColor2 = 1;
			}
		}

		public override void Update(GameTime gameTime)
		{
			Fluftrodon _Fluftrodon = ModContent.GetInstance<Fluftrodon>();
			base.Update(gameTime);
			Fluftrodon.FluftrodonPaintTileMode = FluftrodonPaintTileMode2;
			Fluftrodon.FluftrodonPaintWallMode = FluftrodonPaintWallMode2;
			Fluftrodon.FluftrodonPaintColor = FluftrodonPaintColor2;
			if (FluftrodonPaintTileMode2 == 0)
			{
				FluftrodonPaintUIBrushText.SetText("Ignore");
			}
			else if (FluftrodonPaintTileMode2 == 1)
			{
				FluftrodonPaintUIBrushText.SetText("Paint");
			}
			else if (FluftrodonPaintTileMode2 == 2)
			{
				FluftrodonPaintUIBrushText.SetText("Erase");
			}
			else
			{
				FluftrodonPaintUIColorText.SetText("Error (please report to MrPlague!)");
			}
			if (FluftrodonPaintWallMode2 == 0)
			{
				FluftrodonPaintUIRollerText.SetText("Ignore");
			}
			else if (FluftrodonPaintWallMode2 == 1)
			{
				FluftrodonPaintUIRollerText.SetText("Paint");
			}
			else if (FluftrodonPaintWallMode2 == 2)
			{
				FluftrodonPaintUIRollerText.SetText("Erase");
			}
			else
			{
				FluftrodonPaintUIColorText.SetText("Error (please report to MrPlague!)");
			}
			if (FluftrodonPaintColor2 == 1)
			{
				FluftrodonPaintUIColorText.SetText("Red");
			}
			else if (FluftrodonPaintColor2 == 2)
			{
				FluftrodonPaintUIColorText.SetText("Orange");
			}
			else if (FluftrodonPaintColor2 == 3)
			{
				FluftrodonPaintUIColorText.SetText("Yellow");
			}
			else if (FluftrodonPaintColor2 == 4)
			{
				FluftrodonPaintUIColorText.SetText("Lime");
			}
			else if (FluftrodonPaintColor2 == 5)
			{
				FluftrodonPaintUIColorText.SetText("Green");
			}
			else if (FluftrodonPaintColor2 == 6)
			{
				FluftrodonPaintUIColorText.SetText("Teal");
			}
			else if (FluftrodonPaintColor2 == 7)
			{
				FluftrodonPaintUIColorText.SetText("Cyan");
			}
			else if (FluftrodonPaintColor2 == 8)
			{
				FluftrodonPaintUIColorText.SetText("Sky");
			}
			else if (FluftrodonPaintColor2 == 9)
			{
				FluftrodonPaintUIColorText.SetText("Blue");
			}
			else if (FluftrodonPaintColor2 == 10)
			{
				FluftrodonPaintUIColorText.SetText("Purple");
			}
			else if (FluftrodonPaintColor2 == 11)
			{
				FluftrodonPaintUIColorText.SetText("Violet");
			}
			else if (FluftrodonPaintColor2 == 12)
			{
				FluftrodonPaintUIColorText.SetText("Pink");
			}
			else if (FluftrodonPaintColor2 == 25)
			{
				FluftrodonPaintUIColorText.SetText("Black");
			}
			else if (FluftrodonPaintColor2 == 27)
			{
				FluftrodonPaintUIColorText.SetText("Gray");
			}
			else if (FluftrodonPaintColor2 == 26)
			{
				FluftrodonPaintUIColorText.SetText("White");
			}
			else if (FluftrodonPaintColor2 == 28)
			{
				FluftrodonPaintUIColorText.SetText("Brown");
			}
			else
			{
				FluftrodonPaintUIColorText.SetText("Error (please report to MrPlague!)");
			}
			if (_Fluftrodon.FluftrodonPaintUIPositionSet)
			{
				FluftrodonPaintUIPanelBackground.Left.Set(Main.mouseX - 100, 0);
				FluftrodonPaintUIPanelBackground.Top.Set(Main.mouseY - 33, 0);
			}
			if (!_Fluftrodon.FluftrodonPaintUI)
			{
				FluftrodonPaintUIPanelBackground.Left.Set(999999, 0);
				FluftrodonPaintUIPanelBackground.Top.Set(999999, 0);
			}
			Recalculate();
		}
	}
}