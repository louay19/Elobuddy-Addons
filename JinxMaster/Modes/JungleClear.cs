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
            var targetjungle = EntityManager.MinionsAndMonsters.GetJungleMonsters()
                .Where(j => j.Health < 1.1f*Player.Instance.GetAutoAttackDamage(j) 
                            && Player.Instance.Distance(j) < Q.Range).First();

            if (targetjungle != null && Settings.UseQ && Q.IsReady() && targetjungle.IsValid)
            {
                if (Player.Instance.AttackRange <= 525f
                    && Player.Instance.ManaPercent > Settings.Mana
                   )
                {
                    Q.Cast();
                }
               
            }
           
        }
    }
}
