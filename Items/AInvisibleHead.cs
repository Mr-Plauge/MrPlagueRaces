using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class AInvisibleHead : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Invisible Mask");
			Tooltip.SetDefault("Makes your headwear appear invisible");
		}

		public override void SetDefaults() 
		{
			item.width = 18;
			item.height = 18;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CopperCoin, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}