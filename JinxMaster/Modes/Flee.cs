﻿using EloBuddy;
using EloBuddy.SDK;

namespace JinxMaster.Modes
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
            E.Cast(Player.Instance);
            // TODO: Add flee logic here
        }
    }
}
