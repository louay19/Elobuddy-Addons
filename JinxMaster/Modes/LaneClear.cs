using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = JinxMaster.Config.Modes.Laneclear;

namespace JinxMaster.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on laneclear mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            var target = EntityManager.MinionsAndMonsters.GetLaneMinions()
                .Where(o => o.Health < 1.1f*Player.Instance.GetAutoAttackDamage(o)
                            && Player.Instance.Distance(o) < Q.Range).First();

            if (target != null && Settings.UseQ && Q.IsReady() && target.IsValid)
            {
                Orbwalker.ForcedTarget = target;
                if (!Extensions.FishBoneActive
                    && CheckFarmQ(target)
                    && Player.Instance.ManaPercent > Settings.Mana
                   )
                {
                    Q.Cast();
                }
                else Extensions.OffFishBone();
            }
            
                // TODO: Add laneclear logic here
            }
        

        private bool CheckFarmQ(Obj_AI_Base target)
        {
            var minions = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, target.Position, 185)
                .Where(l => l.Health < Player.Instance.GetAutoAttackDamage(l) * 1.1f);
            return minions.Count() > Config.Modes.Misc.NumberQKill;         
        }
    }
}
