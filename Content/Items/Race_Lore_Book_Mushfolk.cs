using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Content.Items
{
	public class Race_Lore_Book_Mushfolk : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Racial Lore: Mushfolk");
			Tooltip.SetDefault("The origins of the Mushfolk are incredibly mysterious, and they are seldom seen outside of the Glowing Mushroom fields." + "\nIt is theorized that they were created by the planet itself to protect it in the abscense of the near-extinct Dryads, although this is debatable." + "\nThe Mushfolk seem to generate a healing Aura around them, which regenerates the health of anything they are close to." + "\nRacial Stats:" + $"\n[c/34EB93:+10%] Health, [c/34EB93:+1] Minions, [c/34EB93:+10%] Movement Speed" + $"\n[c/34EB93:All nearby Allies are healed by you]" + $"\n[c/EB3449:-15%] Damage");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 30;
			item.rare = ItemRarityID.Blue;
		}
	}
}