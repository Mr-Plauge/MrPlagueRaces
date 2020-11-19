using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Content.Dusts
{
	public class BlankDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noLight = true;
			dust.noGravity = true;
			dust.alpha = 0;
		}

		public override bool Update(Dust dust)
		{
			dust.active = false;
			return false;
		}
	}
}