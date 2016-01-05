using EloBuddy;
using EloBuddy.SDK;
using System.Linq;

// Using the config like this makes your life easier, trust me
using Settings = JinxMaster.Config.Modes.Misc;

namespace JinxMaster.Modes
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
            // TODO: Add permaactive logic here, good for spells like Ignite or Smite
            Ultimate();
            OffFishBone();
        }

        private void Ultimate()
        {
            var enemyheroes = EntityManager.Heroes.Enemies;
            foreach (var h in enemyheroes)
            {
                int timeflymissile = (int)Player.Instance.Distance(h) / R.Speed;
                if (h.IsValidTarget(10000) && Extensions.GetDamageToTarget(SpellSlot.R, h) > 0.5f*Prediction.Health.GetPrediction(h, timeflymissile))
                {
                    var Pred = R.GetPrediction(h);
                    if (Pred.HitChancePercent > Settings.HitChance)
                    {
                        R.Cast(Pred.CastPosition);
                    }
                }
            }
        }

        private void OffFishBone()
        {
            var minions = EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.Position, Q.Range);
            var heroes = EntityManager.Heroes.Enemies.Where(o => Player.Instance.IsInRange(o, Q.Range));
            if (Extensions.FishBoneActive && minions == null && heroes == null )
            {
                Q.Cast();
            }
        }
    }
}
