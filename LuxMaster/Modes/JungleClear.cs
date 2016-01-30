using EloBuddy;
using EloBuddy.SDK;
using System.Linq;
using Settings = LuxMaster.Config.JungleClear;

namespace LuxMaster.Modes
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
            if (MyHero.ManaPercent < Settings.Mana) return;
            var jungleminion = EntityManager.MinionsAndMonsters.GetJungleMonsters(MyHero.Position, 1100).First();
            if (jungleminion == null || !jungleminion.IsValid) return;
            if (Settings.UseQ && Q.IsReady() && jungleminion.IsValidTarget(Q.Range))
                Q.Cast(jungleminion.Position);
            if (Settings.UseE && E.IsReady() && jungleminion.IsValidTarget(E.Range))
                E.Cast(jungleminion.Position);
            if (Settings.UseR && R.IsReady() && jungleminion.IsValidTarget(R.Range))
                R.Cast(jungleminion.Position);
            // TODO: Add jungleclear logic here
        }
    }
}
