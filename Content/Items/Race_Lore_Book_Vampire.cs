using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Content.Items
{
	public class Race_Lore_Book_Vampire : ModItem
	{

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Racial Lore: Vampire");
            Tooltip.SetDefault("According to most Human folklore, Vampires are undead Humans that were given some form of unholy power." + "\nIn reality, Vampires are an entirely separate species." + "\nThey are primarily nocturnal, and feed by draining the blood of weaker creatures. Additionally, they are capable of morphing into a bat-like state." + "\nSunlight is incredibly deadly to Vampires, forcing them into caves and abandoned buildings during the day." + "\nRacial Stats:" + $"\n[c/34EB93:Press Racial Ability to become a Bat]" + $"\n[c/34EB93:+5%] Movement Speed, [c/34EB93:+10%] Mining Speed" + $"\n[c/34EB93:Increased Heart Pickup Range]" + $"\n[c/EB3449:Burns in Sunlight, Cannot use items as a Bat]");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 30;
            item.rare = ItemRarityID.Blue;
        }
    }
}