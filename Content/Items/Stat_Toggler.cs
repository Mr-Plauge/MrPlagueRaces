using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Content.Items
{
	public class Stat_Toggler : ModItem
	{
        public override void SetStaticDefaults()
        {
		    DisplayName.SetDefault("Racial Stat Toggling Device");
			Tooltip.SetDefault("A device that disables/reenables Racial Stats for the user." + "\nToggles Racial Stats on and off for the current character when used");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 5;
            item.useTime = 5;
            item.useTurn = true;
            item.rare = ItemRarityID.Quest;
		}

		public override bool UseItem(Player player) 
		{
		    MrPlagueRacesPlayer MrPlagueRacesPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();
			if (MrPlagueRacesPlayer.RaceStats)
			{
				Main.PlaySound(SoundID.MenuClose, (int)player.Center.X, (int)player.Center.Y, 1, 1f, 0f);
				MrPlagueRacesPlayer.RaceStats = false;
				Main.NewText(player.name + "'s Racial Stats have been disabled!", 52, 235, 147);
			}
			else if (!MrPlagueRacesPlayer.RaceStats)
			{
				Main.PlaySound(SoundID.MenuOpen, (int)player.Center.X, (int)player.Center.Y, 1, 1f, 0f);
				MrPlagueRacesPlayer.RaceStats = true;
				Main.NewText(player.name + "'s Racial Stats have been enabled!", 52, 235, 147);
			}
			return true;
		}
    }
}