using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.UI;
using Terraria.Graphics;
using Terraria.ModLoader;
using MrPlagueRaces.Content.Items;
using MrPlagueRaces.Common.Races;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Common.UI
{
	public class MrPlagueRaceInformation : UIState
	{
        private UIPanel MrPlagueRaceBackground;
		private UIPanel MrPlagueRaceStatDisplayBackground;
        private UIPanel MrPlagueRaceAbilityDisplayBackground;
		private UIPanel MrPlagueRaceInformationMenuBackground;
        private int RaceIndex = 0;
        private int RacePage = 0;
        private int RaceStatAmount = 0;
		public static bool IsBeingHoveredOver = false;
		public static bool Visible;

		private int StatHealth = 0;
		private int StatRegeneration = 0;
		private int StatMana = 0;
		private int StatManaRegeneration = 0;
		private int StatDefense = 0;
		private int StatDamageReduction = 0;
		private int StatThorns = 0;
		private int StatLavaResistance = 0;
		private int StatAllDamage = 0;
		private int StatMeleeDamage = 0;
		private int StatRangedDamage = 0;
		private int StatMagicDamage = 0;
		private int StatSummonDamage = 0;
		private int StatMeleeSpeed = 0;
		private int StatArmorPenetration = 0;
		private int StatBulletDamage = 0;
		private int StatRocketDamage = 0;
		private int StatManaCost = 0;
		private int StatMinionKnockback = 0;
		private int StatMinions = 0;
		private int StatSentries = 0;
		private int StatMeleeCritChance = 0;
		private int StatRangedCritChance = 0;
		private int StatMagicCritChance = 0;
		private int StatMiningSpeed = 0;
		private int StatBuildingSpeed = 0;
		private int StatBuildingRange = 0;
		private int StatBuildingWallSpeed = 0;
		private int StatArrowDamage = 0;
		private int StatMovementSpeed = 0;
		private int StatJumpSpeed = 0;
		private int StatFallDamageResistance = 0;
		private int StatFishingSkill = 0;
		private int StatAggro = 0;
		private int StatRunSpeed = 0;
        private int StatRunAcceleration = 0;

		private bool StatPosition1Taken = false;
		private bool StatPosition2Taken = false;
		private bool StatPosition3Taken = false;
		private bool StatPosition4Taken = false;
		private bool StatPosition5Taken = false;
		private bool StatPosition6Taken = false;
		private bool StatPosition7Taken = false;
		private bool StatPosition8Taken = false;
		private bool StatPosition9Taken = false;
		private bool StatPosition10Taken = false;
		private bool StatPosition11Taken = false;
		private bool StatPosition12Taken = false;
		private bool StatPosition13Taken = false;
		private bool StatPosition14Taken = false;
		private bool StatPosition15Taken = false;
		private bool StatPosition16Taken = false;
		private bool StatPosition17Taken = false;
		private bool StatPosition18Taken = false;
		private bool StatPosition19Taken = false;
		private bool StatPosition20Taken = false;
		private bool StatPosition21Taken = false;
		private bool StatPosition22Taken = false;
		private bool StatPosition23Taken = false;
		private bool StatPosition24Taken = false;
		private bool StatPosition25Taken = false;
		private bool StatPosition26Taken = false;
		private bool StatPosition27Taken = false;
		private bool StatPosition28Taken = false;
		private bool StatPosition29Taken = false;
		private bool StatPosition30Taken = false;
		private bool StatPosition31Taken = false;
		private bool StatPosition32Taken = false;
		private bool StatPosition33Taken = false;
		private bool StatPosition34Taken = false;
		private bool StatPosition35Taken = false;
        private bool StatPosition36Taken = false;

		private Texture2D UI_RaceEnvironmentImageIcon()
		{
			return GetTexture(RaceLoader.Races[RaceIndex].RaceEnvironmentIcon);
		}
		private Texture2D UI_RaceEnvironmentOverlay1ImageIcon()
		{
			return GetTexture(RaceLoader.Races[RaceIndex].RaceEnvironmentOverlay1Icon);
		}
		private Texture2D UI_RaceEnvironmentOverlay2ImageIcon()
		{
			return GetTexture(RaceLoader.Races[RaceIndex].RaceEnvironmentOverlay2Icon);
		}
		private Texture2D UI_RaceDisplayMaleImageIcon()
		{
			return GetTexture(RaceLoader.Races[RaceIndex].RaceDisplayMaleIcon);
		}
		private Texture2D UI_RaceDisplayFemaleImageIcon()
		{
			return GetTexture(RaceLoader.Races[RaceIndex].RaceDisplayFemaleIcon);
		}
		private Texture2D UI_RaceSelectImageIcon1()
        {
			switch (RaceLoader.Races.Count > (0 + (RacePage * 34)))
            {
				case true:
                    return GetTexture(RaceLoader.Races[0 + (RacePage * 34)].RaceSelectIcon);
                default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
        }
		private Texture2D UI_RaceSelectImageIcon2()
        {
			switch (RaceLoader.Races.Count > (1 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[1 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon3()
		{
			switch (RaceLoader.Races.Count > (2 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[2 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon4()
		{
			switch (RaceLoader.Races.Count > (3 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[3 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon5()
		{
			switch (RaceLoader.Races.Count > (4 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[4 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon6()
		{
			switch (RaceLoader.Races.Count > (5 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[5 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon7()
		{
			switch (RaceLoader.Races.Count > (6 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[6 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon8()
		{
			switch (RaceLoader.Races.Count > (7 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[7 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon9()
		{
			switch (RaceLoader.Races.Count > (8 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[8 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon10()
		{
			switch (RaceLoader.Races.Count > (9 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[9 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon11()
		{
			switch (RaceLoader.Races.Count > (10 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[10 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon12()
		{
			switch (RaceLoader.Races.Count > (11 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[11 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon13()
		{
			switch (RaceLoader.Races.Count > (12 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[12 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon14()
		{
			switch (RaceLoader.Races.Count > (13 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[13 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon15()
		{
			switch (RaceLoader.Races.Count > (14 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[14 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon16()
		{
			switch (RaceLoader.Races.Count > (15 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[15 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon17()
		{
			switch (RaceLoader.Races.Count > (16 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[16 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon18()
		{
			switch (RaceLoader.Races.Count > (17 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[17 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon19()
		{
			switch (RaceLoader.Races.Count > (18 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[18 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon20()
		{
			switch (RaceLoader.Races.Count > (19 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[19 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon21()
		{
			switch (RaceLoader.Races.Count > (20 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[20 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon22()
		{
			switch (RaceLoader.Races.Count > (21 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[21 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon23()
		{
			switch (RaceLoader.Races.Count > (22 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[22 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon24()
		{
			switch (RaceLoader.Races.Count > (23 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[23 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon25()
		{
			switch (RaceLoader.Races.Count > (24 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[24 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon26()
		{
			switch (RaceLoader.Races.Count > (25 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[25 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon27()
		{
			switch (RaceLoader.Races.Count > (26 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[26 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon28()
		{
			switch (RaceLoader.Races.Count > (27 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[27 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon29()
		{
			switch (RaceLoader.Races.Count > (28 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[28 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon30()
		{
			switch (RaceLoader.Races.Count > (29 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[29 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon31()
		{
			switch (RaceLoader.Races.Count > (30 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[30 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon32()
		{
			switch (RaceLoader.Races.Count > (31 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[31 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon33()
		{
			switch (RaceLoader.Races.Count > (32 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[32 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		private Texture2D UI_RaceSelectImageIcon34()
		{
			switch (RaceLoader.Races.Count > (33 + (RacePage * 34)))
			{
				case true:
					return GetTexture(RaceLoader.Races[33 + (RacePage * 34)].RaceSelectIcon);
				default:
					return GetTexture("MrPlagueRaces/Common/UI/RaceDisplay/BlankSelect");
			}
		}
		UITextPanel<string> RaceNameDisplay = new UITextPanel<string>("");
		UITextPanel<string> Lore1Description = new UITextPanel<string>("");
		UITextPanel<string> Lore2Description = new UITextPanel<string>("");
		UITextPanel<string> Ability = new UITextPanel<string>("");
        UITextPanel<string> AdditionalNotes = new UITextPanel<string>("");
        UITextPanel<string> AbilityDescription1 = new UITextPanel<string>("");
        UITextPanel<string> AbilityDescription2 = new UITextPanel<string>("");
        UITextPanel<string> AbilityDescription3 = new UITextPanel<string>("");
		UITextPanel<string> AbilityDescription4 = new UITextPanel<string>("");
		UITextPanel<string> AbilityDescription5 = new UITextPanel<string>("");
		UITextPanel<string> AbilityDescription6 = new UITextPanel<string>("");
		UITextPanel<string> AdditionalNotesDescription1 = new UITextPanel<string>("");
		UITextPanel<string> AdditionalNotesDescription2 = new UITextPanel<string>("");
		UITextPanel<string> AdditionalNotesDescription3 = new UITextPanel<string>("");
		UITextPanel<string> AdditionalNotesDescription4 = new UITextPanel<string>("");
		UITextPanel<string> AdditionalNotesDescription5 = new UITextPanel<string>("");
		UITextPanel<string> AdditionalNotesDescription6 = new UITextPanel<string>("");
		UITextPanel<string> RaceSelect = new UITextPanel<string>("");
		UITextPanel<string> DisplayHealth = new UITextPanel<string>("");
		UITextPanel<string> DisplayRegeneration = new UITextPanel<string>("");
		UITextPanel<string> DisplayMana = new UITextPanel<string>("");
		UITextPanel<string> DisplayManaRegeneration = new UITextPanel<string>("");
		UITextPanel<string> DisplayDefense = new UITextPanel<string>("");
		UITextPanel<string> DisplayDamageReduction = new UITextPanel<string>("");
		UITextPanel<string> DisplayThorns = new UITextPanel<string>("");
		UITextPanel<string> DisplayLavaResistance = new UITextPanel<string>("");
		UITextPanel<string> DisplayAllDamage = new UITextPanel<string>("");
		UITextPanel<string> DisplayMeleeDamage = new UITextPanel<string>("");
		UITextPanel<string> DisplayRangedDamage = new UITextPanel<string>("");
		UITextPanel<string> DisplayMagicDamage = new UITextPanel<string>("");
		UITextPanel<string> DisplaySummonDamage = new UITextPanel<string>("");
		UITextPanel<string> DisplayMeleeSpeed = new UITextPanel<string>("");
		UITextPanel<string> DisplayArmorPenetration = new UITextPanel<string>("");
		UITextPanel<string> DisplayBulletDamage = new UITextPanel<string>("");
		UITextPanel<string> DisplayRocketDamage = new UITextPanel<string>("");
		UITextPanel<string> DisplayManaCost = new UITextPanel<string>("");
		UITextPanel<string> DisplayMinionKnockback = new UITextPanel<string>("");
		UITextPanel<string> DisplayMinions = new UITextPanel<string>("");
		UITextPanel<string> DisplaySentries = new UITextPanel<string>("");
		UITextPanel<string> DisplayMeleeCritChance = new UITextPanel<string>("");
		UITextPanel<string> DisplayRangedCritChance = new UITextPanel<string>("");
		UITextPanel<string> DisplayMagicCritChance = new UITextPanel<string>("");
		UITextPanel<string> DisplayMiningSpeed = new UITextPanel<string>("");
		UITextPanel<string> DisplayBuildingSpeed = new UITextPanel<string>("");
		UITextPanel<string> DisplayBuildingRange = new UITextPanel<string>("");
        UITextPanel<string> DisplayBuildingWallSpeed = new UITextPanel<string>("");
		UITextPanel<string> DisplayArrowDamage = new UITextPanel<string>("");
		UITextPanel<string> DisplayMovementSpeed = new UITextPanel<string>("");
		UITextPanel<string> DisplayJumpSpeed = new UITextPanel<string>("");
		UITextPanel<string> DisplayFallDamageResistance = new UITextPanel<string>("");
		UITextPanel<string> DisplayFishingSkill = new UITextPanel<string>("");
		UITextPanel<string> DisplayAggro = new UITextPanel<string>("");
		UITextPanel<string> DisplayRunSpeed = new UITextPanel<string>("");
        UITextPanel<string> DisplayRunAcceleration = new UITextPanel<string>("");
		UITextPanel<string> DisplayGoodBiomes = new UITextPanel<string>("");
		UITextPanel<string> DisplayBadBiomes = new UITextPanel<string>("");
		private static Texture2D Stat_HealthIconPlaceholder = GetTexture("MrPlagueRaces/Common/UI/Stat_Health");
		MrPlagueRaceImageInfo Stat_Health = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_Regeneration = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_Mana = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_ManaRegeneration = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_Defense = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
        MrPlagueRaceImageInfo Stat_DamageReduction = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_Thorns = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_LavaResistance = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_DamageAll = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_DamageMelee = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_DamageRanged = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_DamageMagic = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_DamageSummon = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_MeleeSpeed = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_ArmorPenetration = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_DamageBullet = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_DamageRocket = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_ManaCost = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_MinionKnockback = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_Minions = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_Sentries = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_CritChanceMelee = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_CritChanceRanged = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_CritChanceMagic = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_MiningSpeed = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_BuildingSpeed = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_BuildingRange = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_BuildingWallSpeed = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_DamageArrow = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_MovementSpeed = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_JumpSpeed = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_FallDamageResistance = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_FishingSkill = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_Aggro = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Stat_RunSpeed = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
        MrPlagueRaceImageInfo Stat_RunAcceleration = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Environment_GoodBiomes = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo Environment_BadBiomes = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo UI_DecorativeLine_StatBox1 = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo UI_DecorativeLine_StatBox2 = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo UI_DecorativeLine_StatBox3 = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");
		MrPlagueRaceImageInfo UI_DecorativeLine_StatBox4 = new MrPlagueRaceImageInfo(Stat_HealthIconPlaceholder, "");

		public override void OnInitialize()
        {
			Width.Set(Main.screenWidth, 0);
            Height.Set(Main.screenHeight, 0);
            Top.Set(0, 0);
            Left.Set(0, 0);

            MrPlagueRaceBackground = new UIPanel();
            MrPlagueRaceBackground.Width.Set(1600, 0);
            MrPlagueRaceBackground.Height.Set(800, 0);
			MrPlagueRaceBackground.Left.Set(999999, 0);
			MrPlagueRaceBackground.Top.Set(999999, 0);
			MrPlagueRaceBackground.BackgroundColor = new Color(33, 43, 79) * 0.8f;
            Append(MrPlagueRaceBackground);

            MrPlagueRaceStatDisplayBackground = new UIPanel();
            MrPlagueRaceStatDisplayBackground.Width.Set(300, 0);
            MrPlagueRaceStatDisplayBackground.Height.Set(680, 0);
            MrPlagueRaceStatDisplayBackground.Left.Set(5 + 16 - 13 + 2, 0);
            MrPlagueRaceStatDisplayBackground.Top.Set(80, 0);
            MrPlagueRaceStatDisplayBackground.BackgroundColor = new Color(72, 94, 170);
            MrPlagueRaceBackground.Append(MrPlagueRaceStatDisplayBackground);

            MrPlagueRaceAbilityDisplayBackground = new UIPanel();
            MrPlagueRaceAbilityDisplayBackground.Width.Set(1216 + 20, 0);
            MrPlagueRaceAbilityDisplayBackground.Height.Set(740 - 252, 0);
            MrPlagueRaceAbilityDisplayBackground.Left.Set(330, 0);
            MrPlagueRaceAbilityDisplayBackground.Top.Set(20 + 252, 0);
            MrPlagueRaceAbilityDisplayBackground.BackgroundColor = new Color(72, 94, 170);
            MrPlagueRaceBackground.Append(MrPlagueRaceAbilityDisplayBackground);

			MrPlagueRaceInformationMenuBackground = new UIPanel();
			MrPlagueRaceInformationMenuBackground.Width.Set(1216 + 20, 0);
			MrPlagueRaceInformationMenuBackground.Height.Set(172, 0);
			MrPlagueRaceInformationMenuBackground.Left.Set(330, 0);
			MrPlagueRaceInformationMenuBackground.Top.Set(20 + 252 - 192, 0);
			MrPlagueRaceInformationMenuBackground.BackgroundColor = new Color(72, 94, 170);
			MrPlagueRaceBackground.Append(MrPlagueRaceInformationMenuBackground);

			UITextPanel<string> RaceInfo = new UITextPanel<string>("Race Information", 0.8f, true);
			RaceInfo.HAlign = 0.5f;
			RaceInfo.Top.Set(0 - 130 + 92, 0);
			RaceInfo.BackgroundColor = new Color(73, 94, 171);
			MrPlagueRaceBackground.Append(RaceInfo);

            Texture2D UI_ButtonPreviousIcon = GetTexture("MrPlagueRaces/Common/UI/UI_ButtonPrevious");
			Texture2D UI_ButtonPrevious_ActiveIcon = GetTexture("MrPlagueRaces/Common/UI/UI_ButtonPrevious_Active");
			MrPlagueRaceButton UI_ButtonPrevious = new MrPlagueRaceButton(UI_ButtonPreviousIcon, UI_ButtonPrevious_ActiveIcon);
            UI_ButtonPrevious.Width.Set(56, 0);
            UI_ButtonPrevious.Height.Set(56, 0);
            UI_ButtonPrevious.Left.Set(10, 0);
            UI_ButtonPrevious.Top.Set(129 - 124, 0);
			UI_ButtonPrevious.OnClick += new MouseEvent(UI_ButtonPrevious_Clicked);
            MrPlagueRaceBackground.Append(UI_ButtonPrevious);

            Texture2D UI_ButtonRandomIcon = GetTexture("MrPlagueRaces/Common/UI/UI_ButtonRandom");
			Texture2D UI_ButtonRandom_ActiveIcon = GetTexture("MrPlagueRaces/Common/UI/UI_ButtonRandom_Active");
			MrPlagueRaceButton UI_ButtonRandom = new MrPlagueRaceButton(UI_ButtonRandomIcon, UI_ButtonRandom_ActiveIcon);
			UI_ButtonRandom.Width.Set(56, 0);
			UI_ButtonRandom.Height.Set(56, 0);
			UI_ButtonRandom.Left.Set(80, 0);
			UI_ButtonRandom.Top.Set(129 - 124, 0);
			UI_ButtonRandom.OnClick += new MouseEvent(UI_ButtonRandom_Clicked);
			MrPlagueRaceBackground.Append(UI_ButtonRandom);

            Texture2D UI_ButtonNextIcon = GetTexture("MrPlagueRaces/Common/UI/UI_ButtonNext");
			Texture2D UI_ButtonNext_ActiveIcon = GetTexture("MrPlagueRaces/Common/UI/UI_ButtonNext_Active");
			MrPlagueRaceButton UI_ButtonNext = new MrPlagueRaceButton(UI_ButtonNextIcon, UI_ButtonNext_ActiveIcon);
            UI_ButtonNext.Width.Set(56, 0);
            UI_ButtonNext.Height.Set(56, 0);
            UI_ButtonNext.Left.Set(80 + 70, 0);
            UI_ButtonNext.Top.Set(129 - 124, 0);
            UI_ButtonNext.OnClick += new MouseEvent(UI_ButtonNext_Clicked);
            MrPlagueRaceBackground.Append(UI_ButtonNext);

            Texture2D UI_DecorativeLine_StatBoxIcon = GetTexture("MrPlagueRaces/Common/UI/UI_DecorativeLine_StatBox");
			UI_DecorativeLine_StatBox1 = new MrPlagueRaceImageInfo(UI_DecorativeLine_StatBoxIcon, "");
            UI_DecorativeLine_StatBox1.Width.Set(280, 0);
            UI_DecorativeLine_StatBox1.Height.Set(4, 0);
            UI_DecorativeLine_StatBox1.Left.Set(20 - 22, 0);
            UI_DecorativeLine_StatBox1.Top.Set(129 - 124 + 108 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(UI_DecorativeLine_StatBox1);

			UI_DecorativeLine_StatBox2 = new MrPlagueRaceImageInfo(UI_DecorativeLine_StatBoxIcon, "");
            UI_DecorativeLine_StatBox2.Width.Set(280, 0);
            UI_DecorativeLine_StatBox2.Height.Set(4, 0);
            UI_DecorativeLine_StatBox2.Left.Set(20 - 22, 0);
            UI_DecorativeLine_StatBox2.Top.Set(129 - 124 + 108 + 156 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(UI_DecorativeLine_StatBox2);

			UI_DecorativeLine_StatBox3 = new MrPlagueRaceImageInfo(UI_DecorativeLine_StatBoxIcon, "");
            UI_DecorativeLine_StatBox3.Width.Set(280, 0);
            UI_DecorativeLine_StatBox3.Height.Set(4, 0);
            UI_DecorativeLine_StatBox3.Left.Set(20 - 22, 0);
            UI_DecorativeLine_StatBox3.Top.Set(129 - 124 + 108 + 156 + 260 + 132 - 92 - 260, 0);
			MrPlagueRaceStatDisplayBackground.Append(UI_DecorativeLine_StatBox3);

			UI_DecorativeLine_StatBox4 = new MrPlagueRaceImageInfo(UI_DecorativeLine_StatBoxIcon, "");
            UI_DecorativeLine_StatBox4.Width.Set(280, 0);
            UI_DecorativeLine_StatBox4.Height.Set(4, 0);
            UI_DecorativeLine_StatBox4.Left.Set(20 - 22, 0);
            UI_DecorativeLine_StatBox4.Top.Set(129 - 124 + 108 + 156 + 260 + 76 + 132 - 468 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(UI_DecorativeLine_StatBox4);

            Texture2D UI_DecorativeLine_AbilityBoxIcon = GetTexture("MrPlagueRaces/Common/UI/UI_DecorativeLine_AbilityBox");
			MrPlagueRaceImageInfo UI_DecorativeLine_AbilityBox1 = new MrPlagueRaceImageInfo(UI_DecorativeLine_AbilityBoxIcon, "");
            UI_DecorativeLine_AbilityBox1.Width.Set(1216, 0);
            UI_DecorativeLine_AbilityBox1.Height.Set(4, 0);
            UI_DecorativeLine_AbilityBox1.Left.Set(360 - 362, 0);
            UI_DecorativeLine_AbilityBox1.Top.Set(129 - 124 + 108 - 59 - 34 + 1, 0);
			MrPlagueRaceAbilityDisplayBackground.Append(UI_DecorativeLine_AbilityBox1);

			MrPlagueRaceImageInfo UI_DecorativeLine_AbilityBox2 = new MrPlagueRaceImageInfo(UI_DecorativeLine_AbilityBoxIcon, "");
            UI_DecorativeLine_AbilityBox2.Width.Set(1216, 0);
            UI_DecorativeLine_AbilityBox2.Height.Set(4, 0);
            UI_DecorativeLine_AbilityBox2.Left.Set(360 - 362, 0);
            UI_DecorativeLine_AbilityBox2.Top.Set(129 - 124 + 108 + 169 - 34 + 1, 0);
            MrPlagueRaceAbilityDisplayBackground.Append(UI_DecorativeLine_AbilityBox2);

			MrPlagueRaceImageInfo UI_DecorativeLine_RaceSelectBox = new MrPlagueRaceImageInfo(UI_DecorativeLine_AbilityBoxIcon, "");
			UI_DecorativeLine_RaceSelectBox.Width.Set(1216, 0);
			UI_DecorativeLine_RaceSelectBox.Height.Set(4, 0);
			UI_DecorativeLine_RaceSelectBox.Left.Set(360 - 362, 0);
			UI_DecorativeLine_RaceSelectBox.Top.Set(129 - 124 + 108 - 92, 0);
			MrPlagueRaceInformationMenuBackground.Append(UI_DecorativeLine_RaceSelectBox);

			Texture2D UI_LoreBoxIcon = GetTexture("MrPlagueRaces/Common/UI/UI_LoreBox");
			MrPlagueRaceImageInfo UI_LoreBox = new MrPlagueRaceImageInfo(UI_LoreBoxIcon, "");
            UI_LoreBox.Width.Set(172, 0);
            UI_LoreBox.Height.Set(138, 0);
            UI_LoreBox.Left.Set(128 - 22, 0);
            UI_LoreBox.Top.Set(129 - 124 + 120 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(UI_LoreBox);

            Texture2D UI_LoreBox2Icon = GetTexture("MrPlagueRaces/Common/UI/UI_LoreBox2");
			MrPlagueRaceImageInfo UI_LoreBox2 = new MrPlagueRaceImageInfo(UI_LoreBox2Icon, "");
            UI_LoreBox2.Width.Set(280, 0);
            UI_LoreBox2.Height.Set(116, 0);
            UI_LoreBox2.Left.Set(20 - 22, 0);
            UI_LoreBox2.Top.Set(615 - 336 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(UI_LoreBox2);

            Texture2D UI_AbilityBoxIcon = GetTexture("MrPlagueRaces/Common/UI/UI_AbilityBox");
			MrPlagueRaceImageInfo UI_AbilityBox1 = new MrPlagueRaceImageInfo(UI_AbilityBoxIcon, "");
            UI_AbilityBox1.Width.Set(1216, 0);
            UI_AbilityBox1.Height.Set(188, 0);
            UI_AbilityBox1.Left.Set(360 - 362, 0);
            UI_AbilityBox1.Top.Set(129 - 124 + 120 - 61 - 34 + 1, 0);
			MrPlagueRaceAbilityDisplayBackground.Append(UI_AbilityBox1);

			MrPlagueRaceImageInfo UI_AbilityBox2 = new MrPlagueRaceImageInfo(UI_AbilityBoxIcon, "");
            UI_AbilityBox2.Width.Set(1216, 0);
            UI_AbilityBox2.Height.Set(188, 0);
            UI_AbilityBox2.Left.Set(360 - 362, 0);
            UI_AbilityBox2.Top.Set(129 - 124 + 120 - 61 + 228 - 34 + 1, 0);
			MrPlagueRaceAbilityDisplayBackground.Append(UI_AbilityBox2);

            Texture2D UI_RaceDisplayBoxIcon = GetTexture("MrPlagueRaces/Common/UI/UI_RaceDisplayBox");
			MrPlagueRaceImageInfo UI_RaceDisplayBox = new MrPlagueRaceImageInfo(UI_RaceDisplayBoxIcon, "");
            UI_RaceDisplayBox.Width.Set(100, 0);
            UI_RaceDisplayBox.Height.Set(138, 0);
            UI_RaceDisplayBox.Left.Set(20 - 22, 0);
            UI_RaceDisplayBox.Top.Set(129 - 124 + 120 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(UI_RaceDisplayBox);

            Texture2D Stat_HealthIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_Health");
			Stat_Health = new MrPlagueRaceImageInfo(Stat_HealthIcon, "Health");
            Stat_Health.Width.Set(64, 0);
            Stat_Health.Height.Set(20, 0);
            Stat_Health.Left.Set(20 - 22, 0);
            Stat_Health.Top.Set(279 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_Health);

            Texture2D Stat_RegenerationIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_Regeneration");
			Stat_Regeneration = new MrPlagueRaceImageInfo(Stat_RegenerationIcon, "Health Regeneration");
            Stat_Regeneration.Width.Set(64, 0);
            Stat_Regeneration.Height.Set(20, 0);
            Stat_Regeneration.Left.Set(20 - 22 + 64 + 8, 0);
            Stat_Regeneration.Top.Set(279 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_Regeneration);

            Texture2D Stat_ManaIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_Mana");
			Stat_Mana = new MrPlagueRaceImageInfo(Stat_ManaIcon, "Mana");
            Stat_Mana.Width.Set(64, 0);
            Stat_Mana.Height.Set(20, 0);
            Stat_Mana.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
            Stat_Mana.Top.Set(279 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_Mana);

            Texture2D Stat_ManaRegenerationIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_ManaRegeneration");
			Stat_ManaRegeneration = new MrPlagueRaceImageInfo(Stat_ManaRegenerationIcon, "Mana Regeneration");
            Stat_ManaRegeneration.Width.Set(64, 0);
            Stat_ManaRegeneration.Height.Set(20, 0);
            Stat_ManaRegeneration.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
            Stat_ManaRegeneration.Top.Set(279 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_ManaRegeneration);

            Texture2D Stat_DefenseIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_Defense");
			Stat_Defense = new MrPlagueRaceImageInfo(Stat_DefenseIcon, "Defense");
            Stat_Defense.Width.Set(64, 0);
            Stat_Defense.Height.Set(20, 0);
            Stat_Defense.Left.Set(20 - 22, 0);
            Stat_Defense.Top.Set(279 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_Defense);

            Texture2D Stat_DamageReductionIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_DamageReduction");
			Stat_DamageReduction = new MrPlagueRaceImageInfo(Stat_DamageReductionIcon, "Damage Resistance");
            Stat_DamageReduction.Width.Set(64, 0);
            Stat_DamageReduction.Height.Set(20, 0);
            Stat_DamageReduction.Left.Set(20 - 22 + 64 + 8, 0);
            Stat_DamageReduction.Top.Set(279 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_DamageReduction);

			Texture2D Stat_ThornsIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_Thorns");
			Stat_Thorns = new MrPlagueRaceImageInfo(Stat_ThornsIcon, "Thorns");
			Stat_Thorns.Width.Set(64, 0);
			Stat_Thorns.Height.Set(20, 0);
			Stat_Thorns.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
			Stat_Thorns.Top.Set(279 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_Thorns);

			Texture2D Stat_LavaResistanceIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_LavaResistance");
			Stat_LavaResistance = new MrPlagueRaceImageInfo(Stat_LavaResistanceIcon, "Lava Immunity Time");
            Stat_LavaResistance.Width.Set(64, 0);
            Stat_LavaResistance.Height.Set(20, 0);
            Stat_LavaResistance.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
            Stat_LavaResistance.Top.Set(279 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_LavaResistance);

            Texture2D Stat_DamageMeleeIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_DamageMelee");
			Stat_DamageMelee = new MrPlagueRaceImageInfo(Stat_DamageMeleeIcon, "Melee Damage");
            Stat_DamageMelee.Width.Set(64, 0);
            Stat_DamageMelee.Height.Set(20, 0);
            Stat_DamageMelee.Left.Set(20 - 22, 0);
            Stat_DamageMelee.Top.Set(279 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_DamageMelee);

            Texture2D Stat_DamageRangedIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_DamageRanged");
			Stat_DamageRanged = new MrPlagueRaceImageInfo(Stat_DamageRangedIcon, "Ranged Damage");
            Stat_DamageRanged.Width.Set(64, 0);
            Stat_DamageRanged.Height.Set(20, 0);
            Stat_DamageRanged.Left.Set(20 - 22 + 64 + 8, 0);
            Stat_DamageRanged.Top.Set(279 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_DamageRanged);

            Texture2D Stat_DamageMagicIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_DamageMagic");
			Stat_DamageMagic = new MrPlagueRaceImageInfo(Stat_DamageMagicIcon, "Magic Damage");
            Stat_DamageMagic.Width.Set(64, 0);
            Stat_DamageMagic.Height.Set(20, 0);
            Stat_DamageMagic.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
            Stat_DamageMagic.Top.Set(279 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_DamageMagic);

            Texture2D Stat_DamageSummonIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_DamageSummon");
			Stat_DamageSummon = new MrPlagueRaceImageInfo(Stat_DamageSummonIcon, "Summoning Damage");
            Stat_DamageSummon.Width.Set(64, 0);
            Stat_DamageSummon.Height.Set(20, 0);
            Stat_DamageSummon.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
            Stat_DamageSummon.Top.Set(279 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_DamageSummon);

            Texture2D Stat_MeleeSpeedIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_MeleeSpeed");
			Stat_MeleeSpeed = new MrPlagueRaceImageInfo(Stat_MeleeSpeedIcon, "Melee Speed");
            Stat_MeleeSpeed.Width.Set(64, 0);
            Stat_MeleeSpeed.Height.Set(20, 0);
            Stat_MeleeSpeed.Left.Set(20 - 22, 0);
            Stat_MeleeSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_MeleeSpeed);

            Texture2D Stat_ArmorPenetrationIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_ArmorPenetration");
			Stat_ArmorPenetration = new MrPlagueRaceImageInfo(Stat_ArmorPenetrationIcon, "Armor Penetration");
            Stat_ArmorPenetration.Width.Set(64, 0);
            Stat_ArmorPenetration.Height.Set(20, 0);
            Stat_ArmorPenetration.Left.Set(20 - 22 + 64 + 8, 0);
            Stat_ArmorPenetration.Top.Set(279 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_ArmorPenetration);

            Texture2D Stat_DamageBulletIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_DamageBullet");
			Stat_DamageBullet = new MrPlagueRaceImageInfo(Stat_DamageBulletIcon, "Bullet Damage");
            Stat_DamageBullet.Width.Set(64, 0);
            Stat_DamageBullet.Height.Set(20, 0);
            Stat_DamageBullet.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
            Stat_DamageBullet.Top.Set(279 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_DamageBullet);

            Texture2D Stat_DamageRocketIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_DamageRocket");
			Stat_DamageRocket = new MrPlagueRaceImageInfo(Stat_DamageRocketIcon, "Rocket Damage");
            Stat_DamageRocket.Width.Set(64, 0);
            Stat_DamageRocket.Height.Set(20, 0);
            Stat_DamageRocket.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
            Stat_DamageRocket.Top.Set(279 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_DamageRocket);

            Texture2D Stat_ManaCostIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_ManaCost");
			Stat_ManaCost = new MrPlagueRaceImageInfo(Stat_ManaCostIcon, "Mana Cost");
            Stat_ManaCost.Width.Set(64, 0);
            Stat_ManaCost.Height.Set(20, 0);
            Stat_ManaCost.Left.Set(20 - 22, 0);
            Stat_ManaCost.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_ManaCost);

            Texture2D Stat_MinionKnockbackIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_MinionKnockback");
			Stat_MinionKnockback = new MrPlagueRaceImageInfo(Stat_MinionKnockbackIcon, "Minion Knockback");
            Stat_MinionKnockback.Width.Set(64, 0);
            Stat_MinionKnockback.Height.Set(20, 0);
            Stat_MinionKnockback.Left.Set(20 - 22 + 64 + 8, 0);
            Stat_MinionKnockback.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_MinionKnockback);

            Texture2D Stat_MinionsIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_Minions");
			Stat_Minions = new MrPlagueRaceImageInfo(Stat_MinionsIcon, "Minions");
            Stat_Minions.Width.Set(64, 0);
            Stat_Minions.Height.Set(20, 0);
            Stat_Minions.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
            Stat_Minions.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_Minions);

            Texture2D Stat_SentriesIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_Sentries");
			Stat_Sentries = new MrPlagueRaceImageInfo(Stat_SentriesIcon, "Sentries");
            Stat_Sentries.Width.Set(64, 0);
            Stat_Sentries.Height.Set(20, 0);
            Stat_Sentries.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
            Stat_Sentries.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_Sentries);

            Texture2D Stat_CritChanceMeleeIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_CritChanceMelee");
			Stat_CritChanceMelee = new MrPlagueRaceImageInfo(Stat_CritChanceMeleeIcon, "Melee Critical Hit Chance");
            Stat_CritChanceMelee.Width.Set(64, 0);
            Stat_CritChanceMelee.Height.Set(20, 0);
            Stat_CritChanceMelee.Left.Set(20 - 22, 0);
            Stat_CritChanceMelee.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_CritChanceMelee);

            Texture2D Stat_CritChanceRangedIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_CritChanceRanged");
			Stat_CritChanceRanged = new MrPlagueRaceImageInfo(Stat_CritChanceRangedIcon, "Ranged Critical Hit Chance");
            Stat_CritChanceRanged.Width.Set(64, 0);
            Stat_CritChanceRanged.Height.Set(20, 0);
            Stat_CritChanceRanged.Left.Set(20 - 22 + 64 + 8, 0);
            Stat_CritChanceRanged.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_CritChanceRanged);

            Texture2D Stat_CritChanceMagicIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_CritChanceMagic");
			Stat_CritChanceMagic = new MrPlagueRaceImageInfo(Stat_CritChanceMagicIcon, "Magic Critical Hit Chance");
            Stat_CritChanceMagic.Width.Set(64, 0);
            Stat_CritChanceMagic.Height.Set(20, 0);
            Stat_CritChanceMagic.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
            Stat_CritChanceMagic.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_CritChanceMagic);

            Texture2D Stat_MiningSpeedIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_MiningSpeed");
			Stat_MiningSpeed = new MrPlagueRaceImageInfo(Stat_MiningSpeedIcon, "Mining Speed");
            Stat_MiningSpeed.Width.Set(64, 0);
            Stat_MiningSpeed.Height.Set(20, 0);
            Stat_MiningSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
            Stat_MiningSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_MiningSpeed);

            Texture2D Stat_BuildingSpeedIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_BuildingSpeed");
			Stat_BuildingSpeed = new MrPlagueRaceImageInfo(Stat_BuildingSpeedIcon, "Tile Placement Speed");
            Stat_BuildingSpeed.Width.Set(64, 0);
            Stat_BuildingSpeed.Height.Set(20, 0);
            Stat_BuildingSpeed.Left.Set(20 - 22, 0);
            Stat_BuildingSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_BuildingSpeed);

            Texture2D Stat_BuildingWallSpeedIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_BuildingWallSpeed");
			Stat_BuildingWallSpeed = new MrPlagueRaceImageInfo(Stat_BuildingWallSpeedIcon, "Wall Placement Speed");
            Stat_BuildingWallSpeed.Width.Set(64, 0);
            Stat_BuildingWallSpeed.Height.Set(20, 0);
            Stat_BuildingWallSpeed.Left.Set(20 - 22 + 64 + 8, 0);
            Stat_BuildingWallSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
            MrPlagueRaceStatDisplayBackground.Append(Stat_BuildingWallSpeed);

			Texture2D Stat_BuildingRangeIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_BuildingRange");
			Stat_BuildingRange = new MrPlagueRaceImageInfo(Stat_BuildingRangeIcon, "Block Placement Range");
			Stat_BuildingRange.Width.Set(64, 0);
			Stat_BuildingRange.Height.Set(20, 0);
			Stat_BuildingRange.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
			Stat_BuildingRange.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
            MrPlagueRaceStatDisplayBackground.Append(Stat_BuildingRange);

			Texture2D Stat_DamageArrowIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_DamageArrow");
			Stat_DamageArrow = new MrPlagueRaceImageInfo(Stat_DamageArrowIcon, "Arrow Damage");
			Stat_DamageArrow.Width.Set(64, 0);
			Stat_DamageArrow.Height.Set(20, 0);
			Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
			Stat_DamageArrow.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_DamageArrow);

			Texture2D Stat_MovementSpeedIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_MovementSpeed");
			Stat_MovementSpeed = new MrPlagueRaceImageInfo(Stat_MovementSpeedIcon, "Movement Speed");
            Stat_MovementSpeed.Width.Set(64, 0);
            Stat_MovementSpeed.Height.Set(20, 0);
            Stat_MovementSpeed.Left.Set(20 - 22, 0);
            Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_MovementSpeed);

            Texture2D Stat_JumpSpeedIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_JumpSpeed");
			Stat_JumpSpeed = new MrPlagueRaceImageInfo(Stat_JumpSpeedIcon, "Jump Height");
            Stat_JumpSpeed.Width.Set(64, 0);
            Stat_JumpSpeed.Height.Set(20, 0);
            Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8, 0);
            Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_JumpSpeed);

            Texture2D Stat_FallDamageResistanceIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_FallDamageResistance");
			Stat_FallDamageResistance = new MrPlagueRaceImageInfo(Stat_FallDamageResistanceIcon, "Fall Damage");
            Stat_FallDamageResistance.Width.Set(64, 0);
            Stat_FallDamageResistance.Height.Set(20, 0);
            Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
            Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_FallDamageResistance);

            Texture2D Stat_DamageAllIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_DamageAll");
			Stat_DamageAll = new MrPlagueRaceImageInfo(Stat_DamageAllIcon, "Attack Damage");
            Stat_DamageAll.Width.Set(64, 0);
            Stat_DamageAll.Height.Set(20, 0);
            Stat_DamageAll.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
            Stat_DamageAll.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_DamageAll);

            Texture2D Stat_FishingSkillIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_FishingSkill");
			Stat_FishingSkill = new MrPlagueRaceImageInfo(Stat_FishingSkillIcon, "Fishing Skill");
            Stat_FishingSkill.Width.Set(64, 0);
            Stat_FishingSkill.Height.Set(20, 0);
            Stat_FishingSkill.Left.Set(20 - 22, 0);
            Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_FishingSkill);

            Texture2D Stat_AggroIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_Aggro");
			Stat_Aggro = new MrPlagueRaceImageInfo(Stat_AggroIcon, "Enemy Aggresion");
            Stat_Aggro.Width.Set(64, 0);
            Stat_Aggro.Height.Set(20, 0);
            Stat_Aggro.Left.Set(20 - 22 + 64 + 8, 0);
            Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_Aggro);

            Texture2D Stat_RunSpeedIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_RunSpeed");
			Stat_RunSpeed = new MrPlagueRaceImageInfo(Stat_RunSpeedIcon, "Maximum Running Speed");
            Stat_RunSpeed.Width.Set(64, 0);
            Stat_RunSpeed.Height.Set(20, 0);
            Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
            Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_RunSpeed);

            Texture2D Stat_RunAccelerationIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_RunAcceleration");
			Stat_RunAcceleration = new MrPlagueRaceImageInfo(Stat_RunAccelerationIcon, "Running Acceleration");
            Stat_RunAcceleration.Width.Set(64, 0);
            Stat_RunAcceleration.Height.Set(20, 0);
            Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
            Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92 + 999999, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_RunAcceleration);

            Texture2D Environment_GoodBiomesIcon = GetTexture("MrPlagueRaces/Common/UI/Environment_GoodBiomes");
			Environment_GoodBiomes = new MrPlagueRaceImageInfo(Environment_GoodBiomesIcon, "Adapted for" + "\n(CURRENTLY COSMETIC)");
            Environment_GoodBiomes.Width.Set(280, 0);
            Environment_GoodBiomes.Height.Set(26, 0);
            Environment_GoodBiomes.Left.Set(20 - 22, 0);
            Environment_GoodBiomes.Top.Set(539 + 132 - 92 - 260, 0);
			MrPlagueRaceStatDisplayBackground.Append(Environment_GoodBiomes);

			Texture2D Environment_BadBiomesIcon = GetTexture("MrPlagueRaces/Common/UI/Environment_BadBiomes");
			Environment_BadBiomes = new MrPlagueRaceImageInfo(Environment_BadBiomesIcon, "Unadapted for" + "\n(CURRENTLY COSMETIC)");
			Environment_BadBiomes.Width.Set(280, 0);
			Environment_BadBiomes.Height.Set(26, 0);
			Environment_BadBiomes.Left.Set(20 - 22, 0);
			Environment_BadBiomes.Top.Set(539 + 34 + 132 - 92 - 260, 0);
			MrPlagueRaceStatDisplayBackground.Append(Environment_BadBiomes);

            Ability = new UITextPanel<string>("Ability:" + "\n                                                                                                                                                                       ");
            Ability.Width.Set(1216, 0);
            Ability.Height.Set(40, 0);
            Ability.Left.Set(350 - 362 - 10, 0);
            Ability.Top.Set(20 - 34 + 1, 0);
            Ability.BackgroundColor = Color.Transparent;
            Ability.BorderColor = Color.Transparent;
			MrPlagueRaceAbilityDisplayBackground.Append(Ability);

            AdditionalNotes = new UITextPanel<string>("Additional Notes:" + "\n                                                                                                                                                                       ");
            AdditionalNotes.Width.Set(1216, 0);
            AdditionalNotes.Height.Set(40, 0);
            AdditionalNotes.Left.Set(350 - 362 - 10, 0);
            AdditionalNotes.Top.Set(80 + 168 - 34 + 1, 0);
            AdditionalNotes.BackgroundColor = Color.Transparent;
            AdditionalNotes.BorderColor = Color.Transparent;
			MrPlagueRaceAbilityDisplayBackground.Append(AdditionalNotes);

            AbilityDescription1 = new UITextPanel<string>("" + "\n                                                                                                                                                                       ");
            AbilityDescription1.Width.Set(1216, 0);
            AbilityDescription1.Height.Set(40, 0);
            AbilityDescription1.Left.Set(350 - 362 - 8, 0);
            AbilityDescription1.Top.Set(20 + 40 - 34 + 1, 0);
            AbilityDescription1.BackgroundColor = Color.Transparent;
            AbilityDescription1.BorderColor = Color.Transparent;
            MrPlagueRaceAbilityDisplayBackground.Append(AbilityDescription1);

			AbilityDescription2 = new UITextPanel<string>("" + "\n                                                                                                                                                                       ");
			AbilityDescription2.Width.Set(1216, 0);
			AbilityDescription2.Height.Set(40, 0);
			AbilityDescription2.Left.Set(350 - 362 - 8, 0);
			AbilityDescription2.Top.Set(20 + 40 - 34 + 1 + 28, 0);
			AbilityDescription2.BackgroundColor = Color.Transparent;
			AbilityDescription2.BorderColor = Color.Transparent;
            MrPlagueRaceAbilityDisplayBackground.Append(AbilityDescription2);

			AbilityDescription3 = new UITextPanel<string>("" + "\n                                                                                                                                                                       ");
			AbilityDescription3.Width.Set(1216, 0);
			AbilityDescription3.Height.Set(40, 0);
			AbilityDescription3.Left.Set(350 - 362 - 8, 0);
			AbilityDescription3.Top.Set(20 + 40 - 34 + 1 + 28 + 28, 0);
			AbilityDescription3.BackgroundColor = Color.Transparent;
			AbilityDescription3.BorderColor = Color.Transparent;
            MrPlagueRaceAbilityDisplayBackground.Append(AbilityDescription3);

			AbilityDescription4 = new UITextPanel<string>("" + "\n                                                                                                                                                                       ");
			AbilityDescription4.Width.Set(1216, 0);
			AbilityDescription4.Height.Set(40, 0);
			AbilityDescription4.Left.Set(350 - 362 - 8, 0);
			AbilityDescription4.Top.Set(20 + 40 - 34 + 1 + 28 + 28 + 28, 0);
			AbilityDescription4.BackgroundColor = Color.Transparent;
			AbilityDescription4.BorderColor = Color.Transparent;
            MrPlagueRaceAbilityDisplayBackground.Append(AbilityDescription4);

			AbilityDescription5 = new UITextPanel<string>("" + "\n                                                                                                                                                                       ");
			AbilityDescription5.Width.Set(1216, 0);
			AbilityDescription5.Height.Set(40, 0);
			AbilityDescription5.Left.Set(350 - 362 - 8, 0);
			AbilityDescription5.Top.Set(20 + 40 - 34 + 1 + 28 + 28 + 28 + 28, 0);
			AbilityDescription5.BackgroundColor = Color.Transparent;
			AbilityDescription5.BorderColor = Color.Transparent;
            MrPlagueRaceAbilityDisplayBackground.Append(AbilityDescription5);

			AbilityDescription6 = new UITextPanel<string>("" + "\n                                                                                                                                                                       ");
			AbilityDescription6.Width.Set(1216, 0);
			AbilityDescription6.Height.Set(40, 0);
			AbilityDescription6.Left.Set(350 - 362 - 8, 0);
			AbilityDescription6.Top.Set(20 + 40 - 34 + 1 + 28 + 28 + 28 + 28 + 28, 0);
			AbilityDescription6.BackgroundColor = Color.Transparent;
			AbilityDescription6.BorderColor = Color.Transparent;
			MrPlagueRaceAbilityDisplayBackground.Append(AbilityDescription6);

			AdditionalNotesDescription1 = new UITextPanel<string>("" + "\n                                                                                                                                                                       ");
            AdditionalNotesDescription1.Width.Set(1216, 0);
            AdditionalNotesDescription1.Height.Set(40, 0);
            AdditionalNotesDescription1.Left.Set(350 - 362 - 8, 0);
            AdditionalNotesDescription1.Top.Set(80 + 168 + 40 - 34 + 1, 0);
            AdditionalNotesDescription1.BackgroundColor = Color.Transparent;
            AdditionalNotesDescription1.BorderColor = Color.Transparent;
            MrPlagueRaceAbilityDisplayBackground.Append(AdditionalNotesDescription1);

			AdditionalNotesDescription2 = new UITextPanel<string>("" + "\n                                                                                                                                                                       ");
			AdditionalNotesDescription2.Width.Set(1216, 0);
			AdditionalNotesDescription2.Height.Set(40, 0);
			AdditionalNotesDescription2.Left.Set(350 - 362 - 8, 0);
			AdditionalNotesDescription2.Top.Set(80 + 168 + 40 - 34 + 1 + 28, 0);
			AdditionalNotesDescription2.BackgroundColor = Color.Transparent;
			AdditionalNotesDescription2.BorderColor = Color.Transparent;
            MrPlagueRaceAbilityDisplayBackground.Append(AdditionalNotesDescription2);

			AdditionalNotesDescription3 = new UITextPanel<string>("" + "\n                                                                                                                                                                       ");
			AdditionalNotesDescription3.Width.Set(1216, 0);
			AdditionalNotesDescription3.Height.Set(40, 0);
			AdditionalNotesDescription3.Left.Set(350 - 362 - 8, 0);
			AdditionalNotesDescription3.Top.Set(80 + 168 + 40 - 34 + 1 + 28 + 28, 0);
			AdditionalNotesDescription3.BackgroundColor = Color.Transparent;
			AdditionalNotesDescription3.BorderColor = Color.Transparent;
            MrPlagueRaceAbilityDisplayBackground.Append(AdditionalNotesDescription3);

			AdditionalNotesDescription4 = new UITextPanel<string>("" + "\n                                                                                                                                                                       ");
			AdditionalNotesDescription4.Width.Set(1216, 0);
			AdditionalNotesDescription4.Height.Set(40, 0);
			AdditionalNotesDescription4.Left.Set(350 - 362 - 8, 0);
			AdditionalNotesDescription4.Top.Set(80 + 168 + 40 - 34 + 1 + 28 + 28 + 28, 0);
			AdditionalNotesDescription4.BackgroundColor = Color.Transparent;
			AdditionalNotesDescription4.BorderColor = Color.Transparent;
			MrPlagueRaceAbilityDisplayBackground.Append(AdditionalNotesDescription4);

			AdditionalNotesDescription5 = new UITextPanel<string>("" + "\n                                                                                                                                                                       ");
			AdditionalNotesDescription5.Width.Set(1216, 0);
			AdditionalNotesDescription5.Height.Set(40, 0);
			AdditionalNotesDescription5.Left.Set(350 - 362 - 8, 0);
			AdditionalNotesDescription5.Top.Set(80 + 168 + 40 - 34 + 1 + 28 + 28 + 28 + 28, 0);
			AdditionalNotesDescription5.BackgroundColor = Color.Transparent;
			AdditionalNotesDescription5.BorderColor = Color.Transparent;
			MrPlagueRaceAbilityDisplayBackground.Append(AdditionalNotesDescription5);

			AdditionalNotesDescription6 = new UITextPanel<string>("" + "\n                                                                                                                                                                       ");
			AdditionalNotesDescription6.Width.Set(1216, 0);
			AdditionalNotesDescription6.Height.Set(40, 0);
			AdditionalNotesDescription6.Left.Set(350 - 362 - 8, 0);
			AdditionalNotesDescription6.Top.Set(80 + 168 + 40 - 34 + 1 + 28 + 28 + 28 + 28 + 28, 0);
			AdditionalNotesDescription6.BackgroundColor = Color.Transparent;
			AdditionalNotesDescription6.BorderColor = Color.Transparent;
			MrPlagueRaceAbilityDisplayBackground.Append(AdditionalNotesDescription6);

			Lore1Description = new UITextPanel<string>("A diverse race with" + "\na surprising amount" + "\nof resilience, known" + "\nfor their adaptivity." + "\n                                                                                                                                                                       ");
            Lore1Description.Width.Set(280, 0);
            Lore1Description.Height.Set(40, 0);
            Lore1Description.Left.Set(118 - 20, 0);
            Lore1Description.Top.Set(129 - 124 + 117 - 92, 0);
            Lore1Description.BackgroundColor = Color.Transparent;
            Lore1Description.BorderColor = Color.Transparent;
            MrPlagueRaceStatDisplayBackground.Append(Lore1Description);

            Lore2Description = new UITextPanel<string>("Old records seem to suggest they" + "\nonce built advanced technology," + "\nalthough there are no remnants." + "\n                                                                                                                                                                       ");
            Lore2Description.Width.Set(280, 0);
            Lore2Description.Height.Set(40, 0);
            Lore2Description.Left.Set(10 - 20, 0);
            Lore2Description.Top.Set(612 - 336 - 92, 0);
            Lore2Description.BackgroundColor = Color.Transparent;
            Lore2Description.BorderColor = Color.Transparent;
            MrPlagueRaceStatDisplayBackground.Append(Lore2Description);

			RaceSelect = new UITextPanel<string>("View Race Information (page " + (RacePage + 1) + ")" + "\n                                                                                                                                                                       ");
			RaceSelect.Width.Set(1216, 0);
			RaceSelect.Height.Set(40, 0);
			RaceSelect.Left.Set(350 - 362 - 10, 0);
			RaceSelect.Top.Set(20 - 34 + 1, 0);
			RaceSelect.BackgroundColor = Color.Transparent;
			RaceSelect.BorderColor = Color.Transparent;
			MrPlagueRaceInformationMenuBackground.Append(RaceSelect);

			RaceNameDisplay = new UITextPanel<string>("Human");
            RaceNameDisplay.Width.Set(300, 0);
            RaceNameDisplay.Height.Set(40, 0);
            RaceNameDisplay.Left.Set(5 + 16 - 13 + 2 - 22, 0);
            RaceNameDisplay.Top.Set(80 - 92, 0);
            RaceNameDisplay.BackgroundColor = Color.Transparent;
            RaceNameDisplay.BorderColor = Color.Transparent;
            MrPlagueRaceStatDisplayBackground.Append(RaceNameDisplay);

			DisplayHealth = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayHealth.Width.Set(64, 0);
			DisplayHealth.Height.Set(20, 0);
			DisplayHealth.Left.Set(10 + 20 - 22  - 10 + 7, 0);
            DisplayHealth.Top.Set(-10 + 279 + 132 - 90 + 999999, 0);
			DisplayHealth.BackgroundColor = Color.Transparent;
			DisplayHealth.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayHealth);

			DisplayRegeneration = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayRegeneration.Width.Set(64, 0);
			DisplayRegeneration.Height.Set(20, 0);
			DisplayRegeneration.Left.Set(10 + 20 - 22 + 72  - 10 + 7, 0);
            DisplayRegeneration.Top.Set(-10 + 279 + 132 - 90 + 999999, 0);
			DisplayRegeneration.BackgroundColor = Color.Transparent;
			DisplayRegeneration.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayRegeneration);

			DisplayMana = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayMana.Width.Set(64, 0);
			DisplayMana.Height.Set(20, 0);
			DisplayMana.Left.Set(10 + 20 - 22 + 72 + 72  - 10 + 7, 0);
            DisplayMana.Top.Set(-10 + 279 + 132 - 90 + 999999, 0);
			DisplayMana.BackgroundColor = Color.Transparent;
			DisplayMana.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayMana);

			DisplayManaRegeneration = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayManaRegeneration.Width.Set(64, 0);
			DisplayManaRegeneration.Height.Set(20, 0);
			DisplayManaRegeneration.Left.Set(10 + 20 - 22 + 72 + 72 + 72  - 10 + 7, 0);
            DisplayManaRegeneration.Top.Set(-10 + 279 + 132 - 90 + 999999, 0);
			DisplayManaRegeneration.BackgroundColor = Color.Transparent;
			DisplayManaRegeneration.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayManaRegeneration);

			DisplayDefense = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayDefense.Width.Set(64, 0);
			DisplayDefense.Height.Set(20, 0);
			DisplayDefense.Left.Set(10 + 20 - 22  - 10 + 7, 0);
            DisplayDefense.Top.Set(-10 + 279 + 28 + 132 - 90 + 999999, 0);
			DisplayDefense.BackgroundColor = Color.Transparent;
			DisplayDefense.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayDefense);

			DisplayDamageReduction = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayDamageReduction.Width.Set(64, 0);
			DisplayDamageReduction.Height.Set(20, 0);
			DisplayDamageReduction.Left.Set(10 + 20 - 22 + 72  - 10 + 7, 0);
            DisplayDamageReduction.Top.Set(-10 + 279 + 28 + 132 - 90 + 999999, 0);
			DisplayDamageReduction.BackgroundColor = Color.Transparent;
			DisplayDamageReduction.BorderColor = Color.Transparent;
            MrPlagueRaceStatDisplayBackground.Append(DisplayDamageReduction);

			DisplayThorns = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayThorns.Width.Set(64, 0);
			DisplayThorns.Height.Set(20, 0);
			DisplayThorns.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
			DisplayThorns.Top.Set(-10 + 279 + 28 + 132 - 90 + 999999, 0);
			DisplayThorns.BackgroundColor = Color.Transparent;
			DisplayThorns.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayThorns);

			DisplayLavaResistance = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayLavaResistance.Width.Set(64, 0);
			DisplayLavaResistance.Height.Set(20, 0);
			DisplayLavaResistance.Left.Set(10 + 20 - 22 + 72 + 72 + 72  - 10 + 7, 0);
            DisplayLavaResistance.Top.Set(-10 + 279 + 28 + 132 - 90 + 999999, 0);
			DisplayLavaResistance.BackgroundColor = Color.Transparent;
			DisplayLavaResistance.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayLavaResistance);

			DisplayMeleeDamage = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayMeleeDamage.Width.Set(64, 0);
			DisplayMeleeDamage.Height.Set(20, 0);
			DisplayMeleeDamage.Left.Set(10 + 20 - 22  - 10 + 7, 0);
            DisplayMeleeDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayMeleeDamage.BackgroundColor = Color.Transparent;
			DisplayMeleeDamage.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayMeleeDamage);

			DisplayRangedDamage = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayRangedDamage.Width.Set(64, 0);
			DisplayRangedDamage.Height.Set(20, 0);
			DisplayRangedDamage.Left.Set(10 + 20 - 22 + 72  - 10 + 7, 0);
            DisplayRangedDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayRangedDamage.BackgroundColor = Color.Transparent;
			DisplayRangedDamage.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayRangedDamage);

			DisplayMagicDamage = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayMagicDamage.Width.Set(64, 0);
			DisplayMagicDamage.Height.Set(20, 0);
			DisplayMagicDamage.Left.Set(10 + 20 - 22 + 72 + 72  - 10 + 7, 0);
            DisplayMagicDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayMagicDamage.BackgroundColor = Color.Transparent;
			DisplayMagicDamage.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayMagicDamage);

			DisplaySummonDamage = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplaySummonDamage.Width.Set(64, 0);
			DisplaySummonDamage.Height.Set(20, 0);
			DisplaySummonDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72  - 10 + 7, 0);
            DisplaySummonDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplaySummonDamage.BackgroundColor = Color.Transparent;
			DisplaySummonDamage.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplaySummonDamage);

			DisplayMeleeSpeed = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayMeleeSpeed.Width.Set(64, 0);
			DisplayMeleeSpeed.Height.Set(20, 0);
			DisplayMeleeSpeed.Left.Set(10 + 20 - 22  - 10 + 7, 0);
            DisplayMeleeSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayMeleeSpeed.BackgroundColor = Color.Transparent;
			DisplayMeleeSpeed.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayMeleeSpeed);

			DisplayArmorPenetration = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayArmorPenetration.Width.Set(64, 0);
			DisplayArmorPenetration.Height.Set(20, 0);
			DisplayArmorPenetration.Left.Set(10 + 20 - 22 + 72  - 10 + 7, 0);
            DisplayArmorPenetration.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayArmorPenetration.BackgroundColor = Color.Transparent;
			DisplayArmorPenetration.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayArmorPenetration);

			DisplayBulletDamage = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayBulletDamage.Width.Set(64, 0);
			DisplayBulletDamage.Height.Set(20, 0);
			DisplayBulletDamage.Left.Set(10 + 20 - 22 + 72 + 72  - 10 + 7, 0);
            DisplayBulletDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayBulletDamage.BackgroundColor = Color.Transparent;
			DisplayBulletDamage.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayBulletDamage);

			DisplayRocketDamage = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayRocketDamage.Width.Set(64, 0);
			DisplayRocketDamage.Height.Set(20, 0);
			DisplayRocketDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72  - 10 + 7, 0);
            DisplayRocketDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayRocketDamage.BackgroundColor = Color.Transparent;
			DisplayRocketDamage.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayRocketDamage);

			DisplayManaCost = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayManaCost.Width.Set(64, 0);
			DisplayManaCost.Height.Set(20, 0);
			DisplayManaCost.Left.Set(10 + 20 - 22  - 10 + 7, 0);
            DisplayManaCost.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayManaCost.BackgroundColor = Color.Transparent;
			DisplayManaCost.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayManaCost);

			DisplayMinionKnockback = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayMinionKnockback.Width.Set(64, 0);
			DisplayMinionKnockback.Height.Set(20, 0);
			DisplayMinionKnockback.Left.Set(10 + 20 - 22 + 72  - 10 + 7, 0);
            DisplayMinionKnockback.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayMinionKnockback.BackgroundColor = Color.Transparent;
			DisplayMinionKnockback.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayMinionKnockback);

			DisplayMinions = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayMinions.Width.Set(64, 0);
			DisplayMinions.Height.Set(20, 0);
			DisplayMinions.Left.Set(10 + 20 - 22 + 72 + 72  - 10 + 7, 0);
            DisplayMinions.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayMinions.BackgroundColor = Color.Transparent;
			DisplayMinions.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayMinions);

			DisplaySentries = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplaySentries.Width.Set(64, 0);
			DisplaySentries.Height.Set(20, 0);
			DisplaySentries.Left.Set(10 + 20 - 22 + 72 + 72 + 72  - 10 + 7, 0);
            DisplaySentries.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplaySentries.BackgroundColor = Color.Transparent;
			DisplaySentries.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplaySentries);

			DisplayMeleeCritChance = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayMeleeCritChance.Width.Set(64, 0);
			DisplayMeleeCritChance.Height.Set(20, 0);
			DisplayMeleeCritChance.Left.Set(10 + 20 - 22  - 10 + 7, 0);
            DisplayMeleeCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayMeleeCritChance.BackgroundColor = Color.Transparent;
			DisplayMeleeCritChance.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayMeleeCritChance);

			DisplayRangedCritChance = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayRangedCritChance.Width.Set(64, 0);
			DisplayRangedCritChance.Height.Set(20, 0);
			DisplayRangedCritChance.Left.Set(10 + 20 - 22 + 72  - 10 + 7, 0);
            DisplayRangedCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayRangedCritChance.BackgroundColor = Color.Transparent;
			DisplayRangedCritChance.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayRangedCritChance);

			DisplayMagicCritChance = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayMagicCritChance.Width.Set(64, 0);
			DisplayMagicCritChance.Height.Set(20, 0);
			DisplayMagicCritChance.Left.Set(10 + 20 - 22 + 72 + 72  - 10 + 7, 0);
            DisplayMagicCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayMagicCritChance.BackgroundColor = Color.Transparent;
			DisplayMagicCritChance.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayMagicCritChance);

			DisplayMiningSpeed = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayMiningSpeed.Width.Set(64, 0);
			DisplayMiningSpeed.Height.Set(20, 0);
			DisplayMiningSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72  - 10 + 7, 0);
            DisplayMiningSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayMiningSpeed.BackgroundColor = Color.Transparent;
			DisplayMiningSpeed.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayMiningSpeed);

			DisplayBuildingSpeed = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayBuildingSpeed.Width.Set(64, 0);
			DisplayBuildingSpeed.Height.Set(20, 0);
			DisplayBuildingSpeed.Left.Set(10 + 20 - 22  - 10 + 7, 0);
            DisplayBuildingSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayBuildingSpeed.BackgroundColor = Color.Transparent;
			DisplayBuildingSpeed.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayBuildingSpeed);

			DisplayBuildingWallSpeed = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayBuildingWallSpeed.Width.Set(64, 0);
			DisplayBuildingWallSpeed.Height.Set(20, 0);
			DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 + 72  - 10 + 7, 0);
            DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayBuildingWallSpeed.BackgroundColor = Color.Transparent;
			DisplayBuildingWallSpeed.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayBuildingWallSpeed);

			DisplayBuildingRange = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayBuildingRange.Width.Set(64, 0);
			DisplayBuildingRange.Height.Set(20, 0);
			DisplayBuildingRange.Left.Set(10 + 20 - 22 + 72 + 72  - 10 + 7, 0);
            DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayBuildingRange.BackgroundColor = Color.Transparent;
			DisplayBuildingRange.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayBuildingRange);

			DisplayArrowDamage = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayArrowDamage.Width.Set(64, 0);
			DisplayArrowDamage.Height.Set(20, 0);
			DisplayArrowDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
			DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayArrowDamage.BackgroundColor = Color.Transparent;
			DisplayArrowDamage.BorderColor = Color.Transparent;
            MrPlagueRaceStatDisplayBackground.Append(DisplayArrowDamage);

			DisplayMovementSpeed = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayMovementSpeed.Width.Set(64, 0);
			DisplayMovementSpeed.Height.Set(20, 0);
			DisplayMovementSpeed.Left.Set(10 + 20 - 22  - 10 + 7, 0);
            DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayMovementSpeed.BackgroundColor = Color.Transparent;
			DisplayMovementSpeed.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayMovementSpeed);

			DisplayJumpSpeed = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayJumpSpeed.Width.Set(64, 0);
			DisplayJumpSpeed.Height.Set(20, 0);
			DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72  - 10 + 7, 0);
            DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayJumpSpeed.BackgroundColor = Color.Transparent;
			DisplayJumpSpeed.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayJumpSpeed);

			DisplayFallDamageResistance = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayFallDamageResistance.Width.Set(64, 0);
			DisplayFallDamageResistance.Height.Set(20, 0);
			DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 + 72  - 10 + 7, 0);
            DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayFallDamageResistance.BackgroundColor = Color.Transparent;
			DisplayFallDamageResistance.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayFallDamageResistance);

			DisplayAllDamage = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayAllDamage.Width.Set(64, 0);
			DisplayAllDamage.Height.Set(20, 0);
			DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72  - 10 + 7, 0);
            DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayAllDamage.BackgroundColor = Color.Transparent;
			DisplayAllDamage.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayAllDamage);

			DisplayFishingSkill = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayFishingSkill.Width.Set(64, 0);
			DisplayFishingSkill.Height.Set(20, 0);
			DisplayFishingSkill.Left.Set(10 + 20 - 22  - 10 + 7, 0);
            DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayFishingSkill.BackgroundColor = Color.Transparent;
			DisplayFishingSkill.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayFishingSkill);

			DisplayAggro = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayAggro.Width.Set(64, 0);
			DisplayAggro.Height.Set(20, 0);
			DisplayAggro.Left.Set(10 + 20 - 22 + 72  - 10 + 7, 0);
            DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayAggro.BackgroundColor = Color.Transparent;
			DisplayAggro.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayAggro);

			DisplayRunSpeed = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayRunSpeed.Width.Set(64, 0);
			DisplayRunSpeed.Height.Set(20, 0);
			DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 + 72  - 10 + 7, 0);
            DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayRunSpeed.BackgroundColor = Color.Transparent;
			DisplayRunSpeed.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayRunSpeed);

			DisplayRunAcceleration = new UITextPanel<string>("" + "\n                                          ", 0.8f);
			DisplayRunAcceleration.Width.Set(64, 0);
			DisplayRunAcceleration.Height.Set(20, 0);
			DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 + 72 + 72  - 10 + 7, 0);
            DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90 + 999999, 0);
			DisplayRunAcceleration.BackgroundColor = Color.Transparent;
			DisplayRunAcceleration.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayRunAcceleration);

			DisplayGoodBiomes = new UITextPanel<string>("None" + "\n                                          ", 0.8f);
			DisplayGoodBiomes.Width.Set(280, 0);
			DisplayGoodBiomes.Height.Set(26, 0);
			DisplayGoodBiomes.Left.Set(15 + 20 - 22 - 10, 0);
            DisplayGoodBiomes.Top.Set(-6 + 539 + 132 - 92 - 260 + 2, 0);
			DisplayGoodBiomes.BackgroundColor = Color.Transparent;
			DisplayGoodBiomes.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayGoodBiomes);

			DisplayBadBiomes = new UITextPanel<string>("None" + "\n                                          ", 0.8f);
			DisplayBadBiomes.Width.Set(280, 0);
			DisplayBadBiomes.Height.Set(26, 0);
			DisplayBadBiomes.Left.Set(15 + 20 - 22 - 10, 0);
			DisplayBadBiomes.Top.Set(-6 + 539 + 34 + 132 - 92 - 260 + 2, 0);
			DisplayBadBiomes.BackgroundColor = Color.Transparent;
			DisplayBadBiomes.BorderColor = Color.Transparent;
			MrPlagueRaceStatDisplayBackground.Append(DisplayBadBiomes);

            Texture2D UI_RaceSelectButtonIcon = GetTexture("MrPlagueRaces/Common/UI/UI_RaceSelectButton");
			Texture2D UI_RaceSelectButton_ActiveIcon = GetTexture("MrPlagueRaces/Common/UI/UI_RaceSelectButton_Active");
			MrPlagueRaceSelectButton UI_RaceSelectButton1 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton1.Width.Set(64, 0);
			UI_RaceSelectButton1.Height.Set(56, 0);
			UI_RaceSelectButton1.Left.Set(20 - 22, 0);
            UI_RaceSelectButton1.Top.Set(129 - 124 + 120 - 92, 0);
			UI_RaceSelectButton1.OnClick += new MouseEvent(Select_RaceSelectButton1);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton1);

			MrPlagueRaceSelectButton UI_RaceSelectButton2 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton2.Width.Set(64, 0);
			UI_RaceSelectButton2.Height.Set(56, 0);
			UI_RaceSelectButton2.Left.Set(20 - 22 + 72, 0);
            UI_RaceSelectButton2.Top.Set(129 - 124 + 120 - 92, 0);
			UI_RaceSelectButton2.OnClick += new MouseEvent(Select_RaceSelectButton2);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton2);

			MrPlagueRaceSelectButton UI_RaceSelectButton3 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton3.Width.Set(64, 0);
			UI_RaceSelectButton3.Height.Set(56, 0);
			UI_RaceSelectButton3.Left.Set(20 - 22 + 72 + 72, 0);
            UI_RaceSelectButton3.Top.Set(129 - 124 + 120 - 92, 0);
			UI_RaceSelectButton3.OnClick += new MouseEvent(Select_RaceSelectButton3);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton3);

			MrPlagueRaceSelectButton UI_RaceSelectButton4 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton4.Width.Set(64, 0);
			UI_RaceSelectButton4.Height.Set(56, 0);
			UI_RaceSelectButton4.Left.Set(20 - 22 + 72 + 72 + 72, 0);
            UI_RaceSelectButton4.Top.Set(129 - 124 + 120 - 92, 0);
			UI_RaceSelectButton4.OnClick += new MouseEvent(Select_RaceSelectButton4);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton4);

			MrPlagueRaceSelectButton UI_RaceSelectButton5 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton5.Width.Set(64, 0);
			UI_RaceSelectButton5.Height.Set(56, 0);
			UI_RaceSelectButton5.Left.Set(20 - 22 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton5.Top.Set(129 - 124 + 120 - 92, 0);
			UI_RaceSelectButton5.OnClick += new MouseEvent(Select_RaceSelectButton5);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton5);

			MrPlagueRaceSelectButton UI_RaceSelectButton6 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton6.Width.Set(64, 0);
			UI_RaceSelectButton6.Height.Set(56, 0);
			UI_RaceSelectButton6.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton6.Top.Set(129 - 124 + 120 - 92, 0);
			UI_RaceSelectButton6.OnClick += new MouseEvent(Select_RaceSelectButton6);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton6);

			MrPlagueRaceSelectButton UI_RaceSelectButton7 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton7.Width.Set(64, 0);
			UI_RaceSelectButton7.Height.Set(56, 0);
			UI_RaceSelectButton7.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton7.Top.Set(129 - 124 + 120 - 92, 0);
			UI_RaceSelectButton7.OnClick += new MouseEvent(Select_RaceSelectButton7);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton7);

			MrPlagueRaceSelectButton UI_RaceSelectButton8 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton8.Width.Set(64, 0);
			UI_RaceSelectButton8.Height.Set(56, 0);
			UI_RaceSelectButton8.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton8.Top.Set(129 - 124 + 120 - 92, 0);
			UI_RaceSelectButton8.OnClick += new MouseEvent(Select_RaceSelectButton8);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton8);

			MrPlagueRaceSelectButton UI_RaceSelectButton9 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton9.Width.Set(64, 0);
			UI_RaceSelectButton9.Height.Set(56, 0);
			UI_RaceSelectButton9.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton9.Top.Set(129 - 124 + 120 - 92, 0);
			UI_RaceSelectButton9.OnClick += new MouseEvent(Select_RaceSelectButton9);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton9);

			MrPlagueRaceSelectButton UI_RaceSelectButton10 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton10.Width.Set(64, 0);
			UI_RaceSelectButton10.Height.Set(56, 0);
			UI_RaceSelectButton10.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton10.Top.Set(129 - 124 + 120 - 92, 0);
			UI_RaceSelectButton10.OnClick += new MouseEvent(Select_RaceSelectButton10);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton10);

			MrPlagueRaceSelectButton UI_RaceSelectButton11 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton11.Width.Set(64, 0);
			UI_RaceSelectButton11.Height.Set(56, 0);
			UI_RaceSelectButton11.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton11.Top.Set(129 - 124 + 120 - 92, 0);
			UI_RaceSelectButton11.OnClick += new MouseEvent(Select_RaceSelectButton11);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton11);

			MrPlagueRaceSelectButton UI_RaceSelectButton12 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton12.Width.Set(64, 0);
			UI_RaceSelectButton12.Height.Set(56, 0);
			UI_RaceSelectButton12.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton12.Top.Set(129 - 124 + 120 - 92, 0);
			UI_RaceSelectButton12.OnClick += new MouseEvent(Select_RaceSelectButton12);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton12);

			MrPlagueRaceSelectButton UI_RaceSelectButton13 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton13.Width.Set(64, 0);
			UI_RaceSelectButton13.Height.Set(56, 0);
			UI_RaceSelectButton13.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton13.Top.Set(129 - 124 + 120 - 92, 0);
			UI_RaceSelectButton13.OnClick += new MouseEvent(Select_RaceSelectButton13);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton13);


			MrPlagueRaceSelectButton UI_RaceSelectButton14 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton14.Width.Set(64, 0);
			UI_RaceSelectButton14.Height.Set(56, 0);
			UI_RaceSelectButton14.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton14.Top.Set(129 - 124 + 120 - 92, 0);
			UI_RaceSelectButton14.OnClick += new MouseEvent(Select_RaceSelectButton14);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton14);

			MrPlagueRaceSelectButton UI_RaceSelectButton15 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton15.Width.Set(64, 0);
			UI_RaceSelectButton15.Height.Set(56, 0);
			UI_RaceSelectButton15.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton15.Top.Set(129 - 124 + 120 - 92, 0);
			UI_RaceSelectButton15.OnClick += new MouseEvent(Select_RaceSelectButton15);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton15);

			MrPlagueRaceSelectButton UI_RaceSelectButton16 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton16.Width.Set(64, 0);
			UI_RaceSelectButton16.Height.Set(56, 0);
			UI_RaceSelectButton16.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton16.Top.Set(129 - 124 + 120 - 92, 0);
			UI_RaceSelectButton16.OnClick += new MouseEvent(Select_RaceSelectButton16);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton16);

			MrPlagueRaceSelectButton UI_RaceSelectButton17 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton17.Width.Set(64, 0);
			UI_RaceSelectButton17.Height.Set(56, 0);
			UI_RaceSelectButton17.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton17.Top.Set(129 - 124 + 120 - 92, 0);
			UI_RaceSelectButton17.OnClick += new MouseEvent(Select_RaceSelectButton17);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton17);

			MrPlagueRaceSelectButton UI_RaceSelectButton18 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton18.Width.Set(64, 0);
			UI_RaceSelectButton18.Height.Set(56, 0);
			UI_RaceSelectButton18.Left.Set(20 - 22, 0);
            UI_RaceSelectButton18.Top.Set(129 - 124 + 120 - 92 + 60, 0);
			UI_RaceSelectButton18.OnClick += new MouseEvent(Select_RaceSelectButton18);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton18);

			MrPlagueRaceSelectButton UI_RaceSelectButton19 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton19.Width.Set(64, 0);
			UI_RaceSelectButton19.Height.Set(56, 0);
			UI_RaceSelectButton19.Left.Set(20 - 22 + 72, 0);
            UI_RaceSelectButton19.Top.Set(129 - 124 + 120 - 92 + 60, 0);
			UI_RaceSelectButton19.OnClick += new MouseEvent(Select_RaceSelectButton19);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton19);

			MrPlagueRaceSelectButton UI_RaceSelectButton20 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton20.Width.Set(64, 0);
			UI_RaceSelectButton20.Height.Set(56, 0);
			UI_RaceSelectButton20.Left.Set(20 - 22 + 72 + 72, 0);
            UI_RaceSelectButton20.Top.Set(129 - 124 + 120 - 92 + 60, 0);
			UI_RaceSelectButton20.OnClick += new MouseEvent(Select_RaceSelectButton20);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton20);

			MrPlagueRaceSelectButton UI_RaceSelectButton21 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton21.Width.Set(64, 0);
			UI_RaceSelectButton21.Height.Set(56, 0);
			UI_RaceSelectButton21.Left.Set(20 - 22 + 72 + 72 + 72, 0);
            UI_RaceSelectButton21.Top.Set(129 - 124 + 120 - 92 + 60, 0);
			UI_RaceSelectButton21.OnClick += new MouseEvent(Select_RaceSelectButton21);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton21);

			MrPlagueRaceSelectButton UI_RaceSelectButton22 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton22.Width.Set(64, 0);
			UI_RaceSelectButton22.Height.Set(56, 0);
			UI_RaceSelectButton22.Left.Set(20 - 22 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton22.Top.Set(129 - 124 + 120 - 92 + 60, 0);
			UI_RaceSelectButton22.OnClick += new MouseEvent(Select_RaceSelectButton22);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton22);

			MrPlagueRaceSelectButton UI_RaceSelectButton23 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton23.Width.Set(64, 0);
			UI_RaceSelectButton23.Height.Set(56, 0);
			UI_RaceSelectButton23.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton23.Top.Set(129 - 124 + 120 - 92 + 60, 0);
			UI_RaceSelectButton23.OnClick += new MouseEvent(Select_RaceSelectButton23);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton23);

			MrPlagueRaceSelectButton UI_RaceSelectButton24 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton24.Width.Set(64, 0);
			UI_RaceSelectButton24.Height.Set(56, 0);
			UI_RaceSelectButton24.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton24.Top.Set(129 - 124 + 120 - 92 + 60, 0);
			UI_RaceSelectButton24.OnClick += new MouseEvent(Select_RaceSelectButton24);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton24);

			MrPlagueRaceSelectButton UI_RaceSelectButton25 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton25.Width.Set(64, 0);
			UI_RaceSelectButton25.Height.Set(56, 0);
			UI_RaceSelectButton25.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton25.Top.Set(129 - 124 + 120 - 92 + 60, 0);
			UI_RaceSelectButton25.OnClick += new MouseEvent(Select_RaceSelectButton25);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton25);

			MrPlagueRaceSelectButton UI_RaceSelectButton26 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton26.Width.Set(64, 0);
			UI_RaceSelectButton26.Height.Set(56, 0);
			UI_RaceSelectButton26.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton26.Top.Set(129 - 124 + 120 - 92 + 60, 0);
			UI_RaceSelectButton26.OnClick += new MouseEvent(Select_RaceSelectButton26);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton26);

			MrPlagueRaceSelectButton UI_RaceSelectButton27 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton27.Width.Set(64, 0);
			UI_RaceSelectButton27.Height.Set(56, 0);
			UI_RaceSelectButton27.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton27.Top.Set(129 - 124 + 120 - 92 + 60, 0);
			UI_RaceSelectButton27.OnClick += new MouseEvent(Select_RaceSelectButton27);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton27);

			MrPlagueRaceSelectButton UI_RaceSelectButton28 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton28.Width.Set(64, 0);
			UI_RaceSelectButton28.Height.Set(56, 0);
			UI_RaceSelectButton28.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton28.Top.Set(129 - 124 + 120 - 92 + 60, 0);
			UI_RaceSelectButton28.OnClick += new MouseEvent(Select_RaceSelectButton28);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton28);

			MrPlagueRaceSelectButton UI_RaceSelectButton29 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton29.Width.Set(64, 0);
			UI_RaceSelectButton29.Height.Set(56, 0);
			UI_RaceSelectButton29.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton29.Top.Set(129 - 124 + 120 - 92 + 60, 0);
			UI_RaceSelectButton29.OnClick += new MouseEvent(Select_RaceSelectButton29);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton29);

			MrPlagueRaceSelectButton UI_RaceSelectButton30 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton30.Width.Set(64, 0);
			UI_RaceSelectButton30.Height.Set(56, 0);
			UI_RaceSelectButton30.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton30.Top.Set(129 - 124 + 120 - 92 + 60, 0);
			UI_RaceSelectButton30.OnClick += new MouseEvent(Select_RaceSelectButton30);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton30);


			MrPlagueRaceSelectButton UI_RaceSelectButton31 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton31.Width.Set(64, 0);
			UI_RaceSelectButton31.Height.Set(56, 0);
			UI_RaceSelectButton31.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton31.Top.Set(129 - 124 + 120 - 92 + 60, 0);
			UI_RaceSelectButton31.OnClick += new MouseEvent(Select_RaceSelectButton31);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton31);

			MrPlagueRaceSelectButton UI_RaceSelectButton32 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton32.Width.Set(64, 0);
			UI_RaceSelectButton32.Height.Set(56, 0);
			UI_RaceSelectButton32.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton32.Top.Set(129 - 124 + 120 - 92 + 60, 0);
			UI_RaceSelectButton32.OnClick += new MouseEvent(Select_RaceSelectButton32);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton32);

			MrPlagueRaceSelectButton UI_RaceSelectButton33 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton33.Width.Set(64, 0);
			UI_RaceSelectButton33.Height.Set(56, 0);
			UI_RaceSelectButton33.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton33.Top.Set(129 - 124 + 120 - 92 + 60, 0);
			UI_RaceSelectButton33.OnClick += new MouseEvent(Select_RaceSelectButton33);
			MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton33);

			MrPlagueRaceSelectButton UI_RaceSelectButton34 = new MrPlagueRaceSelectButton(UI_RaceSelectButtonIcon, UI_RaceSelectButton_ActiveIcon);
			UI_RaceSelectButton34.Width.Set(64, 0);
			UI_RaceSelectButton34.Height.Set(56, 0);
			UI_RaceSelectButton34.Left.Set(20 - 22 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72 + 72, 0);
            UI_RaceSelectButton34.Top.Set(129 - 124 + 120 - 92 + 60, 0);
			UI_RaceSelectButton34.OnClick += new MouseEvent(Select_RaceSelectButton34);
            MrPlagueRaceInformationMenuBackground.Append(UI_RaceSelectButton34);
		}

		private void FadedMouseOver(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
            ((UIPanel)evt.Target).BackgroundColor = new Color(73, 94, 171);
		}

        private void FadedMouseOut(UIMouseEvent evt, UIElement listeningElement)
        {
            ((UIPanel)evt.Target).BackgroundColor = new Color(63, 82, 151) * 0.7f;
		}

		public void UI_ButtonPrevious_Clicked(UIMouseEvent mouseEvent, UIElement targetElement)
		{
            if (RacePage >= 1)
            {
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RacePage -= 1;
            }
            else
            {
				RacePage = 0;
            }
		}

        public void UI_ButtonNext_Clicked(UIMouseEvent mouseEvent, UIElement targetElement)
        {
            Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
			RacePage += 1;
		}

        public void UI_ButtonRandom_Clicked(UIMouseEvent mouseEvent, UIElement targetElement)
        {
            Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
            RaceIndex = Main.rand.Next((RaceLoader.Races.Count - 1));
		}

        public void Select_RaceSelectButton1(UIMouseEvent mouseEvent, UIElement targetElement)
        {
            
            if (RaceLoader.Races.Count > (0 + RacePage * 34))
            {
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (0 + (RacePage * 34));
            }
        }

        public void Select_RaceSelectButton2(UIMouseEvent mouseEvent, UIElement targetElement)
        {
            
            if (RaceLoader.Races.Count > (1 + RacePage * 34))
            {
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (1 + (RacePage * 34));
            }
        }

		public void Select_RaceSelectButton3(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (2 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (2 + (RacePage * 34));
			}
		}

        public void Select_RaceSelectButton4(UIMouseEvent mouseEvent, UIElement targetElement)
        {
            
            if (RaceLoader.Races.Count > (3 + RacePage * 34))
            {
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (3 + (RacePage * 34));
            }
        }

		public void Select_RaceSelectButton5(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (4 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (4 + (RacePage * 34));
			}
		}

		public void Select_RaceSelectButton6(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (5 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (5 + (RacePage * 34));
			}
		}

		public void Select_RaceSelectButton7(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (6 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (6 + (RacePage * 34));
			}
		}

        public void Select_RaceSelectButton8(UIMouseEvent mouseEvent, UIElement targetElement)
        {
            
            if (RaceLoader.Races.Count > (7 + RacePage * 34))
            {
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (7 + (RacePage * 34));
            }
        }

		public void Select_RaceSelectButton9(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (8 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (8 + (RacePage * 34));
			}
		}

		public void Select_RaceSelectButton10(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (9 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (9 + (RacePage * 34));
			}
		}

		public void Select_RaceSelectButton11(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (10 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (10 + (RacePage * 34));
			}
		}

		public void Select_RaceSelectButton12(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (11 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (11 + (RacePage * 34));
			}
		}

		public void Select_RaceSelectButton13(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (12 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (12 + (RacePage * 34));
			}
		}

		public void Select_RaceSelectButton14(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (13 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (13 + (RacePage * 34));
			}
		}

		public void Select_RaceSelectButton15(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (14 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (14 + (RacePage * 34));
			}
		}

        public void Select_RaceSelectButton16(UIMouseEvent mouseEvent, UIElement targetElement)
        {
            
            if (RaceLoader.Races.Count > (15 + RacePage * 34))
            {
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (15 + (RacePage * 34));
            }
        }


		public void Select_RaceSelectButton17(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (16 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (16 + (RacePage * 34));
			}
		}

		public void Select_RaceSelectButton18(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (17 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (17 + (RacePage * 34));
			}
		}

		public void Select_RaceSelectButton19(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (18 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (18 + (RacePage * 34));
			}
		}

		public void Select_RaceSelectButton20(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (19 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (19 + (RacePage * 34));
			}
		}

		public void Select_RaceSelectButton21(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (20 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (20 + (RacePage * 34));
			}
		}

		public void Select_RaceSelectButton22(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (21 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (21 + (RacePage * 34));
			}
		}

		public void Select_RaceSelectButton23(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (22 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (22 + (RacePage * 34));
			}
		}

		public void Select_RaceSelectButton24(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (23 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (23 + (RacePage * 34));
			}
		}

		public void Select_RaceSelectButton25(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (24 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (24 + (RacePage * 34));
			}
		}

		public void Select_RaceSelectButton26(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (25 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (25 + (RacePage * 34));
			}
		}

		public void Select_RaceSelectButton27(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (26 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (26 + (RacePage * 34));
			}
		}

		public void Select_RaceSelectButton28(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (27 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (27 + (RacePage * 34));
			}
		}

		public void Select_RaceSelectButton29(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (28 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (28 + (RacePage * 34));
			}
		}

		public void Select_RaceSelectButton30(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (29 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (29 + (RacePage * 34));
			}
		}

		public void Select_RaceSelectButton31(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			
			if (RaceLoader.Races.Count > (30 + RacePage * 34))
			{
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (30 + (RacePage * 34));
			}
		}

        public void Select_RaceSelectButton32(UIMouseEvent mouseEvent, UIElement targetElement)
        {
            
            if (RaceLoader.Races.Count > (31 + RacePage * 34))
            {
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (31 + (RacePage * 34));
            }
        }

        public void Select_RaceSelectButton33(UIMouseEvent mouseEvent, UIElement targetElement)
        {
            
            if (RaceLoader.Races.Count > (32 + RacePage * 34))
            {
				Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
				RaceIndex = (32 + (RacePage * 34));
            }
        }

        public void Select_RaceSelectButton34(UIMouseEvent mouseEvent, UIElement targetElement)
        {

            if (RaceLoader.Races.Count > (33 + RacePage * 34))
            {
                Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
                RaceIndex = (33 + (RacePage * 34));
            }
        }

		protected override void DrawChildren(SpriteBatch spriteBatch)
		{
			base.DrawChildren(spriteBatch);
            CalculatedStyle MrPlagueRaceInformationMenuInnerDimension = MrPlagueRaceInformationMenuBackground.GetInnerDimensions();
            CalculatedStyle MrPlagueRaceStatDisplayInnerDimension = MrPlagueRaceStatDisplayBackground.GetInnerDimensions();
			var RaceEnvironmentImageIcon = UI_RaceEnvironmentImageIcon();
			var RaceEnvironmentOverlay1ImageIcon = UI_RaceEnvironmentOverlay1ImageIcon();
			var RaceEnvironmentOverlay2ImageIcon = UI_RaceEnvironmentOverlay2ImageIcon();
			var RaceDisplayMaleImageIcon = UI_RaceDisplayMaleImageIcon();
			var RaceDisplayFemaleImageIcon = UI_RaceDisplayFemaleImageIcon();
			var RaceSelectImageIcon1 = UI_RaceSelectImageIcon1();
			var RaceSelectImageIcon2 = UI_RaceSelectImageIcon2();
			var RaceSelectImageIcon3 = UI_RaceSelectImageIcon3();
			var RaceSelectImageIcon4 = UI_RaceSelectImageIcon4();
			var RaceSelectImageIcon5 = UI_RaceSelectImageIcon5();
			var RaceSelectImageIcon6 = UI_RaceSelectImageIcon6();
			var RaceSelectImageIcon7 = UI_RaceSelectImageIcon7();
			var RaceSelectImageIcon8 = UI_RaceSelectImageIcon8();
			var RaceSelectImageIcon9 = UI_RaceSelectImageIcon9();
			var RaceSelectImageIcon10 = UI_RaceSelectImageIcon10();
			var RaceSelectImageIcon11 = UI_RaceSelectImageIcon11();
			var RaceSelectImageIcon12 = UI_RaceSelectImageIcon12();
			var RaceSelectImageIcon13 = UI_RaceSelectImageIcon13();
			var RaceSelectImageIcon14 = UI_RaceSelectImageIcon14();
			var RaceSelectImageIcon15 = UI_RaceSelectImageIcon15();
			var RaceSelectImageIcon16 = UI_RaceSelectImageIcon16();
			var RaceSelectImageIcon17 = UI_RaceSelectImageIcon17();
			var RaceSelectImageIcon18 = UI_RaceSelectImageIcon18();
			var RaceSelectImageIcon19 = UI_RaceSelectImageIcon19();
			var RaceSelectImageIcon20 = UI_RaceSelectImageIcon20();
			var RaceSelectImageIcon21 = UI_RaceSelectImageIcon21();
			var RaceSelectImageIcon22 = UI_RaceSelectImageIcon22();
			var RaceSelectImageIcon23 = UI_RaceSelectImageIcon23();
			var RaceSelectImageIcon24 = UI_RaceSelectImageIcon24();
			var RaceSelectImageIcon25 = UI_RaceSelectImageIcon25();
			var RaceSelectImageIcon26 = UI_RaceSelectImageIcon26();
			var RaceSelectImageIcon27 = UI_RaceSelectImageIcon27();
			var RaceSelectImageIcon28 = UI_RaceSelectImageIcon28();
			var RaceSelectImageIcon29 = UI_RaceSelectImageIcon29();
			var RaceSelectImageIcon30 = UI_RaceSelectImageIcon30();
			var RaceSelectImageIcon31 = UI_RaceSelectImageIcon31();
			var RaceSelectImageIcon32 = UI_RaceSelectImageIcon32();
			var RaceSelectImageIcon33 = UI_RaceSelectImageIcon33();
			var RaceSelectImageIcon34 = UI_RaceSelectImageIcon34();

			Vector2 SelectButtonIconPosition = new Vector2(64 / 2 - RaceSelectImageIcon1.Width * 1f / 2,
				56 / 2 - UI_RaceSelectImageIcon1().Height * 1f / 2);
			Vector2 DisplayIconPosition = new Vector2(100 / 2 - RaceDisplayMaleImageIcon.Width * 1f / 2,
				138 / 2 - UI_RaceDisplayMaleImageIcon().Height * 1f / 2);
			if (RaceLoader.Races[RaceIndex].DarkenEnvironment)
			{
				spriteBatch.Draw(RaceEnvironmentImageIcon, new Vector2(MrPlagueRaceStatDisplayInnerDimension.X - 2f, MrPlagueRaceStatDisplayInnerDimension.Y + 33f) + DisplayIconPosition, null, new Color(100, 100, 100), 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			}
			else
			{
				spriteBatch.Draw(RaceEnvironmentImageIcon, new Vector2(MrPlagueRaceStatDisplayInnerDimension.X - 2f, MrPlagueRaceStatDisplayInnerDimension.Y + 33f) + DisplayIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			}
			spriteBatch.Draw(RaceEnvironmentOverlay1ImageIcon, new Vector2(MrPlagueRaceStatDisplayInnerDimension.X - 2f, MrPlagueRaceStatDisplayInnerDimension.Y + 33f) + DisplayIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceEnvironmentOverlay2ImageIcon, new Vector2(MrPlagueRaceStatDisplayInnerDimension.X - 2f, MrPlagueRaceStatDisplayInnerDimension.Y + 33f) + DisplayIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceDisplayMaleImageIcon, new Vector2(MrPlagueRaceStatDisplayInnerDimension.X - 2f, MrPlagueRaceStatDisplayInnerDimension.Y + 33f) + DisplayIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceDisplayFemaleImageIcon, new Vector2(MrPlagueRaceStatDisplayInnerDimension.X - 2f, MrPlagueRaceStatDisplayInnerDimension.Y + 33f) + DisplayIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon1, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            spriteBatch.Draw(RaceSelectImageIcon2, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            spriteBatch.Draw(RaceSelectImageIcon3, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon4, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon5, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon6, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon7, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon8, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon9, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon10, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon11, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon12, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon13, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon14, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon15, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon16, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            spriteBatch.Draw(RaceSelectImageIcon17, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon18, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f + 60f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon19, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f + 60f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon20, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f + 60f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon21, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f + 60f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon22, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f + 60f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon23, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f + 60f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon24, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f + 60f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon25, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f + 60f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon26, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f + 60f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon27, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f + 60f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon28, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f + 60f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon29, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f + 60f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon30, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f + 60f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon31, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f + 60f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon32, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f + 60f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			spriteBatch.Draw(RaceSelectImageIcon33, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f + 60f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
            spriteBatch.Draw(RaceSelectImageIcon34, new Vector2(MrPlagueRaceInformationMenuInnerDimension.X - 2f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f + 72f, MrPlagueRaceInformationMenuInnerDimension.Y + 33f + 60f) + SelectButtonIconPosition, null, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 1f);
		}

		public override void Update(GameTime gameTime)
		{
            base.Update(gameTime);
            var modPlayer = Main.LocalPlayer.GetModPlayer<MrPlagueRacesPlayer>();
            RaceLoader.Races[RaceIndex] = RaceLoader.Races[RaceIndex];
            if (RaceLoader.Races[RaceIndex].RaceDisplayName != null)
            {
                RaceNameDisplay.SetText(RaceLoader.Races[RaceIndex].RaceDisplayName);
            }
            else
            {
                RaceNameDisplay.SetText(RaceLoader.Races[RaceIndex].Name);
            }
			Rectangle InfoUIBoundary = new Rectangle(modPlayer.MrPlagueRaceInfoMouseX, modPlayer.MrPlagueRaceInfoMouseY, 1600, 800);
			if (InfoUIBoundary.Contains(Main.MouseScreen.ToPoint()))
			{
				IsBeingHoveredOver = true;
			}
			else
            {
				IsBeingHoveredOver = false;
			}
			RaceSelect.SetText("View Race Information (page " + (RacePage + 1) + ")" + "\n                                                                                                                                                                       ");
			Lore1Description.SetText(RaceLoader.Races[RaceIndex].RaceLore1 + "\n                                                                                                                                                                       ");
            Lore2Description.SetText(RaceLoader.Races[RaceIndex].RaceLore2 + "\n                                                                                                                                                                       ");
			Ability.SetText("Ability: " + RaceLoader.Races[RaceIndex].RaceAbilityName + "\n                                                                                                                                                                       ");
            AbilityDescription1.SetText(RaceLoader.Races[RaceIndex].RaceAbilityDescription1 + "\n                                                                                                                                                                       ");
            AbilityDescription2.SetText(RaceLoader.Races[RaceIndex].RaceAbilityDescription2 + "\n                                                                                                                                                                       ");
			AbilityDescription3.SetText(RaceLoader.Races[RaceIndex].RaceAbilityDescription3 + "\n                                                                                                                                                                       ");
			AbilityDescription4.SetText(RaceLoader.Races[RaceIndex].RaceAbilityDescription4 + "\n                                                                                                                                                                       ");
            AbilityDescription5.SetText(RaceLoader.Races[RaceIndex].RaceAbilityDescription5 + "\n                                                                                                                                                                       ");
			AbilityDescription6.SetText(RaceLoader.Races[RaceIndex].RaceAbilityDescription6 + "\n                                                                                                                                                                       ");
			AdditionalNotesDescription1.SetText(RaceLoader.Races[RaceIndex].RaceAdditionalNotesDescription1 + "\n                                                                                                                                                                       ");
			AdditionalNotesDescription2.SetText(RaceLoader.Races[RaceIndex].RaceAdditionalNotesDescription2 + "\n                                                                                                                                                                       ");
			AdditionalNotesDescription3.SetText(RaceLoader.Races[RaceIndex].RaceAdditionalNotesDescription3 + "\n                                                                                                                                                                       ");
			AdditionalNotesDescription4.SetText(RaceLoader.Races[RaceIndex].RaceAdditionalNotesDescription4 + "\n                                                                                                                                                                       ");
			AdditionalNotesDescription5.SetText(RaceLoader.Races[RaceIndex].RaceAdditionalNotesDescription5 + "\n                                                                                                                                                                       ");
			AdditionalNotesDescription6.SetText(RaceLoader.Races[RaceIndex].RaceAdditionalNotesDescription6 + "\n                                                                                                                                                                       ");
			DisplayHealth.SetText(RaceLoader.Races[RaceIndex].RaceHealthDisplayText);
			DisplayRegeneration.SetText(RaceLoader.Races[RaceIndex].RaceRegenerationDisplayText);
			DisplayMana.SetText(RaceLoader.Races[RaceIndex].RaceManaDisplayText);
			DisplayManaRegeneration.SetText(RaceLoader.Races[RaceIndex].RaceManaRegenerationDisplayText);
			DisplayDefense.SetText(RaceLoader.Races[RaceIndex].RaceDefenseDisplayText);
            DisplayDamageReduction.SetText(RaceLoader.Races[RaceIndex].RaceDamageReductionDisplayText);
			DisplayThorns.SetText(RaceLoader.Races[RaceIndex].RaceThornsDisplayText);
			DisplayLavaResistance.SetText(RaceLoader.Races[RaceIndex].RaceLavaResistanceDisplayText);
			DisplayMeleeDamage.SetText(RaceLoader.Races[RaceIndex].RaceMeleeDamageDisplayText);
			DisplayRangedDamage.SetText(RaceLoader.Races[RaceIndex].RaceRangedDamageDisplayText);
			DisplayMagicDamage.SetText(RaceLoader.Races[RaceIndex].RaceMagicDamageDisplayText);
			DisplaySummonDamage.SetText(RaceLoader.Races[RaceIndex].RaceSummonDamageDisplayText);
			DisplayMeleeSpeed.SetText(RaceLoader.Races[RaceIndex].RaceMeleeSpeedDisplayText);
			DisplayArmorPenetration.SetText(RaceLoader.Races[RaceIndex].RaceArmorPenetrationDisplayText);
			DisplayBulletDamage.SetText(RaceLoader.Races[RaceIndex].RaceBulletDamageDisplayText);
			DisplayRocketDamage.SetText(RaceLoader.Races[RaceIndex].RaceRocketDamageDisplayText);
			DisplayManaCost.SetText(RaceLoader.Races[RaceIndex].RaceManaCostDisplayText);
			DisplayMinionKnockback.SetText(RaceLoader.Races[RaceIndex].RaceMinionKnockbackDisplayText);
			DisplayMinions.SetText(RaceLoader.Races[RaceIndex].RaceMinionsDisplayText);
			DisplaySentries.SetText(RaceLoader.Races[RaceIndex].RaceSentriesDisplayText);
			DisplayMeleeCritChance.SetText(RaceLoader.Races[RaceIndex].RaceMeleeCritChanceDisplayText);
			DisplayRangedCritChance.SetText(RaceLoader.Races[RaceIndex].RaceRangedCritChanceDisplayText);
			DisplayMagicCritChance.SetText(RaceLoader.Races[RaceIndex].RaceMagicCritChanceDisplayText);
			DisplayMiningSpeed.SetText(RaceLoader.Races[RaceIndex].RaceMiningSpeedDisplayText);
			DisplayBuildingSpeed.SetText(RaceLoader.Races[RaceIndex].RaceBuildingSpeedDisplayText);
            DisplayBuildingWallSpeed.SetText(RaceLoader.Races[RaceIndex].RaceBuildingWallSpeedDisplayText);
            DisplayBuildingRange.SetText(RaceLoader.Races[RaceIndex].RaceBuildingRangeDisplayText);
			DisplayArrowDamage.SetText(RaceLoader.Races[RaceIndex].RaceArrowDamageDisplayText);
			DisplayMovementSpeed.SetText(RaceLoader.Races[RaceIndex].RaceMovementSpeedDisplayText);
			DisplayJumpSpeed.SetText(RaceLoader.Races[RaceIndex].RaceJumpSpeedDisplayText);
            DisplayFallDamageResistance.SetText(RaceLoader.Races[RaceIndex].RaceFallDamageResistanceDisplayText);
			DisplayAllDamage.SetText(RaceLoader.Races[RaceIndex].RaceAllDamageDisplayText);
			DisplayFishingSkill.SetText(RaceLoader.Races[RaceIndex].RaceFishingSkillDisplayText);
            DisplayAggro.SetText(RaceLoader.Races[RaceIndex].RaceAggroDisplayText);
			DisplayRunSpeed.SetText(RaceLoader.Races[RaceIndex].RaceRunSpeedDisplayText);
            DisplayRunAcceleration.SetText(RaceLoader.Races[RaceIndex].RaceRunAccelerationDisplayText);
			DisplayGoodBiomes.SetText(RaceLoader.Races[RaceIndex].RaceGoodBiomesDisplayText + "\n                                          ");
			DisplayBadBiomes.SetText(RaceLoader.Races[RaceIndex].RaceBadBiomesDisplayText + "\n                                          ");
			RaceStatAmount = 0;

			StatPosition1Taken = false;
			StatPosition2Taken = false;
			StatPosition3Taken = false;
			StatPosition4Taken = false;
			StatPosition5Taken = false;
			StatPosition6Taken = false;
			StatPosition7Taken = false;
			StatPosition8Taken = false;
			StatPosition9Taken = false;
			StatPosition10Taken = false;
			StatPosition11Taken = false;
			StatPosition12Taken = false;
			StatPosition13Taken = false;
			StatPosition14Taken = false;
			StatPosition15Taken = false;
			StatPosition16Taken = false;
			StatPosition17Taken = false;
			StatPosition18Taken = false;
			StatPosition19Taken = false;
			StatPosition20Taken = false;
			StatPosition21Taken = false;
			StatPosition22Taken = false;
			StatPosition23Taken = false;
			StatPosition24Taken = false;
			StatPosition25Taken = false;
			StatPosition26Taken = false;
			StatPosition27Taken = false;
			StatPosition28Taken = false;
			StatPosition29Taken = false;
			StatPosition30Taken = false;
			StatPosition31Taken = false;
			StatPosition32Taken = false;
			StatPosition33Taken = false;
			StatPosition34Taken = false;
			StatPosition35Taken = false;
			StatPosition36Taken = false;
			if (DisplayHealth.Text != "")
            {
				Stat_Health.Left.Set(20 - 22, 0);
				Stat_Health.Top.Set(279 + 132 - 92, 0);
				DisplayHealth.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                DisplayHealth.Top.Set(-10 + 279 + 132 - 90, 0);
				StatPosition1Taken = true;
				StatHealth = 1;
            }
			else
            {
				DisplayHealth.Left.Set(999999, 0);
                DisplayHealth.Top.Set(999999, 0);
				Stat_Health.Left.Set(999999, 0);
				Stat_Health.Top.Set(999999, 0);
				StatHealth = 0;
			}
            if (DisplayRegeneration.Text != "")
            {
                if (!StatPosition1Taken)
                {
                    Stat_Regeneration.Left.Set(20 - 22, 0);
                    Stat_Regeneration.Top.Set(279 + 132 - 92, 0);
                    DisplayRegeneration.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayRegeneration.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else
                {
					Stat_Regeneration.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Regeneration.Top.Set(279 + 132 - 92, 0);
					DisplayRegeneration.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayRegeneration.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
                StatRegeneration = 1;
            }
			else
			{
				DisplayRegeneration.Left.Set(999999, 0);
                DisplayRegeneration.Top.Set(999999, 0);
				Stat_Regeneration.Left.Set(999999, 0);
				Stat_Regeneration.Top.Set(999999, 0);
				StatRegeneration = 0;
			}
            if (DisplayMana.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_Mana.Left.Set(20 - 22, 0);
					Stat_Mana.Top.Set(279 + 132 - 92, 0);
					DisplayMana.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMana.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_Mana.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Mana.Top.Set(279 + 132 - 92, 0);
					DisplayMana.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMana.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else
                {
					Stat_Mana.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_Mana.Top.Set(279 + 132 - 92, 0);
					DisplayMana.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayMana.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				StatMana = 1;
            }
			else
			{
				DisplayMana.Left.Set(999999, 0);
                DisplayMana.Top.Set(999999, 0);
				Stat_Mana.Left.Set(999999, 0);
				Stat_Mana.Top.Set(999999, 0);
				StatMana = 0;
			}
            if (DisplayManaRegeneration.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_ManaRegeneration.Left.Set(20 - 22, 0);
					Stat_ManaRegeneration.Top.Set(279 + 132 - 92, 0);
					DisplayManaRegeneration.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayManaRegeneration.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_ManaRegeneration.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_ManaRegeneration.Top.Set(279 + 132 - 92, 0);
					DisplayManaRegeneration.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayManaRegeneration.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_ManaRegeneration.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_ManaRegeneration.Top.Set(279 + 132 - 92, 0);
					DisplayManaRegeneration.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayManaRegeneration.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else
                {
					Stat_ManaRegeneration.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_ManaRegeneration.Top.Set(279 + 132 - 92, 0);
					DisplayManaRegeneration.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayManaRegeneration.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				StatManaRegeneration = 1;
            }
			else
			{
				DisplayManaRegeneration.Left.Set(999999, 0);
                DisplayManaRegeneration.Top.Set(999999, 0);
				Stat_ManaRegeneration.Left.Set(999999, 0);
				Stat_ManaRegeneration.Top.Set(999999, 0);
				StatManaRegeneration = 0;
			}
            if (DisplayDefense.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_Defense.Left.Set(20 - 22, 0);
					Stat_Defense.Top.Set(279 + 132 - 92, 0);
					DisplayDefense.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayDefense.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_Defense.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Defense.Top.Set(279 + 132 - 92, 0);
					DisplayDefense.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayDefense.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_Defense.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_Defense.Top.Set(279 + 132 - 92, 0);
					DisplayDefense.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayDefense.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_Defense.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_Defense.Top.Set(279 + 132 - 92, 0);
					DisplayDefense.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayDefense.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else
                {
					Stat_Defense.Left.Set(20 - 22, 0);
					Stat_Defense.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayDefense.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayDefense.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				StatDefense = 1;
            }
			else
			{
                DisplayDefense.Left.Set(999999, 0);
                DisplayDefense.Top.Set(999999, 0);
				Stat_Defense.Left.Set(999999, 0);
				Stat_Defense.Top.Set(999999, 0);
				StatDefense = 0;
			}
            if (DisplayDamageReduction.Text != "")
            {
                if (!StatPosition1Taken)
                {
                    Stat_DamageReduction.Left.Set(20 - 22, 0);
                    Stat_DamageReduction.Top.Set(279 + 132 - 92, 0);
                    DisplayDamageReduction.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayDamageReduction.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition1Taken = true;
                }
                else if (!StatPosition2Taken)
                {
                    Stat_DamageReduction.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_DamageReduction.Top.Set(279 + 132 - 92, 0);
                    DisplayDamageReduction.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayDamageReduction.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition2Taken = true;
                }
                else if (!StatPosition3Taken)
                {
                    Stat_DamageReduction.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_DamageReduction.Top.Set(279 + 132 - 92, 0);
                    DisplayDamageReduction.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayDamageReduction.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition3Taken = true;
                }
                else if (!StatPosition4Taken)
                {
                    Stat_DamageReduction.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_DamageReduction.Top.Set(279 + 132 - 92, 0);
                    DisplayDamageReduction.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayDamageReduction.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition4Taken = true;
                }
                else if (!StatPosition5Taken)
                {
                    Stat_DamageReduction.Left.Set(20 - 22, 0);
                    Stat_DamageReduction.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplayDamageReduction.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayDamageReduction.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition5Taken = true;
                }
				else
                {
					Stat_DamageReduction.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageReduction.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayDamageReduction.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayDamageReduction.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				StatDamageReduction = 1;
            }
			else
			{
				DisplayDamageReduction.Left.Set(999999, 0);
                DisplayDamageReduction.Top.Set(999999, 0);
				Stat_DamageReduction.Left.Set(999999, 0);
				Stat_DamageReduction.Top.Set(999999, 0);
				StatDamageReduction = 0;
			}
            if (DisplayThorns.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_Thorns.Left.Set(20 - 22, 0);
					Stat_Thorns.Top.Set(279 + 132 - 92, 0);
					DisplayThorns.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayThorns.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_Thorns.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Thorns.Top.Set(279 + 132 - 92, 0);
					DisplayThorns.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayThorns.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_Thorns.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_Thorns.Top.Set(279 + 132 - 92, 0);
					DisplayThorns.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayThorns.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_Thorns.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_Thorns.Top.Set(279 + 132 - 92, 0);
					DisplayThorns.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayThorns.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_Thorns.Left.Set(20 - 22, 0);
					Stat_Thorns.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayThorns.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayThorns.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_Thorns.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Thorns.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayThorns.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayThorns.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else
                {
					Stat_Thorns.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_Thorns.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayThorns.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayThorns.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				StatThorns = 1;
            }
			else
			{
				DisplayThorns.Left.Set(999999, 0);
                DisplayThorns.Top.Set(999999, 0);
				Stat_Thorns.Left.Set(999999, 0);
				Stat_Thorns.Top.Set(999999, 0);
				StatThorns = 0;
			}
            if (DisplayLavaResistance.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_LavaResistance.Left.Set(20 - 22, 0);
					Stat_LavaResistance.Top.Set(279 + 132 - 92, 0);
					DisplayLavaResistance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayLavaResistance.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_LavaResistance.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_LavaResistance.Top.Set(279 + 132 - 92, 0);
					DisplayLavaResistance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayLavaResistance.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_LavaResistance.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_LavaResistance.Top.Set(279 + 132 - 92, 0);
					DisplayLavaResistance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayLavaResistance.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_LavaResistance.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_LavaResistance.Top.Set(279 + 132 - 92, 0);
					DisplayLavaResistance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayLavaResistance.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_LavaResistance.Left.Set(20 - 22, 0);
					Stat_LavaResistance.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayLavaResistance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayLavaResistance.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_LavaResistance.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_LavaResistance.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayLavaResistance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayLavaResistance.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_LavaResistance.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_LavaResistance.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayLavaResistance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayLavaResistance.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else
				{
					Stat_LavaResistance.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_LavaResistance.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayLavaResistance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayLavaResistance.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				StatLavaResistance = 1;
            }
			else
			{
				DisplayLavaResistance.Left.Set(999999, 0);
                DisplayLavaResistance.Top.Set(999999, 0);
				Stat_LavaResistance.Left.Set(999999, 0);
				Stat_LavaResistance.Top.Set(999999, 0);
				StatLavaResistance = 0;
			}
            if (DisplayMeleeDamage.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_DamageMelee.Left.Set(20 - 22, 0);
					Stat_DamageMelee.Top.Set(279 + 132 - 92, 0);
					DisplayMeleeDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMeleeDamage.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_DamageMelee.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageMelee.Top.Set(279 + 132 - 92, 0);
					DisplayMeleeDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMeleeDamage.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_DamageMelee.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageMelee.Top.Set(279 + 132 - 92, 0);
					DisplayMeleeDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMeleeDamage.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_DamageMelee.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageMelee.Top.Set(279 + 132 - 92, 0);
					DisplayMeleeDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMeleeDamage.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_DamageMelee.Left.Set(20 - 22, 0);
					Stat_DamageMelee.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMeleeDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMeleeDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_DamageMelee.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageMelee.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMeleeDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMeleeDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_DamageMelee.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageMelee.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMeleeDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMeleeDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else if (!StatPosition8Taken)
				{
					Stat_DamageMelee.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageMelee.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMeleeDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMeleeDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				else
                {
					Stat_DamageMelee.Left.Set(20 - 22, 0);
					Stat_DamageMelee.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMeleeDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMeleeDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition9Taken = true;
				}
				StatMeleeDamage = 1;
            }
			else
			{
				DisplayMeleeDamage.Left.Set(999999, 0);
                DisplayMeleeDamage.Top.Set(999999, 0);
				Stat_DamageMelee.Left.Set(999999, 0);
				Stat_DamageMelee.Top.Set(999999, 0);
				StatMeleeDamage = 0;
			}
			if (DisplayRangedDamage.Text != "")
            {
                if (!StatPosition1Taken)
                {
                    Stat_DamageRanged.Left.Set(20 - 22, 0);
                    Stat_DamageRanged.Top.Set(279 + 132 - 92, 0);
                    DisplayRangedDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayRangedDamage.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition1Taken = true;
                }
                else if (!StatPosition2Taken)
                {
                    Stat_DamageRanged.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_DamageRanged.Top.Set(279 + 132 - 92, 0);
                    DisplayRangedDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayRangedDamage.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition2Taken = true;
                }
                else if (!StatPosition3Taken)
                {
                    Stat_DamageRanged.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_DamageRanged.Top.Set(279 + 132 - 92, 0);
                    DisplayRangedDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayRangedDamage.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition3Taken = true;
                }
                else if (!StatPosition4Taken)
                {
                    Stat_DamageRanged.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_DamageRanged.Top.Set(279 + 132 - 92, 0);
                    DisplayRangedDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayRangedDamage.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition4Taken = true;
                }
                else if (!StatPosition5Taken)
                {
                    Stat_DamageRanged.Left.Set(20 - 22, 0);
                    Stat_DamageRanged.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplayRangedDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayRangedDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition5Taken = true;
                }
                else if (!StatPosition6Taken)
                {
                    Stat_DamageRanged.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_DamageRanged.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplayRangedDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayRangedDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition6Taken = true;
                }
                else if (!StatPosition7Taken)
                {
                    Stat_DamageRanged.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_DamageRanged.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplayRangedDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayRangedDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition7Taken = true;
                }
                else if (!StatPosition8Taken)
                {
                    Stat_DamageRanged.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_DamageRanged.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplayRangedDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayRangedDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition8Taken = true;
                }
                else if (!StatPosition9Taken)
                {
                    Stat_DamageRanged.Left.Set(20 - 22, 0);
                    Stat_DamageRanged.Top.Set(279 + 28 + 28 + 132 - 92, 0);
                    DisplayRangedDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayRangedDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
                    StatPosition9Taken = true;
                }
				else
				{
					Stat_DamageRanged.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageRanged.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayRangedDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRangedDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition10Taken = true;
				}
				StatRangedDamage = 1;
            }
			else
			{
				DisplayRangedDamage.Left.Set(999999, 0);
                DisplayRangedDamage.Top.Set(999999, 0);
				Stat_DamageRanged.Left.Set(999999, 0);
				Stat_DamageRanged.Top.Set(999999, 0);
				StatRangedDamage = 0;
			}
            if (DisplayMagicDamage.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_DamageMagic.Left.Set(20 - 22, 0);
					Stat_DamageMagic.Top.Set(279 + 132 - 92, 0);
					DisplayMagicDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMagicDamage.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_DamageMagic.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageMagic.Top.Set(279 + 132 - 92, 0);
					DisplayMagicDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMagicDamage.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_DamageMagic.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageMagic.Top.Set(279 + 132 - 92, 0);
					DisplayMagicDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMagicDamage.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_DamageMagic.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageMagic.Top.Set(279 + 132 - 92, 0);
					DisplayMagicDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMagicDamage.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_DamageMagic.Left.Set(20 - 22, 0);
					Stat_DamageMagic.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMagicDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMagicDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_DamageMagic.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageMagic.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMagicDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMagicDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_DamageMagic.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageMagic.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMagicDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMagicDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else if (!StatPosition8Taken)
				{
					Stat_DamageMagic.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageMagic.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMagicDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMagicDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				else if (!StatPosition9Taken)
				{
					Stat_DamageMagic.Left.Set(20 - 22, 0);
					Stat_DamageMagic.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMagicDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMagicDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition9Taken = true;
				}
				else if (!StatPosition10Taken)
				{
					Stat_DamageMagic.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageMagic.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMagicDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMagicDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition10Taken = true;
				}
				else
                {
					Stat_DamageMagic.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageMagic.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMagicDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMagicDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition11Taken = true;
				}
				StatMagicDamage = 1;
            }
			else
			{
				DisplayMagicDamage.Left.Set(999999, 0);
                DisplayMagicDamage.Top.Set(999999, 0);
				Stat_DamageMagic.Left.Set(999999, 0);
				Stat_DamageMagic.Top.Set(999999, 0);
				StatMagicDamage = 0;
			}
            if (DisplaySummonDamage.Text != "")
            {
                if (!StatPosition1Taken)
                {
                    Stat_DamageSummon.Left.Set(20 - 22, 0);
                    Stat_DamageSummon.Top.Set(279 + 132 - 92, 0);
                    DisplaySummonDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplaySummonDamage.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition1Taken = true;
                }
                else if (!StatPosition2Taken)
                {
                    Stat_DamageSummon.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_DamageSummon.Top.Set(279 + 132 - 92, 0);
                    DisplaySummonDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplaySummonDamage.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition2Taken = true;
                }
                else if (!StatPosition3Taken)
                {
                    Stat_DamageSummon.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_DamageSummon.Top.Set(279 + 132 - 92, 0);
                    DisplaySummonDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplaySummonDamage.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition3Taken = true;
                }
                else if (!StatPosition4Taken)
                {
                    Stat_DamageSummon.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_DamageSummon.Top.Set(279 + 132 - 92, 0);
                    DisplaySummonDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplaySummonDamage.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition4Taken = true;
                }
                else if (!StatPosition5Taken)
                {
                    Stat_DamageSummon.Left.Set(20 - 22, 0);
                    Stat_DamageSummon.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplaySummonDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplaySummonDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition5Taken = true;
                }
                else if (!StatPosition6Taken)
                {
                    Stat_DamageSummon.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_DamageSummon.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplaySummonDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplaySummonDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition6Taken = true;
                }
                else if (!StatPosition7Taken)
                {
                    Stat_DamageSummon.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_DamageSummon.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplaySummonDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplaySummonDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition7Taken = true;
                }
                else if (!StatPosition8Taken)
                {
                    Stat_DamageSummon.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_DamageSummon.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplaySummonDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplaySummonDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition8Taken = true;
                }
                else if (!StatPosition9Taken)
                {
                    Stat_DamageSummon.Left.Set(20 - 22, 0);
                    Stat_DamageSummon.Top.Set(279 + 28 + 28 + 132 - 92, 0);
                    DisplaySummonDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplaySummonDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
                    StatPosition9Taken = true;
                }
                else if (!StatPosition10Taken)
                {
                    Stat_DamageSummon.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_DamageSummon.Top.Set(279 + 28 + 28 + 132 - 92, 0);
                    DisplaySummonDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplaySummonDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
                    StatPosition10Taken = true;
                }
                else if (!StatPosition11Taken)
                {
                    Stat_DamageSummon.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_DamageSummon.Top.Set(279 + 28 + 28 + 132 - 92, 0);
                    DisplaySummonDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplaySummonDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
                    StatPosition11Taken = true;
                }
				else
                {
					Stat_DamageSummon.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageSummon.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplaySummonDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplaySummonDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition12Taken = true;
				}
				StatSummonDamage = 1;
            }
			else
			{
				DisplaySummonDamage.Left.Set(999999, 0);
                DisplaySummonDamage.Top.Set(999999, 0);
				Stat_DamageSummon.Left.Set(999999, 0);
				Stat_DamageSummon.Top.Set(999999, 0);
				StatSummonDamage = 0;
			}
            if (DisplayMeleeSpeed.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_MeleeSpeed.Left.Set(20 - 22, 0);
					Stat_MeleeSpeed.Top.Set(279 + 132 - 92, 0);
					DisplayMeleeSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMeleeSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_MeleeSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_MeleeSpeed.Top.Set(279 + 132 - 92, 0);
					DisplayMeleeSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMeleeSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_MeleeSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_MeleeSpeed.Top.Set(279 + 132 - 92, 0);
					DisplayMeleeSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMeleeSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_MeleeSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_MeleeSpeed.Top.Set(279 + 132 - 92, 0);
					DisplayMeleeSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMeleeSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_MeleeSpeed.Left.Set(20 - 22, 0);
					Stat_MeleeSpeed.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMeleeSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMeleeSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_MeleeSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_MeleeSpeed.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMeleeSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMeleeSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_MeleeSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_MeleeSpeed.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMeleeSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMeleeSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else if (!StatPosition8Taken)
				{
					Stat_MeleeSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_MeleeSpeed.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMeleeSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMeleeSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				else if (!StatPosition9Taken)
				{
					Stat_MeleeSpeed.Left.Set(20 - 22, 0);
					Stat_MeleeSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMeleeSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMeleeSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition9Taken = true;
				}
				else if (!StatPosition10Taken)
				{
					Stat_MeleeSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_MeleeSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMeleeSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMeleeSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition10Taken = true;
				}
				else if (!StatPosition11Taken)
				{
					Stat_MeleeSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_MeleeSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMeleeSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMeleeSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition11Taken = true;
				}
				else if (!StatPosition12Taken)
				{
					Stat_MeleeSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_MeleeSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMeleeSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMeleeSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition12Taken = true;
				}
				else
                {
					Stat_MeleeSpeed.Left.Set(20 - 22, 0);
					Stat_MeleeSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMeleeSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayMeleeSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition13Taken = true;
				}
				StatMeleeSpeed = 1;
            }
			else
			{
				DisplayMeleeSpeed.Left.Set(999999, 0);
                DisplayMeleeSpeed.Top.Set(999999, 0);
				Stat_MeleeSpeed.Left.Set(999999, 0);
				Stat_MeleeSpeed.Top.Set(999999, 0);
				StatMeleeSpeed = 0;
			}
            if (DisplayArmorPenetration.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_ArmorPenetration.Left.Set(20 - 22, 0);
					Stat_ArmorPenetration.Top.Set(279 + 132 - 92, 0);
					DisplayArmorPenetration.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayArmorPenetration.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_ArmorPenetration.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_ArmorPenetration.Top.Set(279 + 132 - 92, 0);
					DisplayArmorPenetration.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayArmorPenetration.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_ArmorPenetration.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_ArmorPenetration.Top.Set(279 + 132 - 92, 0);
					DisplayArmorPenetration.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayArmorPenetration.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_ArmorPenetration.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_ArmorPenetration.Top.Set(279 + 132 - 92, 0);
					DisplayArmorPenetration.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayArmorPenetration.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_ArmorPenetration.Left.Set(20 - 22, 0);
					Stat_ArmorPenetration.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayArmorPenetration.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayArmorPenetration.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_ArmorPenetration.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_ArmorPenetration.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayArmorPenetration.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayArmorPenetration.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_ArmorPenetration.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_ArmorPenetration.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayArmorPenetration.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayArmorPenetration.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else if (!StatPosition8Taken)
				{
					Stat_ArmorPenetration.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_ArmorPenetration.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayArmorPenetration.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayArmorPenetration.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				else if (!StatPosition9Taken)
				{
					Stat_ArmorPenetration.Left.Set(20 - 22, 0);
					Stat_ArmorPenetration.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayArmorPenetration.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayArmorPenetration.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition9Taken = true;
				}
				else if (!StatPosition10Taken)
				{
					Stat_ArmorPenetration.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_ArmorPenetration.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayArmorPenetration.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayArmorPenetration.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition10Taken = true;
				}
				else if (!StatPosition11Taken)
				{
					Stat_ArmorPenetration.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_ArmorPenetration.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayArmorPenetration.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayArmorPenetration.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition11Taken = true;
				}
				else if (!StatPosition12Taken)
				{
					Stat_ArmorPenetration.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_ArmorPenetration.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayArmorPenetration.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayArmorPenetration.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition12Taken = true;
				}
				else if (!StatPosition13Taken)
				{
					Stat_ArmorPenetration.Left.Set(20 - 22, 0);
					Stat_ArmorPenetration.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayArmorPenetration.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayArmorPenetration.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition13Taken = true;
				}
				else
                {
					Stat_ArmorPenetration.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_ArmorPenetration.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayArmorPenetration.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayArmorPenetration.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition14Taken = true;
				}
				StatArmorPenetration = 1;
            }
			else
			{
				DisplayArmorPenetration.Left.Set(999999, 0);
                DisplayArmorPenetration.Top.Set(999999, 0);
				Stat_ArmorPenetration.Left.Set(999999, 0);
				Stat_ArmorPenetration.Top.Set(999999, 0);
				StatArmorPenetration = 0;
			}
            if (DisplayBulletDamage.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_DamageBullet.Left.Set(20 - 22, 0);
					Stat_DamageBullet.Top.Set(279 + 132 - 92, 0);
					DisplayBulletDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayBulletDamage.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_DamageBullet.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageBullet.Top.Set(279 + 132 - 92, 0);
					DisplayBulletDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayBulletDamage.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_DamageBullet.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageBullet.Top.Set(279 + 132 - 92, 0);
					DisplayBulletDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayBulletDamage.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_DamageBullet.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageBullet.Top.Set(279 + 132 - 92, 0);
					DisplayBulletDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayBulletDamage.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_DamageBullet.Left.Set(20 - 22, 0);
					Stat_DamageBullet.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayBulletDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayBulletDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_DamageBullet.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageBullet.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayBulletDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayBulletDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_DamageBullet.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageBullet.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayBulletDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayBulletDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else if (!StatPosition8Taken)
				{
					Stat_DamageBullet.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageBullet.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayBulletDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayBulletDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				else if (!StatPosition9Taken)
				{
					Stat_DamageBullet.Left.Set(20 - 22, 0);
					Stat_DamageBullet.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayBulletDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayBulletDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition9Taken = true;
				}
				else if (!StatPosition10Taken)
				{
					Stat_DamageBullet.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageBullet.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayBulletDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayBulletDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition10Taken = true;
				}
				else if (!StatPosition11Taken)
				{
					Stat_DamageBullet.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageBullet.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayBulletDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayBulletDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition11Taken = true;
				}
				else if (!StatPosition12Taken)
				{
					Stat_DamageBullet.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageBullet.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayBulletDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayBulletDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition12Taken = true;
				}
				else if (!StatPosition13Taken)
				{
					Stat_DamageBullet.Left.Set(20 - 22, 0);
					Stat_DamageBullet.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBulletDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayBulletDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition13Taken = true;
				}
				else if (!StatPosition14Taken)
				{
					Stat_DamageBullet.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageBullet.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBulletDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayBulletDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition14Taken = true;
				}
				else
                {
					Stat_DamageBullet.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageBullet.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBulletDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayBulletDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition15Taken = true;
				}
				StatBulletDamage = 1;
            }
			else
			{
				DisplayBulletDamage.Left.Set(999999, 0);
                DisplayBulletDamage.Top.Set(999999, 0);
				Stat_DamageBullet.Left.Set(999999, 0);
				Stat_DamageBullet.Top.Set(999999, 0);
				StatBulletDamage = 0;
			}
            if (DisplayRocketDamage.Text != "")
            {
                if (!StatPosition1Taken)
                {
                    Stat_DamageRocket.Left.Set(20 - 22, 0);
                    Stat_DamageRocket.Top.Set(279 + 132 - 92, 0);
                    DisplayRocketDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayRocketDamage.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition1Taken = true;
                }
                else if (!StatPosition2Taken)
                {
                    Stat_DamageRocket.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_DamageRocket.Top.Set(279 + 132 - 92, 0);
                    DisplayRocketDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayRocketDamage.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition2Taken = true;
                }
                else if (!StatPosition3Taken)
                {
                    Stat_DamageRocket.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_DamageRocket.Top.Set(279 + 132 - 92, 0);
                    DisplayRocketDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayRocketDamage.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition3Taken = true;
                }
                else if (!StatPosition4Taken)
                {
                    Stat_DamageRocket.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_DamageRocket.Top.Set(279 + 132 - 92, 0);
                    DisplayRocketDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayRocketDamage.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition4Taken = true;
                }
                else if (!StatPosition5Taken)
                {
                    Stat_DamageRocket.Left.Set(20 - 22, 0);
                    Stat_DamageRocket.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplayRocketDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayRocketDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition5Taken = true;
                }
                else if (!StatPosition6Taken)
                {
                    Stat_DamageRocket.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_DamageRocket.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplayRocketDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayRocketDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition6Taken = true;
                }
                else if (!StatPosition7Taken)
                {
                    Stat_DamageRocket.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_DamageRocket.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplayRocketDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayRocketDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition7Taken = true;
                }
                else if (!StatPosition8Taken)
                {
                    Stat_DamageRocket.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_DamageRocket.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplayRocketDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayRocketDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition8Taken = true;
                }
                else if (!StatPosition9Taken)
                {
                    Stat_DamageRocket.Left.Set(20 - 22, 0);
                    Stat_DamageRocket.Top.Set(279 + 28 + 28 + 132 - 92, 0);
                    DisplayRocketDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayRocketDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
                    StatPosition9Taken = true;
                }
                else if (!StatPosition10Taken)
                {
                    Stat_DamageRocket.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_DamageRocket.Top.Set(279 + 28 + 28 + 132 - 92, 0);
                    DisplayRocketDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayRocketDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
                    StatPosition10Taken = true;
                }
                else if (!StatPosition11Taken)
                {
                    Stat_DamageRocket.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_DamageRocket.Top.Set(279 + 28 + 28 + 132 - 92, 0);
                    DisplayRocketDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayRocketDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
                    StatPosition11Taken = true;
                }
                else if (!StatPosition12Taken)
                {
                    Stat_DamageRocket.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_DamageRocket.Top.Set(279 + 28 + 28 + 132 - 92, 0);
                    DisplayRocketDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayRocketDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
                    StatPosition12Taken = true;
                }
                else if (!StatPosition13Taken)
                {
                    Stat_DamageRocket.Left.Set(20 - 22, 0);
                    Stat_DamageRocket.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayRocketDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayRocketDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition13Taken = true;
                }
                else if (!StatPosition14Taken)
                {
                    Stat_DamageRocket.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_DamageRocket.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayRocketDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayRocketDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition14Taken = true;
                }
                else if (!StatPosition15Taken)
                {
                    Stat_DamageRocket.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_DamageRocket.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayRocketDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayRocketDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition15Taken = true;
                }
				else
                {
					Stat_DamageRocket.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageRocket.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRocketDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRocketDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition16Taken = true;
				}
				StatRocketDamage = 1;
            }
			else
			{
				DisplayRocketDamage.Left.Set(999999, 0);
                DisplayRocketDamage.Top.Set(999999, 0);
				Stat_DamageRocket.Left.Set(999999, 0);
				Stat_DamageRocket.Top.Set(999999, 0);
				StatRocketDamage = 0;
			}
            if (DisplayManaCost.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_ManaCost.Left.Set(20 - 22, 0);
					Stat_ManaCost.Top.Set(279 + 132 - 92, 0);
					DisplayManaCost.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayManaCost.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_ManaCost.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_ManaCost.Top.Set(279 + 132 - 92, 0);
					DisplayManaCost.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayManaCost.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_ManaCost.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_ManaCost.Top.Set(279 + 132 - 92, 0);
					DisplayManaCost.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayManaCost.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_ManaCost.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_ManaCost.Top.Set(279 + 132 - 92, 0);
					DisplayManaCost.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayManaCost.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_ManaCost.Left.Set(20 - 22, 0);
					Stat_ManaCost.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayManaCost.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayManaCost.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_ManaCost.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_ManaCost.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayManaCost.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayManaCost.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_ManaCost.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_ManaCost.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayManaCost.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayManaCost.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else if (!StatPosition8Taken)
				{
					Stat_ManaCost.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_ManaCost.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayManaCost.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayManaCost.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				else if (!StatPosition9Taken)
				{
					Stat_ManaCost.Left.Set(20 - 22, 0);
					Stat_ManaCost.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayManaCost.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayManaCost.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition9Taken = true;
				}
				else if (!StatPosition10Taken)
				{
					Stat_ManaCost.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_ManaCost.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayManaCost.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayManaCost.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition10Taken = true;
				}
				else if (!StatPosition11Taken)
				{
					Stat_ManaCost.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_ManaCost.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayManaCost.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayManaCost.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition11Taken = true;
				}
				else if (!StatPosition12Taken)
				{
					Stat_ManaCost.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_ManaCost.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayManaCost.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayManaCost.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition12Taken = true;
				}
				else if (!StatPosition13Taken)
				{
					Stat_ManaCost.Left.Set(20 - 22, 0);
					Stat_ManaCost.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayManaCost.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayManaCost.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition13Taken = true;
				}
				else if (!StatPosition14Taken)
				{
					Stat_ManaCost.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_ManaCost.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayManaCost.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayManaCost.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition14Taken = true;
				}
				else if (!StatPosition15Taken)
				{
					Stat_ManaCost.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_ManaCost.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayManaCost.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayManaCost.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition15Taken = true;
				}
				else if (!StatPosition16Taken)
				{
					Stat_ManaCost.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_ManaCost.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayManaCost.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayManaCost.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition16Taken = true;
				}
				else
                {
					Stat_ManaCost.Left.Set(20 - 22, 0);
					Stat_ManaCost.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayManaCost.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayManaCost.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition17Taken = true;
				}
				StatManaCost = 1;
            }
			else
			{
				DisplayManaCost.Left.Set(999999, 0);
                DisplayManaCost.Top.Set(999999, 0);
				Stat_ManaCost.Left.Set(999999, 0);
				Stat_ManaCost.Top.Set(999999, 0);
				StatManaCost = 0;
			}
            if (DisplayMinionKnockback.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_MinionKnockback.Left.Set(20 - 22, 0);
					Stat_MinionKnockback.Top.Set(279 + 132 - 92, 0);
					DisplayMinionKnockback.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMinionKnockback.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_MinionKnockback.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_MinionKnockback.Top.Set(279 + 132 - 92, 0);
					DisplayMinionKnockback.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMinionKnockback.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_MinionKnockback.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_MinionKnockback.Top.Set(279 + 132 - 92, 0);
					DisplayMinionKnockback.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMinionKnockback.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_MinionKnockback.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_MinionKnockback.Top.Set(279 + 132 - 92, 0);
					DisplayMinionKnockback.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMinionKnockback.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_MinionKnockback.Left.Set(20 - 22, 0);
					Stat_MinionKnockback.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMinionKnockback.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMinionKnockback.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_MinionKnockback.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_MinionKnockback.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMinionKnockback.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMinionKnockback.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_MinionKnockback.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_MinionKnockback.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMinionKnockback.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMinionKnockback.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else if (!StatPosition8Taken)
				{
					Stat_MinionKnockback.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_MinionKnockback.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMinionKnockback.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMinionKnockback.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				else if (!StatPosition9Taken)
				{
					Stat_MinionKnockback.Left.Set(20 - 22, 0);
					Stat_MinionKnockback.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMinionKnockback.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMinionKnockback.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition9Taken = true;
				}
				else if (!StatPosition10Taken)
				{
					Stat_MinionKnockback.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_MinionKnockback.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMinionKnockback.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMinionKnockback.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition10Taken = true;
				}
				else if (!StatPosition11Taken)
				{
					Stat_MinionKnockback.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_MinionKnockback.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMinionKnockback.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMinionKnockback.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition11Taken = true;
				}
				else if (!StatPosition12Taken)
				{
					Stat_MinionKnockback.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_MinionKnockback.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMinionKnockback.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMinionKnockback.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition12Taken = true;
				}
				else if (!StatPosition13Taken)
				{
					Stat_MinionKnockback.Left.Set(20 - 22, 0);
					Stat_MinionKnockback.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMinionKnockback.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMinionKnockback.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition13Taken = true;
				}
				else if (!StatPosition14Taken)
				{
					Stat_MinionKnockback.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_MinionKnockback.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMinionKnockback.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMinionKnockback.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition14Taken = true;
				}
				else if (!StatPosition15Taken)
				{
					Stat_MinionKnockback.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_MinionKnockback.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMinionKnockback.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMinionKnockback.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition15Taken = true;
				}
				else if (!StatPosition16Taken)
				{
					Stat_MinionKnockback.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_MinionKnockback.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMinionKnockback.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMinionKnockback.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition16Taken = true;
				}
				else if (!StatPosition17Taken)
				{
					Stat_MinionKnockback.Left.Set(20 - 22, 0);
					Stat_MinionKnockback.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMinionKnockback.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMinionKnockback.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition17Taken = true;
				}
				else
                {
					Stat_MinionKnockback.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_MinionKnockback.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMinionKnockback.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMinionKnockback.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition18Taken = true;
				}
				StatMinionKnockback = 1;
            }
			else
			{
				DisplayMinionKnockback.Left.Set(999999, 0);
				DisplayMinionKnockback.Top.Set(999999, 0);
				Stat_MinionKnockback.Left.Set(999999, 0);
				Stat_MinionKnockback.Top.Set(999999, 0);
				StatMinionKnockback = 0;
			}
			if (DisplayMinions.Text != "")
			{
				if (!StatPosition1Taken)
				{
					Stat_Minions.Left.Set(20 - 22, 0);
					Stat_Minions.Top.Set(279 + 132 - 92, 0);
					DisplayMinions.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMinions.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_Minions.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Minions.Top.Set(279 + 132 - 92, 0);
					DisplayMinions.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMinions.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_Minions.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_Minions.Top.Set(279 + 132 - 92, 0);
					DisplayMinions.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMinions.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_Minions.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_Minions.Top.Set(279 + 132 - 92, 0);
					DisplayMinions.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMinions.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_Minions.Left.Set(20 - 22, 0);
					Stat_Minions.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMinions.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMinions.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_Minions.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Minions.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMinions.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMinions.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_Minions.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_Minions.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMinions.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMinions.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else if (!StatPosition8Taken)
				{
					Stat_Minions.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_Minions.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMinions.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMinions.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				else if (!StatPosition9Taken)
				{
					Stat_Minions.Left.Set(20 - 22, 0);
					Stat_Minions.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMinions.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMinions.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition9Taken = true;
				}
				else if (!StatPosition10Taken)
				{
					Stat_Minions.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Minions.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMinions.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMinions.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition10Taken = true;
				}
				else if (!StatPosition11Taken)
				{
					Stat_Minions.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_Minions.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMinions.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMinions.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition11Taken = true;
				}
				else if (!StatPosition12Taken)
				{
					Stat_Minions.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_Minions.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMinions.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMinions.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition12Taken = true;
				}
				else if (!StatPosition13Taken)
				{
					Stat_Minions.Left.Set(20 - 22, 0);
					Stat_Minions.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMinions.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMinions.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition13Taken = true;
				}
				else if (!StatPosition14Taken)
				{
					Stat_Minions.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Minions.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMinions.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMinions.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition14Taken = true;
				}
				else if (!StatPosition15Taken)
				{
					Stat_Minions.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_Minions.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMinions.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMinions.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition15Taken = true;
				}
				else if (!StatPosition16Taken)
				{
					Stat_Minions.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_Minions.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMinions.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMinions.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition16Taken = true;
				}
				else if (!StatPosition17Taken)
				{
					Stat_Minions.Left.Set(20 - 22, 0);
					Stat_Minions.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMinions.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMinions.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition17Taken = true;
				}
				else if (!StatPosition18Taken)
				{
					Stat_Minions.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Minions.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMinions.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMinions.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition18Taken = true;
				}
				else
                {
					Stat_Minions.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_Minions.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMinions.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMinions.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition19Taken = true;
				}
				StatMinions = 1;
			}
			else
			{
				DisplayMinions.Left.Set(999999, 0);
                DisplayMinions.Top.Set(999999, 0);
				Stat_Minions.Left.Set(999999, 0);
				Stat_Minions.Top.Set(999999, 0);
				StatMinions = 0;
			}
            if (DisplaySentries.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_Sentries.Left.Set(20 - 22, 0);
					Stat_Sentries.Top.Set(279 + 132 - 92, 0);
					DisplaySentries.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplaySentries.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_Sentries.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Sentries.Top.Set(279 + 132 - 92, 0);
					DisplaySentries.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplaySentries.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_Sentries.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_Sentries.Top.Set(279 + 132 - 92, 0);
					DisplaySentries.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplaySentries.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_Sentries.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_Sentries.Top.Set(279 + 132 - 92, 0);
					DisplaySentries.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplaySentries.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_Sentries.Left.Set(20 - 22, 0);
					Stat_Sentries.Top.Set(279 + 28 + 132 - 92, 0);
					DisplaySentries.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplaySentries.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_Sentries.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Sentries.Top.Set(279 + 28 + 132 - 92, 0);
					DisplaySentries.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplaySentries.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_Sentries.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_Sentries.Top.Set(279 + 28 + 132 - 92, 0);
					DisplaySentries.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplaySentries.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else if (!StatPosition8Taken)
				{
					Stat_Sentries.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_Sentries.Top.Set(279 + 28 + 132 - 92, 0);
					DisplaySentries.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplaySentries.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				else if (!StatPosition9Taken)
				{
					Stat_Sentries.Left.Set(20 - 22, 0);
					Stat_Sentries.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplaySentries.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplaySentries.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition9Taken = true;
				}
				else if (!StatPosition10Taken)
				{
					Stat_Sentries.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Sentries.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplaySentries.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplaySentries.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition10Taken = true;
				}
				else if (!StatPosition11Taken)
				{
					Stat_Sentries.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_Sentries.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplaySentries.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplaySentries.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition11Taken = true;
				}
				else if (!StatPosition12Taken)
				{
					Stat_Sentries.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_Sentries.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplaySentries.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplaySentries.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition12Taken = true;
				}
				else if (!StatPosition13Taken)
				{
					Stat_Sentries.Left.Set(20 - 22, 0);
					Stat_Sentries.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplaySentries.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplaySentries.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition13Taken = true;
				}
				else if (!StatPosition14Taken)
				{
					Stat_Sentries.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Sentries.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplaySentries.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplaySentries.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition14Taken = true;
				}
				else if (!StatPosition15Taken)
				{
					Stat_Sentries.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_Sentries.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplaySentries.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplaySentries.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition15Taken = true;
				}
				else if (!StatPosition16Taken)
				{
					Stat_Sentries.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_Sentries.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplaySentries.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplaySentries.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition16Taken = true;
				}
				else if (!StatPosition17Taken)
				{
					Stat_Sentries.Left.Set(20 - 22, 0);
					Stat_Sentries.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplaySentries.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplaySentries.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition17Taken = true;
				}
				else if (!StatPosition18Taken)
				{
					Stat_Sentries.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Sentries.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplaySentries.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplaySentries.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition18Taken = true;
				}
				else if (!StatPosition19Taken)
				{
					Stat_Sentries.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_Sentries.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplaySentries.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplaySentries.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition19Taken = true;
				}
				else
                {
					Stat_Sentries.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_Sentries.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplaySentries.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplaySentries.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition20Taken = true;
				}
				StatSentries = 1;
            }
			else
			{
				DisplaySentries.Left.Set(999999, 0);
                DisplaySentries.Top.Set(999999, 0);
				Stat_Sentries.Left.Set(999999, 0);
				Stat_Sentries.Top.Set(999999, 0);
				StatSentries = 0;
			}
            if (DisplayMeleeCritChance.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_CritChanceMelee.Left.Set(20 - 22, 0);
					Stat_CritChanceMelee.Top.Set(279 + 132 - 92, 0);
					DisplayMeleeCritChance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMeleeCritChance.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_CritChanceMelee.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_CritChanceMelee.Top.Set(279 + 132 - 92, 0);
					DisplayMeleeCritChance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMeleeCritChance.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_CritChanceMelee.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceMelee.Top.Set(279 + 132 - 92, 0);
					DisplayMeleeCritChance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMeleeCritChance.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_CritChanceMelee.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceMelee.Top.Set(279 + 132 - 92, 0);
					DisplayMeleeCritChance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMeleeCritChance.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_CritChanceMelee.Left.Set(20 - 22, 0);
					Stat_CritChanceMelee.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMeleeCritChance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMeleeCritChance.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_CritChanceMelee.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_CritChanceMelee.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMeleeCritChance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMeleeCritChance.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_CritChanceMelee.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceMelee.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMeleeCritChance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMeleeCritChance.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else if (!StatPosition8Taken)
				{
					Stat_CritChanceMelee.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceMelee.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMeleeCritChance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMeleeCritChance.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				else if (!StatPosition9Taken)
				{
					Stat_CritChanceMelee.Left.Set(20 - 22, 0);
					Stat_CritChanceMelee.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMeleeCritChance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMeleeCritChance.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition9Taken = true;
				}
				else if (!StatPosition10Taken)
				{
					Stat_CritChanceMelee.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_CritChanceMelee.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMeleeCritChance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMeleeCritChance.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition10Taken = true;
				}
				else if (!StatPosition11Taken)
				{
					Stat_CritChanceMelee.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceMelee.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMeleeCritChance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMeleeCritChance.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition11Taken = true;
				}
				else if (!StatPosition12Taken)
				{
					Stat_CritChanceMelee.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceMelee.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMeleeCritChance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMeleeCritChance.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition12Taken = true;
				}
				else if (!StatPosition13Taken)
				{
					Stat_CritChanceMelee.Left.Set(20 - 22, 0);
					Stat_CritChanceMelee.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMeleeCritChance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMeleeCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition13Taken = true;
				}
				else if (!StatPosition14Taken)
				{
					Stat_CritChanceMelee.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_CritChanceMelee.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMeleeCritChance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMeleeCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition14Taken = true;
				}
				else if (!StatPosition15Taken)
				{
					Stat_CritChanceMelee.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceMelee.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMeleeCritChance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMeleeCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition15Taken = true;
				}
				else if (!StatPosition16Taken)
				{
					Stat_CritChanceMelee.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceMelee.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMeleeCritChance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMeleeCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition16Taken = true;
				}
				else if (!StatPosition17Taken)
				{
					Stat_CritChanceMelee.Left.Set(20 - 22, 0);
					Stat_CritChanceMelee.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMeleeCritChance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMeleeCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition17Taken = true;
				}
				else if (!StatPosition18Taken)
				{
					Stat_CritChanceMelee.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_CritChanceMelee.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMeleeCritChance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMeleeCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition18Taken = true;
				}
				else if (!StatPosition19Taken)
				{
					Stat_CritChanceMelee.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceMelee.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMeleeCritChance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMeleeCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition19Taken = true;
				}
				else if (!StatPosition20Taken)
				{
					Stat_CritChanceMelee.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceMelee.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMeleeCritChance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMeleeCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition20Taken = true;
				}
				else
                {
					Stat_CritChanceMelee.Left.Set(20 - 22, 0);
					Stat_CritChanceMelee.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMeleeCritChance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMeleeCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition21Taken = true;
				}
				StatMeleeCritChance = 1;
            }
			else
			{
				DisplayMeleeCritChance.Left.Set(999999, 0);
                DisplayMeleeCritChance.Top.Set(999999, 0);
				Stat_CritChanceMelee.Left.Set(999999, 0);
				Stat_CritChanceMelee.Top.Set(999999, 0);
				StatMeleeCritChance = 0;
			}
            if (DisplayRangedCritChance.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_CritChanceRanged.Left.Set(20 - 22, 0);
					Stat_CritChanceRanged.Top.Set(279 + 132 - 92, 0);
					DisplayRangedCritChance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRangedCritChance.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_CritChanceRanged.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_CritChanceRanged.Top.Set(279 + 132 - 92, 0);
					DisplayRangedCritChance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRangedCritChance.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_CritChanceRanged.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceRanged.Top.Set(279 + 132 - 92, 0);
					DisplayRangedCritChance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRangedCritChance.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_CritChanceRanged.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceRanged.Top.Set(279 + 132 - 92, 0);
					DisplayRangedCritChance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRangedCritChance.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_CritChanceRanged.Left.Set(20 - 22, 0);
					Stat_CritChanceRanged.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayRangedCritChance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRangedCritChance.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_CritChanceRanged.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_CritChanceRanged.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayRangedCritChance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRangedCritChance.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_CritChanceRanged.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceRanged.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayRangedCritChance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRangedCritChance.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else if (!StatPosition8Taken)
				{
					Stat_CritChanceRanged.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceRanged.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayRangedCritChance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRangedCritChance.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				else if (!StatPosition9Taken)
				{
					Stat_CritChanceRanged.Left.Set(20 - 22, 0);
					Stat_CritChanceRanged.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayRangedCritChance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRangedCritChance.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition9Taken = true;
				}
				else if (!StatPosition10Taken)
				{
					Stat_CritChanceRanged.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_CritChanceRanged.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayRangedCritChance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRangedCritChance.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition10Taken = true;
				}
				else if (!StatPosition11Taken)
				{
					Stat_CritChanceRanged.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceRanged.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayRangedCritChance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRangedCritChance.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition11Taken = true;
				}
				else if (!StatPosition12Taken)
				{
					Stat_CritChanceRanged.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceRanged.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayRangedCritChance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRangedCritChance.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition12Taken = true;
				}
				else if (!StatPosition13Taken)
				{
					Stat_CritChanceRanged.Left.Set(20 - 22, 0);
					Stat_CritChanceRanged.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRangedCritChance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRangedCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition13Taken = true;
				}
				else if (!StatPosition14Taken)
				{
					Stat_CritChanceRanged.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_CritChanceRanged.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRangedCritChance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRangedCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition14Taken = true;
				}
				else if (!StatPosition15Taken)
				{
					Stat_CritChanceRanged.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceRanged.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRangedCritChance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRangedCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition15Taken = true;
				}
				else if (!StatPosition16Taken)
				{
					Stat_CritChanceRanged.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceRanged.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRangedCritChance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRangedCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition16Taken = true;
				}
				else if (!StatPosition17Taken)
				{
					Stat_CritChanceRanged.Left.Set(20 - 22, 0);
					Stat_CritChanceRanged.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRangedCritChance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRangedCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition17Taken = true;
				}
				else if (!StatPosition18Taken)
				{
					Stat_CritChanceRanged.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_CritChanceRanged.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRangedCritChance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRangedCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition18Taken = true;
				}
				else if (!StatPosition19Taken)
				{
					Stat_CritChanceRanged.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceRanged.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRangedCritChance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRangedCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition19Taken = true;
				}
				else if (!StatPosition20Taken)
				{
					Stat_CritChanceRanged.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceRanged.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRangedCritChance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRangedCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition20Taken = true;
				}
				else if (!StatPosition21Taken)
				{
					Stat_CritChanceRanged.Left.Set(20 - 22, 0);
					Stat_CritChanceRanged.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRangedCritChance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRangedCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition21Taken = true;
				}
				else
                {
					Stat_CritChanceRanged.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_CritChanceRanged.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRangedCritChance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRangedCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition22Taken = true;
				}
				StatRangedCritChance = 1;
            }
			else
			{
				DisplayRangedCritChance.Left.Set(999999, 0);
                DisplayRangedCritChance.Top.Set(999999, 0);
				Stat_CritChanceRanged.Left.Set(999999, 0);
				Stat_CritChanceRanged.Top.Set(999999, 0);
				StatRangedCritChance = 0;
			}
            if (DisplayMagicCritChance.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_CritChanceMagic.Left.Set(20 - 22, 0);
					Stat_CritChanceMagic.Top.Set(279 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_CritChanceMagic.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_CritChanceMagic.Top.Set(279 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_CritChanceMagic.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceMagic.Top.Set(279 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_CritChanceMagic.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceMagic.Top.Set(279 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_CritChanceMagic.Left.Set(20 - 22, 0);
					Stat_CritChanceMagic.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_CritChanceMagic.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_CritChanceMagic.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_CritChanceMagic.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceMagic.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else if (!StatPosition8Taken)
				{
					Stat_CritChanceMagic.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceMagic.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				else if (!StatPosition9Taken)
				{
					Stat_CritChanceMagic.Left.Set(20 - 22, 0);
					Stat_CritChanceMagic.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition9Taken = true;
				}
				else if (!StatPosition10Taken)
				{
					Stat_CritChanceMagic.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_CritChanceMagic.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition10Taken = true;
				}
				else if (!StatPosition11Taken)
				{
					Stat_CritChanceMagic.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceMagic.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition11Taken = true;
				}
				else if (!StatPosition12Taken)
				{
					Stat_CritChanceMagic.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceMagic.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition12Taken = true;
				}
				else if (!StatPosition13Taken)
				{
					Stat_CritChanceMagic.Left.Set(20 - 22, 0);
					Stat_CritChanceMagic.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition13Taken = true;
				}
				else if (!StatPosition14Taken)
				{
					Stat_CritChanceMagic.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_CritChanceMagic.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition14Taken = true;
				}
				else if (!StatPosition15Taken)
				{
					Stat_CritChanceMagic.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceMagic.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition15Taken = true;
				}
				else if (!StatPosition16Taken)
				{
					Stat_CritChanceMagic.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceMagic.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition16Taken = true;
				}
				else if (!StatPosition17Taken)
				{
					Stat_CritChanceMagic.Left.Set(20 - 22, 0);
					Stat_CritChanceMagic.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition17Taken = true;
				}
				else if (!StatPosition18Taken)
				{
					Stat_CritChanceMagic.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_CritChanceMagic.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition18Taken = true;
				}
				else if (!StatPosition19Taken)
				{
					Stat_CritChanceMagic.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceMagic.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition19Taken = true;
				}
				else if (!StatPosition20Taken)
				{
					Stat_CritChanceMagic.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceMagic.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition20Taken = true;
				}
				else if (!StatPosition21Taken)
				{
					Stat_CritChanceMagic.Left.Set(20 - 22, 0);
					Stat_CritChanceMagic.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition21Taken = true;
				}
				else if (!StatPosition22Taken)
				{
					Stat_CritChanceMagic.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_CritChanceMagic.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition22Taken = true;
				}
				else
                {
					Stat_CritChanceMagic.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_CritChanceMagic.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMagicCritChance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayMagicCritChance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition23Taken = true;
				}
				StatMagicCritChance = 1;
            }
			else
			{
				DisplayMagicCritChance.Left.Set(999999, 0);
                DisplayMagicCritChance.Top.Set(999999, 0);
				Stat_CritChanceMagic.Left.Set(999999, 0);
				Stat_CritChanceMagic.Top.Set(999999, 0);
				StatMagicCritChance = 0;
			}
            if (DisplayMiningSpeed.Text != "")
            {
                if (!StatPosition1Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22, 0);
                    Stat_MiningSpeed.Top.Set(279 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition1Taken = true;
                }
                else if (!StatPosition2Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_MiningSpeed.Top.Set(279 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition2Taken = true;
                }
                else if (!StatPosition3Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_MiningSpeed.Top.Set(279 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition3Taken = true;
                }
                else if (!StatPosition4Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_MiningSpeed.Top.Set(279 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition4Taken = true;
                }
                else if (!StatPosition5Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22, 0);
                    Stat_MiningSpeed.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition5Taken = true;
                }
                else if (!StatPosition6Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_MiningSpeed.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition6Taken = true;
                }
                else if (!StatPosition7Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_MiningSpeed.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition7Taken = true;
                }
                else if (!StatPosition8Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_MiningSpeed.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition8Taken = true;
                }
                else if (!StatPosition9Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22, 0);
                    Stat_MiningSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
                    StatPosition9Taken = true;
                }
                else if (!StatPosition10Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_MiningSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
                    StatPosition10Taken = true;
                }
                else if (!StatPosition11Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_MiningSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
                    StatPosition11Taken = true;
                }
                else if (!StatPosition12Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_MiningSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
                    StatPosition12Taken = true;
                }
                else if (!StatPosition13Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22, 0);
                    Stat_MiningSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition13Taken = true;
                }
                else if (!StatPosition14Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_MiningSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition14Taken = true;
                }
                else if (!StatPosition15Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_MiningSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition15Taken = true;
                }
                else if (!StatPosition16Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_MiningSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition16Taken = true;
                }
                else if (!StatPosition17Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22, 0);
                    Stat_MiningSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition17Taken = true;
                }
                else if (!StatPosition18Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_MiningSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition18Taken = true;
                }
                else if (!StatPosition19Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_MiningSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition19Taken = true;
                }
                else if (!StatPosition20Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_MiningSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition20Taken = true;
                }
                else if (!StatPosition21Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22, 0);
                    Stat_MiningSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition21Taken = true;
                }
                else if (!StatPosition22Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_MiningSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition22Taken = true;
                }
                else if (!StatPosition23Taken)
                {
                    Stat_MiningSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_MiningSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMiningSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayMiningSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition23Taken = true;
                }
				else
				{
					Stat_MiningSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_MiningSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMiningSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayMiningSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition24Taken = true;
				}
				StatMiningSpeed = 1;
            }
			else
			{
				DisplayMiningSpeed.Left.Set(999999, 0);
                DisplayMiningSpeed.Top.Set(999999, 0);
				Stat_MiningSpeed.Left.Set(999999, 0);
				Stat_MiningSpeed.Top.Set(999999, 0);
				StatMiningSpeed = 0;
			}
            if (DisplayBuildingSpeed.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22, 0);
					Stat_BuildingSpeed.Top.Set(279 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_BuildingSpeed.Top.Set(279 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingSpeed.Top.Set(279 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingSpeed.Top.Set(279 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22, 0);
					Stat_BuildingSpeed.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_BuildingSpeed.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingSpeed.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else if (!StatPosition8Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingSpeed.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				else if (!StatPosition9Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22, 0);
					Stat_BuildingSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition9Taken = true;
				}
				else if (!StatPosition10Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_BuildingSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition10Taken = true;
				}
				else if (!StatPosition11Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition11Taken = true;
				}
				else if (!StatPosition12Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition12Taken = true;
				}
				else if (!StatPosition13Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22, 0);
					Stat_BuildingSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition13Taken = true;
				}
				else if (!StatPosition14Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_BuildingSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition14Taken = true;
				}
				else if (!StatPosition15Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition15Taken = true;
				}
				else if (!StatPosition16Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition16Taken = true;
				}
				else if (!StatPosition17Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22, 0);
					Stat_BuildingSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition17Taken = true;
				}
				else if (!StatPosition18Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_BuildingSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition18Taken = true;
				}
				else if (!StatPosition19Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition19Taken = true;
				}
				else if (!StatPosition20Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition20Taken = true;
				}
				else if (!StatPosition21Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22, 0);
					Stat_BuildingSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition21Taken = true;
				}
				else if (!StatPosition22Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_BuildingSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition22Taken = true;
				}
				else if (!StatPosition23Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition23Taken = true;
				}
				else if (!StatPosition24Taken)
				{
					Stat_BuildingSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition24Taken = true;
				}
				else
                {
					Stat_BuildingSpeed.Left.Set(20 - 22, 0);
					Stat_BuildingSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayBuildingSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition25Taken = true;
				}
				StatBuildingSpeed = 1;
            }
			else
			{
				DisplayBuildingSpeed.Left.Set(999999, 0);
                DisplayBuildingSpeed.Top.Set(999999, 0);
				Stat_BuildingSpeed.Left.Set(999999, 0);
				Stat_BuildingSpeed.Top.Set(999999, 0);
				StatBuildingSpeed = 0;
			}
            if (DisplayBuildingWallSpeed.Text != "")
            {
                if (!StatPosition1Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition1Taken = true;
                }
                else if (!StatPosition2Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition2Taken = true;
                }
                else if (!StatPosition3Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition3Taken = true;
                }
                else if (!StatPosition4Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition4Taken = true;
                }
                else if (!StatPosition5Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition5Taken = true;
                }
                else if (!StatPosition6Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition6Taken = true;
                }
                else if (!StatPosition7Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition7Taken = true;
                }
                else if (!StatPosition8Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition8Taken = true;
                }
                else if (!StatPosition9Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
                    StatPosition9Taken = true;
                }
                else if (!StatPosition10Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
                    StatPosition10Taken = true;
                }
                else if (!StatPosition11Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
                    StatPosition11Taken = true;
                }
                else if (!StatPosition12Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
                    StatPosition12Taken = true;
                }
                else if (!StatPosition13Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition13Taken = true;
                }
                else if (!StatPosition14Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition14Taken = true;
                }
                else if (!StatPosition15Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition15Taken = true;
                }
                else if (!StatPosition16Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition16Taken = true;
                }
                else if (!StatPosition17Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition17Taken = true;
                }
                else if (!StatPosition18Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition18Taken = true;
                }
                else if (!StatPosition19Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition19Taken = true;
                }
                else if (!StatPosition20Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition20Taken = true;
                }
                else if (!StatPosition21Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition21Taken = true;
                }
                else if (!StatPosition22Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition22Taken = true;
                }
                else if (!StatPosition23Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition23Taken = true;
                }
                else if (!StatPosition24Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition24Taken = true;
                }
                else if (!StatPosition25Taken)
                {
                    Stat_BuildingWallSpeed.Left.Set(20 - 22, 0);
                    Stat_BuildingWallSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition25Taken = true;
                }
				else
                {
					Stat_BuildingWallSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_BuildingWallSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingWallSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayBuildingWallSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition26Taken = true;
				}
				StatBuildingWallSpeed = 1;
            }
			else
			{
				DisplayBuildingWallSpeed.Left.Set(999999, 0);
                DisplayBuildingWallSpeed.Top.Set(999999, 0);
				Stat_BuildingWallSpeed.Left.Set(999999, 0);
				Stat_BuildingWallSpeed.Top.Set(999999, 0);
				StatBuildingWallSpeed = 0;
			}
            if (DisplayBuildingRange.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22, 0);
					Stat_BuildingRange.Top.Set(279 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_BuildingRange.Top.Set(279 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingRange.Top.Set(279 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingRange.Top.Set(279 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else if (!StatPosition8Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				else if (!StatPosition9Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition9Taken = true;
				}
				else if (!StatPosition10Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition10Taken = true;
				}
				else if (!StatPosition11Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition11Taken = true;
				}
				else if (!StatPosition12Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition12Taken = true;
				}
				else if (!StatPosition13Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition13Taken = true;
				}
				else if (!StatPosition14Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition14Taken = true;
				}
				else if (!StatPosition15Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition15Taken = true;
				}
				else if (!StatPosition16Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition16Taken = true;
				}
				else if (!StatPosition17Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition17Taken = true;
				}
				else if (!StatPosition18Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition18Taken = true;
				}
				else if (!StatPosition19Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition19Taken = true;
				}
				else if (!StatPosition20Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition20Taken = true;
				}
				else if (!StatPosition21Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition21Taken = true;
				}
				else if (!StatPosition22Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition22Taken = true;
				}
				else if (!StatPosition23Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition23Taken = true;
				}
				else if (!StatPosition24Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition24Taken = true;
				}
				else if (!StatPosition25Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition25Taken = true;
				}
				else if (!StatPosition26Taken)
				{
					Stat_BuildingRange.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition26Taken = true;
				}
				else
                {
					Stat_BuildingRange.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_BuildingRange.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayBuildingRange.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayBuildingRange.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition27Taken = true;
				}
				StatBuildingRange = 1;
            }
			else
			{
				DisplayBuildingRange.Left.Set(999999, 0);
                DisplayBuildingRange.Top.Set(999999, 0);
				Stat_BuildingRange.Left.Set(999999, 0);
				Stat_BuildingRange.Top.Set(999999, 0);
				StatBuildingRange = 0;
			}
			if (DisplayArrowDamage.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22, 0);
					Stat_DamageArrow.Top.Set(279 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageArrow.Top.Set(279 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageArrow.Top.Set(279 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageArrow.Top.Set(279 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else if (!StatPosition8Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				else if (!StatPosition9Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition9Taken = true;
				}
				else if (!StatPosition10Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition10Taken = true;
				}
				else if (!StatPosition11Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition11Taken = true;
				}
				else if (!StatPosition12Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition12Taken = true;
				}
				else if (!StatPosition13Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition13Taken = true;
				}
				else if (!StatPosition14Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition14Taken = true;
				}
				else if (!StatPosition15Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition15Taken = true;
				}
				else if (!StatPosition16Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition16Taken = true;
				}
				else if (!StatPosition17Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition17Taken = true;
				}
				else if (!StatPosition18Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition18Taken = true;
				}
				else if (!StatPosition19Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition19Taken = true;
				}
				else if (!StatPosition20Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition20Taken = true;
				}
				else if (!StatPosition21Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition21Taken = true;
				}
				else if (!StatPosition22Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition22Taken = true;
				}
				else if (!StatPosition23Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition23Taken = true;
				}
				else if (!StatPosition24Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition24Taken = true;
				}
				else if (!StatPosition25Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition25Taken = true;
				}
				else if (!StatPosition26Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition26Taken = true;
				}
				else if (!StatPosition27Taken)
				{
					Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition27Taken = true;
				}
				else
                {
					Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageArrow.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayArrowDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayArrowDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition28Taken = true;
				}
				StatArrowDamage = 1;
            }
			else
			{
				DisplayArrowDamage.Left.Set(999999, 0);
                DisplayArrowDamage.Top.Set(999999, 0);
				Stat_DamageArrow.Left.Set(999999, 0);
				Stat_DamageArrow.Top.Set(999999, 0);
				StatArrowDamage = 0;
			}
			if (DisplayMovementSpeed.Text != "")
            {
                if (!StatPosition1Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22, 0);
                    Stat_MovementSpeed.Top.Set(279 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition1Taken = true;
                }
                else if (!StatPosition2Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_MovementSpeed.Top.Set(279 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition2Taken = true;
                }
                else if (!StatPosition3Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_MovementSpeed.Top.Set(279 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition3Taken = true;
                }
                else if (!StatPosition4Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_MovementSpeed.Top.Set(279 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
                    StatPosition4Taken = true;
                }
                else if (!StatPosition5Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition5Taken = true;
                }
                else if (!StatPosition6Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition6Taken = true;
                }
                else if (!StatPosition7Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition7Taken = true;
                }
                else if (!StatPosition8Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
                    StatPosition8Taken = true;
                }
                else if (!StatPosition9Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
                    StatPosition9Taken = true;
                }
                else if (!StatPosition10Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
                    StatPosition10Taken = true;
                }
                else if (!StatPosition11Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
                    StatPosition11Taken = true;
                }
                else if (!StatPosition12Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
                    StatPosition12Taken = true;
                }
                else if (!StatPosition13Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition13Taken = true;
                }
                else if (!StatPosition14Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition14Taken = true;
                }
                else if (!StatPosition15Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition15Taken = true;
                }
                else if (!StatPosition16Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition16Taken = true;
                }
                else if (!StatPosition17Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition17Taken = true;
                }
                else if (!StatPosition18Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition18Taken = true;
                }
                else if (!StatPosition19Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition19Taken = true;
                }
                else if (!StatPosition20Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition20Taken = true;
                }
                else if (!StatPosition21Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition21Taken = true;
                }
                else if (!StatPosition22Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition22Taken = true;
                }
                else if (!StatPosition23Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition23Taken = true;
                }
                else if (!StatPosition24Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition24Taken = true;
                }
                else if (!StatPosition25Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition25Taken = true;
                }
                else if (!StatPosition26Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22 + 64 + 8, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition26Taken = true;
                }
                else if (!StatPosition27Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition27Taken = true;
                }
                else if (!StatPosition28Taken)
                {
                    Stat_MovementSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
                    Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
                    DisplayMovementSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
                    DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
                    StatPosition28Taken = true;
                }
				else
                {
					Stat_MovementSpeed.Left.Set(20 - 22, 0);
					Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayMovementSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayMovementSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition29Taken = true;
				}
				StatMovementSpeed = 1;
            }
			else
			{
				DisplayMovementSpeed.Left.Set(999999, 0);
                DisplayMovementSpeed.Top.Set(999999, 0);
				Stat_MovementSpeed.Left.Set(999999, 0);
				Stat_MovementSpeed.Top.Set(999999, 0);
				StatMovementSpeed = 0;
			}
			if (DisplayJumpSpeed.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22, 0);
					Stat_JumpSpeed.Top.Set(279 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_JumpSpeed.Top.Set(279 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_JumpSpeed.Top.Set(279 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_JumpSpeed.Top.Set(279 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else if (!StatPosition8Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				else if (!StatPosition9Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition9Taken = true;
				}
				else if (!StatPosition10Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition10Taken = true;
				}
				else if (!StatPosition11Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition11Taken = true;
				}
				else if (!StatPosition12Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition12Taken = true;
				}
				else if (!StatPosition13Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition13Taken = true;
				}
				else if (!StatPosition14Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition14Taken = true;
				}
				else if (!StatPosition15Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition15Taken = true;
				}
				else if (!StatPosition16Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition16Taken = true;
				}
				else if (!StatPosition17Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition17Taken = true;
				}
				else if (!StatPosition18Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition18Taken = true;
				}
				else if (!StatPosition19Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition19Taken = true;
				}
				else if (!StatPosition20Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition20Taken = true;
				}
				else if (!StatPosition21Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition21Taken = true;
				}
				else if (!StatPosition22Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition22Taken = true;
				}
				else if (!StatPosition23Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition23Taken = true;
				}
				else if (!StatPosition24Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition24Taken = true;
				}
				else if (!StatPosition25Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition25Taken = true;
				}
				else if (!StatPosition26Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition26Taken = true;
				}
				else if (!StatPosition27Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition27Taken = true;
				}
				else if (!StatPosition28Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition28Taken = true;
				}
				else if (!StatPosition29Taken)
				{
					Stat_JumpSpeed.Left.Set(20 - 22, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition29Taken = true;
				}
				else
                {
					Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayJumpSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayJumpSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition30Taken = true;
				}
				StatJumpSpeed = 1;
            }
			else
			{
				DisplayJumpSpeed.Left.Set(999999, 0);
                DisplayJumpSpeed.Top.Set(999999, 0);
				Stat_JumpSpeed.Left.Set(999999, 0);
				Stat_JumpSpeed.Top.Set(999999, 0);
				StatJumpSpeed = 0;
			}
			if (DisplayFallDamageResistance.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22, 0);
					Stat_FallDamageResistance.Top.Set(279 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else if (!StatPosition8Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				else if (!StatPosition9Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition9Taken = true;
				}
				else if (!StatPosition10Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition10Taken = true;
				}
				else if (!StatPosition11Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition11Taken = true;
				}
				else if (!StatPosition12Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition12Taken = true;
				}
				else if (!StatPosition13Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition13Taken = true;
				}
				else if (!StatPosition14Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition14Taken = true;
				}
				else if (!StatPosition15Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition15Taken = true;
				}
				else if (!StatPosition16Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition16Taken = true;
				}
				else if (!StatPosition17Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition17Taken = true;
				}
				else if (!StatPosition18Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition18Taken = true;
				}
				else if (!StatPosition19Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition19Taken = true;
				}
				else if (!StatPosition20Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition20Taken = true;
				}
				else if (!StatPosition21Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition21Taken = true;
				}
				else if (!StatPosition22Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition22Taken = true;
				}
				else if (!StatPosition23Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition23Taken = true;
				}
				else if (!StatPosition24Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition24Taken = true;
				}
				else if (!StatPosition25Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition25Taken = true;
				}
				else if (!StatPosition26Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition26Taken = true;
				}
				else if (!StatPosition27Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition27Taken = true;
				}
				else if (!StatPosition28Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition28Taken = true;
				}
				else if (!StatPosition29Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition29Taken = true;
				}
				else if (!StatPosition30Taken)
				{
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition30Taken = true;
				}
				else
                {
					Stat_FallDamageResistance.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_FallDamageResistance.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFallDamageResistance.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayFallDamageResistance.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition31Taken = true;
				}
				StatFallDamageResistance = 1;
            }
			else
			{
				DisplayFallDamageResistance.Left.Set(999999, 0);
                DisplayFallDamageResistance.Top.Set(999999, 0);
				Stat_FallDamageResistance.Left.Set(999999, 0);
				Stat_FallDamageResistance.Top.Set(999999, 0);
				StatFallDamageResistance = 0;
			}
			if (DisplayAllDamage.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22, 0);
					Stat_DamageAll.Top.Set(279 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else if (!StatPosition8Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				else if (!StatPosition9Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition9Taken = true;
				}
				else if (!StatPosition10Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition10Taken = true;
				}
				else if (!StatPosition11Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition11Taken = true;
				}
				else if (!StatPosition12Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition12Taken = true;
				}
				else if (!StatPosition13Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition13Taken = true;
				}
				else if (!StatPosition14Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition14Taken = true;
				}
				else if (!StatPosition15Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition15Taken = true;
				}
				else if (!StatPosition16Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition16Taken = true;
				}
				else if (!StatPosition17Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition17Taken = true;
				}
				else if (!StatPosition18Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition18Taken = true;
				}
				else if (!StatPosition19Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition19Taken = true;
				}
				else if (!StatPosition20Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition20Taken = true;
				}
				else if (!StatPosition21Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition21Taken = true;
				}
				else if (!StatPosition22Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition22Taken = true;
				}
				else if (!StatPosition23Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition23Taken = true;
				}
				else if (!StatPosition24Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition24Taken = true;
				}
				else if (!StatPosition25Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition25Taken = true;
				}
				else if (!StatPosition26Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition26Taken = true;
				}
				else if (!StatPosition27Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition27Taken = true;
				}
				else if (!StatPosition28Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition28Taken = true;
				}
				else if (!StatPosition29Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition29Taken = true;
				}
				else if (!StatPosition30Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition30Taken = true;
				}
				else if (!StatPosition31Taken)
				{
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition31Taken = true;
				}
				else
                {
					Stat_DamageAll.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_DamageAll.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAllDamage.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayAllDamage.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition32Taken = true;
				}
				StatAllDamage = 1;
            }
			else
			{
				DisplayAllDamage.Left.Set(999999, 0);
                DisplayAllDamage.Top.Set(999999, 0);
				Stat_DamageAll.Left.Set(999999, 0);
				Stat_DamageAll.Top.Set(999999, 0);
				StatAllDamage = 0;
			}
			if (DisplayFishingSkill.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22, 0);
					Stat_FishingSkill.Top.Set(279 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else if (!StatPosition8Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				else if (!StatPosition9Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition9Taken = true;
				}
				else if (!StatPosition10Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition10Taken = true;
				}
				else if (!StatPosition11Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition11Taken = true;
				}
				else if (!StatPosition12Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition12Taken = true;
				}
				else if (!StatPosition13Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition13Taken = true;
				}
				else if (!StatPosition14Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition14Taken = true;
				}
				else if (!StatPosition15Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition15Taken = true;
				}
				else if (!StatPosition16Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition16Taken = true;
				}
				else if (!StatPosition17Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition17Taken = true;
				}
				else if (!StatPosition18Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition18Taken = true;
				}
				else if (!StatPosition19Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition19Taken = true;
				}
				else if (!StatPosition20Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition20Taken = true;
				}
				else if (!StatPosition21Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition21Taken = true;
				}
				else if (!StatPosition22Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition22Taken = true;
				}
				else if (!StatPosition23Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition23Taken = true;
				}
				else if (!StatPosition24Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition24Taken = true;
				}
				else if (!StatPosition25Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition25Taken = true;
				}
				else if (!StatPosition26Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition26Taken = true;
				}
				else if (!StatPosition27Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition27Taken = true;
				}
				else if (!StatPosition28Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition28Taken = true;
				}
				else if (!StatPosition29Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition29Taken = true;
				}
				else if (!StatPosition30Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition30Taken = true;
				}
				else if (!StatPosition31Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition31Taken = true;
				}
				else if (!StatPosition32Taken)
				{
					Stat_FishingSkill.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition32Taken = true;
				}
				else
                {
					Stat_FishingSkill.Left.Set(20 - 22, 0);
					Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayFishingSkill.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayFishingSkill.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition33Taken = true;
				}
				StatFishingSkill = 1;
            }
			else
			{
				DisplayFishingSkill.Left.Set(999999, 0);
                DisplayFishingSkill.Top.Set(999999, 0);
				Stat_FishingSkill.Left.Set(999999, 0);
				Stat_FishingSkill.Top.Set(999999, 0);
				StatFishingSkill = 0;
			}
			if (DisplayAggro.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_Aggro.Left.Set(20 - 22, 0);
					Stat_Aggro.Top.Set(279 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_Aggro.Left.Set(20 - 22, 0);
					Stat_Aggro.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else if (!StatPosition8Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				else if (!StatPosition9Taken)
				{
					Stat_Aggro.Left.Set(20 - 22, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition9Taken = true;
				}
				else if (!StatPosition10Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition10Taken = true;
				}
				else if (!StatPosition11Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition11Taken = true;
				}
				else if (!StatPosition12Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition12Taken = true;
				}
				else if (!StatPosition13Taken)
				{
					Stat_Aggro.Left.Set(20 - 22, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition13Taken = true;
				}
				else if (!StatPosition14Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition14Taken = true;
				}
				else if (!StatPosition15Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition15Taken = true;
				}
				else if (!StatPosition16Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition16Taken = true;
				}
				else if (!StatPosition17Taken)
				{
					Stat_Aggro.Left.Set(20 - 22, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition17Taken = true;
				}
				else if (!StatPosition18Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition18Taken = true;
				}
				else if (!StatPosition19Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition19Taken = true;
				}
				else if (!StatPosition20Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition20Taken = true;
				}
				else if (!StatPosition21Taken)
				{
					Stat_Aggro.Left.Set(20 - 22, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition21Taken = true;
				}
				else if (!StatPosition22Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition22Taken = true;
				}
				else if (!StatPosition23Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition23Taken = true;
				}
				else if (!StatPosition24Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition24Taken = true;
				}
				else if (!StatPosition25Taken)
				{
					Stat_Aggro.Left.Set(20 - 22, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition25Taken = true;
				}
				else if (!StatPosition26Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition26Taken = true;
				}
				else if (!StatPosition27Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition27Taken = true;
				}
				else if (!StatPosition28Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition28Taken = true;
				}
				else if (!StatPosition29Taken)
				{
					Stat_Aggro.Left.Set(20 - 22, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition29Taken = true;
				}
				else if (!StatPosition30Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition30Taken = true;
				}
				else if (!StatPosition31Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition31Taken = true;
				}
				else if (!StatPosition32Taken)
				{
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition32Taken = true;
				}
				else if (!StatPosition33Taken)
				{
					Stat_Aggro.Left.Set(20 - 22, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition33Taken = true;
				}
				else
                {
					Stat_Aggro.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayAggro.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayAggro.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition34Taken = true;
				}
				StatAggro = 1;
            }
			else
			{
				DisplayAggro.Left.Set(999999, 0);
                DisplayAggro.Top.Set(999999, 0);
				Stat_Aggro.Left.Set(999999, 0);
				Stat_Aggro.Top.Set(999999, 0);
				StatAggro = 0;
			}
			if (DisplayRunSpeed.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22, 0);
					Stat_RunSpeed.Top.Set(279 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else if (!StatPosition8Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				else if (!StatPosition9Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition9Taken = true;
				}
				else if (!StatPosition10Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition10Taken = true;
				}
				else if (!StatPosition11Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition11Taken = true;
				}
				else if (!StatPosition12Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition12Taken = true;
				}
				else if (!StatPosition13Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition13Taken = true;
				}
				else if (!StatPosition14Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition14Taken = true;
				}
				else if (!StatPosition15Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition15Taken = true;
				}
				else if (!StatPosition16Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition16Taken = true;
				}
				else if (!StatPosition17Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition17Taken = true;
				}
				else if (!StatPosition18Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition18Taken = true;
				}
				else if (!StatPosition19Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition19Taken = true;
				}
				else if (!StatPosition20Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition20Taken = true;
				}
				else if (!StatPosition21Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition21Taken = true;
				}
				else if (!StatPosition22Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition22Taken = true;
				}
				else if (!StatPosition23Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition23Taken = true;
				}
				else if (!StatPosition24Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition24Taken = true;
				}
				else if (!StatPosition25Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition25Taken = true;
				}
				else if (!StatPosition26Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition26Taken = true;
				}
				else if (!StatPosition27Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition27Taken = true;
				}
				else if (!StatPosition28Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition28Taken = true;
				}
				else if (!StatPosition29Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition29Taken = true;
				}
				else if (!StatPosition30Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition30Taken = true;
				}
				else if (!StatPosition31Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition31Taken = true;
				}
				else if (!StatPosition32Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition32Taken = true;
				}
				else if (!StatPosition33Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition33Taken = true;
				}
				else if (!StatPosition34Taken)
				{
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition34Taken = true;
				}
				else
                {
					Stat_RunSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_RunSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunSpeed.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRunSpeed.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition35Taken = true;
				}
				StatRunSpeed = 1;
            }
			else
			{
				DisplayRunSpeed.Left.Set(999999, 0);
                DisplayRunSpeed.Top.Set(999999, 0);
				Stat_RunSpeed.Left.Set(999999, 0);
				Stat_RunSpeed.Top.Set(999999, 0);
				StatRunSpeed = 0;
			}
            if (DisplayRunAcceleration.Text != "")
            {
				if (!StatPosition1Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22, 0);
					Stat_RunAcceleration.Top.Set(279 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition1Taken = true;
				}
				else if (!StatPosition2Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition2Taken = true;
				}
				else if (!StatPosition3Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition3Taken = true;
				}
				else if (!StatPosition4Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 132 - 90, 0);
					StatPosition4Taken = true;
				}
				else if (!StatPosition5Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition5Taken = true;
				}
				else if (!StatPosition6Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition6Taken = true;
				}
				else if (!StatPosition7Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition7Taken = true;
				}
				else if (!StatPosition8Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 132 - 90, 0);
					StatPosition8Taken = true;
				}
				else if (!StatPosition9Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition9Taken = true;
				}
				else if (!StatPosition10Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition10Taken = true;
				}
				else if (!StatPosition11Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition11Taken = true;
				}
				else if (!StatPosition12Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 132 - 90, 0);
					StatPosition12Taken = true;
				}
				else if (!StatPosition13Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition13Taken = true;
				}
				else if (!StatPosition14Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition14Taken = true;
				}
				else if (!StatPosition15Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition15Taken = true;
				}
				else if (!StatPosition16Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition16Taken = true;
				}
				else if (!StatPosition17Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition17Taken = true;
				}
				else if (!StatPosition18Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition18Taken = true;
				}
				else if (!StatPosition19Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition19Taken = true;
				}
				else if (!StatPosition20Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition20Taken = true;
				}
				else if (!StatPosition21Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition21Taken = true;
				}
				else if (!StatPosition22Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition22Taken = true;
				}
				else if (!StatPosition23Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition23Taken = true;
				}
				else if (!StatPosition24Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition24Taken = true;
				}
				else if (!StatPosition25Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition25Taken = true;
				}
				else if (!StatPosition26Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition26Taken = true;
				}
				else if (!StatPosition27Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition27Taken = true;
				}
				else if (!StatPosition28Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition28Taken = true;
				}
				else if (!StatPosition29Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition29Taken = true;
				}
				else if (!StatPosition30Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition30Taken = true;
				}
				else if (!StatPosition31Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition31Taken = true;
				}
				else if (!StatPosition32Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition32Taken = true;
				}
				else if (!StatPosition33Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition33Taken = true;
				}
				else if (!StatPosition34Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition34Taken = true;
				}
				else if (!StatPosition35Taken)
				{
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition35Taken = true;
				}
				else
                {
					Stat_RunAcceleration.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
					Stat_RunAcceleration.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
					DisplayRunAcceleration.Left.Set(10 + 20 - 22 + 72 + 72 + 72 - 10 + 7, 0);
					DisplayRunAcceleration.Top.Set(-10 + 279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 90, 0);
					StatPosition36Taken = true;
				}
				StatRunAcceleration = 1;
            }
            else
            {
				DisplayRunAcceleration.Left.Set(999999, 0);
                DisplayRunAcceleration.Top.Set(999999, 0);
				Stat_RunAcceleration.Left.Set(999999, 0);
				Stat_RunAcceleration.Top.Set(999999, 0);
				StatRunAcceleration = 0;
            }
			RaceStatAmount = (StatHealth + StatRegeneration + StatMana + StatManaRegeneration + StatDefense + StatDamageReduction + StatArrowDamage + StatLavaResistance + StatAllDamage + StatMeleeDamage + StatRangedDamage + StatMagicDamage + StatSummonDamage + StatMeleeSpeed + StatArmorPenetration + StatBulletDamage + StatRocketDamage + StatManaCost + StatMinionKnockback + StatMinions + StatSentries + StatMeleeCritChance + StatRangedCritChance + StatMagicCritChance + StatMiningSpeed + StatBuildingSpeed + StatBuildingRange + StatBuildingWallSpeed + StatThorns + StatMovementSpeed + StatJumpSpeed + StatFallDamageResistance + StatFishingSkill + StatAggro + StatRunSpeed + StatRunAcceleration);
			if (RaceStatAmount <= 0)
			{
				UI_DecorativeLine_StatBox3.Top.Set(129 - 124 + 108 + 156 + 260 + 132 - 92 - 260, 0);
				Environment_GoodBiomes.Top.Set(539 + 132 - 92 - 260, 0);
				Environment_BadBiomes.Top.Set(539 + 34 + 132 - 92 - 260, 0);
				DisplayGoodBiomes.Top.Set(-6 + 539 + 132 - 92 - 260 + 2, 0);
				DisplayBadBiomes.Top.Set(-6 + 539 + 34 + 132 - 92 - 260 + 2, 0);
			}
			else if (RaceStatAmount < 5 && RaceStatAmount > 0)
			{
				UI_DecorativeLine_StatBox3.Top.Set(129 - 124 + 108 + 156 + 260 + 132 - 92 - 28 - 28 - 28 - 28 - 28 - 28 - 28 - 28, 0);
				Environment_GoodBiomes.Top.Set(539 + 132 - 92 - 28 - 28 - 28 - 28 - 28 - 28 - 28 - 28, 0);
				Environment_BadBiomes.Top.Set(539 + 34 + 132 - 92 - 28 - 28 - 28 - 28 - 28 - 28 - 28 - 28, 0);
				DisplayGoodBiomes.Top.Set(-6 + 539 + 132 - 92 - 28 - 28 - 28 - 28 - 28 - 28 - 28 - 28 + 2, 0);
				DisplayBadBiomes.Top.Set(-6 + 539 + 34 + 132 - 92 - 28 - 28 - 28 - 28 - 28 - 28 - 28 - 28 + 2, 0);
			}
			else if (RaceStatAmount < 9 && RaceStatAmount > 4)
			{
				UI_DecorativeLine_StatBox3.Top.Set(129 - 124 + 108 + 156 + 260 + 132 - 92 - 28 - 28 - 28 - 28 - 28 - 28 - 28, 0);
				Environment_GoodBiomes.Top.Set(539 + 132 - 92 - 28 - 28 - 28 - 28 - 28 - 28 - 28, 0);
				Environment_BadBiomes.Top.Set(539 + 34 + 132 - 92 - 28 - 28 - 28 - 28 - 28 - 28 - 28, 0);
				DisplayGoodBiomes.Top.Set(-6 + 539 + 132 - 92 - 28 - 28 - 28 - 28 - 28 - 28 - 28 + 2, 0);
				DisplayBadBiomes.Top.Set(-6 + 539 + 34 + 132 - 92 - 28 - 28 - 28 - 28 - 28 - 28 - 28 + 2, 0);
			}
			else if (RaceStatAmount < 13 && RaceStatAmount > 8)
			{
				UI_DecorativeLine_StatBox3.Top.Set(129 - 124 + 108 + 156 + 260 + 132 - 92 - 28 - 28 - 28 - 28 - 28 - 28, 0);
				Environment_GoodBiomes.Top.Set(539 + 132 - 92 - 28 - 28 - 28 - 28 - 28 - 28, 0);
				Environment_BadBiomes.Top.Set(539 + 34 + 132 - 92 - 28 - 28 - 28 - 28 - 28 - 28, 0);
				DisplayGoodBiomes.Top.Set(-6 + 539 + 132 - 92 - 28 - 28 - 28 - 28 - 28 - 28 + 2, 0);
				DisplayBadBiomes.Top.Set(-6 + 539 + 34 + 132 - 92 - 28 - 28 - 28 - 28 - 28 - 28 + 2, 0);
			}
			else if (RaceStatAmount < 17 && RaceStatAmount > 12)
			{
				UI_DecorativeLine_StatBox3.Top.Set(129 - 124 + 108 + 156 + 260 + 132 - 92 - 28 - 28 - 28 - 28 - 28, 0);
				Environment_GoodBiomes.Top.Set(539 + 132 - 92 - 28 - 28 - 28 - 28 - 28, 0);
				Environment_BadBiomes.Top.Set(539 + 34 + 132 - 92 - 28 - 28 - 28 - 28 - 28, 0);
				DisplayGoodBiomes.Top.Set(-6 + 539 + 132 - 92 - 28 - 28 - 28 - 28 - 28 + 2, 0);
				DisplayBadBiomes.Top.Set(-6 + 539 + 34 + 132 - 92 - 28 - 28 - 28 - 28 - 28 + 2, 0);
			}
			else if (RaceStatAmount < 21 && RaceStatAmount > 16)
			{
				UI_DecorativeLine_StatBox3.Top.Set(129 - 124 + 108 + 156 + 260 + 132 - 92 - 28 - 28 - 28 - 28, 0);
				Environment_GoodBiomes.Top.Set(539 + 132 - 92 - 28 - 28 - 28 - 28, 0);
				Environment_BadBiomes.Top.Set(539 + 34 + 132 - 92 - 28 - 28 - 28 - 28, 0);
				DisplayGoodBiomes.Top.Set(-6 + 539 + 132 - 92 - 28 - 28 - 28 - 28 + 2, 0);
				DisplayBadBiomes.Top.Set(-6 + 539 + 34 + 132 - 92 - 28 - 28 - 28 - 28 + 2, 0);
			}
			else if (RaceStatAmount < 25 && RaceStatAmount > 20)
			{
				UI_DecorativeLine_StatBox3.Top.Set(129 - 124 + 108 + 156 + 260 + 132 - 92 - 28 - 28 - 28, 0);
				Environment_GoodBiomes.Top.Set(539 + 132 - 92 - 28 - 28 - 28, 0);
				Environment_BadBiomes.Top.Set(539 + 34 + 132 - 92 - 28 - 28 - 28, 0);
				DisplayGoodBiomes.Top.Set(-6 + 539 + 132 - 92 - 28 - 28 - 28 + 2, 0);
				DisplayBadBiomes.Top.Set(-6 + 539 + 34 + 132 - 92 - 28 - 28 - 28 + 2, 0);
			}
			else if (RaceStatAmount < 29 && RaceStatAmount > 24)
			{
				UI_DecorativeLine_StatBox3.Top.Set(129 - 124 + 108 + 156 + 260 + 132 - 92 - 28 - 28, 0);
				Environment_GoodBiomes.Top.Set(539 + 132 - 92 - 28 - 28, 0);
				Environment_BadBiomes.Top.Set(539 + 34 + 132 - 92 - 28 - 28, 0);
				DisplayGoodBiomes.Top.Set(-6 + 539 + 132 - 92 - 28 - 28 + 2, 0);
				DisplayBadBiomes.Top.Set(-6 + 539 + 34 + 132 - 92 - 28 - 28 + 2, 0);
			}
			else if (RaceStatAmount < 33 && RaceStatAmount > 28)
			{
				UI_DecorativeLine_StatBox3.Top.Set(129 - 124 + 108 + 156 + 260 + 132 - 92 - 28, 0);
				Environment_GoodBiomes.Top.Set(539 + 132 - 92 - 28, 0);
				Environment_BadBiomes.Top.Set(539 + 34 + 132 - 92 - 28, 0);
				DisplayGoodBiomes.Top.Set(-6 + 539 + 132 - 92 - 28 + 2, 0);
				DisplayBadBiomes.Top.Set(-6 + 539 + 34 + 132 - 92 - 28 + 2, 0);
			}
			else if (RaceStatAmount > 32)
			{
				UI_DecorativeLine_StatBox3.Top.Set(129 - 124 + 108 + 156 + 260 + 132 - 92, 0);
				Environment_GoodBiomes.Top.Set(539 + 132 - 92, 0);
				Environment_BadBiomes.Top.Set(539 + 34 + 132 - 92, 0);
				DisplayGoodBiomes.Top.Set(-6 + 539 + 132 - 92 + 2, 0);
				DisplayBadBiomes.Top.Set(-6 + 539 + 34 + 132 - 92 + 2, 0);
			}
			MrPlagueRaceBackground.Left.Set(modPlayer.MrPlagueRaceInfoMouseX, 0);
            MrPlagueRaceBackground.Top.Set(modPlayer.MrPlagueRaceInfoMouseY, 0);
			if (!modPlayer.MrPlagueRaceInfo)
            {
				MrPlagueRaceBackground.Left.Set(999999, 0);
                MrPlagueRaceBackground.Top.Set(999999, 0);

			}
			Recalculate();
		}
	}
}