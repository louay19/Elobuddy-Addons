using EloBuddy;
using EloBuddy.SDK;
using System;

// Using the config like this makes your life easier, trust me
using Settings = Velkoz.Config.Modes.Combo;

namespace Velkoz.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on combo mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        private void ReactiveQ()
        {
            Q.Cast(Player);
        }

        public override void Execute()
        {
            // TODO: Add combo logic here
            // See how I used the Settings.UseQ here, this is why I love my way of using
            // the menu in the Config class!
            var target = TargetSelector.GetTarget(1600, DamageType.Magical);

            if (target != null && target.IsValidTarget(1575))
            {
                //Q Normal
                if (Settings.UseQ && Q.IsReady() &&Q.Name != "velkozqsplitactivate" && target.IsValidTarget(Q.Range))
                {
                    var Pred = Q.GetPrediction(target);
                    if(Pred.HitChancePercent > 60)
                    {
                        Q.Cast(Pred.CastPosition);

                    }                    
                }

                //Q Smart
                if (Settings.UseSmartQ && Q.IsReady())
                {
                    var Pred = QDummy.GetPrediction(target);
                    if (Pred.HitChancePercent > 70)
                    {
                        for (var i = -1; i < 1; i = i + 2)
                        {
                            var alpha = 28 * (float)Math.PI / 180;
                            ModeManager.cp = ObjectManager.Player.ServerPosition.To2D() +
                                     (Pred.CastPosition.To2D() - ObjectManager.Player.ServerPosition.To2D()).Rotated
                                     (i * alpha);
                            
                            var minions = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.ServerPosition, Q.Range*1.5f);

                            if (!Q.GetCollision(Player.Position.To2D(),ModeManager.cp,minions,5000,80,0) 
                                && !Q.GetCollision(ModeManager.cp, Pred.CastPosition.To2D(), minions, 5000, 80, 0)) //Need to fixed here
                            {
                                if (Q.Name == "velkozqsplitactivate")
                                {
                                    int delaytime = 1000 * (int)Player.Distance(ModeManager.cp.To3DWorld()) / 1200;
                                    Core.DelayAction(ReactiveQ, delaytime);
                                }
                                else Q.Cast(ModeManager.cp.To3DWorld());
                            }
                        }
                    }
                }
                //W Skill

                if (Settings.UseW && W.IsReady() && target.IsValidTarget(W.Range))
                {
                    var Pred = W.GetPrediction(target);
                    if (Pred.HitChancePercent > 70) W.Cast(Pred.CastPosition);
                }

                //E Skill
                if (Settings.UseE && E.IsReady() && target.IsValidTarget(E.Range))
                {
                    var Pred = E.GetPrediction(target);
                    if (Pred.HitChancePercent > 70) E.Cast(Pred.CastPosition);
                }

                //R Skill
                if (Settings.UseR && R.IsReady() && target.IsValidTarget(R.Range))
                {
                    R.Cast(target);
                }
            }
        }
    }
}
