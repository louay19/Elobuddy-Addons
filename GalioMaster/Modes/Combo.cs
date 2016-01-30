using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = GalioMaster.Config.Combo;

namespace GalioMaster.Modes
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
            var target = TargetSelector.GetTarget(1500, DamageType.Physical);
            if (target == null) return;
            // TODO: Add combo logic here
            // See how I used the Settings.UseQ here, this is why I love my way of using
            // the menu in the Config class!
            if (Settings.UseQ && Q.IsReady() && target.IsValidTarget(Q.Range))
            {
                var Pred = Q.GetPrediction(target);
                if (Pred.HitChancePercent > Config.Misc.Hitchance) Q.Cast(target);
            }

            if(Settings.UseE && E.IsReady() && target.IsValidTarget(E.Range))
            {
                var Pred = E.GetPrediction(target);
                if (Pred.HitChancePercent > Config.Misc.Hitchance) E.Cast(target);
            }
        }
    }
}
