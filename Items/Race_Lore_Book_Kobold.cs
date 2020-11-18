using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Items
{
	public class Race_Lore_Book_Kobold : ModItem
	{

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Racial Lore: Kobold");
            Tooltip.SetDefault("Unmatched at digging and finding ores, Kobolds spend the majority of their life underground." + "\nThey possess an organ within their skull that lets them 'sniff out' nearby minerals and treasure, although the nature of this organ isn't fully understood." + "\nKobolds are heavily adapted for subterranean life, to the point sunlight is physically harmful to them." + "\nIt is rumored that Kobolds were once a colony of Dragonkin that became lost underground, although nothing besides their similar appearance suggests it." + "\nRacial Stats:" + $"\n[c/34EB93:+5%] Nonmelee Damage, [c/34EB93:+5%] Movement Speed" + $"[c/34EB93:Press Racial Ability to see ores]" + $"\n[c/34EB93:+60%] Mining Speed, [c/EB3449:-10%] Health, [c/EB3449:-4] Defense" + $"\n[c/EB3449:-10%] Melee Damage, [c/EB3449:Burns in Sunlight]");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 30;
            item.rare = ItemRarityID.Blue;
        }
    }
}