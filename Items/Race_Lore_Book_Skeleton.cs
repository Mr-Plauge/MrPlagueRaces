using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Items
{
	public class Race_Lore_Book_Skeleton : ModItem
	{

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Racial Lore: Skeleton");
            Tooltip.SetDefault("The skeletons of this world can be reanimated in a variety of ways." + "\nThe most common practice is to forcefully bind a spirit to a dead body." + "\nDue to the crudeness of the magic involved, Skeletons reanimated via this process are typically reduced to an animal-like state." + "\nThe ones that manage to retain their sanity after going through reanimation are almost always strong-willed, and rarely back down from adversity." + "\nRacial Stats:" + $"\n[c/34EB93:+20%] Magic Damage, [c/34EB93:+15%] Movement Speed" + $"\n[c/34EB93:+50] Mana, [c/34EB93:Can breathe in water]" + $"\n[c/34EB93:Immune to Bleeding, Suffocation, and Poison]" + $"\n[c/EB3449:-25%] Health, [c/EB3449:-4] defense");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 30;
            item.rare = ItemRarityID.Blue;
        }
    }
}