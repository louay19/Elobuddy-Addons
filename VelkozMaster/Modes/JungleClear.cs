using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = Velkoz.Config.Modes.JungleClear;

namespace Velkoz.Modes
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
            var minions = EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.ServerPosition,R.Range, true).ToArray();
            if (minions.Length == 0)
            {
                return;
            }
            if (Settings.UseQ && Q.IsReady() && Q.Name == "SpellVelkozQ")
            {
                if (Q.Cast(EntityManager.MinionsAndMonsters.GetLineFarmLocation(minions, Q.Width, (int)Q.Range).CastPosition))
                    return;
            }

            if (Settings.UseW && W.IsReady())
            {
                if (W.Cast(EntityManager.MinionsAndMonsters.GetLineFarmLocation(minions, W.Width, (int)W.Range).CastPosition))
                    return;
            }
            if (Settings.UseE && E.IsReady())
            {
                if (E.Cast(EntityManager.MinionsAndMonsters.GetCircularFarmLocation(minions, E.Width, (int)E.Range).CastPosition))
                    return;
            }
            if (Settings.UseR && R.IsReady())
            {
                if (R.Cast(EntityManager.MinionsAndMonsters.GetLineFarmLocation(minions, R.Width, (int)R.Range).CastPosition))
                    return;
            }
        }
    }
}
