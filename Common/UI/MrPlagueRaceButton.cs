using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.UI;

namespace MrPlagueRaces.Common.UI
{
	public class MrPlagueRaceButton : UIElement
	{
		private Texture2D _texture;
		private float _visibilityActive = 1f;
        private float _visibilityInactive = 0.8f;

		public MrPlagueRaceButton(Texture2D texture)
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
			CalculatedStyle dimensions = GetDimensions();
            spriteBatch.Draw(_texture, dimensions.Position(), Color.White * (IsMouseHovering ? _visibilityActive : _visibilityInactive));
		}

		public override void MouseOver(UIMouseEvent evt)
		{
			base.MouseOver(evt);
			Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
		}

		public void SetVisibility(float whenActive, float whenInactive)
		{
			_visibilityActive = MathHelper.Clamp(whenActive, 0f, 1f);
			_visibilityInactive = MathHelper.Clamp(whenInactive, 0f, 1f);
		}
	}
}
