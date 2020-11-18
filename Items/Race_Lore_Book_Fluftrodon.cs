using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Items
{
	public class Race_Lore_Book_Fluftrodon : ModItem
	{

        public override void SetStaticDefaults()
        {
		    DisplayName.SetDefault("Racial Lore: Fluftrodons");
            Tooltip.SetDefault("Raptor-like creatures with an affinity for building and painting. Art is heavily engrained within their culture." + "\nFluftrodons don't seem to have originated from this planet, with most of their fossils and remnants suggesting they popped up abruptly from seemingly nowhere." + "\nTheir fur has a paintbrush-like consistency and they can produce an ink-like substance of various colors from their tails, making them into living paintbrushes." + "\nLINK TO THE FLUFTRODON COMMUNITY'S DISCORD: https://discord.gg/xXQ3d25" + "\nRacial Stats:" + "\n[c/34EB93:Press Racial Ability to paint]" + "\n[c/34EB93:+15%] Movement Speed, [c/34EB93:+10%] Jump Speed" + "\n[c/34EB93:+20%] Mining Speed, [c/34EB93:+50%] Placement Speed" + "\n[c/34EB93:+2] Placement Range, [c/EB3449:-15%] Damage");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 30;
            item.rare = ItemRarityID.Blue;
        }
    }
}