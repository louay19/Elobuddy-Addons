using EloBuddy.SDK;
using System.Linq;

namespace Kindred.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return true;
        }

        public override void Execute()
        {
            if (!R.IsReady()) return;
            if (Player.HealthPercent < Config.Misc.LowHP)
            {
                if (R.Cast(Player)) return;
            }

            var allylowHP = EntityManager.Heroes.Allies.Where(o => o.HealthPercent < Config.Misc.LowHP
                                                             && o.Distance(Player) < R.Range).First();
            if (allylowHP != null)
            {
                if (R.Cast(allylowHP)) return;
            }
        }
    }
}
