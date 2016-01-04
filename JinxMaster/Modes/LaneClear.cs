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
            && Player.Instance.IsInRange(o, Extensions.FishBoneRange())).First();
                if (Settings.UseQ && Q.IsReady() && target != null)
                {
                    Orbwalker.ForcedTarget = target;
                    if (target.IsValidTarget(Q.Range +150)
                        && ObjectManager.Player.Distance(target) > 525f
                        && !Extensions.Fishbone() && CheckFarmQ(target) && Player.Instance.ManaPercent > Settings.Mana)
                    {
                        Q.Cast();
                    }
                    if  (Extensions.Fishbone()) 
                    {
                        Q.Cast();
                    }
                }
                // TODO: Add laneclear logic here
            }
        

        private bool CheckFarmQ(AttackableUnit target)
        {
                var minions = EntityManager.MinionsAndMonsters.GetLaneMinions().Where(m => target.IsInRange(m,200) && Player.Instance.GetAutoAttackDamage(m) > m.Health);   
                if (minions.Count() >= 2) return true;
                else return false;             
        }
    }
}
