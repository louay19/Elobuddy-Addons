using EloBuddy;
using EloBuddy.SDK;
using System.Linq;

namespace LuxMaster.Modes
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
            AutouseE();

        }

        public void AutouseE()
        {
            if (Program.luxEObject == null) return;
            var enemyheroes = EntityManager.Heroes.Enemies;        
            foreach (var h in enemyheroes)
            {
                if (h.Distance(Program.luxEObject.Position) < 350) E.Cast(h.Position);
            }
        }
    }
}
