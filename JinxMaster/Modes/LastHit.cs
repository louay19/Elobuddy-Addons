using EloBuddy;
using EloBuddy.SDK;
using System.Linq;

namespace JinxMaster.Modes
{
    public sealed class LastHit : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on lasthit mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit);
        }

        public override void Execute()
        {
            var minion = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.Position, Q.Range).Where(m => m.Health < Player.Instance.GetAutoAttackDamage(m) * 1.1f).First();
            Orbwalker.ForcedTarget = minion;
        }
    }
}
