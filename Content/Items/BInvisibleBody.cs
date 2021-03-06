using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Content.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class BInvisibleBody : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Invisible Suit");
			Tooltip.SetDefault("Makes your torsowear appear invisible");
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