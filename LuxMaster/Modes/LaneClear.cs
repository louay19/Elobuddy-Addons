using EloBuddy;
using EloBuddy.SDK;
using System.Linq;
using Settings = LuxMaster.Config.LaneClear;

namespace LuxMaster.Modes
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
            if (MyHero.ManaPercent < Settings.Mana) return;
            if(Settings.UseE && E.IsReady())
            {
                var minion = Extensions.SelectLaneMinion(E.Range, SpellSlot.E);
                if (minion.IsValid && minion.CountAlliesInRange(350) > 1) E.Cast(minion.ServerPosition);
            }

            if (Settings.UseQ && Q.IsReady())
            {
                var minion = Extensions.SelectLaneMinion(Q.Range, SpellSlot.Q);
                if (minion.IsValid) Q.Cast(minion);
            }

            if(Settings.UseR && R.IsReady())
            {
                var minions = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, MyHero.Position, R.Range);
                var bestpos = EntityManager.MinionsAndMonsters.GetLineFarmLocation(minions, 80, (int)R.Range, MyHero.Position.To2D());
                if (bestpos.HitNumber > 5) R.Cast(bestpos.CastPosition);
            }
        }
    }
}
