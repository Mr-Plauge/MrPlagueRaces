using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Items
{
	public class Race_Lore_Book_Goblin : ModItem
	{

        public override void SetStaticDefaults()
        {
		    DisplayName.SetDefault("Racial Lore: Goblins");
            Tooltip.SetDefault("The Goblins of this world travel in massive colonies, taking over entire continents with their sheer numbers." + "\nWhilst their volatile nature may make them seem brutish and dumb, Goblins have been proven to be quite intelligent." + "\nRacial Stats:" + $"\n[c/34EB93:+1] Minions, [c/34EB93:+1] Turrets, [c/34EB93:+10%] Movement Speed" + $"\n[c/34EB93:+10%] Placement Speed, [c/34EB93:+10%] Mining Speed" + $"\n[c/EB3449:-20%] Health, [c/EB3449:-10%] Damage");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 30;
            item.rare = ItemRarityID.Blue;
        }
    }
}