using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Content.Items
{
	public class Merfolk_Water_Generator : ModItem
	{
        public override void SetStaticDefaults()
        {
		    DisplayName.SetDefault("Emergency Water Generator");
            Tooltip.SetDefault("A piece of Merfolk Technology. Creates a pool of water underneath the user." + "\nCreates a pool of water directly underneath the user" + "\nUse if there are no pools or lakes in your immediate spawn range" + $"\n[c/FF0000:WARNING: This item is consumed upon use, use it wisely!]");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 32;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useAnimation = 15;
            item.useTime = 15;
            item.UseSound = SoundID.Item3;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
        }

		public override bool UseItem(Player player) 
		{
		    Main.tile[(int)((player.position.X / 16) - 3), ((int)((player.position.Y - 3)/ 16) + 2)].ClearTile();
			Main.tile[(int)((player.position.X / 16) - 2), ((int)((player.position.Y - 3)/ 16) + 2)].ClearTile();
			Main.tile[(int)((player.position.X / 16) - 1), ((int)((player.position.Y - 3)/ 16) + 2)].ClearTile();
			Main.tile[(int)(player.position.X / 16), ((int)((player.position.Y - 3)/ 16) + 2)].ClearTile();
			Main.tile[(int)((player.position.X / 16) + 1), ((int)((player.position.Y - 3)/ 16) + 2)].ClearTile();
			Main.tile[(int)((player.position.X / 16) + 2), ((int)((player.position.Y - 3)/ 16) + 2)].ClearTile();
			Main.tile[(int)((player.position.X / 16) + 3), ((int)((player.position.Y - 3)/ 16) + 2)].ClearTile();
			Main.tile[(int)((player.position.X / 16) + 4), ((int)((player.position.Y - 3)/ 16) + 2)].ClearTile();
		    Main.tile[(int)((player.position.X / 16) - 3), ((int)((player.position.Y - 3)/ 16) + 3)].ClearTile();
		    Main.tile[(int)((player.position.X / 16) - 3), ((int)((player.position.Y - 3)/ 16) + 3)].liquidType(0);
			Main.tile[(int)((player.position.X / 16) - 3), ((int)((player.position.Y - 3)/ 16) + 3)].liquid = 255;
		    Main.tile[(int)((player.position.X / 16) - 2), ((int)((player.position.Y - 3)/ 16) + 3)].ClearTile();
		    Main.tile[(int)((player.position.X / 16) - 2), ((int)((player.position.Y - 3)/ 16) + 3)].liquidType(0);
			Main.tile[(int)((player.position.X / 16) - 2), ((int)((player.position.Y - 3)/ 16) + 3)].liquid = 255;
		    Main.tile[(int)((player.position.X / 16) - 1), ((int)((player.position.Y - 3)/ 16) + 3)].ClearTile();
		    Main.tile[(int)((player.position.X / 16) - 1), ((int)((player.position.Y - 3)/ 16) + 3)].liquidType(0);
			Main.tile[(int)((player.position.X / 16) - 1), ((int)((player.position.Y - 3)/ 16) + 3)].liquid = 255;
		    Main.tile[(int)(player.position.X / 16), ((int)((player.position.Y - 3)/ 16) + 3)].ClearTile();
		    Main.tile[(int)(player.position.X / 16), ((int)((player.position.Y - 3)/ 16) + 3)].liquidType(0);
			Main.tile[(int)(player.position.X / 16), ((int)((player.position.Y - 3)/ 16) + 3)].liquid = 255;
			Main.tile[(int)((player.position.X / 16) + 1), ((int)((player.position.Y - 3)/ 16) + 3)].ClearTile();
		    Main.tile[(int)((player.position.X / 16) + 1), ((int)((player.position.Y - 3)/ 16) + 3)].liquidType(0);
			Main.tile[(int)((player.position.X / 16) + 1), ((int)((player.position.Y - 3)/ 16) + 3)].liquid = 255;
			Main.tile[(int)((player.position.X / 16) + 2), ((int)((player.position.Y - 3)/ 16) + 3)].ClearTile();
		    Main.tile[(int)((player.position.X / 16) + 2), ((int)((player.position.Y - 3)/ 16) + 3)].liquidType(0);
			Main.tile[(int)((player.position.X / 16) + 2), ((int)((player.position.Y - 3)/ 16) + 3)].liquid = 255;
			Main.tile[(int)((player.position.X / 16) + 3), ((int)((player.position.Y - 3)/ 16) + 3)].ClearTile();
		    Main.tile[(int)((player.position.X / 16) + 3), ((int)((player.position.Y - 3)/ 16) + 3)].liquidType(0);
			Main.tile[(int)((player.position.X / 16) + 3), ((int)((player.position.Y - 3)/ 16) + 3)].liquid = 255;
			Main.tile[(int)((player.position.X / 16) + 4), ((int)((player.position.Y - 3)/ 16) + 3)].ClearTile();
		    Main.tile[(int)((player.position.X / 16) + 4), ((int)((player.position.Y - 3)/ 16) + 3)].liquidType(0);
			Main.tile[(int)((player.position.X / 16) + 4), ((int)((player.position.Y - 3)/ 16) + 3)].liquid = 255;
			Main.tile[(int)((player.position.X / 16) - 2), ((int)((player.position.Y - 3)/ 16) + 4)].ClearTile();
		    Main.tile[(int)((player.position.X / 16) - 2), ((int)((player.position.Y - 3)/ 16) + 4)].liquidType(0);
			Main.tile[(int)((player.position.X / 16) - 2), ((int)((player.position.Y - 3)/ 16) + 4)].liquid = 255;
			Main.tile[(int)((player.position.X / 16) - 1), ((int)((player.position.Y - 3)/ 16) + 4)].ClearTile();
		    Main.tile[(int)((player.position.X / 16) - 1), ((int)((player.position.Y - 3)/ 16) + 4)].liquidType(0);
			Main.tile[(int)((player.position.X / 16) - 1), ((int)((player.position.Y - 3)/ 16) + 4)].liquid = 255;
			Main.tile[(int)(player.position.X / 16), ((int)((player.position.Y - 3)/ 16) + 4)].ClearTile();
		    Main.tile[(int)(player.position.X / 16), ((int)((player.position.Y - 3)/ 16) + 4)].liquidType(0);
			Main.tile[(int)(player.position.X / 16), ((int)((player.position.Y - 3)/ 16) + 4)].liquid = 255;
			Main.tile[(int)((player.position.X / 16) + 1), ((int)((player.position.Y - 3)/ 16) + 4)].ClearTile();
		    Main.tile[(int)((player.position.X / 16) + 1), ((int)((player.position.Y - 3)/ 16) + 4)].liquidType(0);
			Main.tile[(int)((player.position.X / 16) + 1), ((int)((player.position.Y - 3)/ 16) + 4)].liquid = 255;
			Main.tile[(int)((player.position.X / 16) + 2), ((int)((player.position.Y - 3)/ 16) + 4)].ClearTile();
		    Main.tile[(int)((player.position.X / 16) + 2), ((int)((player.position.Y - 3)/ 16) + 4)].liquidType(0);
			Main.tile[(int)((player.position.X / 16) + 2), ((int)((player.position.Y - 3)/ 16) + 4)].liquid = 255;
			Main.tile[(int)((player.position.X / 16) + 3), ((int)((player.position.Y - 3)/ 16) + 4)].ClearTile();
		    Main.tile[(int)((player.position.X / 16) + 3), ((int)((player.position.Y - 3)/ 16) + 4)].liquidType(0);
			Main.tile[(int)((player.position.X / 16) + 3), ((int)((player.position.Y - 3)/ 16) + 4)].liquid = 255;
			Main.tile[(int)((player.position.X / 16) - 1), ((int)((player.position.Y - 3)/ 16) + 5)].ClearTile();
		    Main.tile[(int)((player.position.X / 16) - 1), ((int)((player.position.Y - 3)/ 16) + 5)].liquidType(0);
			Main.tile[(int)((player.position.X / 16) - 1), ((int)((player.position.Y - 3)/ 16) + 5)].liquid = 255;
			Main.tile[(int)(player.position.X / 16), ((int)((player.position.Y - 3)/ 16) + 5)].ClearTile();
		    Main.tile[(int)(player.position.X / 16), ((int)((player.position.Y - 3)/ 16) + 5)].liquidType(0);
			Main.tile[(int)(player.position.X / 16), ((int)((player.position.Y - 3)/ 16) + 5)].liquid = 255;
			Main.tile[(int)((player.position.X / 16) + 2), ((int)((player.position.Y - 3)/ 16) + 5)].ClearTile();
		    Main.tile[(int)((player.position.X / 16) + 2), ((int)((player.position.Y - 3)/ 16) + 5)].liquidType(0);
			Main.tile[(int)((player.position.X / 16) + 2), ((int)((player.position.Y - 3)/ 16) + 5)].liquid = 255;
			Main.tile[(int)((player.position.X / 16) + 1), ((int)((player.position.Y - 3)/ 16) + 5)].ClearTile();
		    Main.tile[(int)((player.position.X / 16) + 1), ((int)((player.position.Y - 3)/ 16) + 5)].liquidType(0);
			Main.tile[(int)((player.position.X / 16) + 1), ((int)((player.position.Y - 3)/ 16) + 5)].liquid = 255;
			WorldGen.SquareTileFrame((int)((player.position.X / 16) - 3), ((int)((player.position.Y - 3)/ 16) + 1));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) - 2), ((int)((player.position.Y - 3)/ 16) + 1));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) - 1), ((int)((player.position.Y - 3)/ 16) + 1));
			WorldGen.SquareTileFrame((int)(player.position.X / 16), ((int)((player.position.Y - 3)/ 16) + 3));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) + 1), ((int)((player.position.Y - 3)/ 16) + 1));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) + 2), ((int)((player.position.Y - 3)/ 16) + 1));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) + 3), ((int)((player.position.Y - 3)/ 16) + 1));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) + 4), ((int)((player.position.Y - 3)/ 16) + 1));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) - 3), ((int)((player.position.Y - 3)/ 16) + 2));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) - 2), ((int)((player.position.Y - 3)/ 16) + 2));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) - 1), ((int)((player.position.Y - 3)/ 16) + 2));
			WorldGen.SquareTileFrame((int)(player.position.X / 16), ((int)((player.position.Y - 3)/ 16) + 3));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) + 1), ((int)((player.position.Y - 3)/ 16) + 2));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) + 2), ((int)((player.position.Y - 3)/ 16) + 2));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) + 3), ((int)((player.position.Y - 3)/ 16) + 2));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) + 4), ((int)((player.position.Y - 3)/ 16) + 2));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) - 3), ((int)((player.position.Y - 3)/ 16) + 3));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) - 2), ((int)((player.position.Y - 3)/ 16) + 3));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) - 1), ((int)((player.position.Y - 3)/ 16) + 3));
			WorldGen.SquareTileFrame((int)(player.position.X / 16), ((int)((player.position.Y - 3)/ 16) + 3));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) + 1), ((int)((player.position.Y - 3)/ 16) + 3));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) + 2), ((int)((player.position.Y - 3)/ 16) + 3));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) + 3), ((int)((player.position.Y - 3)/ 16) + 3));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) + 4), ((int)((player.position.Y - 3)/ 16) + 3));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) - 2), ((int)((player.position.Y - 3)/ 16) + 4));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) - 1), ((int)((player.position.Y - 3)/ 16) + 4));
			WorldGen.SquareTileFrame((int)(player.position.X / 16), ((int)((player.position.Y - 3)/ 16) + 4));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) + 1), ((int)((player.position.Y - 3)/ 16) + 4));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) + 2), ((int)((player.position.Y - 3)/ 16) + 4));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) + 3), ((int)((player.position.Y - 3)/ 16) + 4));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) - 1), ((int)((player.position.Y - 3)/ 16) + 5));
			WorldGen.SquareTileFrame((int)(player.position.X / 16), ((int)((player.position.Y - 3)/ 16) + 5));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) + 2), ((int)((player.position.Y - 3)/ 16) + 5));
			WorldGen.SquareTileFrame((int)((player.position.X / 16) + 1), ((int)((player.position.Y - 3)/ 16) + 5));
			return true;
		}
    }
}