using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass
namespace AlistarMaster
{
    // I can't really help you with my layout of a good config class
    // since everyone does it the way they like it most, go checkout my
    // config classes I make on my GitHub if you wanna take over the
    // complex way that I use
    public static class Config
    {
        private const string MenuName = "ALISTAR - TRAU VANG VN";

        private static readonly Menu Menu;

        static Config()
        {
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Welcome to this Sivuu Master Family Addons!");
            Menu.AddLabel("Thank for Addons Template by Hellsing");
            Menu.AddLabel("Goodluck and please vote on elobuddydb.com!");

            // Initialize the modes
            Modes.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            static Modes()
            {       
                // Combo
                Combo.Initialize();

                // Harass
                Harass.Initialize();
                // LaneClear
                LaneClear.Initialize();
                // JungleClear
                JungleClear.Initialize();
                // Misc
                Misc.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                public static bool comboQW = false;
                private static readonly Menu ComboMenu;
                public static bool UseQ
                {
                    get { return ComboMenu["comboUseQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseW
                {
                    get { return ComboMenu["comboUseW"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseE
                {
                    get { return ComboMenu["comboUseE"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseR
                {
                    get { return ComboMenu["comboUseR"].Cast<CheckBox>().CurrentValue; }
                }

                static Combo()
                {
                    // Initialize the menu values
                    ComboMenu = Config.Menu.AddSubMenu("Combo");
                    ComboMenu.Add("comboUseQ", new CheckBox("Use Q"));
                    ComboMenu.Add("comboUseW", new CheckBox("Use W"));
                    ComboMenu.Add("comboUseE", new CheckBox("Use E"));
                    ComboMenu.Add("comboUseR", new CheckBox("Use R", false)); // Default false
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                private static readonly Menu HarassMenu;
                public static bool UseQ
                {
                    get { return HarassMenu["harassUseQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseW
                {
                    get { return HarassMenu["harassUseW"].Cast<CheckBox>().CurrentValue; }
                }
                public static int Mana
                {
                    get { return HarassMenu["harassMana"].Cast<Slider>().CurrentValue; }
                }

                static Harass()
                {
                    // Here is another option on how to use the menu, but I prefer the
                    // way that I used in the combo class
                    HarassMenu = Config.Menu.AddSubMenu("Harass");
                    HarassMenu.Add("harassUseQ", new CheckBox("Use Q"));
                    HarassMenu.Add("harassUseW", new CheckBox("Use W"));

                    // Adding a slider, we have a little more options with them, using {0} {1} and {2}
                    // in the display name will replace it with 0=current 1=min and 2=max value
                    HarassMenu.Add("harassMana", new Slider("Maximum mana usage in percent ({0}%)", 40));
                }

                public static void Initialize()
                {
                }
            }

            public static class LaneClear
            {
                private static readonly Menu LaneClearMenu;
                public static bool UseQ
                {
                    get { return LaneClearMenu["laneclearUseQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseW
                {
                    get { return LaneClearMenu["laneclearUseW"].Cast<CheckBox>().CurrentValue; }
                }
                public static int Mana
                {
                    get { return LaneClearMenu["laneclearMana"].Cast<Slider>().CurrentValue; }
                }

                static LaneClear()
                {
                    // Initialize the menu values
                    LaneClearMenu = Config.Menu.AddSubMenu("Lane Clear");
                    LaneClearMenu.Add("laneclearUseQ", new CheckBox("Use Q"));
                    LaneClearMenu.Add("laneclearUseW", new CheckBox("Use W"));
                    LaneClearMenu.Add("laneclearMana", new Slider("Maximum mana usage in percent ({0}%)", 40));
                }

                public static void Initialize()
                {
                }
            }

            public static class JungleClear
            {
                private static readonly Menu JungleClearMenu;
                public static bool UseQ
                {
                    get { return JungleClearMenu["jungleclearUseQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseW
                {
                    get { return JungleClearMenu["jungleclearUseW"].Cast<CheckBox>().CurrentValue; }
                }
                public static int Mana
                {
                    get { return JungleClearMenu["jungleclearMana"].Cast<Slider>().CurrentValue; }
                }

                static JungleClear()
                {
                    // Initialize the menu values
                    JungleClearMenu = Config.Menu.AddSubMenu("Jungle Clear");
                    JungleClearMenu.Add("jungleclearUseQ", new CheckBox("Use Q"));
                    JungleClearMenu.Add("jungleclearUseW", new CheckBox("Use W"));
                    JungleClearMenu.Add("jungleclearMana", new Slider("Maximum mana usage in percent ({0}%)", 40));

                }

                public static void Initialize()
                {
                }
            }

            public static class Misc
            {
                private static readonly Menu MiscMenu;
                public static bool AntiGapCloser
                {
                    get { return MiscMenu["antiGapCloser"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool Interrupted
                {
                    get { return MiscMenu["antiInterrupter"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool Keepuppassivebuff
                {
                    get { return MiscMenu["keeppassiveBuff"].Cast<CheckBox>().CurrentValue; }
                }
                public static int LowHPE
                {
                    get { return MiscMenu["misclowhpUseE"].Cast<Slider>().CurrentValue; }
                }
                public static int LowHPR
                {
                    get { return MiscMenu["misclowhpUseR"].Cast<Slider>().CurrentValue; }
                }

                static Misc()
                {
                    // Initialize the menu values
                    MiscMenu = Config.Menu.AddSubMenu("Misc Setting");
                    MiscMenu.Add("antiGapCloser", new CheckBox("Anti GapCloser Q"));
                    MiscMenu.Add("antiInterrupter", new CheckBox("Disable Channing Spell"));
                    MiscMenu.Add("keeppassiveBuff", new CheckBox("Keep passive buff always on in combat"));
                    MiscMenu.Add("misclowhpUseE", new Slider("Lowest HP for R usage in percent ({0}%)", 50));
                    MiscMenu.Add("misclowhpUseR", new Slider("Lowest HP for R usage in percent ({0}%)", 50));
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}
