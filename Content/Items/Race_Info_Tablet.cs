using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameInput;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Content.Items
{
	public class Race_Info_Tablet : ModItem
	{
        public override void SetStaticDefaults()
        {
		    DisplayName.SetDefault("Racial Information Tablet");
            Tooltip.SetDefault("A device that displays information about every playable race. Batteries included." + "\nOpens the Race Information menu");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 34;
            item.holdStyle = ItemHoldStyleID.HoldingOut;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 5;
            item.useTime = 5;
			item.rare = ItemRarityID.Quest;
        }

		public override void HoldStyle(Player player)
		{
			if (player.direction == 1)
            {
				player.itemLocation.X = player.Center.X - 19f * player.direction;
				player.itemLocation.Y = player.position.Y + 4f * player.gravDir + player.mount.PlayerOffsetHitbox;
				player.itemRotation = 0f;
			}
			else if (player.direction == -1)
            {
				player.itemLocation.X = player.Center.X + 15f * player.direction;
				player.itemLocation.Y = player.position.Y + 4f * player.gravDir + player.mount.PlayerOffsetHitbox;
				player.itemRotation = 0f;
			}

		}

		public override bool UseItem(Player player) 
		{
<<<<<<< HEAD
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();
=======
			var modPlayer = Main.LocalPlayer.GetModPlayer<MrPlagueRacesPlayer>();
>>>>>>> 169fa3e2245a5a331199c3ef20601bfdd7f9e319
			if (modPlayer.MrPlagueRaceInfo)
			{
                Main.PlaySound(SoundID.MenuClose, (int)player.Center.X, (int)player.Center.Y, 1, 1f, 0f);
				modPlayer.MrPlagueRaceInfoMouseX = 999999;
				modPlayer.MrPlagueRaceInfoMouseY = 999999;
				modPlayer.MrPlagueRaceInfo = false;
			}
			else
			{
				Main.PlaySound(SoundID.MenuOpen, (int)player.Center.X, (int)player.Center.Y, 1, 1f, 0f);
				modPlayer.MrPlagueRaceInfo = true;
<<<<<<< HEAD
				modPlayer.MrPlagueRaceInfoMouseX = Main.mouseX - 800;
				modPlayer.MrPlagueRaceInfoMouseY = Main.mouseY - 400;
=======
				modPlayer.MrPlagueRaceInfoMouseX = Main.mouseX;
				modPlayer.MrPlagueRaceInfoMouseY = Main.mouseY;
>>>>>>> 169fa3e2245a5a331199c3ef20601bfdd7f9e319
			}
			return true;
		}
    }
}