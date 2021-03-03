using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.UI;
using MrPlagueRaces.Common.Races;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Common.UI
{
    public class MrPlagueRaceDisplayImageInfo : UIElement
    {
        private Texture2D _texture;
		private Texture2D UI_RaceEnvironmentImageIcon()
		{
			return GetTexture(RaceLoader.Races[MrPlagueRaceInformation.RaceIndex].RaceEnvironmentIcon);
		}
		private Texture2D UI_RaceEnvironmentOverlay1ImageIcon()
		{
			return GetTexture(RaceLoader.Races[MrPlagueRaceInformation.RaceIndex].RaceEnvironmentOverlay1Icon);
		}
		private Texture2D UI_RaceEnvironmentOverlay2ImageIcon()
		{
			return GetTexture(RaceLoader.Races[MrPlagueRaceInformation.RaceIndex].RaceEnvironmentOverlay2Icon);
		}
		public Texture2D UI_RaceDisplayMaleImageIcon()
		{
			return GetTexture(RaceLoader.Races[MrPlagueRaceInformation.RaceIndex].RaceDisplayMaleIcon);
		}
		public Texture2D UI_RaceDisplayFemaleImageIcon()
		{
			return GetTexture(RaceLoader.Races[MrPlagueRaceInformation.RaceIndex].RaceDisplayFemaleIcon);
		}

		public MrPlagueRaceDisplayImageInfo(Texture2D texture)
        {
            if (!Main.dedServ)
            {
                _texture = texture;
                Width.Set(_texture.Width, 0f);
                Height.Set(_texture.Height, 0f);
            }
        }

        public void SetImage(Texture2D texture)
        {
            _texture = texture;
            Width.Set(_texture.Width, 0f);
            Height.Set(_texture.Height, 0f);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
			var RaceEnvironmentImageIcon = UI_RaceEnvironmentImageIcon();
			var RaceEnvironmentOverlay1ImageIcon = UI_RaceEnvironmentOverlay1ImageIcon();
			var RaceEnvironmentOverlay2ImageIcon = UI_RaceEnvironmentOverlay2ImageIcon();
			var RaceDisplayMaleImageIcon = UI_RaceDisplayMaleImageIcon();
			var RaceDisplayFemaleImageIcon = UI_RaceDisplayFemaleImageIcon();
            CalculatedStyle dimensions = GetDimensions();
			Vector2 DisplayIconPosition = new Vector2(100 / 2 - RaceDisplayMaleImageIcon.Width * 1f / 2,
				138 / 2 - UI_RaceDisplayMaleImageIcon().Height * 1f / 2);
			spriteBatch.Draw(_texture, dimensions.Position(), Color.White);
			if (RaceLoader.Races[MrPlagueRaceInformation.RaceIndex].DarkenEnvironment)
			{
				spriteBatch.Draw(RaceEnvironmentImageIcon, new Vector2(dimensions.X, dimensions.Y) + DisplayIconPosition, null, new Color(100, 100, 100), 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			}
			else
			{
				spriteBatch.Draw(RaceEnvironmentImageIcon, new Vector2(dimensions.X, dimensions.Y) + DisplayIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			}
			spriteBatch.Draw(RaceEnvironmentOverlay1ImageIcon, new Vector2(dimensions.X, dimensions.Y) + DisplayIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceEnvironmentOverlay2ImageIcon, new Vector2(dimensions.X, dimensions.Y) + DisplayIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceDisplayMaleImageIcon, new Vector2(dimensions.X, dimensions.Y) + DisplayIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceDisplayFemaleImageIcon, new Vector2(dimensions.X, dimensions.Y) + DisplayIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
		}
	}
}
