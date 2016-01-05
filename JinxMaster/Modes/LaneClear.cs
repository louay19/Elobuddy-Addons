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
            var target = EntityManager.MinionsAndMonsters.GetLaneMinions().Where(o => o.Health < 1.1f*Player.Instance.GetAutoAttackDamage(o)
            && Player.Instance.IsInRange(o,Q.Range+150)).First();
                if (Settings.UseQ && Q.IsReady() && target.IsValidTarget(Q.Range + 150))
                {
                    Orbwalker.ForcedTarget = target;
                    if (ObjectManager.Player.Distance(target) > 525f
                        && !Extensions.FishBoneActive
                        && CheckFarmQ(target) 
                        && Player.Instance.ManaPercent > Settings.Mana
                        )
                    {
                        Q.Cast();
                    }
                }
                // TODO: Add laneclear logic here
            }
        

        private bool CheckFarmQ(Obj_AI_Base target)
        {
            return target.CountAlliesInRange(150) > 2;         
        }
    }
}
