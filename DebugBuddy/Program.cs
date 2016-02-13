using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;
using EloBuddy.SDK;
using System.Linq;

namespace DebugBuddy
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Wait till the loading screen has passed
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {

            // Listen to events we need
            Game.OnTick += Game_OnTick;
            //Drawing.OnDraw += OnDraw;
           // Gapcloser.OnGapcloser += Gapcloser_OnGapcloser;
            //Interrupter.OnInterruptableSpell += Interrupter_OnInterruptableSpell;
           // Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
           // Obj_AI_Base.OnBuffGain += Obj_AI_Base_OnBuffGain;
        }

        private static void Game_OnTick(EventArgs args)
        {
            var target = TargetSelector.GetTarget(1500, DamageType.Magical);
            Chat.Print("Target name: " + target.Name + " - Target Health: " + target.Health + "- Target Prediction Health: " + Prediction.Health.GetPrediction(target, 100));
            throw new NotImplementedException();
        }

        private static void Obj_AI_Base_OnBuffGain(Obj_AI_Base sender, Obj_AI_BaseBuffGainEventArgs args)
        {
            if (!sender.IsMe) return;
            Chat.Print(args.Buff.Name);
            throw new NotImplementedException();
        }

        private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (!(sender.Type == GameObjectType.AIHeroClient)) return;
            Chat.Print("Process Spell Cast report := " + sender.Name + " - " + args.SData.Name);
            throw new NotImplementedException();
        }

        private static void Interrupter_OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            Chat.Print("Interrupter report := " + sender.Name);
            throw new NotImplementedException();
        }

        private static void Gapcloser_OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            Chat.Print("Gapcloser report := " + sender.Name + " - " + e.Target.Name + " - " + e.SpellName);
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
