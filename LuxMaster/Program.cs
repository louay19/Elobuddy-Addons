using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;
using EloBuddy.SDK;

namespace LuxMaster
{
    public static class Program
    {
        // Change this line to the champion you want to make the addon for,
        // watch out for the case being correct!
        public const string ChampName = "Lux";
        public static GameObject luxEObject;

        public static void Main(string[] args)
        {
            // Wait till the loading screen has passed
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            // Verify the champion we made this addon for
            if (Player.Instance.ChampionName != ChampName)
            {
                // Champion is not the one we made this addon for,
                // therefore we return
                return;
            }

            // Initialize the classes that we need
            Config.Initialize();
            SpellManager.Initialize();
            ModeManager.Initialize();

            // Listen to events we need
            Drawing.OnDraw += OnDraw;
            GameObject.OnCreate += Obj_AI_Base_OnCreate;
            GameObject.OnDelete += Obj_AI_Base_OnDelete;
            Gapcloser.OnGapcloser += Gapcloser_OnGapcloser;
            AttackableUnit.OnDamage += AIHeroClient_OnDamage;
        }

        private static void AIHeroClient_OnDamage(AttackableUnit sender, AttackableUnitDamageEventArgs args)
        {
            if (sender.IsAlly
               && sender.Type == GameObjectType.AIHeroClient
               && sender.IsValidTarget(SpellManager.W.Range)
               && sender.HealthPercent < 60
               && args.Damage > 50)
                SpellManager.W.Cast(sender.Position);
        }

        private static void Gapcloser_OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (sender.IsEnemy && sender.IsValidTarget(3340) && e.End.Distance(Player.Instance.Position) < 1000)
            {
                if (SpellManager.Q.IsReady()) SpellManager.Q.Cast(sender);
                if (SpellManager.E.IsReady()) SpellManager.E.Cast(sender);
            }
        }

        private static void Obj_AI_Base_OnDelete(GameObject sender, EventArgs args)
         {
             if (sender.Name == "Lux_Base_E_mis.troy")
             {
                 luxEObject = null;
             }
         }

        private static void Obj_AI_Base_OnCreate(GameObject sender, EventArgs args)
        {
            if (sender.Name == "Lux_Base_E_mis.troy")
            {
                luxEObject = sender;
                Chat.Print("Type object = " + sender.Type);
            }
        }

        private static void OnDraw(EventArgs args)
        {        
            // Draw range circles of our spells
            //Circle.Draw(Color.Red, SpellManager.Q.Range, Player.Instance.Position);
            // TODO: Uncomment if you want those enabled aswell, but remember to enable them
            // TODO: in the SpellManager aswell, otherwise you will get a NullReferenceException
            //Circle.Draw(Color.Red, SpellManager.W.Range, Player.Instance.Position);
            //Circle.Draw(Color.Red, SpellManager.E.Range, Player.Instance.Position);
            //Circle.Draw(Color.Red, SpellManager.R.Range, Player.Instance.Position);
        }
    }
}
