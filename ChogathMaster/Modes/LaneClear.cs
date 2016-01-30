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
            if (R.IsReady() && Settings.UseR)
            {
                var Rbuff = _Player.GetBuff("Feast");
                var tar = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, _Player.Position, 500).Where(m => m.Health < Extensions.GetDamageToTarget(SpellSlot.R, m) && m.IsValid).First();
                if (Rbuff == null) R.Cast(tar);
                if (Rbuff.Count != 6) R.Cast(tar);          
            }
           

            if (_Player.ManaPercent > Settings.Mana)
            {
                var minion = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, _Player.Position, 950).Where(m => m.IsValid && m.Health < Extensions.GetDamageToTarget(SpellSlot.W, m) + Extensions.GetDamageToTarget(SpellSlot.E, m)).First();
                if(Extensions.CheckBestLaneFarmTarget(minion,950))
                {
                    if (Q.IsReady() && Settings.UseQ && minion.IsValidTarget(Q.Range))
                    {
                        Q.Cast(minion.ServerPosition);
                    }

                    if (W.IsReady() && Settings.UseW && minion.IsValidTarget(W.Range))
                    {
                        W.Cast(minion.ServerPosition);
                    }
                }                               
            }
        }
    }
}
