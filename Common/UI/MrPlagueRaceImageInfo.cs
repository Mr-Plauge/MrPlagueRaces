using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.UI;

namespace MrPlagueRaces.Common.UI
{
    public class MrPlagueRaceImageInfo : UIElement
    {
        private Texture2D _texture;
        internal string ImageHoverText;

        public MrPlagueRaceImageInfo(Texture2D texture, string hoverText)
        {
            ImageHoverText = hoverText;
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
            CalculatedStyle dimensions = GetDimensions();
            spriteBatch.Draw(_texture, dimensions.Position(), Color.White);
<<<<<<< HEAD
			if (IsMouseHovering)
			{
				Main.hoverItemName = ImageHoverText;
			}
=======
        }

        public override void MouseOver(UIMouseEvent evt)
        {
            base.MouseOver(evt);
            MrPlagueRaceInformation.RaceHoverTextStringInfo = ImageHoverText;
        }

		public override void MouseOut(UIMouseEvent evt)
		{
			MrPlagueRaceInformation.RaceHoverTextStringInfo = ("");
>>>>>>> 169fa3e2245a5a331199c3ef20601bfdd7f9e319
		}
	}
}
