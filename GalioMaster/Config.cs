using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass
namespace GalioMaster
{
    // I can't really help you with my layout of a good config class
    // since everyone does it the way they like it most, go checkout my
    // config classes I make on my GitHub if you wanna take over the
    // complex way that I use
    public static class Config
    {
        private const string MenuName = "Galio Master";

        private static readonly Menu Menu;

        static Config()
        {
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Welcome to this Sivuu Addons Family!");
            Menu.AddLabel("Thank Hellsing for Addon Template");
            Menu.AddLabel("Good luck and have fun with this!");

            // Initialize the modes
            Misc.Initialize();

            Combo.Initialize();

            Harass.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Combo
        {
            public static readonly Menu Menu;
            public static bool UseQ
            {
                get { return Menu["comboUseQ"].Cast<CheckBox>().CurrentValue; }
            }
            public static bool UseE
            {
                get { return Menu["comboUseE"].Cast<CheckBox>().CurrentValue; }
            }
            public static bool UseR
            {
                get { return Menu["comboUseR"].Cast<CheckBox>().CurrentValue; }
            }

            static Combo()
            {
                // Initialize the menu values
                Menu = Config.Menu.AddSubMenu("Combo");
                Menu.Add("comboUseQ", new CheckBox("Use Q"));
                Menu.Add("comboUseE", new CheckBox("Use E"));
                Menu.Add("comboUseR", new CheckBox("Use R", false)); // Default false
            }

            public static void Initialize()
            {
            }
        }

        public static class Harass
        {
            public static readonly Menu Menu;
            public static bool UseQ
            {
                get { return Menu["harassUseQ"].Cast<CheckBox>().CurrentValue; }
            }
            public static bool UseE
            {
                get { return Menu["harassUseE"].Cast<CheckBox>().CurrentValue; }
            }
            public static bool UseR
            {
                get { return Menu["harassUseR"].Cast<CheckBox>().CurrentValue; }
            }
            public static int Mana
            {
                get { return Menu["harassMana"].Cast<Slider>().CurrentValue; }
            }

            static Harass()
            {
                // Here is another option on how to use the menu, but I prefer the
                // way that I used in the combo class
                Menu =  Config.Menu.AddSubMenu("Harass");
                Menu.Add("harassUseQ", new CheckBox("Use Q"));
                Menu.Add("harassUseE", new CheckBox("Use E"));
                Menu.Add("harassUseR", new CheckBox("Use R", false)); // Default false

                // Adding a slider, we have a little more options with them, using {0} {1} and {2}
                // in the display name will replace it with 0=current 1=min and 2=max value
                Menu.Add("harassMana", new Slider("Maximum mana usage in percent ({0}%)", 40));
            }

            public static void Initialize()
            {
            }
        }

        public static class LaneClear
        {
            public static readonly Menu Menu;
            public static bool UseQ
            {
                get { return Menu["laneclearUseQ"].Cast<CheckBox>().CurrentValue; }
            }
            public static bool UseE
            {
                get { return Menu["laneclearUseE"].Cast<CheckBox>().CurrentValue; }
            }
            public static int Mana
            {
                get { return Menu["laneclearMana"].Cast<Slider>().CurrentValue; }
            }

            static LaneClear()
            {
                // Here is another option on how to use the menu, but I prefer the
                // way that I used in the combo class
                Menu = Config.Menu.AddSubMenu("Lane Clear");
                Menu.Add("laneclearUseQ", new CheckBox("Use Q"));
                Menu.Add("laneclearUseE", new CheckBox("Use E"));

                // Adding a slider, we have a little more options with them, using {0} {1} and {2}
                // in the display name will replace it with 0=current 1=min and 2=max value
                Menu.Add("laneclearMana", new Slider("Maximum mana usage in percent ({0}%)", 40));
            }

            public static void Initialize()
            {
            }
        }

        public static class JungleClear
        {
            public static readonly Menu Menu;
            public static bool UseQ
            {
                get { return Menu["jungleclearUseQ"].Cast<CheckBox>().CurrentValue; }
            }
            public static bool UseE
            {
                get { return Menu["jungleclearUseE"].Cast<CheckBox>().CurrentValue; }
            }
            public static int Mana
            {
                get { return Menu["jungleclearMana"].Cast<Slider>().CurrentValue; }
            }

            static JungleClear()
            {
                // Here is another option on how to use the menu, but I prefer the
                // way that I used in the combo class
                Menu = Config.Menu.AddSubMenu("Jungle Clear");
                Menu.Add("jungleclearUseQ", new CheckBox("Use Q"));
                Menu.Add("jungleclearUseE", new CheckBox("Use E"));

                // Adding a slider, we have a little more options with them, using {0} {1} and {2}
                // in the display name will replace it with 0=current 1=min and 2=max value
                Menu.Add("jungleclearMana", new Slider("Maximum mana usage in percent ({0}%)", 40));
            }

            public static void Initialize()
            {
            }
        }

        public static class Misc
        {
            private static readonly Menu Menu;

            public static bool UseW
            {
                get { return Menu["defensiveUseW"].Cast<CheckBox>().CurrentValue; }
            }

            public static bool UseR
            {
                get { return Menu["defensiveUseR"].Cast<CheckBox>().CurrentValue; }
            }

            public static int Hitchance
            {
                get { return Menu["hitchance"].Cast<Slider>().CurrentValue; }
            }

            static Misc()
            {
                // Initialize the menu
                Menu = Config.Menu.AddSubMenu("Misc");
                Menu.Add("defensiveUseW", new CheckBox("Use W when any enemy spell cast on me"));
                Menu.Add("defensiveUseR", new CheckBox("Use R when any enemy spell cast on me"));
                Menu.Add("hitchance", new Slider("Hit chance at {0}%", 80, 0, 100));
            }

            public static void Initialize()
            {
            }           
        }
    }
}
