using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = LuxMaster.Config.Harass;

namespace LuxMaster.Modes
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
            if (MyHero.ManaPercent < Settings.Mana) return;
            var target = TargetSelector.GetTarget(3343, DamageType.Magical);
            if (target == null || !target.IsValid) return;
            // TODO: Add combo logic here
            // See how I used the Settings.UseQ here, this is why I love my way of using
            // the menu in the Config class!
            if (Settings.UseQ && Q.IsReady() && target.IsValidTarget(Q.Range))
            {
              
                    Q.Cast(target.ServerPosition);
            }

            if (Settings.UseE && E.IsReady() && target.IsValidTarget(E.Range) && E.Name == "LuxLightStrikeKugel")
            {
                
                    E.Cast(target.ServerPosition);
            }

            if (Settings.UseR && R.IsReady() && target.IsValidTarget(R.Range))
            {
                R.Cast(target.ServerPosition);
            }

        }
    }
}
