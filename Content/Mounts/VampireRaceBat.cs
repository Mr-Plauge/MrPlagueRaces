using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MrPlagueRaces.Content.Dusts;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Content.Mounts
{
	public class VampireRaceBat : ModMountData
	{
		Player player = Main.player[Main.myPlayer];
		public override void SetDefaults()
		{
			mountData.spawnDust = DustType<BlankDust>();
			mountData.heightBoost = -28;
			mountData.fallDamage = 1f;
			mountData.flightTimeMax = 100;
			mountData.fatigueMax = 0;
			mountData.fallDamage = 0f;
			mountData.runSpeed = 1f;
			mountData.acceleration = 0.16f;
			mountData.jumpHeight = 10;
			mountData.jumpSpeed = 4f;
			mountData.totalFrames = 3;
			int[] array = new int[mountData.totalFrames];
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = -8;
			}
			mountData.playerYOffsets = array;
			mountData.bodyFrame = 8;
			mountData.xOffset = 0;
			mountData.yOffset = 0;
			mountData.playerHeadOffset = -18;
			mountData.standingFrameCount = 0;
			mountData.standingFrameDelay = 0;
			mountData.standingFrameStart = 0;
			mountData.runningFrameCount = 1;
			mountData.runningFrameDelay = 0;
			mountData.runningFrameStart = 0;
			mountData.flyingFrameCount = 1;
			mountData.flyingFrameDelay = 0;
			mountData.flyingFrameStart = 2;
			mountData.inAirFrameCount = 1;
			mountData.inAirFrameDelay = 0;
			mountData.inAirFrameStart = 2;
			mountData.idleFrameCount = 0;
			mountData.idleFrameDelay = 0;
			mountData.idleFrameStart = 0;
			mountData.swimFrameCount = mountData.inAirFrameCount;
			mountData.swimFrameDelay = mountData.inAirFrameDelay;
			mountData.swimFrameStart = mountData.inAirFrameStart;
			if (Main.netMode == NetmodeID.Server)
			{
				return;
			}

			mountData.textureWidth = mountData.backTexture.Width + 20;
			mountData.textureHeight = mountData.backTexture.Height;
		}
		public override void UpdateEffects(Player player)
		{
			if (player.velocity.Y != 0)
			{
				mountData.runSpeed = (player.moveSpeed) + (player.accRunSpeed) + (player.wingTimeMax / 30);
			}
			else
			{
				mountData.runSpeed = 1f;
			}
			mountData.flightTimeMax = player.wingTimeMax + 100;
		}
	}
}