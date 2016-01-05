using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass
namespace JinxMaster
{
    // I can't really help you with my layout of a good config class
    // since everyone does it the way they like it most, go checkout my
    // config classes I make on my GitHub if you wanna take over the
    // complex way that I use
    public static class Config
    {
        private const string MenuName = "JinxMasterAddon";

        private static readonly Menu Menu;

        static Config()
        {
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Welcome to Sivuu Family Addons!");
            Menu.AddLabel("I hope you can enjoy it !");
            Menu.AddLabel("Get Penta kill every game with this addon !!!");

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
                // Combo
                Combo.Initialize();
                Menu.AddSeparator();

                // Harass
                Harass.Initialize();
                Menu.AddSeparator();

                //Laneclear
                Laneclear.Initialize();
                Menu.AddSeparator();

                //Jungleclear
                Jungleclear.Initialize();
                //Misc mode
                Misc.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;

                public static int ManaSwitchQ
                {
                    get { return Menu["manaSwitchQ"].Cast<Slider>().CurrentValue; }
                }
                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
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
                    Menu.Add("manaSwitchQ", new Slider("Low mana to use Q ({0}%): ", 0, 0, 100));
                    _useQ = Menu.Add("comboUseQ", new CheckBox("Use Q"));
                    _useW = Menu.Add("comboUseW", new CheckBox("Use W"));
                    _useE = Menu.Add("comboUseE", new CheckBox("Use E"));
                    _useR = Menu.Add("comboUseR", new CheckBox("Use R",false)); // Default false
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
                    Menu.Add("harassUseW", new CheckBox("Use W"));
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

            public static class Laneclear
            {
                private static readonly CheckBox _useQ;

                public static int Mana
                {
                    get { return Menu["LaneclearMana"].Cast<Slider>().CurrentValue; }
                }

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }


                static Laneclear()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Laneclear");
                    _useQ = Menu.Add("LaneclearUseQ", new CheckBox("Use Q"));                    
                    Menu.Add("LaneclearMana", new Slider("Maximum mana usage in percent ({0}%)", 40));
                }

                public static void Initialize()
                {
                }
            }

            public static class Jungleclear
            {
                private static readonly CheckBox _useQ;

                public static int Mana
                {
                    get { return Menu["JungleclearMana"].Cast<Slider>().CurrentValue; }
                }
                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }


                static Jungleclear()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Jungleclear");
                    _useQ = Menu.Add("JungleclearUseQ", new CheckBox("Use Q"));
                    Menu.Add("JungleclearMana", new Slider("Maximum mana usage in percent ({0}%)", 40));

                }

                public static void Initialize()
                {
                }
            }

            public static class Misc
            {

                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;
                public static int NumberQKill
                {
                    get { return Menu["NumberKillByQ"].Cast<Slider>().CurrentValue; }
                }
                public static int HitChance
                {
                    get { return Menu["HitChance"].Cast<Slider>().CurrentValue; }
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


                static Misc()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Misc Mode");
                    Menu.Add("NumberKillByQ", new Slider("Number minions to use Q ({0})",2,0,5));
                    Menu.Add("HitChance", new Slider("Hit chance for all skills in percent ({0}%)", 70));
                    _useW = Menu.Add("UseW", new CheckBox("Use W To Gapclose"));
                    _useE = Menu.Add("UseE", new CheckBox("Use E To Gapclose"));
                    _useR = Menu.Add("LasthitR", new CheckBox("Use R To Last Hit"));
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}
