using EloBuddy;
using EloBuddy.SDK;
using System.Linq;
using Settings = Chogath.Config.Modes.LaneClear;

namespace Chogath.Modes
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
            if (!Q.IsReady() && !W.IsReady()) return;
            // TODO: Add laneclear logic here
            var minions = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, _Player.Position, 1000);


            if (Q.IsReady() && Settings.UseQ)
            {     
                Q.Cast(EntityManager.MinionsAndMonsters.GetCircularFarmLocation(minions, 175, 950, _Player.Position.To2D()).CastPosition);
            }
            
            if (W.IsReady() && Settings.UseW)
            {
                W.Cast(EntityManager.MinionsAndMonsters.GetLineFarmLocation(minions, 150, 650, _Player.Position.To2D()).CastPosition);
            }
            
            if(R.IsReady() && Settings.UseR)
            {
                var tar = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, _Player.Position, 350).Where(m => m.Health < Extensions.GetDamageToTarget(SpellSlot.R, m)).First();
                if (tar.IsValidTarget(350))
                {
                    R.Cast(tar);
                }
            }          
        }
    }
}
