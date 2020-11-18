using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Items
{
	public class Stat_Toggler : ModItem
	{
        public override void SetStaticDefaults()
        {
		    DisplayName.SetDefault("Racial Stat Toggling Potion");
			Tooltip.SetDefault("A concoction that disables/reenables Racial Stats for the user." + "\nToggles Racial Stats on and off for the current character when used");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 24;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.rare = ItemRarityID.Blue;
		}

		public override bool UseItem(Player player) 
		{
		    MrPlagueRacesPlayer MrPlagueRacesPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();
			if (MrPlagueRacesPlayer.RaceStats == true)
			{
			    MrPlagueRacesPlayer.RaceStats = false;
				Main.NewText(player.name + "'s Racial Stats have been disabled!", 52, 235, 147);
			}
			else if (MrPlagueRacesPlayer.RaceStats == false)
			{
				MrPlagueRacesPlayer.RaceStats = true;
				Main.NewText(player.name + "'s Racial Stats have been enabled!", 52, 235, 147);
			}
			return true;
		}
    }
}