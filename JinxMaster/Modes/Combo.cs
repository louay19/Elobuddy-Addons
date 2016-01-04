using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = JinxMaster.Config.Modes.Combo;

namespace JinxMaster.Modes
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
            var target = TargetSelector.GetTarget(1500f, DamageType.Physical);

            if (Settings.UseQ && Q.IsReady())
            {              
                if (target.IsValidTarget(Q.Range+150)
                    && ObjectManager.Player.Distance(target) > 525f
                    && !Extensions.Fishbone() && Player.Instance.Mana > 100)
                {
                    Q.Cast();
                }
                if ((target.IsValidTarget(Q.Range)
                    && ObjectManager.Player.Distance(target) < 525f
                    && Extensions.Fishbone()) || (Player.Instance.Mana < 100 && Extensions.Fishbone())) 
                {
                    Q.Cast();
                }
            }

            if (Settings.UseW && W.IsReady())
            {
                if (target.IsValidTarget(W.Range) && ObjectManager.Player.Distance(target) > 525f)
                {
                    var Pred = W.GetPrediction(target);
                    if (Pred.HitChancePercent > 70)
                    W.Cast(Pred.CastPosition);
                }
            }

            if (Settings.UseE && E.IsReady())
            {
                if (target.IsValidTarget(E.Range))
                {
                    var Pred = E.GetPrediction(target);
                    if (Pred.HitChancePercent > 70)
                        E.Cast(Pred.CastPosition);
                }
            }

            if (Settings.UseR && R.IsReady())
            {
                if (target.IsValidTarget(R.Range) && ObjectManager.Player.Distance(target) > 525f)
                {
                    var Pred = R.GetPrediction(target);
                    if (Pred.HitChancePercent > 70)
                        R.Cast(Pred.CastPosition);
                }
            }
        }
    }
}
