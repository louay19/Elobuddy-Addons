using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;
using EloBuddy.SDK;
using System.Linq;

namespace Chogath
{
    public static class Program
    {
        // Change this line to the champion you want to make the addon for,
        // watch out for the case being correct!
        public const string ChampName = "Chogath";

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
           
            if (Config.Modes.Misc.MiscQ && sender.IsEnemy && sender.IsValidTarget(SpellManager.Q.Range) && SpellManager.Q.IsReady())
                SpellManager.Q.Cast(sender);
            if (Config.Modes.Misc.MiscW && sender.IsEnemy && sender.IsValidTarget(SpellManager.W.Range) && SpellManager.W.IsReady())
                SpellManager.W.Cast(sender);

            throw new NotImplementedException();
        }

        private static void Gapcloser_OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (Config.Modes.Misc.MiscQ && sender.IsEnemy && sender.IsValidTarget(SpellManager.Q.Range) && SpellManager.Q.IsReady())
                SpellManager.Q.Cast(e.End);
            if (Config.Modes.Misc.MiscW && sender.IsEnemy && sender.IsValidTarget(SpellManager.W.Range) && SpellManager.W.IsReady())
                SpellManager.W.Cast(e.End);

            throw new NotImplementedException();
        }

        private static void OnDraw(EventArgs args)
        {
            // Debug Range Skill
            /*
            Circle.Draw(Color.Red, SpellManager.Q.Radius, Player.Instance.Position);
            Circle.Draw(Color.Green, SpellManager.Q.Range, Player.Instance.Position);
            Circle.Draw(Color.Yellow, SpellManager.W.Range, Player.Instance.Position);
            Circle.Draw(Color.Blue, SpellManager.R.Range, Player.Instance.Position);*/
            
        }
    }
}
