using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = LuxMaster.Config.Combo;

namespace LuxMaster.Modes
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
            var target = TargetSelector.GetTarget(3340, DamageType.Magical);
            if (target == null || !target.IsValid) return;
            // TODO: Add combo logic here
            // See how I used the Settings.UseE here, this is why I love my way of using
            // the menu in the Config class!
            if (Settings.UseQ && Q.IsReady() && target.IsValidTarget(Q.Range))
            {
                var Pred = Q.GetPrediction(target);
                if (Pred.HitChance > EloBuddy.SDK.Enumerations.HitChance.Collision)
                    Q.Cast(Pred.CastPosition);
            }

            if (Settings.UseE && E.IsReady() && target.IsValidTarget(E.Range) && E.Name == "LuxLightStrikeKugel")
            {
                var Pred = E.GetPrediction(target);
                if (Pred.HitChance > EloBuddy.SDK.Enumerations.HitChance.Collision)
                    E.Cast(Pred.CastPosition);
            }

            if (Settings.UseR && R.IsReady() && target.IsValidTarget(R.Range)
                && target.Health < Extensions.GetDamageToTarget(SpellSlot.R, target))
            {
                var Pred = R.GetPrediction(target);
                if (Pred.HitChance > EloBuddy.SDK.Enumerations.HitChance.Collision)
                    R.Cast(Pred.CastPosition);
            }
        }
    }
}
