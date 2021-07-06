using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System.Text;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace MrPlagueRaces.Common.UI
{
	public class WrappedUITextPanel<T> : UIPanel
	{
		private T _textObject;

		public virtual string Text
		{
			get => _textObject.ToString();
		}

		public bool IsLarge { get; set; }

		public float TextScale { get; set; }

		public Vector2 TextSize { get; set; } = Vector2.Zero;

		public Color TextColor { get; set; }

		public bool DrawPanel { get; set; }

		public WrappedUITextPanel(T text, float textScale = 1, bool large = false)
		{
			InternalSetText(text, textScale, large);
		}

		protected void InternalSetText(T text, float textScale, bool large)
		{
			DynamicSpriteFont font = large ? Main.fontDeathText : Main.fontMouseText;
			Vector2 unscaledSize = new Vector2(font.MeasureString(text.ToString()).X, large ? 32f : 16f);
			Vector2 textSize = unscaledSize * textScale;

			_textObject = text;
			TextScale = textScale;
			TextSize = textSize;
			IsLarge = large;

			MinWidth.Set(textSize.X + PaddingLeft + PaddingRight, 0.0f);
			MinHeight.Set(textSize.Y + PaddingTop + PaddingBottom, 0.0f);
		}

		public void SetText(T text, float? textScale = null, bool? large = null) =>
			InternalSetText(text, textScale ?? TextScale, large ?? IsLarge);

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			if (DrawPanel)
				base.DrawSelf(spriteBatch);

			CalculatedStyle dimensions = GetInnerDimensions();
			Vector2 positionOffset =
				new Vector2((dimensions.Width - TextSize.X) * 0.5f, -((IsLarge ? 10f : 2f) * TextScale));

			Vector2 position = dimensions.Position() + positionOffset;

			if (IsLarge)
				Utils.DrawBorderStringBig(spriteBatch, GenerateWrappedText(spriteBatch, Text), position, Color.White,
					TextScale);
			else
				Utils.DrawBorderString(spriteBatch, GenerateWrappedText(spriteBatch, Text), position, Color.White,
					TextScale);
		}

		public float GetWordLength(SpriteBatch spriteBatch, string text) => IsLarge
			? Utils.DrawBorderStringBig(spriteBatch, text, Vector2.Zero, Color.White, TextScale).X
			: Utils.DrawBorderString(spriteBatch, text, Vector2.Zero, Color.White, TextScale).X;

		public float GetPaddedBoundary() => GetInnerDimensions().Width + PaddingLeft + PaddingRight;

		public string GenerateWrappedText(SpriteBatch spriteBatch, string text)
		{
			StringBuilder builder = new StringBuilder();
			string currentLine = "";
			string[] splitText = text.Split(' ');

			foreach (string terminatedWord in splitText)
			{
				if (GetWordLength(spriteBatch, currentLine + terminatedWord) > GetPaddedBoundary())
				{
					builder.AppendLine(currentLine);
					currentLine = "";
				}

				currentLine += terminatedWord + ' ';
			}

			return builder.ToString();
		}
	}
}