using EloBuddy;
using EloBuddy.SDK;
using System.Linq;

namespace AlistarMaster.Modes
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
            var enemyheroes = EntityManager.Heroes.Enemies.Where(h => h.IsValidTarget(1550));
            bool check = enemyheroes.Count() > 0;
            // TODO: Add permaactive logic here, good for spells like Ignite or Smite
            if (MyHero.HealthPercent < Config.Modes.Misc.LowHPR && R.IsReady() && check) R.Cast();
            if (MyHero.HealthPercent < Config.Modes.Misc.LowHPE && E.IsReady()) E.Cast();           
        }
    }
}
