using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Content.NPCs
{
	public class MrPlagueRacesGlobalNPC : GlobalNPC
	{
		public override void GetChat(NPC npc, ref string chat) 
		{
			if (npc.type == NPCID.BoundGoblin) 
			{
				chat = ("Thank you for freeing me, kind stranger. I was tied up and left here by the other goblins. You could say that we didn't get along very well.");
			}	
		}
	}
}