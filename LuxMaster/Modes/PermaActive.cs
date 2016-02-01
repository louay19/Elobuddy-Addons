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
            var enemyminions = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Program.luxEObject.Position, 350);
            bool check = false;    
            foreach (var h in enemyheroes)
            {
                if (h.Distance(Program.luxEObject.Position) < 350 + h.BoundingRadius)
                {
                    if(E.Cast(Program.luxEObject.Position)) check = true;
                }
            }
            if (check == false && enemyminions.Count() >= 4) SpellManager.E.Cast(Program.luxEObject.Position);
        }

        public void AutoProtectW()
        {
            var allyheroes = EntityManager.Heroes.Allies
                .Where(a => Player.Instance.Distance(a) < 1100 
                            && a.HealthPercent < 50
                            && a.Position.CountEnemiesInRange(1100) > 0).First();
            if (allyheroes.IsValidTarget(SpellManager.W.Range))
            {
                SpellManager.W.Cast(allyheroes.Position);
            }

        }
    }
}
