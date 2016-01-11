using EloBuddy;
using EloBuddy.SDK;
using System;

// Using the config like this makes your life easier, trust me
using Settings = Velkoz.Config.Modes.Harass;

namespace Velkoz.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on harass mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {
            if (Settings.Mana > Player.ManaPercent) return;
            // TODO: Add harass logic here
            // See how I used the Settings.UseQ and Settings.Mana here, this is why I love
            // my way of using the menu in the Config class!
            var target = TargetSelector.GetTarget(1500, DamageType.Magical);
            if (target != null && target.IsValidTarget(1575) && ObjectManager.Player.ManaPercent > (float)Settings.Mana)
            {

                //Q Normal
                if (Settings.UseQ && Q.IsReady() && Q.Name != "velkozqsplitactivate" && target.IsValidTarget(Q.Range))
                {
                    var Pred = Q.GetPrediction(target);
                    if (Pred.HitChancePercent > 70)
                    {
                        Q.Cast(Pred.CastPosition);
                        ModeManager.cpbool = false;
                    }
                    else //Q Smart
                    if (Settings.UseSmartQ && Q.IsReady() && Q.Name != "velkozqsplitactivate")
                    {
                        var PredQDummy = QDummy.GetPrediction(target);
                        if (PredQDummy.HitChancePercent > 70)
                        {
                            for (var i = -1; i < 1; i = i + 2)
                            {
                                var alpha = 30 * (float)Math.PI / 180;
                                ModeManager.cp = ObjectManager.Player.ServerPosition.To2D() +
                                         (PredQDummy.CastPosition.To2D() - ObjectManager.Player.ServerPosition.To2D()).Rotated
                                         (i * alpha);

                                var minions = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.ServerPosition, Q.Range * 1.5f);

                                if (!Q.GetCollision(Player.Position.To2D(), ModeManager.cp, minions, 5000, 80, 0)
                                    && !Q.GetCollision(ModeManager.cp, PredQDummy.CastPosition.To2D(), minions, 5000, 80, 0)) //Need to fixed here
                                {
                                    Q.Cast(ModeManager.cp.To3DWorld());
                                    ModeManager.cpbool = true;
                                }
                            }
                        }
                    }
                }

                //W Skill Harass
                if (Settings.UseW && W.IsReady() && target.IsValidTarget(W.Range))
                {
                    var Pred = W.GetPrediction(target);
                    if (Pred.HitChancePercent > 75) W.Cast(Pred.CastPosition);
                }

                //E Skill Harass
                if (Settings.UseE && E.IsReady() && target.IsValidTarget(E.Range))
                {
                    var Pred = E.GetPrediction(target);
                    if (Pred.HitChancePercent > 75) E.Cast(Pred.CastPosition);
                }

                //R Skill Harass
                if (Settings.UseR && R.IsReady() && target.IsValidTarget(R.Range))
                {
                    var Pred = R.GetPrediction(target);
                    if (Pred.HitChancePercent > 75) R.Cast(Pred.CastPosition);
                }
            }
        }
    }
}
