using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = Chogath.Config.Modes.Harass;

namespace Chogath.Modes
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
            // TODO: Add harass logic here
            // See how I used the Settings.UseQ and Settings.Mana here, this is why I love
            // my way of using the menu in the Config class!
            var target = TargetSelector.GetTarget(Q.Range, DamageType.Physical);
            if (_Player.ManaPercent > Settings.Mana && target.IsValidTarget(1500))
            {
                if (Settings.UseQ && _Player.Distance(target) <= Q.Range)
                {
                    var Pred = Q.GetPrediction(target);
                    if (Pred.HitChancePercent > 70 && Q.IsReady())
                    {
                        if (Q.Cast(Pred.CastPosition)) return;
                    }

                }

                if (Settings.UseW && _Player.Distance(target) <= W.Range && W.IsReady())
                {

                    if (W.Cast(target)) return;
                }

                if (Settings.UseR && _Player.Distance(target) <= R.Range && R.IsReady() && Extensions.GetDamageToTarget(SpellSlot.R, target) > target.Health - 20)
                {
                    if (R.Cast(target)) return;
                }
            }
        }
    }
}
