using EloBuddy;
using EloBuddy.SDK;
using Settings = AlistarMaster.Config.Modes.JungleClear;

namespace AlistarMaster.Modes
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
            if (Config.Modes.Misc.Keepuppassivebuff && E.IsReady()) E.Cast();
            // TODO: Add jungleclear logic here
        }
    }
}
