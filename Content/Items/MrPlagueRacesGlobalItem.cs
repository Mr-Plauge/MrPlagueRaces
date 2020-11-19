using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Content.Items
{
	public class MrPlagueRacesGlobalItem : GlobalItem
	{
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) 
	    {
			if (item.type == ItemID.FishBowl)
			{
		        var line = new TooltipLine(mod, "", "If you are a Merfolk, wearing this allows you to breathe outside of water at the cost of taking up your helmet slot");
			    tooltips.Add(line);
			}
			if (item.type == ItemID.Umbrella)
			{
				var line = new TooltipLine(mod, "", "If you are a Vampire or a Kobold, holding this prevents you from burning in the sunlight");
				tooltips.Add(line);
			}
			if (item.type == ItemID.UmbrellaHat)
			{
				var line = new TooltipLine(mod, "", "If you are a Vampire or a Kobold, wearing this prevents you from burning in the sunlight at the cost of taking up your helmet slot");
				tooltips.Add(line);
			}
		}
	}
}