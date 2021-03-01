using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using MrPlagueRaces.Common.Races._999998_Goblins;

namespace MrPlagueRaces.Content.NPCs
{
	public class MrPlagueRacesGlobalNPC : GlobalNPC
	{
        public override void GetChat(NPC npc, ref string chat)
        {
			var modPlayer = Main.LocalPlayer.GetModPlayer<MrPlagueRacesPlayer>();
			if (npc.type == NPCID.BoundGoblin)
            {
                if (modPlayer.race is Common.Races._999998_Goblins.Goblin)
                {
                    chat = ("Thank you for freeing me, friend. Did the others abandon you here as well?");
                }
				else
				{
					chat = ("Thank you for freeing me, kind stranger. I was tied up and left here by the other goblins. You could say that we didn't get along very well.");
				}
			}
        }
		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
		{
			var modPlayer = Main.LocalPlayer.GetModPlayer<MrPlagueRacesPlayer>();
			modPlayer.race.EditSpawnRate(player, ref spawnRate, ref maxSpawns);
		}
	}
}