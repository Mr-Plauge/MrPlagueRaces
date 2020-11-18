using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Buffs
{
    public class VampireBurn : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sunburning");
            Description.SetDefault("Vampires burn in sunlight, find shelter to remove this debuff!");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.lifeRegen > 0)
            {
                player.lifeRegen = 0;
            }
            player.lifeRegenTime = 0;
            player.lifeRegen -= 4;
            player.blockRange -= 1;
            player.tileSpeed -= 0.1f;
            player.wallSpeed -= 0.1f;
            player.jumpSpeedBoost -= 0.2f;
            player.pickSpeed += 0.2f;
            Dust.NewDust(player.position, player.width, player.height, 127);
        }
    }
}
