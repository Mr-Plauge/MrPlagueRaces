using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.UI;
using Terraria.ModLoader;
using MrPlagueRaces.Common.Races;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Common.UI
{
    public class MrPlagueRaceSelectButtonInfo : UIElement
    {
        private Texture2D _texture;
        private Texture2D _textureActive;
        private int _raceNumber;

		public Texture2D UI_RaceSelectImageIcon1()
		{
			switch (RaceLoader.Races.Count > (0 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[0 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon2()
		{
			switch (RaceLoader.Races.Count > (1 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[1 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon3()
		{
			switch (RaceLoader.Races.Count > (2 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[2 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon4()
		{
			switch (RaceLoader.Races.Count > (3 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[3 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon5()
		{
			switch (RaceLoader.Races.Count > (4 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[4 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon6()
		{
			switch (RaceLoader.Races.Count > (5 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[5 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon7()
		{
			switch (RaceLoader.Races.Count > (6 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[6 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon8()
		{
			switch (RaceLoader.Races.Count > (7 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[7 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon9()
		{
			switch (RaceLoader.Races.Count > (8 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[8 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon10()
		{
			switch (RaceLoader.Races.Count > (9 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[9 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon11()
		{
			switch (RaceLoader.Races.Count > (10 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[10 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon12()
		{
			switch (RaceLoader.Races.Count > (11 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[11 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon13()
		{
			switch (RaceLoader.Races.Count > (12 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[12 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon14()
		{
			switch (RaceLoader.Races.Count > (13 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[13 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon15()
		{
			switch (RaceLoader.Races.Count > (14 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[14 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon16()
		{
			switch (RaceLoader.Races.Count > (15 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[15 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon17()
		{
			switch (RaceLoader.Races.Count > (16 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[16 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon18()
		{
			switch (RaceLoader.Races.Count > (17 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[17 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon19()
		{
			switch (RaceLoader.Races.Count > (18 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[18 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon20()
		{
			switch (RaceLoader.Races.Count > (19 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[19 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon21()
		{
			switch (RaceLoader.Races.Count > (20 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[20 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon22()
		{
			switch (RaceLoader.Races.Count > (21 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[21 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon23()
		{
			switch (RaceLoader.Races.Count > (22 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[22 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon24()
		{
			switch (RaceLoader.Races.Count > (23 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[23 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon25()
		{
			switch (RaceLoader.Races.Count > (24 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[24 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon26()
		{
			switch (RaceLoader.Races.Count > (25 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[25 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon27()
		{
			switch (RaceLoader.Races.Count > (26 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[26 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon28()
		{
			switch (RaceLoader.Races.Count > (27 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[27 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon29()
		{
			switch (RaceLoader.Races.Count > (28 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[28 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon30()
		{
			switch (RaceLoader.Races.Count > (29 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[29 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon31()
		{
			switch (RaceLoader.Races.Count > (30 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[30 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon32()
		{
			switch (RaceLoader.Races.Count > (31 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[31 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon33()
		{
			switch (RaceLoader.Races.Count > (32 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[32 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		public Texture2D UI_RaceSelectImageIcon34()
		{
			switch (RaceLoader.Races.Count > (33 + (MrPlagueRaceInformation.RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[33 + (MrPlagueRaceInformation.RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}

		public MrPlagueRaceSelectButtonInfo(Texture2D texture, Texture2D textureActive, int raceNumber)
        {
            if (!Main.dedServ)
            {
                _texture = texture;
                _textureActive = textureActive;
				_raceNumber = raceNumber;
				Width.Set(_texture.Width, 0f);
                Height.Set(_texture.Height, 0f);
            }
        }

        public void SetImage(Texture2D texture, Texture2D textureActive, int raceNumber)
        {
            _texture = texture;
            _textureActive = textureActive;
			_raceNumber = raceNumber;
			Width.Set(_texture.Width, 0f);
            Height.Set(_texture.Height, 0f);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
			var RaceSelectImageIcon1 = UI_RaceSelectImageIcon1();
			var RaceSelectImageIcon2 = UI_RaceSelectImageIcon2();
			var RaceSelectImageIcon3 = UI_RaceSelectImageIcon3();
			var RaceSelectImageIcon4 = UI_RaceSelectImageIcon4();
			var RaceSelectImageIcon5 = UI_RaceSelectImageIcon5();
			var RaceSelectImageIcon6 = UI_RaceSelectImageIcon6();
			var RaceSelectImageIcon7 = UI_RaceSelectImageIcon7();
			var RaceSelectImageIcon8 = UI_RaceSelectImageIcon8();
			var RaceSelectImageIcon9 = UI_RaceSelectImageIcon9();
			var RaceSelectImageIcon10 = UI_RaceSelectImageIcon10();
			var RaceSelectImageIcon11 = UI_RaceSelectImageIcon11();
			var RaceSelectImageIcon12 = UI_RaceSelectImageIcon12();
			var RaceSelectImageIcon13 = UI_RaceSelectImageIcon13();
			var RaceSelectImageIcon14 = UI_RaceSelectImageIcon14();
			var RaceSelectImageIcon15 = UI_RaceSelectImageIcon15();
			var RaceSelectImageIcon16 = UI_RaceSelectImageIcon16();
			var RaceSelectImageIcon17 = UI_RaceSelectImageIcon17();
			var RaceSelectImageIcon18 = UI_RaceSelectImageIcon18();
			var RaceSelectImageIcon19 = UI_RaceSelectImageIcon19();
			var RaceSelectImageIcon20 = UI_RaceSelectImageIcon20();
			var RaceSelectImageIcon21 = UI_RaceSelectImageIcon21();
			var RaceSelectImageIcon22 = UI_RaceSelectImageIcon22();
			var RaceSelectImageIcon23 = UI_RaceSelectImageIcon23();
			var RaceSelectImageIcon24 = UI_RaceSelectImageIcon24();
			var RaceSelectImageIcon25 = UI_RaceSelectImageIcon25();
			var RaceSelectImageIcon26 = UI_RaceSelectImageIcon26();
			var RaceSelectImageIcon27 = UI_RaceSelectImageIcon27();
			var RaceSelectImageIcon28 = UI_RaceSelectImageIcon28();
			var RaceSelectImageIcon29 = UI_RaceSelectImageIcon29();
			var RaceSelectImageIcon30 = UI_RaceSelectImageIcon30();
			var RaceSelectImageIcon31 = UI_RaceSelectImageIcon31();
			var RaceSelectImageIcon32 = UI_RaceSelectImageIcon32();
			var RaceSelectImageIcon33 = UI_RaceSelectImageIcon33();
			var RaceSelectImageIcon34 = UI_RaceSelectImageIcon34();
			CalculatedStyle dimensions = GetDimensions();
            Vector2 SelectButtonIconPosition = new Vector2(64 / 2 - RaceSelectImageIcon1.Width * 1f / 2,
                56 / 2 - UI_RaceSelectImageIcon1().Height * 1f / 2);
            spriteBatch.Draw((IsMouseHovering ? _textureActive : _texture), dimensions.Position(), Color.White * 1f);
            if (_raceNumber == 0)
            {
                spriteBatch.Draw(RaceSelectImageIcon1, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            }
            else if (_raceNumber == 1)
            {
                spriteBatch.Draw(RaceSelectImageIcon2, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            }
            else if (_raceNumber == 2)
            {
                spriteBatch.Draw(RaceSelectImageIcon3, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            }
            else if (_raceNumber == 3)
            {
                spriteBatch.Draw(RaceSelectImageIcon4, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            }
            else if (_raceNumber == 4)
            {
                spriteBatch.Draw(RaceSelectImageIcon5, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            }
            else if (_raceNumber == 5)
            {
                spriteBatch.Draw(RaceSelectImageIcon6, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            }
            else if (_raceNumber == 6)
            {
                spriteBatch.Draw(RaceSelectImageIcon7, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            }
            else if (_raceNumber == 7)
            {
                spriteBatch.Draw(RaceSelectImageIcon8, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            }
            else if (_raceNumber == 8)
            {
                spriteBatch.Draw(RaceSelectImageIcon9, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            }
            else if (_raceNumber == 9)
            {
                spriteBatch.Draw(RaceSelectImageIcon10, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            }
            else if (_raceNumber == 10)
            {
                spriteBatch.Draw(RaceSelectImageIcon11, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            }
            else if (_raceNumber == 11)
            {
                spriteBatch.Draw(RaceSelectImageIcon12, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            }
            else if (_raceNumber == 12)
            {
                spriteBatch.Draw(RaceSelectImageIcon13, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            }
            else if (_raceNumber == 13)
            {
                spriteBatch.Draw(RaceSelectImageIcon14, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            }
            else if (_raceNumber == 14)
            {
                spriteBatch.Draw(RaceSelectImageIcon15, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            }
            else if (_raceNumber == 15)
            {
                spriteBatch.Draw(RaceSelectImageIcon16, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            }
            else if (_raceNumber == 16)
            {
                spriteBatch.Draw(RaceSelectImageIcon17, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            }
            else if (_raceNumber == 17)
            {
                spriteBatch.Draw(RaceSelectImageIcon18, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            }
            else if (_raceNumber == 18)
            {
                spriteBatch.Draw(RaceSelectImageIcon19, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            }
            else if (_raceNumber == 19)
            {
                spriteBatch.Draw(RaceSelectImageIcon20, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            }
            else if (_raceNumber == 20)
            {
                spriteBatch.Draw(RaceSelectImageIcon21, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            }
            else if (_raceNumber == 21)
            {
                spriteBatch.Draw(RaceSelectImageIcon22, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            }
			else if (_raceNumber == 22)
			{
				spriteBatch.Draw(RaceSelectImageIcon23, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			}
			else if (_raceNumber == 23)
			{
				spriteBatch.Draw(RaceSelectImageIcon24, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			}
			else if (_raceNumber == 24)
			{
				spriteBatch.Draw(RaceSelectImageIcon25, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			}
			else if (_raceNumber == 25)
			{
				spriteBatch.Draw(RaceSelectImageIcon26, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			}
			else if (_raceNumber == 26)
			{
				spriteBatch.Draw(RaceSelectImageIcon27, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			}
			else if (_raceNumber == 27)
			{
				spriteBatch.Draw(RaceSelectImageIcon28, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			}
			else if (_raceNumber == 28)
			{
				spriteBatch.Draw(RaceSelectImageIcon29, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			}
			else if (_raceNumber == 29)
			{
				spriteBatch.Draw(RaceSelectImageIcon30, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			}
			else if (_raceNumber == 30)
			{
				spriteBatch.Draw(RaceSelectImageIcon31, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			}
			else if (_raceNumber == 31)
			{
				spriteBatch.Draw(RaceSelectImageIcon32, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			}
			else if (_raceNumber == 32)
			{
				spriteBatch.Draw(RaceSelectImageIcon33, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			}
			else if (_raceNumber == 33)
			{
				spriteBatch.Draw(RaceSelectImageIcon34, dimensions.Position() + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			}
		}

		public override void MouseOver(UIMouseEvent evt)
		{
			base.MouseOver(evt);
		}
	}
}
