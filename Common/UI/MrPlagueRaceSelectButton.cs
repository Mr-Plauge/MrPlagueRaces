using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.UI;

namespace MrPlagueRaces.Common.UI
{
    public class MrPlagueRaceSelectButton : UIElement
    {
        private Texture2D _texture;
		private Texture2D _textureActive;

		public MrPlagueRaceSelectButton(Texture2D texture, Texture2D textureActive)
        {
            if (!Main.dedServ)
            {
                _texture = texture;
				_textureActive = textureActive;
				Width.Set(_texture.Width, 0f);
                Height.Set(_texture.Height, 0f);
            }
        }

        public void SetImage(Texture2D texture, Texture2D textureActive)
        {
            _texture = texture;
			_textureActive = textureActive;
			Width.Set(_texture.Width, 0f);
            Height.Set(_texture.Height, 0f);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle dimensions = GetDimensions();
			spriteBatch.Draw((IsMouseHovering ? _textureActive : _texture), dimensions.Position(), Color.White * 1f);
		}

		public override void MouseOver(UIMouseEvent evt)
		{
			base.MouseOver(evt);
		}
	}
}
