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
            var target = EntityManager.MinionsAndMonsters.GetJungleMonsters().Where(j => 
            j.Health < 1.1f*Player.Instance.GetAutoAttackDamage(j) 
            && Player.Instance.IsInRange(j,Q.Range+150)).First();

            if (Settings.UseQ && Q.IsReady() && target.IsValidTarget(Q.Range + 150))
            {
                if (ObjectManager.Player.Distance(target) > 525f
                    && !Extensions.FishBoneActive
                    && Player.Instance.ManaPercent > Settings.Mana
                   )
                {
                    Q.Cast();
                }
            }
        }
    }
}
