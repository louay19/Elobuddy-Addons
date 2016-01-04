using EloBuddy;
using EloBuddy.SDK;

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
            var enemyheroes = EntityManager.Heroes.Enemies;
            foreach(var h in enemyheroes)
            {
                int timeflymissile = (int) Player.Instance.Distance(h) / R.Speed;
                if (h.IsValidTarget(10000) && Extensions.GetDamageToTarget(SpellSlot.R, h) > Prediction.Health.GetPrediction(h,timeflymissile+2))
                {
                    var Pred = R.GetPrediction(h);
                    if(Pred.HitChancePercent > Settings.HitChance )
                    {
                        R.Cast(Pred.CastPosition);
                    }
                }
            }

            // TODO: Add permaactive logic here, good for spells like Ignite or Smite
        }
    }
}
