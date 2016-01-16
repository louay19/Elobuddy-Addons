using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;
using EloBuddy.SDK;

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
            if (!Config.Modes.Misc.MiscQ && !Config.Modes.Misc.MiscW && sender.Type != GameObjectType.AIHeroClient && sender.IsAlly && !sender.IsValid) return;
            if (SpellManager.W.IsReady() && ObjectManager.Player.Distance(sender) < SpellManager.W.Range)
                SpellManager.W.Cast(sender);
            if (SpellManager.Q.IsReady() && ObjectManager.Player.Distance(sender) < SpellManager.Q.Range)
                SpellManager.Q.Cast(sender);
            throw new NotImplementedException();
        }

        private static void Gapcloser_OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (!Config.Modes.Misc.MiscQ && !Config.Modes.Misc.MiscW && sender.Type != GameObjectType.AIHeroClient && sender.IsAlly && !sender.IsValid) return;
            if (SpellManager.W.IsReady() && ObjectManager.Player.Distance(e.End) < SpellManager.W.Range)
                SpellManager.W.Cast(e.End);
            if (SpellManager.Q.IsReady() && ObjectManager.Player.Distance(e.End) < SpellManager.Q.Range)
                SpellManager.Q.Cast(e.End);
            throw new NotImplementedException();
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
