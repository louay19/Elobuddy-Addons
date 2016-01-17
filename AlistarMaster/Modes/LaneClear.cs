using EloBuddy;
using EloBuddy.SDK;
using System.Linq;
using Settings = AlistarMaster.Config.Modes.LaneClear;

namespace AlistarMaster.Modes
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
            var minions = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, MyHero.Position, Q.Range, true)
                .Where(m => m.Health < Extensions.GetDamageToTarget(SpellSlot.Q, m));
            if (minions.Count() >= 2) Q.Cast();
                // TODO: Add laneclear logic here
        }
    }
}
