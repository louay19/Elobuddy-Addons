using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = Chogath.Config.Modes.Combo;

namespace Chogath.Modes
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
            if (target != null && target.IsValidTarget(1500))
            {
               

                if (Settings.UseQ && Q.IsReady() &&  target.IsValidTarget(Q.Range))
                {
                    var Pred = Q.GetPrediction(target);
                    if(Pred.HitChance == EloBuddy.SDK.Enumerations.HitChance.Collision)
                       Q.Cast(Pred.CastPosition); 
                }

                if (Settings.UseW && W.IsReady() && target.IsValidTarget(W.Range))
                {

                        if (W.Cast(target)) return;
                }

                if (Settings.UseR && R.IsReady() && target.IsValidTarget(R.Range) && Extensions.GetDamageToTarget(SpellSlot.R, target) > target.Health)
                {
                        if (R.Cast(target)) return;
                }
            }
        }
    }
}
