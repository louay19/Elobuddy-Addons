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
            if (R.IsReady() && Settings.UseR && _Player.GetBuff("Feast").Count != 6)
            {
                var tar = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, _Player.Position, 350).Where(m => m.Health < Extensions.GetDamageToTarget(SpellSlot.R, m) && m.IsValid).First();
                if (tar.IsValidTarget(350))
                {                  
                    R.Cast(tar);             
                }
            }

            if (_Player.ManaPercent > Settings.Mana)
            {
                var minion = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, _Player.Position, 1000).Where(m => m.Health < Extensions.GetDamageToTarget(SpellSlot.Q, m) && m.IsValidTarget(750)).First();
                if (minion !=  null && minion.IsValidTarget(750))
                {

                    if(minion.CountEnemiesInRange(150) > 2)
                    {
                        if (Q.IsReady() && Settings.UseQ)
                        {

                            Q.Cast(minion);
                        }

                        if (W.IsReady() && Settings.UseW)
                        {
                            W.Cast(minion);
                        }
                    }                   
                }            
            }
        }
    }
}
