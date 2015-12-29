using System.Linq;
using EloBuddy.SDK;
using EloBuddy;
using SharpDX;
using Settings = Kindred.Config.Modes.Flee;

namespace Kindred.Modes
{
    public sealed class Flee : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {
        }
    }
}
