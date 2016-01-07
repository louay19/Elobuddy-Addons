using System.Linq;
using EloBuddy.SDK;
using Settings = Velkoz.Config.Modes.LaneClear;

namespace Velkoz.Modes
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
            var minions = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.ServerPosition, W.Range, false).ToArray();
            if (minions.Length == 0)
            {
                return;
            }
            if (Settings.UseQ && Q.IsReady() && Q.Name == "VelkozQ")
            {
                Q.Cast(EntityManager.MinionsAndMonsters.GetLineFarmLocation(minions, Q.Width, (int)Q.Range).CastPosition);
            }

            if (Settings.UseW && W.IsReady())
            {
               if (W.Cast(EntityManager.MinionsAndMonsters.GetLineFarmLocation(minions, W.Width,(int) W.Range).CastPosition))
                    return;
            }
            if(Settings.UseE && E.IsReady())
            {
               if(E.Cast(EntityManager.MinionsAndMonsters.GetCircularFarmLocation(minions, E.Width, (int)E.Range).CastPosition))
                    return;
            }
            if (Settings.UseR && R.IsReady())
            {
                if (R.Cast(EntityManager.MinionsAndMonsters.GetLineFarmLocation(minions, R.Width, (int)R.Range).CastPosition))
                    return;
            }
            // TODO: Add laneclear logic here
        }
    }
}
