using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Content.Items
{
	public class Race_Lore_Book_Tabaxi : ModItem
	{

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Racial Lore: Tabaxi");
            Tooltip.SetDefault("Tabaxi are usually nomadic, and never stay in one place for more than a day. " + "\nTheir agility and clawed hands allow them to traverse most areas with ease, but they are clumsy fighters." + "\nMost of the Tabaxi are driven by curiosity rather than desire for wealth or power, and they do not stick to a single goal for long." + "\nUsually, they are solitary. Tabaxi very rarely form organized colonies, with their drifting-minded nature typically dissolving the group in a matter of days." + "\nRacial Stats:" + "\n[c/34EB93:Dangersense and fall damage nullification are granted when at low health]" + $"\n[c/34EB93:+40%] Movement Speed, [c/34EB93:+35%] Jump Speed" + $"\n[c/34EB93:+25%] Placement Speed, [c/34EB93:+25%] Mining Speed" + $"\n[c/EB3449:-4] Defense, [c/EB3449:-10%] Damage");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.rare = ItemRarityID.Blue;
        }
    }
}