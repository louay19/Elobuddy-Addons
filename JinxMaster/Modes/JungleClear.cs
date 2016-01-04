using EloBuddy;
using EloBuddy.SDK;
using System.Linq;

// Using the config like this makes your life easier, trust me
using Settings = JinxMaster.Config.Modes.Jungleclear;

namespace JinxMaster.Modes
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on jungleclear mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {
            var target = EntityManager.MinionsAndMonsters.GetJungleMonsters().Where(j => j.Health < 1.1f*Player.Instance.GetAutoAttackDamage(j) && Player.Instance.IsInRange(j,Extensions.FishBoneRange()).First();
            if (Settings.UseQ && Q.IsReady() && target != null)
            {
                if (target.IsValidTarget(Extensions.FishBoneRange())
                    && ObjectManager.Player.Distance(target) > 525f
                    && !Extensions.Fishbone() && Player.Instance.ManaPercent > Settings.Mana)
                {
                    Q.Cast();
                }
                if  (Extensions.Fishbone()) 
                {
                    Q.Cast();
                }
            }
        }
    }
}
