using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Items
{
	public class Race_Lore_Book_Merfolk : ModItem
	{

        public override void SetStaticDefaults()
        {
		    DisplayName.SetDefault("Racial Lore: Merfolk");
            Tooltip.SetDefault("The Merfolk are a nearly extinct race that used to inhabit a now frozen ocean." + "\nThey possess gills instead of lungs, and are natural swimmers." + "\nThe technology of the Merfolk was said to be beyond even that of Humans, although most of it was lost during the ocean's freezing." + "\nRacial Stats:" + $"\n[c/34EB93:+25%] Damage when wet, [c/34EB93:Can breathe in water]" + $"\n[c/34EB93:+25%] Placement Speed, [c/34EB93:+10%] Mining Speed" + $"\n[c/EB3449:Can't breathe in air, except during rain]");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 30;
            item.rare = ItemRarityID.Blue;
        }
    }
}