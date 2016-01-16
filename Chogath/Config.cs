using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass
namespace Chogath
{
    // I can't really help you with my layout of a good config class
    // since everyone does it the way they like it most, go checkout my
    // config classes I make on my GitHub if you wanna take over the
    // complex way that I use
    public static class Config
    {
        private const string MenuName = "Chogath Master";

        private static readonly Menu Menu;

        static Config()
        {
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Welcome to Sivuu Master Family Addons!");
            Menu.AddLabel("Thank for addon template by Hellsing");
            Menu.AddLabel("Goodluck and have fun!");

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

                //Laneclear
                LaneClear.Initialize();

                //Jungle Clear
                JungleClear.Initialize();

                //Misc Config
                Misc.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                static readonly Menu ComboMenu;
                public static bool UseQ
                {
                    get { return ComboMenu["comboUseQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseW
                {
                    get { return ComboMenu["comboUseW"].Cast<CheckBox>().CurrentValue; }
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
                    ComboMenu.Add("comboUseW", new CheckBox("Use W",false));
                    ComboMenu.Add("comboUseR", new CheckBox("Use R"));
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                static readonly Menu HarassMenu;
                public static bool UseQ
                {
                    get { return HarassMenu["harassUseQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseW
                {
                    get { return HarassMenu["harassUseW"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseR
                {
                    get { return HarassMenu["harassUseR"].Cast<CheckBox>().CurrentValue; }
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
                    HarassMenu.Add("harassUseW", new CheckBox("Use W",false));
                    HarassMenu.Add("harassUseR", new CheckBox("Use R")); 

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
                public static bool UseR
                {
                    get { return LaneClearMenu["laneclearUseR"].Cast<CheckBox>().CurrentValue; }
                }
                public static int Mana
                {
                    get { return LaneClearMenu["laneclearMana"].Cast<Slider>().CurrentValue; }
                }

                static LaneClear()
                {
                    // Here is another option on how to use the menu, but I prefer the
                    // way that I used in the combo class
                    LaneClearMenu = Config.Menu.AddSubMenu("LaneClear");
                    LaneClearMenu.Add("laneclearUseQ", new CheckBox("Use Q"));
                    LaneClearMenu.Add("laneclearUseW", new CheckBox("Use W",false));
                    LaneClearMenu.Add("laneclearUseR", new CheckBox("Use R")); 

                    // Adding a slider, we have a little more options with them, using {0} {1} and {2}
                    // in the display name will replace it with 0=current 1=min and 2=max value
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
                public static bool UseR
                {
                    get { return JungleClearMenu["jungleclearUseR"].Cast<CheckBox>().CurrentValue; }
                }
                public static int Mana
                {
                    get { return JungleClearMenu["jungleclearMana"].Cast<Slider>().CurrentValue; }
                }

                static JungleClear()
                {
                    // Here is another option on how to use the menu, but I prefer the
                    // way that I used in the combo class
                    JungleClearMenu = Config.Menu.AddSubMenu("Jungle Clear");
                    JungleClearMenu.Add("jungleclearUseQ", new CheckBox("Use Q"));
                    JungleClearMenu.Add("jungleclearUseW", new CheckBox("Use W",false));
                    JungleClearMenu.Add("jungleclearUseR", new CheckBox("Use R"));

                    // Adding a slider, we have a little more options with them, using {0} {1} and {2}
                    // in the display name will replace it with 0=current 1=min and 2=max value
                    JungleClearMenu.Add("jungleclearMana", new Slider("Maximum mana usage in percent ({0}%)", 40));
                }

                public static void Initialize()
                {
                }
            }

            public static class Misc
            {
                private static readonly Menu MiscMenu;
                public static bool MiscQ
                {
                    get { return MiscMenu["miscQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool MiscW
                {
                    get { return MiscMenu["miscW"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool MiscR
                {
                    get { return MiscMenu["miscR"].Cast<CheckBox>().CurrentValue; }
                }
                public static int HitChance
                {
                    get { return MiscMenu["hitchance"].Cast<Slider>().CurrentValue; }
                }

                static Misc()
                {
                    // Here is another option on how to use the menu, but I prefer the
                    // way that I used in the combo class
                    MiscMenu = Config.Menu.AddSubMenu("Misc");
                    MiscMenu.Add("miscQ", new CheckBox("Use Q for Gapcloser and Interupter"));
                    MiscMenu.Add("miscW", new CheckBox("Use W for Gapcloser and Interupter"));
                    MiscMenu.Add("miscR", new CheckBox("Use R to kill big mob")); // Default false

                    // Adding a slider, we have a little more options with them, using {0} {1} and {2}
                    // in the display name will replace it with 0=current 1=min and 2=max value
                    MiscMenu.Add("hitchance", new Slider("Hit chance for Q skill ({0}%)", 75));
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}
