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
            if (R.IsReady() && Settings.UseR && _Player.GetBuff("Feast").Count != 6)
            {
                var tar = EntityManager.MinionsAndMonsters.GetJungleMonsters(_Player.Position, 350).Where(m => m.Health < Extensions.GetDamageToTarget(SpellSlot.R, m)).First();
                if (tar.IsValidTarget(350))
                {
                    R.Cast(tar);
                }
            }
            if (_Player.ManaPercent > Settings.Mana)
            {
                var minion = Orbwalker.LastTarget;
                if (Q.IsReady() && Settings.UseQ)
                {
                    Q.Cast(minion.Position);
                }

                if (W.IsReady() && Settings.UseW)
                {
                    W.Cast(minion.Position);
                }
            }
        }
    }
}
