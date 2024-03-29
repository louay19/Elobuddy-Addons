﻿using EloBuddy;
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
            AutoProtectW();
            AutoKillSteal();
            if(Program.luxEObject != null && E.Name.Contains("LuxLightStrikeKugel"))
            {
                Program.luxEObject = null;
            }
        }

        public void AutouseE()
        {
            if (Program.luxEObject == null) return;
            var enemyheroes = EntityManager.Heroes.Enemies.Where(h => h.Distance(Program.luxEObject.Position) <= Program.luxEObject.BoundingRadius + 150) ;
            var enemyminions = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Program.luxEObject.Position, Program.luxEObject.BoundingRadius+150);
            if (enemyheroes.Any()) E2.Cast();
            if (enemyminions.Count() >= 4) E2.Cast();
        }

        public void AutoProtectW()
        {
            var allyheroes = EntityManager.Heroes.Allies
                .Where(a => Player.Instance.Distance(a) < 1100 
                            && a.HealthPercent < 50
                            && a.Position.CountEnemiesInRange(1100) > 0).First();

        }

        public void AutoKillSteal()
        {
            var enemyheroes = EntityManager.Heroes.Enemies.Where(e => e.Distance(Player.Instance.Position) < SpellManager.R.Range 
            && (e.Health * 1.1f) < Extensions.GetDamageToTarget(SpellSlot.R, e)
            && e.IsValidTarget(3300));
            
            if (enemyheroes.Any())
            {             
                SpellManager.R.Cast(enemyheroes.First());
            }
        }
    }
}
