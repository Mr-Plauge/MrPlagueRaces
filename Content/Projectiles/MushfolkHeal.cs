using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Content.Projectiles
{
	public class MushfolkHeal : ModProjectile
	{
		public override void SetDefaults() 
		{
			projectile.width = 120;
			projectile.height = 168;
			projectile.alpha = 10;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.timeLeft = 10;
		}

		public override bool? CanCutTiles() 
		{
			return false;
		}

		public override void AI() 
		{
		   Rectangle bounds = projectile.getRect();
		   for (int i = 0; i < Main.player.Length; i++)
		   {
			   Player player = Main.player[i];
			   if (player.active && bounds.Intersects(player.getRect()))
			   {
					if (!(player.statLife == player.statLifeMax2))
					{
						 player.AddBuff(mod.BuffType("MushfolkHeal"), 60);
					}
			   }
		   }
		}
	}
}