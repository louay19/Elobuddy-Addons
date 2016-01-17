using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;

namespace AlistarMaster
{
    public static class Program
    {
        // Change this line to the champion you want to make the addon for,
        // watch out for the case being correct!
        public const string ChampName = "Alistar";

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
            Gapcloser.OnGapcloser += Gapcloser_OnGapcloser;
            Interrupter.OnInterruptableSpell += Interrupter_OnInterruptableSpell;
        }


        private static void Interrupter_OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            if (!Config.Modes.Misc.Interrupted) return;
            if (sender.IsEnemy && sender.IsValidTarget(SpellManager.W.Range))
            {
                if(SpellManager.W.IsReady()) SpellManager.W.Cast(sender);
            }
            if (sender.IsEnemy && sender.IsValidTarget(SpellManager.Q.Range))
            {
                if (SpellManager.Q.IsReady()) SpellManager.Q.Cast();
            }
            throw new NotImplementedException();
        }

        private static void Gapcloser_OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (!Config.Modes.Misc.AntiGapCloser) return;
            if (sender.IsEnemy && sender.IsValidTarget(SpellManager.W.Range) && Player.Instance.Distance(e.End) < 100)
            {
                if (SpellManager.W.IsReady()) SpellManager.W.Cast(sender);
            }
            if (sender.IsEnemy && sender.IsValidTarget(SpellManager.Q.Range))
            {
                if (SpellManager.Q.IsReady()) SpellManager.Q.Cast();
            }
            throw new NotImplementedException();
        }

        private static void OnDraw(EventArgs args)
        {
            // Draw range circles of our spells          
            // TODO: Uncomment if you want those enabled aswell, but remember to enable them
            // TODO: in the SpellManager aswell, otherwise you will get a NullReferenceException
            // Debug comboQW
           
            //Drawing.DrawText(10, 10, System.Drawing.Color.Red, "ComboQW is " + Config.Modes.Combo.comboQW);
        }
    }
}
