using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Content.Items
{
	public class Race_Lore_Book_Derpkin : ModItem
	{

        public override void SetStaticDefaults()
        {
		    DisplayName.SetDefault("Racial Lore: Derpkin");
            Tooltip.SetDefault("Close relatives of the more primitive Derpling, the insectoid Derpkin possess the ability to move at high speeds." + "\nTheir mobility allows them to travel great distances without tiring, although they seldom leave their Jungle environment." + "\nThe relationship between the Derpkin and Derplings can be compared to that of Apes and Humans, albiet with significantly more malice from both sides." + "\nRacial Stats:" + $"\n[c/34EB93:+10%] Damage, [c/34EB93:+25%] Movement Speed" + $"\n[c/34EB93:+60%] Jump Speed, [c/34EB93:Can Autojump]" + $"\n[c/EB3449:-20%] Health, [c/EB3449:-4] Defense");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 30;
            item.rare = ItemRarityID.Blue;
        }
    }
}