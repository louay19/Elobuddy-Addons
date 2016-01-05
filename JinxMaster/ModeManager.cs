using System;
using System.Collections.Generic;
using JinxMaster.Modes;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Utils;
using EloBuddy.SDK.Events;

namespace JinxMaster
{
    public static class ModeManager
    {
        private static List<ModeBase> Modes { get; set; }

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
            Gapcloser.OnGapcloser += Gapcloser_OnGapcloser;
            Interrupter.OnInterruptableSpell += Interrupter_OnInterruptableSpell;
            Obj_AI_Base.OnBuffGain += AIHeroClient_OnBuffGain;
        }

        public static void Initialize()
        {
            // Let the static initializer do the job, this way we avoid multiple init calls aswell
        }

        private static void AIHeroClient_OnBuffGain(Obj_AI_Base sender, Obj_AI_BaseBuffGainEventArgs args)
        {
            if (!Config.Modes.Misc.UseE) return;
            var heroes = EntityManager.Heroes.Enemies;
            foreach (var h in heroes)
            {
                if (sender.IsEnemy
                    && sender == h
                    && sender.IsValidTarget(SpellManager.E.Range)
                    && Player.Instance.Distance(sender) < SpellManager.E.Range
                   )
                {
                    if (args.Buff.IsKnockup
                        || args.Buff.IsRoot
                        || args.Buff.IsStunOrSuppressed
                        || args.Buff.IsSuppression
                      )
                        SpellManager.E.Cast(sender);
                }
            }
            throw new NotImplementedException();
        }

        private static void Interrupter_OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs args)
        {
            if (!Config.Modes.Misc.UseE) return;
            if (sender.IsEnemy && Config.Modes.Misc.UseE && SpellManager.E.IsReady() && SpellManager.E.IsInRange(sender))
            {
                //Cast E on interrupter
                SpellManager.E.Cast(sender);
            }
            throw new NotImplementedException();
        }

        private static void Gapcloser_OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs args)
        {
            if (!Config.Modes.Misc.UseE || !Config.Modes.Misc.UseW) return;
            if (sender.IsEnemy && Config.Modes.Misc.UseE && SpellManager.E.IsReady() && SpellManager.E.IsInRange(args.End))
            {
                // Cast E on the gapcloser caster
                SpellManager.E.Cast(sender);
            }
            if (sender.IsEnemy && Config.Modes.Misc.UseW && SpellManager.W.IsReady() && SpellManager.W.IsInRange(args.End))
            {
                // Cast W on the gapcloser caster
                SpellManager.W.Cast(sender);
            }
            throw new NotImplementedException();
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
