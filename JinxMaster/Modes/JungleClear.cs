using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = JinxMaster.Config.Modes.Jungleclear;

namespace JinxMaster.Modes
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on jungleclear mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {
            var target = Orbwalker.LastTarget;
            if (Settings.UseQ && Q.IsReady())
            {
                if (target.IsValidTarget(Q.Range)
                    && ObjectManager.Player.Distance(target) > 525f
                    && !Extensions.Fishbone() && Player.Instance.ManaPercent > Settings.Mana)
                {
                    Q.Cast();
                }
                if ((target.IsValidTarget(Q.Range)
                    && ObjectManager.Player.Distance(target) < 525f
                    && Extensions.Fishbone()) || (Player.Instance.ManaPercent < Settings.Mana && Extensions.Fishbone()))
                {
                    Q.Cast();
                }
            }
        }
    }
}
