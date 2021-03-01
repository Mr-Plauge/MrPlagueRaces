using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Content.Items
{
	public class Race_Lore_Book_Human : ModItem
	{

        public override void SetStaticDefaults()
        {
		    DisplayName.SetDefault("Racial Lore: Humans");
            Tooltip.SetDefault("Believed to have descended from Apes, Humanity has since evolved and gained sentience quickly." + "\nThey are adapted for a plethora of conditions, and can survive in almost any given environment." + "\nRacial Stats:" + "\nNo stat changes");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 30;
            item.rare = ItemRarityID.Blue;
        }
    }
}