using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using Settings = Kindred.Config.Modes.Harass;

namespace Kindred.Modes
{
    public sealed class Harass : ModeBase
    {
        public bool QSent { get; set; }
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {
            var availableSpells = SpellManager.Spells.Where(spell => spell.IsReady() && spell.IsEnabled(Orbwalker.ActiveModes.Combo)).ToArray();
            if (availableSpells.Length > 0)
            {                             
                
            }
        }
    }
}
