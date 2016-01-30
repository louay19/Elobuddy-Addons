using EloBuddy;
using EloBuddy.SDK;
using Settings = LuxMaster.Config.LaneClear;

namespace LuxMaster.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on laneclear mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            // TODO: Add laneclear logic here
        }
    }
}
