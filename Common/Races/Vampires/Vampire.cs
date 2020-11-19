using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MrPlagueRaces.Common.Races.Vampires
{
	public class Vampire : Race
	{
		public override int? LegacyId => 10;

		public override bool PreHurt(Player player, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			playSound = false;

			return true;
		}

		public override void ModifyDrawLayers(Player player, List<PlayerLayer> layers)
		{
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();

			if (modPlayer.VampireTransformation)
			{
				ModifyDrawLayersTransformed(player, layers);
				return;
			}

			bool hideChestplate = modPlayer.hideChestplate;
			bool hideLeggings = modPlayer.hideLeggings;

			Main.playerTextures[0, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Head");
			Main.playerTextures[0, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_2");
			Main.playerTextures[0, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes");
			Main.playerTextures[0, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Torso");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[0, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_1");
			}
			else
			{
				Main.playerTextures[0, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[0, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[0, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Shirt_1");
			}
			else
			{
				Main.playerTextures[0, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[0, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[0, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_1");
			}
			else
			{
				Main.playerTextures[0, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[0, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hand");
			Main.playerTextures[0, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[0, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_1");
				Main.playerTextures[0, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_1");
			}
			else
			{
				Main.playerTextures[0, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Legs");
				Main.playerTextures[0, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[0, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_1_2");
			}
			else
			{
				Main.playerTextures[0, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[0, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_1_2");
			}
			else
			{
				Main.playerTextures[0, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[1, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Head");
			Main.playerTextures[1, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_2");
			Main.playerTextures[1, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes");
			Main.playerTextures[1, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Torso");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[1, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Sleeves_2");
			}
			else
			{
				Main.playerTextures[1, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[1, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[1, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_2");
			}
			else
			{
				Main.playerTextures[1, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[1, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[1, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_2");
			}
			else
			{
				Main.playerTextures[1, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[1, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hand");
			Main.playerTextures[1, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[1, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_2");
				Main.playerTextures[1, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_2");
			}
			else
			{
				Main.playerTextures[1, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Legs");
				Main.playerTextures[1, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[1, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_2_2");
			}
			else
			{
				Main.playerTextures[1, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[1, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_2_2");
			}
			else
			{
				Main.playerTextures[1, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[2, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Head");
			Main.playerTextures[2, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_2");
			Main.playerTextures[2, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes");
			Main.playerTextures[2, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Torso");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[2, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Sleeves_3");
			}
			else
			{
				Main.playerTextures[2, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[2, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[2, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_3");
			}
			else
			{
				Main.playerTextures[2, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[2, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[2, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_3");
			}
			else
			{
				Main.playerTextures[2, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[2, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hand");
			Main.playerTextures[2, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[2, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_3");
				Main.playerTextures[2, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_3");
			}
			else
			{
				Main.playerTextures[2, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Legs");
				Main.playerTextures[2, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[2, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_3_2");
			}
			else
			{
				Main.playerTextures[2, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[2, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_3_2");
			}
			else
			{
				Main.playerTextures[2, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[3, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Head");
			Main.playerTextures[3, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_2");
			Main.playerTextures[3, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes");
			Main.playerTextures[3, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Torso");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[3, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Sleeves_4");
			}
			else
			{
				Main.playerTextures[3, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[3, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[3, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Shirt_4");
			}
			else
			{
				Main.playerTextures[3, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[3, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[3, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_4");
			}
			else
			{
				Main.playerTextures[3, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[3, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hand");
			Main.playerTextures[3, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[3, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_4");
				Main.playerTextures[3, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_4");
			}
			else
			{
				Main.playerTextures[3, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Legs");
				Main.playerTextures[3, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[3, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_4_2");
			}
			else
			{
				Main.playerTextures[3, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[3, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_4_2");
			}
			else
			{
				Main.playerTextures[3, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[8, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Head");
			Main.playerTextures[8, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_2");
			Main.playerTextures[8, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes");
			Main.playerTextures[8, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Torso");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[8, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Sleeves_9");
			}
			else
			{
				Main.playerTextures[8, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[8, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[8, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Shirt_9");
			}
			else
			{
				Main.playerTextures[8, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[8, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[8, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_9");
			}
			else
			{
				Main.playerTextures[8, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[8, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hand");
			Main.playerTextures[8, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[8, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_9");
				Main.playerTextures[8, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_9");
			}
			else
			{
				Main.playerTextures[8, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Legs");
				Main.playerTextures[8, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[8, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_9_2");
			}
			else
			{
				Main.playerTextures[8, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[8, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_9_2");
			}
			else
			{
				Main.playerTextures[8, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[4, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Head_Female");
			Main.playerTextures[4, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_2_Female");
			Main.playerTextures[4, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_Female");
			Main.playerTextures[4, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Torso_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[4, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Sleeves_5");
			}
			else
			{
				Main.playerTextures[4, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[4, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hands_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[4, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_5");
			}
			else
			{
				Main.playerTextures[4, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Body_Female");
			}

			Main.playerTextures[4, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Arm_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[4, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_5");
			}
			else
			{
				Main.playerTextures[4, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[4, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hand_Female");
			Main.playerTextures[4, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Legs_Female");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[4, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_5");
				Main.playerTextures[4, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_5");
			}
			else
			{
				Main.playerTextures[4, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Legs_Female");
				Main.playerTextures[4, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[4, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_5_2");
			}
			else
			{
				Main.playerTextures[4, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[4, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_5_2");
			}
			else
			{
				Main.playerTextures[4, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[5, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Head_Female");
			Main.playerTextures[5, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_2_Female");
			Main.playerTextures[5, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_Female");
			Main.playerTextures[5, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Torso_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[5, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Sleeves_6");
			}
			else
			{
				Main.playerTextures[5, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[5, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hands_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[5, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_6");
			}
			else
			{
				Main.playerTextures[5, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Body_Female");
			}

			Main.playerTextures[5, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Arm_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[5, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_6");
			}
			else
			{
				Main.playerTextures[5, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[5, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hand_Female");
			Main.playerTextures[5, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Legs_Female");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[5, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_6");
				Main.playerTextures[5, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_6");
			}
			else
			{
				Main.playerTextures[5, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Legs_Female");
				Main.playerTextures[5, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[5, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_6_2");
			}
			else
			{
				Main.playerTextures[5, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[5, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_6_2");
			}
			else
			{
				Main.playerTextures[5, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[6, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Head_Female");
			Main.playerTextures[6, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_2_Female");
			Main.playerTextures[6, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_Female");
			Main.playerTextures[6, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Torso_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[6, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Sleeves_7");
			}
			else
			{
				Main.playerTextures[6, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[6, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hands_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[6, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_7");
			}
			else
			{
				Main.playerTextures[6, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Body_Female");
			}

			Main.playerTextures[6, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Arm_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[6, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_7");
			}
			else
			{
				Main.playerTextures[6, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[6, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hand_Female");
			Main.playerTextures[6, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Legs_Female");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[6, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_7");
				Main.playerTextures[6, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_7");
			}
			else
			{
				Main.playerTextures[6, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Legs_Female");
				Main.playerTextures[6, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[6, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_7_2");
			}
			else
			{
				Main.playerTextures[6, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[6, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_7_2");
			}
			else
			{
				Main.playerTextures[6, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[7, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Head_Female");
			Main.playerTextures[7, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_2_Female");
			Main.playerTextures[7, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_Female");
			Main.playerTextures[7, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Torso_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[7, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_8");
			}
			else
			{
				Main.playerTextures[7, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[7, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hands_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[7, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Shirt_8");
			}
			else
			{
				Main.playerTextures[7, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Body_Female");
			}

			Main.playerTextures[7, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Arm_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[7, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_8");
			}
			else
			{
				Main.playerTextures[7, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[7, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hand_Female");
			Main.playerTextures[7, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Legs_Female");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[7, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_8");
				Main.playerTextures[7, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_8");
			}
			else
			{
				Main.playerTextures[7, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Legs_Female");
				Main.playerTextures[7, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[7, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_8_2");
			}
			else
			{
				Main.playerTextures[7, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[7, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_8_2");
			}
			else
			{
				Main.playerTextures[7, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[9, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Head_Female");
			Main.playerTextures[9, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_2_Female");
			Main.playerTextures[9, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Eyes_Female");
			Main.playerTextures[9, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Torso_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[9, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Sleeves_10");
			}
			else
			{
				Main.playerTextures[9, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[9, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hands_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[9, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_10");
			}
			else
			{
				Main.playerTextures[9, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Body_Female");
			}

			Main.playerTextures[9, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Arm_Female");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[9, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_10");
			}
			else
			{
				Main.playerTextures[9, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[9, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Hand");
			Main.playerTextures[9, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[9, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_10");
				Main.playerTextures[9, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_10");
			}
			else
			{
				Main.playerTextures[9, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Censor_Clothing_Legs_Female");
				Main.playerTextures[9, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[9, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_10_2");
			}
			else
			{
				Main.playerTextures[9, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[9, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_10_2");
			}
			else
			{
				Main.playerTextures[9, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerHairTexture[0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_1");
			Main.playerHairTexture[1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_2");
			Main.playerHairTexture[2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_3");
			Main.playerHairTexture[3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_4");
			Main.playerHairTexture[4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_5");
			Main.playerHairTexture[5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_6");
			Main.playerHairTexture[6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_7");
			Main.playerHairTexture[7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_8");
			Main.playerHairTexture[8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_9");
			Main.playerHairTexture[9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_10");
			Main.playerHairTexture[10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_11");
			Main.playerHairTexture[11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_12");
			Main.playerHairTexture[12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_13");
			Main.playerHairTexture[13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_14");
			Main.playerHairTexture[14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_15");
			Main.playerHairTexture[15] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_16");
			Main.playerHairTexture[16] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_17");
			Main.playerHairTexture[17] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_18");
			Main.playerHairTexture[18] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_19");
			Main.playerHairTexture[19] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_20");
			Main.playerHairTexture[20] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_21");
			Main.playerHairTexture[21] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_22");
			Main.playerHairTexture[22] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_23");
			Main.playerHairTexture[23] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_24");
			Main.playerHairTexture[24] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_25");
			Main.playerHairTexture[25] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_26");
			Main.playerHairTexture[26] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_27");
			Main.playerHairTexture[27] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_28");
			Main.playerHairTexture[28] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_29");
			Main.playerHairTexture[29] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_30");
			Main.playerHairTexture[30] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_31");
			Main.playerHairTexture[31] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_32");
			Main.playerHairTexture[32] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_33");
			Main.playerHairTexture[33] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_34");
			Main.playerHairTexture[34] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_35");
			Main.playerHairTexture[35] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_36");
			Main.playerHairTexture[36] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_37");
			Main.playerHairTexture[37] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_38");
			Main.playerHairTexture[38] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_39");
			Main.playerHairTexture[39] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_40");
			Main.playerHairTexture[40] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_41");
			Main.playerHairTexture[41] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_42");
			Main.playerHairTexture[42] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_43");
			Main.playerHairTexture[43] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_44");
			Main.playerHairTexture[44] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_45");
			Main.playerHairTexture[45] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_46");
			Main.playerHairTexture[46] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_47");
			Main.playerHairTexture[47] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_48");
			Main.playerHairTexture[48] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_49");
			Main.playerHairTexture[49] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_50");
			Main.playerHairTexture[50] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_51");
			Main.playerHairTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_52");
			Main.playerHairTexture[52] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_53");
			Main.playerHairTexture[53] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_54");
			Main.playerHairTexture[54] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_55");
			Main.playerHairTexture[55] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_56");
			Main.playerHairTexture[56] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_57");
			Main.playerHairTexture[57] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_58");
			Main.playerHairTexture[58] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_59");
			Main.playerHairTexture[59] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_60");
			Main.playerHairTexture[60] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_61");
			Main.playerHairTexture[61] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_62");
			Main.playerHairTexture[62] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_63");
			Main.playerHairTexture[63] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_64");
			Main.playerHairTexture[64] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_65");
			Main.playerHairTexture[65] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_66");
			Main.playerHairTexture[66] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_67");
			Main.playerHairTexture[67] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_68");
			Main.playerHairTexture[68] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_69");
			Main.playerHairTexture[69] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_70");
			Main.playerHairTexture[70] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_71");
			Main.playerHairTexture[71] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_72");
			Main.playerHairTexture[72] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_73");
			Main.playerHairTexture[73] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_74");
			Main.playerHairTexture[74] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_75");
			Main.playerHairTexture[75] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_76");
			Main.playerHairTexture[76] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_77");
			Main.playerHairTexture[77] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_78");
			Main.playerHairTexture[78] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_79");
			Main.playerHairTexture[79] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_80");
			Main.playerHairTexture[80] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_81");
			Main.playerHairTexture[81] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_82");
			Main.playerHairTexture[82] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_83");
			Main.playerHairTexture[83] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_84");
			Main.playerHairTexture[84] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_85");
			Main.playerHairTexture[85] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_86");
			Main.playerHairTexture[86] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_87");
			Main.playerHairTexture[87] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_88");
			Main.playerHairTexture[88] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_89");
			Main.playerHairTexture[89] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_90");
			Main.playerHairTexture[90] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_91");
			Main.playerHairTexture[91] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_92");
			Main.playerHairTexture[92] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_93");
			Main.playerHairTexture[93] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_94");
			Main.playerHairTexture[94] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_95");
			Main.playerHairTexture[95] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_96");
			Main.playerHairTexture[96] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_97");
			Main.playerHairTexture[97] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_98");
			Main.playerHairTexture[98] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_99");
			Main.playerHairTexture[99] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_100");
			Main.playerHairTexture[100] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_101");
			Main.playerHairTexture[101] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_102");
			Main.playerHairTexture[102] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_103");
			Main.playerHairTexture[103] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_104");
			Main.playerHairTexture[104] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_105");
			Main.playerHairTexture[105] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_106");
			Main.playerHairTexture[106] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_107");
			Main.playerHairTexture[107] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_108");
			Main.playerHairTexture[108] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_109");
			Main.playerHairTexture[109] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_110");
			Main.playerHairTexture[110] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_111");
			Main.playerHairTexture[111] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_112");
			Main.playerHairTexture[112] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_113");
			Main.playerHairTexture[113] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_114");
			Main.playerHairTexture[114] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_115");
			Main.playerHairTexture[115] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_116");
			Main.playerHairTexture[116] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_117");
			Main.playerHairTexture[117] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_118");
			Main.playerHairTexture[118] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_119");
			Main.playerHairTexture[119] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_120");
			Main.playerHairTexture[120] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_121");
			Main.playerHairTexture[121] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_122");
			Main.playerHairTexture[122] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_123");
			Main.playerHairTexture[123] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_124");
			Main.playerHairTexture[124] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_125");
			Main.playerHairTexture[125] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_126");
			Main.playerHairTexture[126] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_127");
			Main.playerHairTexture[127] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_128");
			Main.playerHairTexture[128] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_129");
			Main.playerHairTexture[129] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_130");
			Main.playerHairTexture[130] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_131");
			Main.playerHairTexture[131] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_132");
			Main.playerHairTexture[132] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_133");
			Main.playerHairTexture[133] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_Hair_134");
			Main.playerHairAltTexture[0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_1");
			Main.playerHairAltTexture[1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_2");
			Main.playerHairAltTexture[2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_3");
			Main.playerHairAltTexture[3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_4");
			Main.playerHairAltTexture[4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_5");
			Main.playerHairAltTexture[5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_6");
			Main.playerHairAltTexture[6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_7");
			Main.playerHairAltTexture[7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_8");
			Main.playerHairAltTexture[8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_9");
			Main.playerHairAltTexture[9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_10");
			Main.playerHairAltTexture[10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_11");
			Main.playerHairAltTexture[11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_12");
			Main.playerHairAltTexture[12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_13");
			Main.playerHairAltTexture[13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_14");
			Main.playerHairAltTexture[14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_15");
			Main.playerHairAltTexture[15] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_16");
			Main.playerHairAltTexture[16] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_17");
			Main.playerHairAltTexture[17] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_18");
			Main.playerHairAltTexture[18] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_19");
			Main.playerHairAltTexture[19] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_20");
			Main.playerHairAltTexture[20] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_21");
			Main.playerHairAltTexture[21] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_22");
			Main.playerHairAltTexture[22] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_23");
			Main.playerHairAltTexture[23] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_24");
			Main.playerHairAltTexture[24] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_25");
			Main.playerHairAltTexture[25] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_26");
			Main.playerHairAltTexture[26] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_27");
			Main.playerHairAltTexture[27] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_28");
			Main.playerHairAltTexture[28] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_29");
			Main.playerHairAltTexture[29] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_30");
			Main.playerHairAltTexture[30] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_31");
			Main.playerHairAltTexture[31] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_32");
			Main.playerHairAltTexture[32] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_33");
			Main.playerHairAltTexture[33] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_34");
			Main.playerHairAltTexture[34] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_35");
			Main.playerHairAltTexture[35] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_36");
			Main.playerHairAltTexture[36] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_37");
			Main.playerHairAltTexture[37] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_38");
			Main.playerHairAltTexture[38] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_39");
			Main.playerHairAltTexture[39] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_40");
			Main.playerHairAltTexture[40] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_41");
			Main.playerHairAltTexture[41] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_42");
			Main.playerHairAltTexture[42] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_43");
			Main.playerHairAltTexture[43] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_44");
			Main.playerHairAltTexture[44] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_45");
			Main.playerHairAltTexture[45] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_46");
			Main.playerHairAltTexture[46] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_47");
			Main.playerHairAltTexture[47] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_48");
			Main.playerHairAltTexture[48] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_49");
			Main.playerHairAltTexture[49] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_50");
			Main.playerHairAltTexture[50] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_51");
			Main.playerHairAltTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_52");
			Main.playerHairAltTexture[52] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_53");
			Main.playerHairAltTexture[53] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_54");
			Main.playerHairAltTexture[54] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_55");
			Main.playerHairAltTexture[55] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_56");
			Main.playerHairAltTexture[56] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_57");
			Main.playerHairAltTexture[57] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_58");
			Main.playerHairAltTexture[58] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_59");
			Main.playerHairAltTexture[59] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_60");
			Main.playerHairAltTexture[60] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_61");
			Main.playerHairAltTexture[61] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_62");
			Main.playerHairAltTexture[62] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_63");
			Main.playerHairAltTexture[63] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_64");
			Main.playerHairAltTexture[64] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_65");
			Main.playerHairAltTexture[65] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_66");
			Main.playerHairAltTexture[66] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_67");
			Main.playerHairAltTexture[67] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_68");
			Main.playerHairAltTexture[68] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_69");
			Main.playerHairAltTexture[69] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_70");
			Main.playerHairAltTexture[70] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_71");
			Main.playerHairAltTexture[71] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_72");
			Main.playerHairAltTexture[72] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_73");
			Main.playerHairAltTexture[73] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_74");
			Main.playerHairAltTexture[74] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_75");
			Main.playerHairAltTexture[75] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_76");
			Main.playerHairAltTexture[76] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_77");
			Main.playerHairAltTexture[77] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_78");
			Main.playerHairAltTexture[78] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_79");
			Main.playerHairAltTexture[79] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_80");
			Main.playerHairAltTexture[80] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_81");
			Main.playerHairAltTexture[81] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_82");
			Main.playerHairAltTexture[82] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_83");
			Main.playerHairAltTexture[83] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_84");
			Main.playerHairAltTexture[84] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_85");
			Main.playerHairAltTexture[85] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_86");
			Main.playerHairAltTexture[86] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_87");
			Main.playerHairAltTexture[87] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_88");
			Main.playerHairAltTexture[88] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_89");
			Main.playerHairAltTexture[89] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_90");
			Main.playerHairAltTexture[90] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_91");
			Main.playerHairAltTexture[91] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_92");
			Main.playerHairAltTexture[92] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_93");
			Main.playerHairAltTexture[93] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_94");
			Main.playerHairAltTexture[94] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_95");
			Main.playerHairAltTexture[95] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_96");
			Main.playerHairAltTexture[96] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_97");
			Main.playerHairAltTexture[97] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_98");
			Main.playerHairAltTexture[98] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_99");
			Main.playerHairAltTexture[99] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_100");
			Main.playerHairAltTexture[100] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_101");
			Main.playerHairAltTexture[101] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_102");
			Main.playerHairAltTexture[102] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_103");
			Main.playerHairAltTexture[103] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_104");
			Main.playerHairAltTexture[104] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_105");
			Main.playerHairAltTexture[105] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_106");
			Main.playerHairAltTexture[106] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_107");
			Main.playerHairAltTexture[107] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_108");
			Main.playerHairAltTexture[108] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_109");
			Main.playerHairAltTexture[109] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_110");
			Main.playerHairAltTexture[110] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_111");
			Main.playerHairAltTexture[111] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_112");
			Main.playerHairAltTexture[112] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_113");
			Main.playerHairAltTexture[113] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_114");
			Main.playerHairAltTexture[114] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_115");
			Main.playerHairAltTexture[115] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_116");
			Main.playerHairAltTexture[116] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_117");
			Main.playerHairAltTexture[117] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_118");
			Main.playerHairAltTexture[118] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_119");
			Main.playerHairAltTexture[119] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_120");
			Main.playerHairAltTexture[120] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_121");
			Main.playerHairAltTexture[121] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_122");
			Main.playerHairAltTexture[122] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_123");
			Main.playerHairAltTexture[123] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_124");
			Main.playerHairAltTexture[124] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_125");
			Main.playerHairAltTexture[125] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_126");
			Main.playerHairAltTexture[126] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_127");
			Main.playerHairAltTexture[127] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_128");
			Main.playerHairAltTexture[128] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_129");
			Main.playerHairAltTexture[129] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_130");
			Main.playerHairAltTexture[130] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_131");
			Main.playerHairAltTexture[131] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_132");
			Main.playerHairAltTexture[132] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_133");
			Main.playerHairAltTexture[133] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/Vampire_HairAlt_134");
			Main.ghostTexture = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Vampire_Ghost");
		}

		private void ModifyDrawLayersTransformed(Player player, List<PlayerLayer> layers)
		{
			var modPlayer = player.GetModPlayer<MrPlagueRacesPlayer>();

			int vampireWingFrame = modPlayer.vampireWingFrame;

			Main.playerTextures[0, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Head");
			Main.playerTextures[0, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

			if (vampireWingFrame == -1)
			{
				Main.playerTextures[0, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 0)
			{
				Main.playerTextures[0, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 1)
			{
				Main.playerTextures[0, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 2)
			{
				Main.playerTextures[0, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_2");
			}
			if (vampireWingFrame == 3)
			{
				Main.playerTextures[0, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_3");
			}
			if (vampireWingFrame == 4)
			{
				Main.playerTextures[0, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_4");
			}

			Main.playerTextures[0, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[0, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[0, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[0, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[0, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[0, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[0, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[0, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[0, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[0, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[0, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[0, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Head");
			Main.playerTextures[1, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

			if (vampireWingFrame == -1)
			{
				Main.playerTextures[1, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_Walk");
			}
			if (vampireWingFrame == 0)
			{
				Main.playerTextures[1, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 1)
			{
				Main.playerTextures[1, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 2)
			{
				Main.playerTextures[1, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_2");
			}
			if (vampireWingFrame == 3)
			{
				Main.playerTextures[1, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_3");
			}
			if (vampireWingFrame == 4)
			{
				Main.playerTextures[1, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_4");
			}

			Main.playerTextures[1, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[1, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Head");
			Main.playerTextures[2, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

			if (vampireWingFrame == -1)
			{
				Main.playerTextures[2, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_Walk");
			}
			if (vampireWingFrame == 0)
			{
				Main.playerTextures[2, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 1)
			{
				Main.playerTextures[2, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 2)
			{
				Main.playerTextures[2, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_2");
			}
			if (vampireWingFrame == 3)
			{
				Main.playerTextures[2, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_3");
			}
			if (vampireWingFrame == 4)
			{
				Main.playerTextures[2, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_4");
			}

			Main.playerTextures[2, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[2, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Head");
			Main.playerTextures[3, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

			if (vampireWingFrame == -1)
			{
				Main.playerTextures[3, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_Walk");
			}
			if (vampireWingFrame == 0)
			{
				Main.playerTextures[3, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 1)
			{
				Main.playerTextures[3, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 2)
			{
				Main.playerTextures[3, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_2");
			}
			if (vampireWingFrame == 3)
			{
				Main.playerTextures[3, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_3");
			}
			if (vampireWingFrame == 4)
			{
				Main.playerTextures[3, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_4");
			}

			Main.playerTextures[3, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[3, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Head");
			Main.playerTextures[8, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

			if (vampireWingFrame == -1)
			{
				Main.playerTextures[8, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_Walk");
			}
			if (vampireWingFrame == 0)
			{
				Main.playerTextures[8, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 1)
			{
				Main.playerTextures[8, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 2)
			{
				Main.playerTextures[8, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_2");
			}
			if (vampireWingFrame == 3)
			{
				Main.playerTextures[8, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_3");
			}
			if (vampireWingFrame == 4)
			{
				Main.playerTextures[8, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_4");
			}

			Main.playerTextures[8, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[8, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Head");
			Main.playerTextures[4, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

			if (vampireWingFrame == -1)
			{
				Main.playerTextures[4, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_Walk");
			}
			if (vampireWingFrame == 0)
			{
				Main.playerTextures[4, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 1)
			{
				Main.playerTextures[4, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 2)
			{
				Main.playerTextures[4, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_2");
			}
			if (vampireWingFrame == 3)
			{
				Main.playerTextures[4, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_3");
			}
			if (vampireWingFrame == 4)
			{
				Main.playerTextures[4, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_4");
			}

			Main.playerTextures[4, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[4, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Head");
			Main.playerTextures[5, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

			if (vampireWingFrame == -1)
			{
				Main.playerTextures[5, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_Walk");
			}
			if (vampireWingFrame == 0)
			{
				Main.playerTextures[5, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 1)
			{
				Main.playerTextures[5, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 2)
			{
				Main.playerTextures[5, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_2");
			}
			if (vampireWingFrame == 3)
			{
				Main.playerTextures[5, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_3");
			}
			if (vampireWingFrame == 4)
			{
				Main.playerTextures[5, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_4");
			}

			Main.playerTextures[5, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[5, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Head");
			Main.playerTextures[6, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

			if (vampireWingFrame == -1)
			{
				Main.playerTextures[6, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_Walk");
			}
			if (vampireWingFrame == 0)
			{
				Main.playerTextures[6, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 1)
			{
				Main.playerTextures[6, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 2)
			{
				Main.playerTextures[6, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_2");
			}
			if (vampireWingFrame == 3)
			{
				Main.playerTextures[6, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_3");
			}
			if (vampireWingFrame == 4)
			{
				Main.playerTextures[6, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_4");
			}

			Main.playerTextures[6, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[6, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Head");
			Main.playerTextures[7, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

			if (vampireWingFrame == -1)
			{
				Main.playerTextures[7, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_Walk");
			}
			if (vampireWingFrame == 0)
			{
				Main.playerTextures[7, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 1)
			{
				Main.playerTextures[7, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 2)
			{
				Main.playerTextures[7, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_2");
			}
			if (vampireWingFrame == 3)
			{
				Main.playerTextures[7, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_3");
			}
			if (vampireWingFrame == 4)
			{
				Main.playerTextures[7, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_4");
			}

			Main.playerTextures[7, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[7, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Head");
			Main.playerTextures[9, 1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

			if (vampireWingFrame == -1)
			{
				Main.playerTextures[9, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_Walk");
			}
			if (vampireWingFrame == 0)
			{
				Main.playerTextures[9, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 1)
			{
				Main.playerTextures[9, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_1");
			}
			if (vampireWingFrame == 2)
			{
				Main.playerTextures[9, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_2");
			}
			if (vampireWingFrame == 3)
			{
				Main.playerTextures[9, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_3");
			}
			if (vampireWingFrame == 4)
			{
				Main.playerTextures[9, 2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/VampireBat_Eyes_4");
			}

			Main.playerTextures[9, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			Main.playerTextures[9, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

			if ((vampireWingFrame == -1 || vampireWingFrame == 0) && !(player.bodyFrame.Y == player.bodyFrame.Height * 8 || player.bodyFrame.Y == player.bodyFrame.Height * 9))
			{
				Main.playerHairTexture[0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[15] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[16] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[17] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[18] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[19] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[20] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[21] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[22] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[23] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[24] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[25] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[26] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[27] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[28] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[29] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[30] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[31] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[32] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[33] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[34] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[35] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[36] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[37] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[38] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[39] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[40] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[41] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[42] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[43] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[44] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[45] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[46] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[47] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[48] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[49] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[50] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[52] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[53] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[54] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[55] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[56] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[57] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[58] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[59] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[60] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[61] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[62] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[63] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[64] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[65] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[66] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[67] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[68] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[69] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[70] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[71] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[72] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[73] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[74] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[75] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[76] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[77] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[78] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[79] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[80] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[81] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[82] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[83] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[84] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[85] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[86] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[87] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[88] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[89] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[90] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[91] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[92] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[93] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[94] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[95] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[96] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[97] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[98] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[99] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[100] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[101] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[102] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[103] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[104] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[105] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[106] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[107] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[108] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[109] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[110] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[111] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[112] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[113] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[114] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[115] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[116] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[117] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[118] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[119] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[120] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[121] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[122] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[123] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[124] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[125] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[126] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[127] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[128] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[129] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[130] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[131] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[132] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairTexture[133] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[15] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[16] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[17] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[18] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[19] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[20] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[21] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[22] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[23] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[24] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[25] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[26] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[27] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[28] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[29] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[30] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[31] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[32] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[33] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[34] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[35] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[36] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[37] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[38] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[39] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[40] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[41] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[42] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[43] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[44] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[45] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[46] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[47] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[48] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[49] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[50] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[52] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[53] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[54] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[55] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[56] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[57] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[58] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[59] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[60] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[61] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[62] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[63] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[64] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[65] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[66] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[67] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[68] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[69] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[70] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[71] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[72] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[73] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[74] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[75] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[76] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[77] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[78] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[79] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[80] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[81] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[82] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[83] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[84] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[85] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[86] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[87] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[88] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[89] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[90] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[91] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[92] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[93] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[94] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[95] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[96] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[97] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[98] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[99] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[100] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[101] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[102] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[103] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[104] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[105] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[106] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[107] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[108] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[109] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[110] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[111] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[112] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[113] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[114] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[115] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[116] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[117] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[118] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[119] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[120] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[121] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[122] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[123] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[124] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[125] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[126] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[127] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[128] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[129] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[130] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[131] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[132] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
				Main.playerHairAltTexture[133] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_1");
			}
			if ((vampireWingFrame == -1 || vampireWingFrame == 0) && (player.bodyFrame.Y == player.bodyFrame.Height * 8 || player.bodyFrame.Y == player.bodyFrame.Height * 9) && !player.dead)
			{
				Main.playerHairTexture[0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[15] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[16] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[17] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[18] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[19] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[20] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[21] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[22] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[23] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[24] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[25] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[26] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[27] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[28] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[29] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[30] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[31] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[32] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[33] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[34] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[35] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[36] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[37] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[38] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[39] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[40] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[41] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[42] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[43] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[44] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[45] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[46] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[47] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[48] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[49] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[50] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[52] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[53] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[54] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[55] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[56] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[57] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[58] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[59] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[60] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[61] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[62] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[63] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[64] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[65] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[66] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[67] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[68] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[69] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[70] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[71] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[72] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[73] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[74] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[75] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[76] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[77] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[78] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[79] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[80] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[81] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[82] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[83] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[84] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[85] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[86] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[87] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[88] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[89] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[90] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[91] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[92] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[93] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[94] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[95] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[96] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[97] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[98] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[99] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[100] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[101] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[102] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[103] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[104] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[105] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[106] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[107] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[108] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[109] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[110] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[111] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[112] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[113] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[114] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[115] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[116] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[117] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[118] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[119] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[120] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[121] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[122] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[123] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[124] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[125] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[126] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[127] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[128] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[129] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[130] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[131] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[132] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairTexture[133] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[15] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[16] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[17] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[18] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[19] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[20] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[21] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[22] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[23] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[24] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[25] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[26] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[27] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[28] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[29] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[30] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[31] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[32] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[33] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[34] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[35] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[36] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[37] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[38] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[39] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[40] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[41] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[42] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[43] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[44] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[45] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[46] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[47] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[48] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[49] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[50] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[52] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[53] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[54] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[55] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[56] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[57] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[58] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[59] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[60] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[61] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[62] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[63] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[64] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[65] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[66] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[67] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[68] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[69] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[70] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[71] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[72] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[73] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[74] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[75] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[76] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[77] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[78] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[79] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[80] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[81] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[82] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[83] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[84] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[85] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[86] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[87] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[88] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[89] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[90] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[91] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[92] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[93] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[94] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[95] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[96] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[97] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[98] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[99] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[100] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[101] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[102] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[103] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[104] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[105] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[106] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[107] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[108] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[109] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[110] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[111] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[112] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[113] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[114] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[115] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[116] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[117] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[118] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[119] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[120] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[121] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[122] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[123] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[124] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[125] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[126] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[127] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[128] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[129] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[130] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[131] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[132] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
				Main.playerHairAltTexture[133] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Walk_2");
			}
			if (vampireWingFrame == 1 && !player.dead)
			{
				Main.playerHairTexture[0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[15] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[16] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[17] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[18] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[19] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[20] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[21] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[22] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[23] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[24] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[25] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[26] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[27] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[28] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[29] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[30] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[31] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[32] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[33] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[34] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[35] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[36] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[37] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[38] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[39] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[40] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[41] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[42] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[43] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[44] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[45] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[46] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[47] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[48] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[49] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[50] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[52] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[53] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[54] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[55] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[56] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[57] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[58] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[59] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[60] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[61] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[62] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[63] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[64] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[65] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[66] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[67] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[68] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[69] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[70] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[71] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[72] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[73] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[74] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[75] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[76] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[77] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[78] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[79] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[80] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[81] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[82] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[83] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[84] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[85] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[86] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[87] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[88] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[89] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[90] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[91] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[92] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[93] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[94] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[95] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[96] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[97] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[98] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[99] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[100] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[101] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[102] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[103] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[104] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[105] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[106] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[107] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[108] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[109] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[110] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[111] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[112] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[113] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[114] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[115] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[116] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[117] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[118] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[119] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[120] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[121] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[122] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[123] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[124] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[125] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[126] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[127] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[128] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[129] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[130] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[131] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[132] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairTexture[133] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[15] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[16] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[17] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[18] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[19] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[20] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[21] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[22] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[23] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[24] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[25] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[26] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[27] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[28] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[29] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[30] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[31] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[32] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[33] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[34] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[35] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[36] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[37] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[38] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[39] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[40] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[41] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[42] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[43] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[44] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[45] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[46] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[47] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[48] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[49] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[50] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[52] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[53] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[54] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[55] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[56] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[57] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[58] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[59] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[60] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[61] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[62] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[63] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[64] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[65] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[66] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[67] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[68] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[69] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[70] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[71] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[72] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[73] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[74] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[75] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[76] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[77] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[78] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[79] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[80] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[81] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[82] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[83] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[84] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[85] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[86] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[87] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[88] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[89] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[90] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[91] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[92] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[93] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[94] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[95] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[96] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[97] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[98] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[99] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[100] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[101] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[102] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[103] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[104] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[105] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[106] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[107] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[108] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[109] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[110] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[111] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[112] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[113] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[114] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[115] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[116] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[117] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[118] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[119] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[120] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[121] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[122] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[123] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[124] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[125] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[126] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[127] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[128] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[129] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[130] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[131] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[132] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
				Main.playerHairAltTexture[133] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_1");
			}
			if (vampireWingFrame == 2 && !player.dead)
			{
				Main.playerHairTexture[0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[15] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[16] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[17] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[18] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[19] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[20] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[21] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[22] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[23] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[24] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[25] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[26] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[27] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[28] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[29] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[30] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[31] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[32] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[33] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[34] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[35] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[36] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[37] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[38] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[39] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[40] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[41] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[42] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[43] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[44] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[45] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[46] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[47] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[48] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[49] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[50] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[52] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[53] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[54] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[55] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[56] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[57] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[58] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[59] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[60] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[61] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[62] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[63] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[64] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[65] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[66] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[67] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[68] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[69] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[70] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[71] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[72] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[73] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[74] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[75] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[76] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[77] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[78] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[79] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[80] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[81] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[82] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[83] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[84] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[85] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[86] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[87] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[88] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[89] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[90] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[91] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[92] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[93] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[94] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[95] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[96] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[97] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[98] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[99] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[100] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[101] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[102] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[103] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[104] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[105] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[106] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[107] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[108] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[109] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[110] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[111] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[112] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[113] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[114] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[115] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[116] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[117] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[118] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[119] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[120] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[121] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[122] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[123] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[124] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[125] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[126] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[127] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[128] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[129] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[130] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[131] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[132] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairTexture[133] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[15] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[16] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[17] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[18] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[19] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[20] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[21] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[22] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[23] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[24] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[25] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[26] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[27] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[28] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[29] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[30] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[31] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[32] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[33] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[34] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[35] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[36] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[37] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[38] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[39] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[40] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[41] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[42] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[43] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[44] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[45] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[46] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[47] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[48] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[49] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[50] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[52] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[53] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[54] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[55] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[56] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[57] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[58] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[59] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[60] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[61] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[62] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[63] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[64] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[65] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[66] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[67] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[68] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[69] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[70] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[71] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[72] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[73] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[74] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[75] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[76] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[77] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[78] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[79] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[80] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[81] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[82] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[83] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[84] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[85] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[86] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[87] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[88] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[89] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[90] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[91] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[92] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[93] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[94] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[95] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[96] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[97] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[98] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[99] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[100] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[101] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[102] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[103] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[104] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[105] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[106] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[107] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[108] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[109] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[110] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[111] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[112] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[113] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[114] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[115] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[116] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[117] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[118] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[119] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[120] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[121] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[122] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[123] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[124] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[125] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[126] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[127] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[128] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[129] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[130] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[131] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[132] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
				Main.playerHairAltTexture[133] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_2");
			}
			if (vampireWingFrame == 3 && !player.dead)
			{
				Main.playerHairTexture[0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[15] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[16] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[17] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[18] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[19] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[20] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[21] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[22] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[23] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[24] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[25] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[26] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[27] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[28] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[29] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[30] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[31] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[32] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[33] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[34] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[35] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[36] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[37] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[38] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[39] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[40] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[41] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[42] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[43] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[44] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[45] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[46] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[47] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[48] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[49] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[50] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[52] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[53] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[54] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[55] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[56] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[57] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[58] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[59] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[60] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[61] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[62] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[63] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[64] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[65] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[66] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[67] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[68] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[69] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[70] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[71] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[72] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[73] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[74] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[75] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[76] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[77] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[78] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[79] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[80] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[81] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[82] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[83] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[84] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[85] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[86] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[87] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[88] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[89] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[90] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[91] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[92] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[93] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[94] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[95] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[96] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[97] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[98] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[99] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[100] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[101] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[102] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[103] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[104] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[105] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[106] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[107] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[108] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[109] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[110] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[111] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[112] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[113] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[114] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[115] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[116] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[117] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[118] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[119] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[120] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[121] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[122] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[123] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[124] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[125] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[126] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[127] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[128] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[129] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[130] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[131] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[132] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairTexture[133] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[15] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[16] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[17] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[18] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[19] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[20] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[21] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[22] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[23] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[24] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[25] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[26] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[27] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[28] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[29] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[30] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[31] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[32] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[33] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[34] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[35] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[36] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[37] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[38] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[39] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[40] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[41] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[42] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[43] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[44] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[45] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[46] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[47] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[48] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[49] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[50] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[52] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[53] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[54] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[55] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[56] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[57] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[58] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[59] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[60] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[61] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[62] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[63] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[64] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[65] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[66] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[67] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[68] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[69] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[70] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[71] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[72] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[73] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[74] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[75] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[76] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[77] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[78] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[79] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[80] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[81] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[82] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[83] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[84] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[85] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[86] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[87] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[88] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[89] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[90] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[91] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[92] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[93] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[94] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[95] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[96] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[97] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[98] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[99] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[100] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[101] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[102] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[103] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[104] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[105] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[106] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[107] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[108] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[109] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[110] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[111] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[112] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[113] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[114] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[115] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[116] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[117] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[118] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[119] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[120] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[121] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[122] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[123] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[124] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[125] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[126] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[127] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[128] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[129] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[130] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[131] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[132] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
				Main.playerHairAltTexture[133] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_3");
			}
			if (vampireWingFrame == 4 && !player.dead)
			{
				Main.playerHairTexture[0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[15] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[16] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[17] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[18] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[19] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[20] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[21] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[22] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[23] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[24] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[25] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[26] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[27] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[28] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[29] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[30] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[31] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[32] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[33] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[34] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[35] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[36] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[37] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[38] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[39] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[40] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[41] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[42] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[43] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[44] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[45] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[46] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[47] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[48] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[49] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[50] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[52] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[53] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[54] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[55] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[56] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[57] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[58] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[59] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[60] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[61] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[62] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[63] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[64] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[65] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[66] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[67] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[68] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[69] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[70] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[71] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[72] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[73] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[74] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[75] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[76] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[77] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[78] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[79] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[80] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[81] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[82] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[83] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[84] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[85] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[86] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[87] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[88] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[89] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[90] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[91] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[92] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[93] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[94] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[95] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[96] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[97] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[98] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[99] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[100] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[101] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[102] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[103] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[104] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[105] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[106] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[107] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[108] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[109] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[110] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[111] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[112] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[113] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[114] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[115] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[116] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[117] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[118] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[119] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[120] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[121] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[122] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[123] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[124] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[125] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[126] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[127] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[128] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[129] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[130] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[131] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[132] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairTexture[133] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[15] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[16] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[17] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[18] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[19] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[20] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[21] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[22] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[23] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[24] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[25] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[26] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[27] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[28] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[29] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[30] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[31] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[32] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[33] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[34] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[35] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[36] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[37] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[38] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[39] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[40] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[41] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[42] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[43] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[44] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[45] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[46] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[47] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[48] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[49] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[50] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[52] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[53] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[54] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[55] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[56] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[57] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[58] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[59] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[60] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[61] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[62] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[63] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[64] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[65] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[66] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[67] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[68] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[69] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[70] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[71] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[72] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[73] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[74] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[75] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[76] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[77] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[78] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[79] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[80] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[81] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[82] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[83] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[84] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[85] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[86] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[87] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[88] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[89] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[90] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[91] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[92] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[93] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[94] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[95] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[96] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[97] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[98] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[99] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[100] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[101] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[102] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[103] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[104] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[105] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[106] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[107] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[108] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[109] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[110] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[111] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[112] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[113] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[114] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[115] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[116] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[117] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[118] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[119] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[120] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[121] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[122] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[123] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[124] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[125] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[126] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[127] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[128] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[129] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[130] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[131] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[132] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
				Main.playerHairAltTexture[133] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_4");
			}

			if (player.dead)
			{
				Main.playerHairTexture[0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[15] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[16] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[17] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[18] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[19] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[20] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[21] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[22] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[23] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[24] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[25] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[26] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[27] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[28] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[29] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[30] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[31] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[32] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[33] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[34] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[35] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[36] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[37] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[38] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[39] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[40] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[41] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[42] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[43] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[44] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[45] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[46] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[47] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[48] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[49] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[50] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[52] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[53] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[54] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[55] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[56] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[57] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[58] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[59] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[60] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[61] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[62] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[63] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[64] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[65] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[66] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[67] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[68] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[69] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[70] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[71] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[72] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[73] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[74] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[75] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[76] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[77] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[78] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[79] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[80] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[81] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[82] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[83] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[84] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[85] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[86] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[87] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[88] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[89] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[90] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[91] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[92] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[93] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[94] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[95] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[96] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[97] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[98] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[99] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[100] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[101] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[102] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[103] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[104] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[105] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[106] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[107] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[108] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[109] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[110] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[111] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[112] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[113] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[114] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[115] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[116] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[117] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[118] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[119] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[120] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[121] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[122] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[123] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[124] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[125] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[126] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[127] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[128] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[129] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[130] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[131] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[132] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairTexture[133] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[15] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[16] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[17] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[18] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[19] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[20] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[21] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[22] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[23] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[24] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[25] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[26] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[27] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[28] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[29] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[30] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[31] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[32] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[33] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[34] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[35] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[36] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[37] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[38] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[39] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[40] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[41] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[42] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[43] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[44] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[45] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[46] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[47] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[48] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[49] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[50] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[52] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[53] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[54] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[55] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[56] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[57] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[58] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[59] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[60] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[61] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[62] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[63] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[64] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[65] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[66] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[67] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[68] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[69] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[70] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[71] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[72] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[73] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[74] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[75] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[76] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[77] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[78] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[79] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[80] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[81] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[82] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[83] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[84] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[85] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[86] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[87] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[88] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[89] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[90] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[91] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[92] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[93] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[94] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[95] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[96] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[97] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[98] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[99] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[100] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[101] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[102] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[103] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[104] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[105] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[106] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[107] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[108] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[109] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[110] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[111] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[112] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[113] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[114] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[115] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[116] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[117] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[118] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[119] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[120] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[121] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[122] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[123] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[124] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[125] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[126] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[127] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[128] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[129] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[130] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[131] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[132] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
				Main.playerHairAltTexture[133] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Vampire/Hair/VampireBat_Legs_Dead");
			}
		}
	}
}
