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
            var target = Orbwalker.LastTarget;
                if (Settings.UseQ && Q.IsReady())
                {
                    if (target.IsValidTarget(Q.Range)
                        && ObjectManager.Player.Distance(target) > 525f
                        && !Extensions.Fishbone() && CheckFarmQ(target) && Player.Instance.ManaPercent > Settings.Mana)
                    {
                        Q.Cast();
                    }
                    if ((target.IsValidTarget(Q.Range)
                        && ObjectManager.Player.Distance(target) < 525f
                        && Extensions.Fishbone()) ||(Player.Instance.ManaPercent < Settings.Mana && Extensions.Fishbone()))
                    {
                        Q.Cast();
                    }
                }
                // TODO: Add laneclear logic here
            }
        

        private bool CheckFarmQ(AttackableUnit target)
        {
            int countLasthit = 0;
            if (target.IsValidTarget(Q.Range))
            {
                var minions = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, target.Position, 200);
                
                foreach (var minion in minions)
                {
                    if (Orbwalker.IsLasthittableMinion(minion)) countLasthit++;
                }
            }
            if (countLasthit >= 3) return true;
            else return false;
        }
    }
}
