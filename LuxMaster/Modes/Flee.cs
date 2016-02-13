using EloBuddy.SDK;

namespace LuxMaster.Modes
{
    public sealed class Flee : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on flee mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {
            var target = TargetSelector.GetTarget(1200, EloBuddy.DamageType.Magical);
            if (target == null) return;
            if (Q.IsReady()) Q.Cast(target);
            if (W.IsReady()) W.Cast(target);
            if (E.IsReady()) E.Cast(target);
            // TODO: Add flee logic here
        }
    }
}
