using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Items
{
	public class Race_Lore_Book_Dragonkin : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Racial Lore: Dragonkin");
			Tooltip.SetDefault("Hailing from a distant land, the Dragonkin are adapted for much harsher conditions." + "\nThey are well known for their strength and endurance, both of which are nearly unmatched." + "\nThe Dragonkin are an incredibly proud species, and can be easy to offend. This causes most interactions between an outsider and a Dragonkin to go choppily." + "\nRacial Stats:" + "\nDefense and damage increase as you lose health" + "\nIncreased regeneration and mining speed while in sunlight" + $"\n[c/34EB93:+20s%] Health, [c/34EB93:+8] Defense, [c/34EB93:+10%] Melee Damage" + $"\n[c/34EB93:+2] Seconds of Lava Immunity" + $"\n[c/EB3449:-10%] Jump Speed" + $"\n[c/EB3449:-10%] Placement Speed, [c/EB3449:-10%] Mining Speed");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.rare = ItemRarityID.Blue;
		}
	}
}