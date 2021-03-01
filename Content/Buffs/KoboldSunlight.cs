using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Content.Buffs
{
	public class KoboldSunlight : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Sunlight Sensitivity");
			Description.SetDefault("Kobolds aren't adapted for sunlight, and become weaker in it. Find shelter to remove this debuff!");
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			canBeCleared = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.blackout = true;
			player.statDefense -= 4;
			player.allDamage -= 0.2f;
			player.jumpSpeedBoost -= 0.5f;
			player.nightVision = false;
			if (player.velocity.X > player.maxRunSpeed)
			{
				player.velocity.X = player.maxRunSpeed;
			}
			if (player.velocity.X < -player.maxRunSpeed)
			{
				player.velocity.X = -player.maxRunSpeed;
			}
		}
	}
}
