using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = JinxMaster.Config.Modes.Harass;

namespace JinxMaster.Modes
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
            var target = TargetSelector.GetTarget(1500f, DamageType.Physical);        
                //Q Setting
                if (Settings.UseQ && Q.IsReady() && target.IsValidTarget(Q.Range + 150))
                {
                    if (ObjectManager.Player.Distance(target) < 525f
                        && Extensions.FishBoneActive)
                    {
                        Q.Cast();
                    }
                    if (ObjectManager.Player.Distance(target) > 525f
                        && !Extensions.FishBoneActive && ObjectManager.Player.ManaPercent > Settings.Mana)
                    {
                        Q.Cast();
                    }

                }
                //W Setting
                if (Settings.UseW && W.IsReady())
                {
                    if (target.IsValidTarget(W.Range) && ObjectManager.Player.Distance(target) > 525f)
                    {
                        var Pred = W.GetPrediction(target);
                        if (Pred.HitChancePercent > Config.Modes.Misc.HitChance)
                            W.Cast(Pred.CastPosition);
                    }
                }
                //E Setting
                if (Settings.UseE && E.IsReady())
                {
                    if (target.IsValidTarget(E.Range))
                    {
                        var Pred = E.GetPrediction(target);
                        if (Pred.HitChancePercent > Config.Modes.Misc.HitChance)
                            E.Cast(Pred.CastPosition);
                    }
                }
                //R Setting
                if (Settings.UseR && R.IsReady())
                {
                    if (target.IsValidTarget(R.Range) && ObjectManager.Player.Distance(target) > 525f)
                    {
                        var Pred = R.GetPrediction(target);
                        if (Pred.HitChancePercent > Config.Modes.Misc.HitChance)
                            R.Cast(Pred.CastPosition);
                    }
                }           
        }
    }
}