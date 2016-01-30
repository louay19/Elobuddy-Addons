using EloBuddy;
using EloBuddy.SDK;
using System.Linq;
using Settings = Chogath.Config.Modes.JungleClear;

namespace Chogath.Modes
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
            
            // TODO: Add jungleclear logic here
            if (R.IsReady() && Settings.UseR)
            {
                var Rbuff = _Player.GetBuff("Feast");
                var tar = EntityManager.MinionsAndMonsters.GetJungleMonsters(_Player.Position, 500).Where(m => m.Health < Extensions.GetDamageToTarget(SpellSlot.R, m) && m.IsValid).First();
                if (Rbuff == null) R.Cast(tar);
                if (Rbuff.Count != 6) R.Cast(tar);
            }

            if (_Player.ManaPercent > Settings.Mana)
            {           
                var minion = EntityManager.MinionsAndMonsters.GetJungleMonsters(_Player.ServerPosition, 950f, true).FirstOrDefault();
                if (Q.IsReady() && Settings.UseQ && minion != null) 
                {
                    Q.Cast(minion.Position);
                }

                if (W.IsReady() && Settings.UseW && minion != null)
                {
                    W.Cast(minion.Position);
                }
            }
        }
    }
}
