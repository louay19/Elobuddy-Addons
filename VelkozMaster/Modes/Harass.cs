using EloBuddy;
using EloBuddy.SDK;

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

                if (Settings.UseQ && Q.IsReady() && Q.Name != "velkozqsplitactivate" && target.IsValidTarget(Q.Range))
                {
                    var Pred = Q.GetPrediction(target);
                    if (Pred.HitChancePercent > 75) Q.Cast(Pred.CastPosition);

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
