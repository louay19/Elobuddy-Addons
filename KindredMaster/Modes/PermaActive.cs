﻿using EloBuddy;
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
            if (Player.HealthPercent < Config.Misc.LowHP && CheckEnemyHeroesAround(Player) > 0)
            {
                if (R.Cast(Player.Position)) return;
            }

            var allylowHP = EntityManager.Heroes.Allies.Where(o => o.HealthPercent < Config.Misc.LowHP
                                                             && o.Distance(Player) < R.Range).First();
            if (allylowHP != null && CheckEnemyHeroesAround(allylowHP) > 0)
            {
                if (R.Cast(allylowHP.Position)) return;
            }
        }

        private int CheckEnemyHeroesAround(Obj_AI_Base target)
        {
            var heroesenemy = EntityManager.Heroes.Enemies.Where(o => o.Distance(target) < 1500);
            return heroesenemy.Count();
        }
    }
}
