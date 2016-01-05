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
            var target = EntityManager.MinionsAndMonsters.GetJungleMonsters()
                .Where(j => j.Health < 1.1f*Player.Instance.GetAutoAttackDamage(j) 
                            && Player.Instance.Distance(j) < Q.Range).First();

            if (Q.IsReady() && Extensions.FishBoneActive)
                {
                    Q.Cast();
                    Chat.Print("Q Name: " + Q.Name + "\n"
                               + "Q State: " + Q.State + "\n");
                }


            if (target != null && Settings.UseQ && Q.IsReady())
            {
                if (!Extensions.FishBoneActive
                    && Player.Instance.ManaPercent > Settings.Mana
                   )
                {
                    Q.Cast();
                }
               
            }
           
        }
    }
}
