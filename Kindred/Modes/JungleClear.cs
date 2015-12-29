using System.Linq;
using EloBuddy.SDK;
using EloBuddy;
using SharpDX;
using Settings = Kindred.Config.Modes.JungleClear;

namespace Kindred.Modes
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {


            var availableSpells = SpellManager.Spells.Where(spell => spell.IsReady()).ToArray();
            if (availableSpells.Length > 0)
            {
                var targetMinion = Kindred.GetTargetJungle(900);

                if (targetMinion != null)
                {
                    foreach (var spell in availableSpells)
                    {
                        switch (spell.Slot)
                        {
                            case SpellSlot.Q:
                                Q.Cast(Game.CursorPos);
                                break;

                            case SpellSlot.W:
                                W.Cast();
                                break;
                            case SpellSlot.E:
                                if (targetMinion.Name.Contains("SRU_Dragon") ||
                                    targetMinion.Name.Contains("SRU_Baron") ||
                                    targetMinion.Name.StartsWith("SRU_Red") ||
                                    targetMinion.Name.StartsWith("SRU_Blue") ||
                                    targetMinion.Name.StartsWith("SRU_Murkwolf") ||
                                    targetMinion.Name.StartsWith("SRU_Krug") ||
                                    targetMinion.Name.StartsWith("SRU_Gromp") ||
                                    targetMinion.Name.StartsWith("SRU_Razorbeak")
                                    )
                                    E.Cast(targetMinion);
                                break;

                        }
                    }
                }
            }
        }
    }
}
