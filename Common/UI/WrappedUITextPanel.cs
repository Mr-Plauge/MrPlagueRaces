using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace MrPlagueRaces.Common.UI
{
	public class WrappedUITextPanel<T> : UIPanel
	{
		private T _text;

		public string Text { get => _text.ToString(); }

		public List<(string, float)> TextLines = new List<(string, float)>();

		public bool RecalculateTextLines { get; set; }

		public WrappedUITextPanel(T text)
		{
			SetText(text);
		}

		public override void OnActivate()
		{
			base.OnActivate();

			RecalculateTextLines = true;
		}

		public void SetText(T text)
		{
			_text = text;
			RecalculateTextLines = true;
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			base.DrawSelf(spriteBatch);

			CalculatedStyle space = GetInnerDimensions();
			DynamicSpriteFont font = Main.fontMouseText;
			float position = 0f;

			foreach ((string textLine, float positionOffset) in TextLines)
			{
				Utils.DrawBorderString(spriteBatch, textLine, new Vector2(space.X, space.Y + position), Color.White);
				position += positionOffset;
			}

			Recalculate();
		}

		public override void RecalculateChildren()
		{
			base.RecalculateChildren();

			if (!RecalculateTextLines)
				return;

			CalculatedStyle space = GetInnerDimensions();

			if (space.Width <= 0 || space.Height <= 0)
				return;

			DynamicSpriteFont font = Main.fontMouseText;

			TextLines.Clear();

			float textHeight = font.MeasureString("A").Y;

			foreach (string line in Text.Split('\n'))
			{
				string drawString = line;

				do
				{
					string remainder = "";

					while (font.MeasureString(drawString).X > space.Width + 26f)
					{
						remainder = drawString[drawString.Length - 1] + remainder;
						drawString = drawString.Substring(0, drawString.Length - 1);
					}

					if (remainder.Length > 0)
					{
						int index = drawString.LastIndexOf(' ');

						if (index >= 0)
						{
							remainder = drawString.Substring(index + 1) + remainder;
							drawString = drawString.Substring(0, index);
						}
					}

					TextLines.Add((drawString, textHeight));

					drawString = remainder;
				}
				while (drawString.Length > 0);
			}
			
			RecalculateTextLines = false;
		}
	}
}