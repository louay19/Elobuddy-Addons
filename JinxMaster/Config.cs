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
        private const string MenuName = "Jinx Master Addon";

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
                Menu = Config.Menu.AddSubMenu("Misc");
                //Misc mode
                Misc.Initialize();
                // Initialize all orther modes
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
                
                
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                public static readonly Menu ComboMenu;

                public static int ManaSwitchQ
                {
                    get { return ComboMenu["manaSwitchQ"].Cast<Slider>().CurrentValue; }
                }
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
                    ComboMenu.Add("manaSwitchQ", new Slider("Low mana to use Q ({0}%): ", 0, 0, 100));
                    ComboMenu.Add("comboUseQ", new CheckBox("Use Q"));
                    ComboMenu.Add("comboUseW", new CheckBox("Use W"));
                    ComboMenu.Add("comboUseE", new CheckBox("Use E"));
                    ComboMenu.Add("comboUseR", new CheckBox("Use R",false)); // Default false
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                public static readonly Menu HarassMenu;
                public static bool UseQ
                {
                    get { return HarassMenu["harassUseQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseW
                {
                    get { return HarassMenu["harassUseW"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseE
                {
                    get { return HarassMenu["harassUseE"].Cast<CheckBox>().CurrentValue; }
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
                    HarassMenu.Add("harassUseW", new CheckBox("Use W"));
                    HarassMenu.Add("harassUseE", new CheckBox("Use E"));
                    HarassMenu.Add("harassUseR", new CheckBox("Use R", false)); // Default false

                    // Adding a slider, we have a little more options with them, using {0} {1} and {2}
                    // in the display name will replace it with 0=current 1=min and 2=max value
                    HarassMenu.Add("harassMana", new Slider("Maximum mana usage in percent ({0}%)", 40));
                }

                public static void Initialize()
                {
                }
            }

            public static class Laneclear
            {
                public static readonly Menu LaneclearMenu;

                public static int Mana
                {
                    get { return LaneclearMenu["LaneclearMana"].Cast<Slider>().CurrentValue; }
                }

                public static bool UseQ
                {
                    get { return LaneclearMenu["LaneclearUseQ"].Cast<CheckBox>().CurrentValue; }
                }


                static Laneclear()
                {
                    // Initialize the menu values
                    LaneclearMenu = Config.Menu.AddSubMenu("Laneclear");
                    LaneclearMenu.Add("LaneclearUseQ", new CheckBox("Use Q"));
                    LaneclearMenu.Add("LaneclearMana", new Slider("Maximum mana usage in percent ({0}%)", 40));
                }

                public static void Initialize()
                {
                }
            }

            public static class Jungleclear
            {
                public static readonly Menu JungleclearMenu;

                public static int Mana
                {
                    get { return JungleclearMenu["JungleclearMana"].Cast<Slider>().CurrentValue; }
                }
                public static bool UseQ
                {
                    get { return JungleclearMenu["JungleclearUseQ"].Cast<CheckBox>().CurrentValue; }
                }


                static Jungleclear()
                {
                    // Initialize the menu values
                    JungleclearMenu = Config.Menu.AddSubMenu("Jungleclear");
                    JungleclearMenu.Add("JungleclearUseQ", new CheckBox("Use Q"));
                    JungleclearMenu.Add("JungleclearMana", new Slider("Maximum mana usage in percent ({0}%)", 40));

                }

                public static void Initialize()
                {
                }
            }

            public static class Misc
            {


                public static int NumberQKill
                {
                    get { return Menu["NumberKillByQ"].Cast<Slider>().CurrentValue; }
                }
                public static int HitChance
                {
                    get { return Menu["HitChance"].Cast<Slider>().CurrentValue; }
                }
                public static bool GCUseW
                {
                    get { return Menu["GapCloseUseW"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool GCUseE
                {
                    get { return Menu["GapCloseUseE"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool IRUseE
                {
                    get { return Menu["InteruptUseE"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool CCUseE
                {
                    get { return Menu["CCUseE"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool LHUseR
                {
                    get { return Menu["LasthitR"].Cast<CheckBox>().CurrentValue; }
                }


                static Misc()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Misc Mode");
                    Menu.Add("NumberKillByQ", new Slider("Number minions to use Q ({0})",2,0,5));
                    Menu.Add("HitChance", new Slider("Hit chance for all skills in percent ({0}%)", 70));
                    Menu.Add("GapCloseUseW", new CheckBox("Use W To Gapclose"));
                    Menu.Add("GapCloseUseE", new CheckBox("Use E To Gapclose"));
                    Menu.Add("InteruptUseE", new CheckBox("Use E To Interupt Enemy"));
                    Menu.Add("CCUseE",new CheckBox("Use E On CC'ed Enemy"));
                    Menu.Add("LasthitR", new CheckBox("Use R To Last Hit"));
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}
