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

        public override void Execute()
        {
            // TODO: Add combo logic here
            // See how I used the Settings.UseQ here, this is why I love my way of using
            // the menu in the Config class!
            var target = TargetSelector.GetTarget(1500, DamageType.Magical);
            if (target != null && target.IsValidTarget(1575))
            {

                if (Settings.UseQ && Q.IsReady() &&Q.Name != "velkozqsplitactivate" && target.IsValidTarget(Q.Range))
                {
                    var Pred = Q.GetPrediction(target);
                    if(Pred.HitChancePercent > 75) Q.Cast(Pred.CastPosition);
                }
                if (Settings.UseSmartQ && Q.IsReady())
                {
                    var Pred = QDummy.GetPrediction(target);
                    if (Pred.HitChancePercent > 75)
                    {
                        for (var i = -1; i < 1; i = i + 2)
                        {
                            var alpha = 28 * (float)Math.PI / 180;
                            var cp = ObjectManager.Player.ServerPosition.To2D() +
                                     (Pred.CastPosition.To2D() - ObjectManager.Player.ServerPosition.To2D()).Rotated
                                     (i * alpha);
                            var minions = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.ServerPosition, Q.Range);

                            if (!(Q.GetCollision(Player.ServerPosition.To2D(), cp, minions, (float)Q.Speed, Q.Width, Q.CastDelay) &&
                               QSplit.GetCollision(cp, Pred.CastPosition.To2D(), minions, (float)QSplit.Speed, QSplit.Width, QSplit.CastDelay)))
                            {
                                if (Q.Name != "velkozqsplitactivate")
                                {
                                    Q.Cast(cp.To3DWorld());
                                }                        
                                if(Program.Velkoz_Q_Missile.IsInRange(cp.To3DWorld(),50f))
                                {
                                    Q.Cast(cp.To3DWorld());
                                }
                            }
                        }
                    }
                }
                if (Settings.UseW && W.IsReady() && target.IsValidTarget(W.Range))
                {
                    var Pred = W.GetPrediction(target);
                    if (Pred.HitChancePercent > 75) W.Cast(Pred.CastPosition);
                }
                if (Settings.UseE && E.IsReady() && target.IsValidTarget(E.Range))
                {
                    var Pred = E.GetPrediction(target);
                    if (Pred.HitChancePercent > 75) E.Cast(Pred.CastPosition);
                }

                if (Settings.UseR && R.IsReady() && target.IsValidTarget(R.Range))
                {
                    var Pred = R.GetPrediction(target);
                    if (Pred.HitChancePercent > 75) R.Cast(Pred.CastPosition);
                }
            }
        }
    }
}
