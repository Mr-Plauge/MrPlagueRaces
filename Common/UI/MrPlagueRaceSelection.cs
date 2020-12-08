using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.UI;
using Terraria.ModLoader;
using MrPlagueRaces.Common.Races;
using MrPlagueRaces.Common.Races.Humans;
using MrPlagueRaces.Common.Races.Goblins;
using MrPlagueRaces.Common.Races.Kenkus;
using MrPlagueRaces.Common.Races.Tabaxis;
using MrPlagueRaces.Common.Races.Dragonkins;
using MrPlagueRaces.Common.Races.Merfolks;
using MrPlagueRaces.Common.Races.Mushfolks;
using MrPlagueRaces.Common.Races.Derpkins;
using MrPlagueRaces.Common.Races.Kobolds;
using MrPlagueRaces.Common.Races.Skeletons;
using MrPlagueRaces.Common.Races.Vampires;
using MrPlagueRaces.Common.Races.Fluftrodons;
using static Terraria.ModLoader.ModContent;

namespace MrPlagueRaces.Common.UI
{
	public class MrPlagueRaceSelection : UIState
	{
        public UIPanel MrPlagueRaceBackground;
        public UIPanel MrPlagueRaceStatDisplayBackground;
		public UIPanel MrPlagueRaceAbilityDisplayBackground;
		public static string RaceHoverTextString = ("");
        private int RaceIndex = 0;
		UITextPanel<string> HoverText = new UITextPanel<string>("");
		UITextPanel<string> RaceNameDisplay = new UITextPanel<string>("");
		UITextPanel<string> Lore1Description = new UITextPanel<string>("");
		UITextPanel<string> Lore2Description = new UITextPanel<string>("");
		UITextPanel<string> Ability1 = new UITextPanel<string>("");
        UITextPanel<string> Ability2 = new UITextPanel<string>("");
		UITextPanel<string> Ability3 = new UITextPanel<string>("");
		UITextPanel<string> Ability1Description = new UITextPanel<string>("");
		UITextPanel<string> Ability2Description = new UITextPanel<string>("");
		UITextPanel<string> Ability3Description = new UITextPanel<string>("");

        public override void OnInitialize()
        {
            Width.Set(Main.screenWidth, 0);
            Height.Set(Main.screenHeight, 0);
            Top.Set(0, 0);
            Left.Set(0, 0);

            MrPlagueRaceBackground = new UIPanel();
            MrPlagueRaceBackground.HAlign = 0.5f;
            MrPlagueRaceBackground.VAlign = 0.4f;
            MrPlagueRaceBackground.Width.Set(1600, 0);
            MrPlagueRaceBackground.Height.Set(800, 0);
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
            MrPlagueRaceAbilityDisplayBackground.Width.Set(1216, 0);
            MrPlagueRaceAbilityDisplayBackground.Height.Set(740, 0);
            MrPlagueRaceAbilityDisplayBackground.Left.Set(350, 0);
            MrPlagueRaceAbilityDisplayBackground.Top.Set(20, 0);
            MrPlagueRaceAbilityDisplayBackground.BackgroundColor = new Color(72, 94, 170);
            MrPlagueRaceBackground.Append(MrPlagueRaceAbilityDisplayBackground);

            UITextPanel<string> SelectRace = new UITextPanel<string>("Select Race", 0.8f, true);
            SelectRace.HAlign = 0.5f;
            SelectRace.VAlign = 0.25f;
            SelectRace.Top.Set(-130f, 0);
            SelectRace.BackgroundColor = new Color(73, 94, 171);
            Append(SelectRace);

            UITextPanel<string> MrPlagueRaceSelectionBackButton = new UITextPanel<string>("Back", 0.7f, true);
            MrPlagueRaceSelectionBackButton.HAlign = 0.5f;
            MrPlagueRaceSelectionBackButton.VAlign = 0.4f;
            MrPlagueRaceSelectionBackButton.Width.Set(315f, 0f);
            MrPlagueRaceSelectionBackButton.Height.Set(50f, 0f);
            MrPlagueRaceSelectionBackButton.Left.Set(-642, 0);
            MrPlagueRaceSelectionBackButton.Top.Set(+515, 0);
            MrPlagueRaceSelectionBackButton.OnMouseOver += new MouseEvent(FadedMouseOver);
            MrPlagueRaceSelectionBackButton.OnMouseOut += new MouseEvent(FadedMouseOut);
            MrPlagueRaceSelectionBackButton.OnClick += new MouseEvent(MrPlagueRaceSelectionBack);
            Append(MrPlagueRaceSelectionBackButton);

            UITextPanel<string> MrPlagueRaceSelectionProceedButton = new UITextPanel<string>("Proceed", 0.7f, true);
            MrPlagueRaceSelectionProceedButton.HAlign = 0.5f;
            MrPlagueRaceSelectionProceedButton.VAlign = 0.4f;
            MrPlagueRaceSelectionProceedButton.Width.Set(315f, 0f);
            MrPlagueRaceSelectionProceedButton.Height.Set(50f, 0f);
            MrPlagueRaceSelectionProceedButton.Left.Set(+643, 0);
            MrPlagueRaceSelectionProceedButton.Top.Set(+515, 0);
            MrPlagueRaceSelectionProceedButton.OnMouseOver += new MouseEvent(FadedMouseOver);
            MrPlagueRaceSelectionProceedButton.OnMouseOut += new MouseEvent(FadedMouseOut);
            MrPlagueRaceSelectionProceedButton.OnClick += new MouseEvent(MrPlagueRaceSelectionProceed);
            Append(MrPlagueRaceSelectionProceedButton);

            Texture2D UI_ButtonPreviousIcon = GetTexture("MrPlagueRaces/Common/UI/UI_ButtonPrevious");
            MrPlagueRaceButton UI_ButtonPrevious = new MrPlagueRaceButton(UI_ButtonPreviousIcon);
            UI_ButtonPrevious.Width.Set(56, 0);
            UI_ButtonPrevious.Height.Set(56, 0);
            UI_ButtonPrevious.Left.Set(10, 0);
            UI_ButtonPrevious.Top.Set(129 - 124, 0);
			UI_ButtonPrevious.OnClick += new MouseEvent(UI_ButtonPrevious_Clicked);
            MrPlagueRaceBackground.Append(UI_ButtonPrevious);

            Texture2D UI_ButtonNextIcon = GetTexture("MrPlagueRaces/Common/UI/UI_ButtonNext");
            MrPlagueRaceButton UI_ButtonNext = new MrPlagueRaceButton(UI_ButtonNextIcon);
            UI_ButtonNext.Width.Set(56, 0);
            UI_ButtonNext.Height.Set(56, 0);
            UI_ButtonNext.Left.Set(80, 0);
            UI_ButtonNext.Top.Set(129 - 124, 0);
            UI_ButtonNext.OnClick += new MouseEvent(UI_ButtonNext_Clicked);
            MrPlagueRaceBackground.Append(UI_ButtonNext);

            Texture2D UI_ButtonRandomIcon = GetTexture("MrPlagueRaces/Common/UI/UI_ButtonRandom");
            MrPlagueRaceButton UI_ButtonRandom = new MrPlagueRaceButton(UI_ButtonRandomIcon);
            UI_ButtonRandom.Width.Set(56, 0);
            UI_ButtonRandom.Height.Set(56, 0);
            UI_ButtonRandom.Left.Set(80 + 70, 0);
            UI_ButtonRandom.Top.Set(129 - 124, 0);
            UI_ButtonRandom.OnClick += new MouseEvent(UI_ButtonRandom_Clicked);
            MrPlagueRaceBackground.Append(UI_ButtonRandom);

            Texture2D UI_DecorativeLine_StatBoxIcon = GetTexture("MrPlagueRaces/Common/UI/UI_DecorativeLine_StatBox");
            MrPlagueRaceImage UI_DecorativeLine_StatBox1 = new MrPlagueRaceImage(UI_DecorativeLine_StatBoxIcon, "");
            UI_DecorativeLine_StatBox1.Width.Set(280, 0);
            UI_DecorativeLine_StatBox1.Height.Set(4, 0);
            UI_DecorativeLine_StatBox1.Left.Set(20 - 22, 0);
            UI_DecorativeLine_StatBox1.Top.Set(129 - 124 + 108 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(UI_DecorativeLine_StatBox1);

            MrPlagueRaceImage UI_DecorativeLine_StatBox2 = new MrPlagueRaceImage(UI_DecorativeLine_StatBoxIcon, "");
            UI_DecorativeLine_StatBox2.Width.Set(280, 0);
            UI_DecorativeLine_StatBox2.Height.Set(4, 0);
            UI_DecorativeLine_StatBox2.Left.Set(20 - 22, 0);
            UI_DecorativeLine_StatBox2.Top.Set(129 - 124 + 108 + 156 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(UI_DecorativeLine_StatBox2);

            MrPlagueRaceImage UI_DecorativeLine_StatBox3 = new MrPlagueRaceImage(UI_DecorativeLine_StatBoxIcon, "");
            UI_DecorativeLine_StatBox3.Width.Set(280, 0);
            UI_DecorativeLine_StatBox3.Height.Set(4, 0);
            UI_DecorativeLine_StatBox3.Left.Set(20 - 22, 0);
            UI_DecorativeLine_StatBox3.Top.Set(129 - 124 + 108 + 156 + 260 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(UI_DecorativeLine_StatBox3);

            MrPlagueRaceImage UI_DecorativeLine_StatBox4 = new MrPlagueRaceImage(UI_DecorativeLine_StatBoxIcon, "");
            UI_DecorativeLine_StatBox4.Width.Set(280, 0);
            UI_DecorativeLine_StatBox4.Height.Set(4, 0);
            UI_DecorativeLine_StatBox4.Left.Set(20 - 22, 0);
            UI_DecorativeLine_StatBox4.Top.Set(129 - 124 + 108 + 156 + 260 + 76 + 132 - 468 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(UI_DecorativeLine_StatBox4);

            Texture2D UI_DecorativeLine_AbilityBoxIcon = GetTexture("MrPlagueRaces/Common/UI/UI_DecorativeLine_AbilityBox");
            MrPlagueRaceImage UI_DecorativeLine_AbilityBox1 = new MrPlagueRaceImage(UI_DecorativeLine_AbilityBoxIcon, "");
            UI_DecorativeLine_AbilityBox1.Width.Set(1196, 0);
            UI_DecorativeLine_AbilityBox1.Height.Set(4, 0);
            UI_DecorativeLine_AbilityBox1.Left.Set(360 - 362, 0);
            UI_DecorativeLine_AbilityBox1.Top.Set(129 - 124 + 108 - 59 - 34, 0);
			MrPlagueRaceAbilityDisplayBackground.Append(UI_DecorativeLine_AbilityBox1);

            MrPlagueRaceImage UI_DecorativeLine_AbilityBox2 = new MrPlagueRaceImage(UI_DecorativeLine_AbilityBoxIcon, "");
            UI_DecorativeLine_AbilityBox2.Width.Set(1196, 0);
            UI_DecorativeLine_AbilityBox2.Height.Set(4, 0);
            UI_DecorativeLine_AbilityBox2.Left.Set(360 - 362, 0);
            UI_DecorativeLine_AbilityBox2.Top.Set(129 - 124 + 108 + 169 - 34, 0);
			MrPlagueRaceAbilityDisplayBackground.Append(UI_DecorativeLine_AbilityBox2);

            MrPlagueRaceImage UI_DecorativeLine_AbilityBox3 = new MrPlagueRaceImage(UI_DecorativeLine_AbilityBoxIcon, "");
            UI_DecorativeLine_AbilityBox3.Width.Set(1196, 0);
            UI_DecorativeLine_AbilityBox3.Height.Set(4, 0);
            UI_DecorativeLine_AbilityBox3.Left.Set(360 - 362, 0);
            UI_DecorativeLine_AbilityBox3.Top.Set(129 - 124 + 108 + 156 + 260 - 19 - 34, 0);
			MrPlagueRaceAbilityDisplayBackground.Append(UI_DecorativeLine_AbilityBox3);

            Texture2D UI_LoreBoxIcon = GetTexture("MrPlagueRaces/Common/UI/UI_LoreBox");
            MrPlagueRaceImage UI_LoreBox = new MrPlagueRaceImage(UI_LoreBoxIcon, "");
            UI_LoreBox.Width.Set(172, 0);
            UI_LoreBox.Height.Set(138, 0);
            UI_LoreBox.Left.Set(128 - 22, 0);
            UI_LoreBox.Top.Set(129 - 124 + 120 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(UI_LoreBox);

            Texture2D UI_LoreBox2Icon = GetTexture("MrPlagueRaces/Common/UI/UI_LoreBox2");
            MrPlagueRaceImage UI_LoreBox2 = new MrPlagueRaceImage(UI_LoreBox2Icon, "");
            UI_LoreBox2.Width.Set(280, 0);
            UI_LoreBox2.Height.Set(116, 0);
            UI_LoreBox2.Left.Set(20 - 22, 0);
            UI_LoreBox2.Top.Set(615 - 336 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(UI_LoreBox2);

            Texture2D UI_AbilityBoxIcon = GetTexture("MrPlagueRaces/Common/UI/UI_AbilityBox");
            MrPlagueRaceImage UI_AbilityBox1 = new MrPlagueRaceImage(UI_AbilityBoxIcon, "");
            UI_AbilityBox1.Width.Set(1196, 0);
            UI_AbilityBox1.Height.Set(188, 0);
            UI_AbilityBox1.Left.Set(360 - 362, 0);
            UI_AbilityBox1.Top.Set(129 - 124 + 120 - 61 - 34, 0);
			MrPlagueRaceAbilityDisplayBackground.Append(UI_AbilityBox1);

            MrPlagueRaceImage UI_AbilityBox2 = new MrPlagueRaceImage(UI_AbilityBoxIcon, "");
            UI_AbilityBox2.Width.Set(1196, 0);
            UI_AbilityBox2.Height.Set(188, 0);
            UI_AbilityBox2.Left.Set(360 - 362, 0);
            UI_AbilityBox2.Top.Set(129 - 124 + 120 - 61 + 228 - 34, 0);
			MrPlagueRaceAbilityDisplayBackground.Append(UI_AbilityBox2);

            MrPlagueRaceImage UI_AbilityBox3 = new MrPlagueRaceImage(UI_AbilityBoxIcon, "");
            UI_AbilityBox3.Width.Set(1196, 0);
            UI_AbilityBox3.Height.Set(188, 0);
            UI_AbilityBox3.Left.Set(360 - 362, 0);
            UI_AbilityBox3.Top.Set(129 - 124 + 120 - 61 + 228 + 228 - 34, 0);
			MrPlagueRaceAbilityDisplayBackground.Append(UI_AbilityBox3);

            Texture2D UI_RaceDisplayBoxIcon = GetTexture("MrPlagueRaces/Common/UI/UI_RaceDisplayBox");
            MrPlagueRaceImage UI_RaceDisplayBox = new MrPlagueRaceImage(UI_RaceDisplayBoxIcon, "");
            UI_RaceDisplayBox.Width.Set(100, 0);
            UI_RaceDisplayBox.Height.Set(138, 0);
            UI_RaceDisplayBox.Left.Set(20 - 22, 0);
            UI_RaceDisplayBox.Top.Set(129 - 124 + 120 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(UI_RaceDisplayBox);

            Texture2D Stat_HealthIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_Health");
            MrPlagueRaceImage Stat_Health = new MrPlagueRaceImage(Stat_HealthIcon, "Health");
            Stat_Health.Width.Set(64, 0);
            Stat_Health.Height.Set(20, 0);
            Stat_Health.Left.Set(20 - 22, 0);
            Stat_Health.Top.Set(279 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_Health);

            Texture2D Stat_RegenerationIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_Regeneration");
            MrPlagueRaceImage Stat_Regeneration = new MrPlagueRaceImage(Stat_RegenerationIcon, "Health Regeneration");
            Stat_Regeneration.Width.Set(64, 0);
            Stat_Regeneration.Height.Set(20, 0);
            Stat_Regeneration.Left.Set(20 - 22 + 64 + 8, 0);
            Stat_Regeneration.Top.Set(279 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_Regeneration);

            Texture2D Stat_ManaIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_Mana");
            MrPlagueRaceImage Stat_Mana = new MrPlagueRaceImage(Stat_ManaIcon, "Mana");
            Stat_Mana.Width.Set(64, 0);
            Stat_Mana.Height.Set(20, 0);
            Stat_Mana.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
            Stat_Mana.Top.Set(279 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_Mana);

            Texture2D Stat_ManaRegenIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_ManaRegen");
            MrPlagueRaceImage Stat_ManaRegen = new MrPlagueRaceImage(Stat_ManaRegenIcon, "Mana Regeneration");
            Stat_ManaRegen.Width.Set(64, 0);
            Stat_ManaRegen.Height.Set(20, 0);
            Stat_ManaRegen.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
            Stat_ManaRegen.Top.Set(279 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_ManaRegen);

            Texture2D Stat_DefenseIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_Defense");
            MrPlagueRaceImage Stat_Defense = new MrPlagueRaceImage(Stat_DefenseIcon, "Defense");
            Stat_Defense.Width.Set(64, 0);
            Stat_Defense.Height.Set(20, 0);
            Stat_Defense.Left.Set(20 - 22, 0);
            Stat_Defense.Top.Set(279 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_Defense);

            Texture2D Stat_DamageReductionIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_DamageReduction");
            MrPlagueRaceImage Stat_DamageReduction = new MrPlagueRaceImage(Stat_DamageReductionIcon, "Damage Resistance");
            Stat_DamageReduction.Width.Set(64, 0);
            Stat_DamageReduction.Height.Set(20, 0);
            Stat_DamageReduction.Left.Set(20 - 22 + 64 + 8, 0);
            Stat_DamageReduction.Top.Set(279 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_DamageReduction);

            Texture2D Stat_BreathIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_Breath");
            MrPlagueRaceImage Stat_Breath = new MrPlagueRaceImage(Stat_BreathIcon, "Breath");
            Stat_Breath.Width.Set(64, 0);
            Stat_Breath.Height.Set(20, 0);
            Stat_Breath.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
            Stat_Breath.Top.Set(279 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_Breath);

            Texture2D Stat_BreathRegenIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_BreathRegen");
            MrPlagueRaceImage Stat_BreathRegen = new MrPlagueRaceImage(Stat_BreathRegenIcon, "Breath Regeneration");
            Stat_BreathRegen.Width.Set(64, 0);
            Stat_BreathRegen.Height.Set(20, 0);
            Stat_BreathRegen.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
            Stat_BreathRegen.Top.Set(279 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_BreathRegen);

            Texture2D Stat_DamageMeleeIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_DamageMelee");
            MrPlagueRaceImage Stat_DamageMelee = new MrPlagueRaceImage(Stat_DamageMeleeIcon, "Melee Damage");
            Stat_DamageMelee.Width.Set(64, 0);
            Stat_DamageMelee.Height.Set(20, 0);
            Stat_DamageMelee.Left.Set(20 - 22, 0);
            Stat_DamageMelee.Top.Set(279 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_DamageMelee);

            Texture2D Stat_DamageArrowIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_DamageArrow");
            MrPlagueRaceImage Stat_DamageArrow = new MrPlagueRaceImage(Stat_DamageArrowIcon, "Arrow Damage");
            Stat_DamageArrow.Width.Set(64, 0);
            Stat_DamageArrow.Height.Set(20, 0);
            Stat_DamageArrow.Left.Set(20 - 22 + 64 + 8, 0);
            Stat_DamageArrow.Top.Set(279 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_DamageArrow);

            Texture2D Stat_DamageMagicIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_DamageMagic");
            MrPlagueRaceImage Stat_DamageMagic = new MrPlagueRaceImage(Stat_DamageMagicIcon, "Magic Damage");
            Stat_DamageMagic.Width.Set(64, 0);
            Stat_DamageMagic.Height.Set(20, 0);
            Stat_DamageMagic.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
            Stat_DamageMagic.Top.Set(279 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_DamageMagic);

            Texture2D Stat_DamageSummonerIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_DamageSummoner");
            MrPlagueRaceImage Stat_DamageSummoner = new MrPlagueRaceImage(Stat_DamageSummonerIcon, "Summoning Damage");
            Stat_DamageSummoner.Width.Set(64, 0);
            Stat_DamageSummoner.Height.Set(20, 0);
            Stat_DamageSummoner.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
            Stat_DamageSummoner.Top.Set(279 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_DamageSummoner);

            Texture2D Stat_MeleeSpeedIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_MeleeSpeed");
            MrPlagueRaceImage Stat_MeleeSpeed = new MrPlagueRaceImage(Stat_MeleeSpeedIcon, "Melee Speed");
            Stat_MeleeSpeed.Width.Set(64, 0);
            Stat_MeleeSpeed.Height.Set(20, 0);
            Stat_MeleeSpeed.Left.Set(20 - 22, 0);
            Stat_MeleeSpeed.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_MeleeSpeed);

            Texture2D Stat_ArmorPenetrationIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_ArmorPenetration");
            MrPlagueRaceImage Stat_ArmorPenetration = new MrPlagueRaceImage(Stat_ArmorPenetrationIcon, "Armor Penetration");
            Stat_ArmorPenetration.Width.Set(64, 0);
            Stat_ArmorPenetration.Height.Set(20, 0);
            Stat_ArmorPenetration.Left.Set(20 - 22 + 64 + 8, 0);
            Stat_ArmorPenetration.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_ArmorPenetration);

            Texture2D Stat_DamageBulletIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_DamageBullet");
            MrPlagueRaceImage Stat_DamageBullet = new MrPlagueRaceImage(Stat_DamageBulletIcon, "Bullet Damage");
            Stat_DamageBullet.Width.Set(64, 0);
            Stat_DamageBullet.Height.Set(20, 0);
            Stat_DamageBullet.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
            Stat_DamageBullet.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_DamageBullet);

            Texture2D Stat_DamageRocketIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_DamageRocket");
            MrPlagueRaceImage Stat_DamageRocket = new MrPlagueRaceImage(Stat_DamageRocketIcon, "Rocket Damage");
            Stat_DamageRocket.Width.Set(64, 0);
            Stat_DamageRocket.Height.Set(20, 0);
            Stat_DamageRocket.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
            Stat_DamageRocket.Top.Set(279 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_DamageRocket);

            Texture2D Stat_ManaCostIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_ManaCost");
            MrPlagueRaceImage Stat_ManaCost = new MrPlagueRaceImage(Stat_ManaCostIcon, "Mana Cost");
            Stat_ManaCost.Width.Set(64, 0);
            Stat_ManaCost.Height.Set(20, 0);
            Stat_ManaCost.Left.Set(20 - 22, 0);
            Stat_ManaCost.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_ManaCost);

            Texture2D Stat_MinionKnockbackIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_MinionKnockback");
            MrPlagueRaceImage Stat_MinionKnockback = new MrPlagueRaceImage(Stat_MinionKnockbackIcon, "Minion Knockback");
            Stat_MinionKnockback.Width.Set(64, 0);
            Stat_MinionKnockback.Height.Set(20, 0);
            Stat_MinionKnockback.Left.Set(20 - 22 + 64 + 8, 0);
            Stat_MinionKnockback.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_MinionKnockback);

            Texture2D Stat_MinionsIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_Minions");
            MrPlagueRaceImage Stat_Minions = new MrPlagueRaceImage(Stat_MinionsIcon, "Minions");
            Stat_Minions.Width.Set(64, 0);
            Stat_Minions.Height.Set(20, 0);
            Stat_Minions.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
            Stat_Minions.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_Minions);

            Texture2D Stat_SentriesIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_Sentries");
            MrPlagueRaceImage Stat_Sentries = new MrPlagueRaceImage(Stat_SentriesIcon, "Sentries");
            Stat_Sentries.Width.Set(64, 0);
            Stat_Sentries.Height.Set(20, 0);
            Stat_Sentries.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
            Stat_Sentries.Top.Set(279 + 28 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_Sentries);

            Texture2D Stat_CritMeleeIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_CritMelee");
            MrPlagueRaceImage Stat_CritMelee = new MrPlagueRaceImage(Stat_CritMeleeIcon, "Melee Critical Hit Chance");
            Stat_CritMelee.Width.Set(64, 0);
            Stat_CritMelee.Height.Set(20, 0);
            Stat_CritMelee.Left.Set(20 - 22, 0);
            Stat_CritMelee.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_CritMelee);

            Texture2D Stat_CritRangedIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_CritRanged");
            MrPlagueRaceImage Stat_CritRanged = new MrPlagueRaceImage(Stat_CritRangedIcon, "Ranged Critical Hit Chance");
            Stat_CritRanged.Width.Set(64, 0);
            Stat_CritRanged.Height.Set(20, 0);
            Stat_CritRanged.Left.Set(20 - 22 + 64 + 8, 0);
            Stat_CritRanged.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_CritRanged);

            Texture2D Stat_CritMagicIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_CritMagic");
            MrPlagueRaceImage Stat_CritMagic = new MrPlagueRaceImage(Stat_CritMagicIcon, "Magic Critical Hit Chance");
            Stat_CritMagic.Width.Set(64, 0);
            Stat_CritMagic.Height.Set(20, 0);
            Stat_CritMagic.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
            Stat_CritMagic.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_CritMagic);

            Texture2D Stat_MiningSpeedIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_MiningSpeed");
            MrPlagueRaceImage Stat_MiningSpeed = new MrPlagueRaceImage(Stat_MiningSpeedIcon, "Mining Speed");
            Stat_MiningSpeed.Width.Set(64, 0);
            Stat_MiningSpeed.Height.Set(20, 0);
            Stat_MiningSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
            Stat_MiningSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_MiningSpeed);

            Texture2D Stat_BuildingSpeedIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_BuildingSpeed");
            MrPlagueRaceImage Stat_BuildingSpeed = new MrPlagueRaceImage(Stat_BuildingSpeedIcon, "Tile Placement Speed");
            Stat_BuildingSpeed.Width.Set(64, 0);
            Stat_BuildingSpeed.Height.Set(20, 0);
            Stat_BuildingSpeed.Left.Set(20 - 22, 0);
            Stat_BuildingSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_BuildingSpeed);

            Texture2D Stat_BuildingRangeIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_BuildingRange");
            MrPlagueRaceImage Stat_BuildingRange = new MrPlagueRaceImage(Stat_BuildingRangeIcon, "Tile Placement Range");
            Stat_BuildingRange.Width.Set(64, 0);
            Stat_BuildingRange.Height.Set(20, 0);
            Stat_BuildingRange.Left.Set(20 - 22 + 64 + 8, 0);
            Stat_BuildingRange.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_BuildingRange);

            Texture2D Stat_BuildingWallSpeedIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_BuildingWallSpeed");
            MrPlagueRaceImage Stat_BuildingWallSpeed = new MrPlagueRaceImage(Stat_BuildingWallSpeedIcon, "Wall Placement Speed");
            Stat_BuildingWallSpeed.Width.Set(64, 0);
            Stat_BuildingWallSpeed.Height.Set(20, 0);
            Stat_BuildingWallSpeed.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
            Stat_BuildingWallSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_BuildingWallSpeed);

            Texture2D Stat_BuildingWallRangeIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_BuildingWallRange");
            MrPlagueRaceImage Stat_BuildingWallRange = new MrPlagueRaceImage(Stat_BuildingWallRangeIcon, "Wall Placement Range");
            Stat_BuildingWallRange.Width.Set(64, 0);
            Stat_BuildingWallRange.Height.Set(20, 0);
            Stat_BuildingWallRange.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
            Stat_BuildingWallRange.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_BuildingWallRange);

            Texture2D Stat_MovementSpeedIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_MovementSpeed");
            MrPlagueRaceImage Stat_MovementSpeed = new MrPlagueRaceImage(Stat_MovementSpeedIcon, "Movement Speed");
            Stat_MovementSpeed.Width.Set(64, 0);
            Stat_MovementSpeed.Height.Set(20, 0);
            Stat_MovementSpeed.Left.Set(20 - 22, 0);
            Stat_MovementSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_MovementSpeed);

            Texture2D Stat_JumpSpeedIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_JumpSpeed");
            MrPlagueRaceImage Stat_JumpSpeed = new MrPlagueRaceImage(Stat_JumpSpeedIcon, "Jump Height");
            Stat_JumpSpeed.Width.Set(64, 0);
            Stat_JumpSpeed.Height.Set(20, 0);
            Stat_JumpSpeed.Left.Set(20 - 22 + 64 + 8, 0);
            Stat_JumpSpeed.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_JumpSpeed);

            Texture2D Stat_FallDamageIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_FallDamage");
            MrPlagueRaceImage Stat_FallDamage = new MrPlagueRaceImage(Stat_FallDamageIcon, "Fall Damage");
            Stat_FallDamage.Width.Set(64, 0);
            Stat_FallDamage.Height.Set(20, 0);
            Stat_FallDamage.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
            Stat_FallDamage.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_FallDamage);

            Texture2D Stat_FlightTimeIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_FlightTime");
            MrPlagueRaceImage Stat_FlightTime = new MrPlagueRaceImage(Stat_FlightTimeIcon, "Flight Time");
            Stat_FlightTime.Width.Set(64, 0);
            Stat_FlightTime.Height.Set(20, 0);
            Stat_FlightTime.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
            Stat_FlightTime.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_FlightTime);

            Texture2D Stat_FishingSkillIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_FishingSkill");
            MrPlagueRaceImage Stat_FishingSkill = new MrPlagueRaceImage(Stat_FishingSkillIcon, "Fishing Skill");
            Stat_FishingSkill.Width.Set(64, 0);
            Stat_FishingSkill.Height.Set(20, 0);
            Stat_FishingSkill.Left.Set(20 - 22, 0);
            Stat_FishingSkill.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_FishingSkill);

            Texture2D Stat_AggroIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_Aggro");
            MrPlagueRaceImage Stat_Aggro = new MrPlagueRaceImage(Stat_AggroIcon, "Enemy Aggresion");
            Stat_Aggro.Width.Set(64, 0);
            Stat_Aggro.Height.Set(20, 0);
            Stat_Aggro.Left.Set(20 - 22 + 64 + 8, 0);
            Stat_Aggro.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_Aggro);

            Texture2D Stat_MobSpawnsIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_MobSpawns");
            MrPlagueRaceImage Stat_MobSpawns = new MrPlagueRaceImage(Stat_MobSpawnsIcon, "Enemy Spawn Rate");
            Stat_MobSpawns.Width.Set(64, 0);
            Stat_MobSpawns.Height.Set(20, 0);
            Stat_MobSpawns.Left.Set(20 - 22 + 64 + 8 + 64 + 8, 0);
            Stat_MobSpawns.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_MobSpawns);

            Texture2D Stat_ThornsIcon = GetTexture("MrPlagueRaces/Common/UI/Stat_Thorns");
            MrPlagueRaceImage Stat_Thorns = new MrPlagueRaceImage(Stat_ThornsIcon, "Thorns");
            Stat_Thorns.Width.Set(64, 0);
            Stat_Thorns.Height.Set(20, 0);
            Stat_Thorns.Left.Set(20 - 22 + 64 + 8 + 64 + 8 + 64 + 8, 0);
            Stat_Thorns.Top.Set(279 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 28 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Stat_Thorns);

            Texture2D Environment_GoodBiomesIcon = GetTexture("MrPlagueRaces/Common/UI/Environment_GoodBiomes");
            MrPlagueRaceImage Environment_GoodBiomes = new MrPlagueRaceImage(Environment_GoodBiomesIcon, "Adapted for");
            Environment_GoodBiomes.Width.Set(136, 0);
            Environment_GoodBiomes.Height.Set(26, 0);
            Environment_GoodBiomes.Left.Set(20 - 22, 0);
            Environment_GoodBiomes.Top.Set(539 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Environment_GoodBiomes);

            Texture2D Environment_BadBiomesIcon = GetTexture("MrPlagueRaces/Common/UI/Environment_BadBiomes");
            MrPlagueRaceImage Environment_BadBiomes = new MrPlagueRaceImage(Environment_BadBiomesIcon, "Unadapted for");
            Environment_BadBiomes.Width.Set(136, 0);
            Environment_BadBiomes.Height.Set(26, 0);
            Environment_BadBiomes.Left.Set(20 - 22 + 144, 0);
            Environment_BadBiomes.Top.Set(539 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Environment_BadBiomes);

            Texture2D Environment_DietIcon = GetTexture("MrPlagueRaces/Common/UI/Environment_Diet");
            MrPlagueRaceImage Environment_Diet = new MrPlagueRaceImage(Environment_DietIcon, "Diet");
            Environment_Diet.Width.Set(136, 0);
            Environment_Diet.Height.Set(26, 0);
            Environment_Diet.Left.Set(20 - 22, 0);
            Environment_Diet.Top.Set(539 + 34 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Environment_Diet);

            Texture2D Environment_TimeIcon = GetTexture("MrPlagueRaces/Common/UI/Environment_Time");
            MrPlagueRaceImage Environment_Time = new MrPlagueRaceImage(Environment_TimeIcon, "Time of Activity");
            Environment_Time.Width.Set(136, 0);
            Environment_Time.Height.Set(26, 0);
            Environment_Time.Left.Set(20 - 22 + 144, 0);
            Environment_Time.Top.Set(539 + 34 + 132 - 92, 0);
			MrPlagueRaceStatDisplayBackground.Append(Environment_Time);

            Ability1 = new UITextPanel<string>("Active Ability:" + "\n                                                                                                                                                                       ");
            Ability1.Width.Set(1196, 0);
            Ability1.Height.Set(40, 0);
            Ability1.Left.Set(350 - 362, 0);
            Ability1.Top.Set(20 - 34, 0);
            Ability1.BackgroundColor = Color.Transparent;
            Ability1.BorderColor = Color.Transparent;
			MrPlagueRaceAbilityDisplayBackground.Append(Ability1);

            Ability2 = new UITextPanel<string>("Passive Ability:" + "\n                                                                                                                                                                       ");
            Ability2.Width.Set(1196, 0);
            Ability2.Height.Set(40, 0);
            Ability2.Left.Set(350 - 362, 0);
            Ability2.Top.Set(80 + 168 - 34, 0);
            Ability2.BackgroundColor = Color.Transparent;
            Ability2.BorderColor = Color.Transparent;
			MrPlagueRaceAbilityDisplayBackground.Append(Ability2);

            Ability3 = new UITextPanel<string>("Passive Ability:" + "\n                                                                                                                                                                       ");
            Ability3.Width.Set(1196, 0);
            Ability3.Height.Set(40, 0);
            Ability3.Left.Set(350 - 362, 0);
            Ability3.Top.Set(80 + 168 + 228 - 34, 0);
            Ability3.BackgroundColor = Color.Transparent;
            Ability3.BorderColor = Color.Transparent;
			MrPlagueRaceAbilityDisplayBackground.Append(Ability3);

            Ability1Description = new UITextPanel<string>("WIP" + "\n                                                                                                                                                                       ");
            Ability1Description.Width.Set(1196, 0);
            Ability1Description.Height.Set(40, 0);
            Ability1Description.Left.Set(350 - 362, 0);
            Ability1Description.Top.Set(20 + 40 - 34, 0);
            Ability1Description.BackgroundColor = Color.Transparent;
            Ability1Description.BorderColor = Color.Transparent;
			MrPlagueRaceAbilityDisplayBackground.Append(Ability1Description);

            Ability2Description = new UITextPanel<string>("WIP" + "\n                                                                                                                                                                       ");
            Ability2Description.Width.Set(1196, 0);
            Ability2Description.Height.Set(40, 0);
            Ability2Description.Left.Set(350 - 362, 0);
            Ability2Description.Top.Set(80 + 168 + 40 - 34, 0);
            Ability2Description.BackgroundColor = Color.Transparent;
            Ability2Description.BorderColor = Color.Transparent;
			MrPlagueRaceAbilityDisplayBackground.Append(Ability2Description);

            Ability3Description = new UITextPanel<string>("WIP" + "\n                                                                                                                                                                       ");
            Ability3Description.Width.Set(1196, 0);
            Ability3Description.Height.Set(40, 0);
            Ability3Description.Left.Set(350 - 362, 0);
            Ability3Description.Top.Set(80 + 168 + 228 + 40 - 34, 0);
            Ability3Description.BackgroundColor = Color.Transparent;
            Ability3Description.BorderColor = Color.Transparent;
			MrPlagueRaceAbilityDisplayBackground.Append(Ability3Description);

            Lore1Description = new UITextPanel<string>("WIP" + "\n                                                                                                                                                                       ");
            Lore1Description.Width.Set(280, 0);
            Lore1Description.Height.Set(40, 0);
            Lore1Description.Left.Set(118 - 22, 0);
            Lore1Description.Top.Set(129 - 124 + 117 - 92, 0);
            Lore1Description.BackgroundColor = Color.Transparent;
            Lore1Description.BorderColor = Color.Transparent;
            MrPlagueRaceStatDisplayBackground.Append(Lore1Description);

            Lore2Description = new UITextPanel<string>("WIP" + "\n                                                                                                                                                                       ");
            Lore2Description.Width.Set(280, 0);
            Lore2Description.Height.Set(40, 0);
            Lore2Description.Left.Set(10 - 22, 0);
            Lore2Description.Top.Set(612 - 336 - 92, 0);
            Lore2Description.BackgroundColor = Color.Transparent;
            Lore2Description.BorderColor = Color.Transparent;
            MrPlagueRaceStatDisplayBackground.Append(Lore2Description);

            RaceNameDisplay = new UITextPanel<string>("");
            RaceNameDisplay.Width.Set(300, 0);
            RaceNameDisplay.Height.Set(40, 0);
            RaceNameDisplay.Left.Set(5 + 16 - 13 + 2 - 22, 0);
            RaceNameDisplay.Top.Set(80 - 92, 0);
            RaceNameDisplay.BackgroundColor = Color.Transparent;
            RaceNameDisplay.BorderColor = Color.Transparent;
            MrPlagueRaceStatDisplayBackground.Append(RaceNameDisplay);

			HoverText = new UITextPanel<string>("");
			HoverText.Width.Set(40, 0);
			HoverText.Height.Set(40, 0);
			HoverText.Left.Set(0, 0);
			HoverText.Top.Set(0, 0);
			HoverText.BackgroundColor = Color.Transparent;
			HoverText.BorderColor = Color.Transparent;
			MrPlagueRaceBackground.Append(HoverText);
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

		public void MrPlagueRaceSelectionProceed(UIMouseEvent mouseEvent, UIElement targetElement)
		{
            Main.PlaySound(SoundID.MenuOpen, -1, -1, 1, 1f, 0f);
            Main.menuMode = 2;
		}

        public void MrPlagueRaceSelectionBack(UIMouseEvent mouseEvent, UIElement targetElement)
        {
            Main.PlaySound(SoundID.MenuClose, -1, -1, 1, 1f, 0f);
            Main.menuMode = 1;
            MrPlagueRacesPlayer.StaticRace = null;
        }

		public void UI_ButtonPrevious_Clicked(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
			if (RaceIndex <= 0)
			{
				RaceIndex = (RaceLoader.Races.Count - 1);
			}
			else
			{
				RaceIndex -= 1;
			}
		}

        public void UI_ButtonNext_Clicked(UIMouseEvent mouseEvent, UIElement targetElement)
        {
            Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
            if (RaceIndex == (RaceLoader.Races.Count - 1))
            {
                RaceIndex = 0;
            }
            else
            {
                RaceIndex += 1;
            }
        }

		public void UI_ButtonRandom_Clicked(UIMouseEvent mouseEvent, UIElement targetElement)
		{
			Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
			RaceIndex = Main.rand.Next((RaceLoader.Races.Count - 1));
		}

		public override void Update(GameTime gameTime)
		{

			/*for (int i = 0; i < 255; i++)
			{
				Player player = Main.player[i];
				Main.DrawPlayer(player, player.fullRotation, player.fullRotationOrigin, 0f);
			}*/
			base.Update(gameTime);
            if (MrPlagueRacesPlayer.StaticRace == null)
            {
                switch (Main.rand.Next(11))
                {
                    case 0:
                        MrPlagueRacesPlayer.StaticRace = ModContent.GetInstance<Human>();
                        break;
                    case 1:
                        MrPlagueRacesPlayer.StaticRace = ModContent.GetInstance<Goblin>();
                        break;
                    case 2:
                        MrPlagueRacesPlayer.StaticRace = ModContent.GetInstance<Kenku>();
                        break;
                    case 3:
                        MrPlagueRacesPlayer.StaticRace = ModContent.GetInstance<Tabaxi>();
                        break;
                    case 4:
                        MrPlagueRacesPlayer.StaticRace = ModContent.GetInstance<Dragonkin>();
                        break;
                    case 5:
                        MrPlagueRacesPlayer.StaticRace = ModContent.GetInstance<Merfolk>();
                        break;
                    case 6:
                        MrPlagueRacesPlayer.StaticRace = ModContent.GetInstance<Mushfolk>();
                        break;
                    case 7:
                        MrPlagueRacesPlayer.StaticRace = ModContent.GetInstance<Derpkin>();
                        break;
                    case 8:
                        MrPlagueRacesPlayer.StaticRace = ModContent.GetInstance<Kobold>();
                        break;
                    case 9:
                        MrPlagueRacesPlayer.StaticRace = ModContent.GetInstance<Skeleton>();
                        break;
                    case 10:
                        MrPlagueRacesPlayer.StaticRace = ModContent.GetInstance<Vampire>();
                        break;
                    default:
                        MrPlagueRacesPlayer.StaticRace = ModContent.GetInstance<Fluftrodon>();
                        break;
                }
            }
			HoverText.SetText(RaceHoverTextString);
			MrPlagueRacesPlayer.StaticRace = RaceLoader.Races[RaceIndex];
            RaceNameDisplay.SetText(MrPlagueRacesPlayer.StaticRace.RaceName);
			RaceNameDisplay.SetText(MrPlagueRacesPlayer.StaticRace.RaceName);
			HoverText.Left.Set(Main.mouseX - 930, 0);
            HoverText.Top.Set(Main.mouseY - 240, 0);
			Recalculate();
		}
	}
}