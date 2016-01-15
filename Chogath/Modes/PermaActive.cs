﻿using EloBuddy;

namespace Chogath.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Since this is permaactive mode, always execute the loop
            return true;
        }

        public override void Execute()
        {
            //Chat.Print("E State: " + _Player.Spellbook.GetSpell(EloBuddy.SpellSlot.E).ToggleState.ToString());
            if (_Player.Spellbook.GetSpell(EloBuddy.SpellSlot.E).ToggleState != 2) E.Cast();
            // TODO: Add permaactive logic here, good for spells like Ignite or Smite
        }
    }
}
