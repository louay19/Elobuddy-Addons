using System.Linq;
using EloBuddy.SDK;
using EloBuddy;
using SharpDX;
using Settings = Kindred.Config.Modes.LaneClear;

namespace Kindred.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            var availableSpells = SpellManager.Spells.Where(spell => spell.IsReady()).ToArray();
            if (availableSpells.Length > 0)
            {
                var targetMinion = Kindred.GetTargetMinion(Player.AttackRange);
                if (targetMinion != null)
                {
                    foreach(var spell in availableSpells)
                    {
                        switch (spell.Slot)
                        {
                            case SpellSlot.Q:
                                Q.Cast(Game.CursorPos);
                                break;

                            case SpellSlot.W:
                                W.Cast();
                                break;
                         
                        }
                    }
                }
            }
        }
    }
}
