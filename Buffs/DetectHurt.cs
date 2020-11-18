using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Buffs
{
    public class DetectHurt : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("");
            Description.SetDefault("");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }
    }
}
