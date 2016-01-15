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
            if (_Player.ManaPercent < Settings.Mana) return;
            if (!Q.IsReady() && !W.IsReady()) return;
            var minions = EntityManager.MinionsAndMonsters.GetJungleMonsters(_Player.Position, 1000);


            if (Q.IsReady() && Settings.UseQ)
            {
                Q.Cast(EntityManager.MinionsAndMonsters.GetCircularFarmLocation(minions, 175, 950, _Player.Position.To2D()).CastPosition);
            }

            if (W.IsReady() && Settings.UseW)
            {
                W.Cast(EntityManager.MinionsAndMonsters.GetLineFarmLocation(minions, 150, 650, _Player.Position.To2D()).CastPosition);
            }

            if (R.IsReady() && Settings.UseR)
            {
                var tar = EntityManager.MinionsAndMonsters.GetJungleMonsters(_Player.Position, 350).Where(m => m.Health < Extensions.GetDamageToTarget(SpellSlot.R, m)).First();
                if (tar.IsValidTarget(350))
                {
                    R.Cast(tar);
                }
            }
        }
    }
}
