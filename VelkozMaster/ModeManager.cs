using System;
using System.Collections.Generic;
using Velkoz.Modes;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Utils;
using EloBuddy.SDK;

namespace Velkoz
{
    public static class ModeManager
    {
        private static List<ModeBase> Modes { get; set; }
        public static SharpDX.Vector2 cp;
        public static bool cpbool;
        public static MissileClient missile;

        static ModeManager()
        {
            // Initialize properties
            Modes = new List<ModeBase>();

            // Load all modes manually since we are in a sandbox which does not allow reflection
            // Order matter here! You would want something like PermaActive being called first
            Modes.AddRange(new ModeBase[]
            {
                new PermaActive(),
                new Combo(),
                new Harass(),
                new LaneClear(),
                new JungleClear(),
                new LastHit(),
                new Flee()
            });

            // Listen to events we need
            Game.OnTick += OnTick;
            GameObject.OnCreate += GameObject_OnCreate;
            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
            Gapcloser.OnGapcloser += Gapcloser_OnGapcloser;
            Interrupter.OnInterruptableSpell += Interrupter_OnInterruptableSpell;
            
        }

        private static void Interrupter_OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            if (sender.IsEnemy && sender.IsValidTarget(SpellManager.E.Range))
                SpellManager.E.Cast(sender);
            throw new NotImplementedException();
        }

        private static void Gapcloser_OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if(sender.IsEnemy && sender.IsValidTarget(SpellManager.E.Range))
            {
                SpellManager.E.Cast(e.End);
                SpellManager.Q.Cast(e.End);
            }
            throw new NotImplementedException();
        }

        private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (!sender.IsMe) return;
            Chat.Print("Name Spell" + args.SData.Name);
            throw new NotImplementedException();
        }

        private static void GameObject_OnCreate(GameObject sender, EventArgs args)
        {
            bool isMissile = sender.GetType() == typeof(MissileClient);
            if (!isMissile)
                return;
            var miss = sender as MissileClient;
            if (!miss.IsValidMissile() || miss.SpellCaster.NetworkId != Player.Instance.NetworkId || miss.SData.Name != "VelkozQMissile")
                return;
            missile = miss;
            throw new NotImplementedException();
        }

        public static void Initialize()
        {
            // Let the static initializer do the job, this way we avoid multiple init calls aswell
        }

        private static void OnTick(EventArgs args)
        {
            // Execute all modes
            Modes.ForEach(mode =>
            {
                try
                {
                    // Precheck if the mode should be executed
                    if (mode.ShouldBeExecuted())
                    {
                        // Execute the mode
                        mode.Execute();
                    }
                                    
                }
                catch (Exception e)
                {
                    // Please enable the debug window to see and solve the exceptions that might occur!
                    Logger.Log(LogLevel.Error, "Error executing mode '{0}'\n{1}", mode.GetType().Name, e);
                }
            });
        }
    }
}
