﻿using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass
namespace Velkoz
{
    // I can't really help you with my layout of a good config class
    // since everyone does it the way they like it most, go checkout my
    // config classes I make on my GitHub if you wanna take over the
    // complex way that I use
    public static class Config
    {
        private const string MenuName = "Velkoz";

        private static readonly Menu Menu;

        static Config()
        {
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Welcome to this Velkoz - Sivuu Master!");
            Menu.AddLabel("To change the menu, please have a look at the");
            Menu.AddLabel("Config.cs class inside the project, now have fun!");

            // Initialize the modes
            Modes.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            private static readonly Menu Menu;

            static Modes()
            {
                // Initialize the menu
                Menu = Config.Menu.AddSubMenu("Modes");

                // Initialize all modes

                Combo.Initialize();
                Harass.Initialize();
                LaneClear.Initialize();
                JungleClear.Initialize();
                Menu.AddSeparator();              
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useSmartQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static bool UseSmartQ
                {
                    get { return _useSmartQ.CurrentValue; }
                }
                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }
                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                static Combo()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Combo");
                    _useQ = Menu.Add("comboUseQ", new CheckBox("Use Q"));
                    _useSmartQ = Menu.Add("comboUseSmartQ", new CheckBox("Use Smart Q"));
                    _useW = Menu.Add("comboUseW", new CheckBox("Use W"));
                    _useE = Menu.Add("comboUseE", new CheckBox("Use E"));
                    _useR = Menu.Add("comboUseR", new CheckBox("Use R", false)); // Default false
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                public static bool UseQ
                {
                    get { return Menu["harassUseQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseSmartQ
                {
                    get { return Menu["harassUseSmartQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseW
                {
                    get { return Menu["harassUseW"].Cast<CheckBox>().CurrentValue; }
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
                    Menu.AddGroupLabel("Harass");
                    Menu.Add("harassUseQ", new CheckBox("Use Q"));
                    Menu.Add("harassUseSmartQ", new CheckBox("Use Smart Q"));
                    Menu.Add("harassUseW", new CheckBox("Use W",false));
                    Menu.Add("harassUseE", new CheckBox("Use E",false));
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
                public static bool UseQ
                {
                    get { return Menu["laneclearUseQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseW
                {
                    get { return Menu["laneclearUseW"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseE
                {
                    get { return Menu["laneclearUseE"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseR
                {
                    get { return Menu["laneclearUseR"].Cast<CheckBox>().CurrentValue; }
                }
                public static int Mana
                {
                    get { return Menu["laneclearMana"].Cast<Slider>().CurrentValue; }
                }

                static LaneClear()
                {
                    // Here is another option on how to use the menu, but I prefer the
                    // way that I used in the combo class
                    Menu.AddGroupLabel("LaneClear");
                    Menu.Add("laneclearUseQ", new CheckBox("Use Q",false));
                    Menu.Add("laneclearUseW", new CheckBox("Use W"));
                    Menu.Add("laneclearUseE", new CheckBox("Use E"));
                    Menu.Add("laneclearUseR", new CheckBox("Use R", false)); // Default false

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
                public static bool UseQ
                {
                    get { return Menu["jungleclearUseQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseW
                {
                    get { return Menu["jungleclearUseW"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseE
                {
                    get { return Menu["jungleclearUseE"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseR
                {
                    get { return Menu["jungleclearUseR"].Cast<CheckBox>().CurrentValue; }
                }
                public static int Mana
                {
                    get { return Menu["jungleclearMana"].Cast<Slider>().CurrentValue; }
                }

                static JungleClear()
                {
                    // Here is another option on how to use the menu, but I prefer the
                    // way that I used in the combo class
                    Menu.AddGroupLabel("JungleClear");
                    Menu.Add("jungleclearUseQ", new CheckBox("Use Q"));
                    Menu.Add("jungleclearUseW", new CheckBox("Use W"));
                    Menu.Add("jungleclearUseE", new CheckBox("Use E"));
                    Menu.Add("jungleclearUseR", new CheckBox("Use R", false)); // Default false

                    // Adding a slider, we have a little more options with them, using {0} {1} and {2}
                    // in the display name will replace it with 0=current 1=min and 2=max value
                    Menu.Add("jungleclearMana", new Slider("Maximum mana usage in percent ({0}%)", 10));
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}
