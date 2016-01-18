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
            if (MyHero.HasBuff("recall"))
            {
                Chat.Print("Dang tele");
                return;
            }
            var enemyheroes = EntityManager.Heroes.Enemies.Where(h => h.IsValidTarget(1550));
            var allyheroes = EntityManager.Heroes.Allies.Where(a => a.HealthPercent < Config.Modes.Misc.LowHPE && MyHero.Distance(a) < E.Range);
            bool check = enemyheroes.Count() > 0;
            // TODO: Add permaactive logic here, good for spells like Ignite or Smite
            if (MyHero.HealthPercent < Config.Modes.Misc.LowHPR && R.IsReady() && check) R.Cast();
            if (allyheroes.Count() > 0 && E.IsReady()) E.Cast();           
        }
    }
}
