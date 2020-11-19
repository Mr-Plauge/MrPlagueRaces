using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Content.Buffs
{
    public class MushfolkHeal : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Mycelial Blessing");
            Description.SetDefault("A Mushfolk is healing you, make sure to keep them alive!");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
			Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegenCount += 6;
			if (Main.rand.NextBool(2)) 
			{
				Dust.NewDust(player.position, player.width, player.height, 107);
			}
        }
    }
}
