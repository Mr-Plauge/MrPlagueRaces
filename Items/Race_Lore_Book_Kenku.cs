using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Items
{
	public class Race_Lore_Book_Kenku : ModItem
	{

        public override void SetStaticDefaults()
        {
		    DisplayName.SetDefault("Racial Lore: Kenku");
            Tooltip.SetDefault("The Kenku are a secretive race, with most of their nature still unknown." + "\nThey possess very weak flight, as well as fast reflexes." + "\nBoth skills combine to make them talented assassins and escape artists." + "\nKenku are native to the woodlands of this world, although they can survive elsewhere with little trouble." + "\nRacial Stats:" + $"\n[c/34EB93:+15%] Damage, [c/34EB93:+10%] Crit Chance" + $"\n[c/34EB93:+25%] Movement Speed, [c/34EB93:+50%] Flight Time" + $"\n[c/EB3449:-25%] Health, [c/EB3449:-8] Defense");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 30;
            item.rare = ItemRarityID.Blue;
        }
    }
}