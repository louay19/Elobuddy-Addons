using EloBuddy;
using EloBuddy.SDK;
using System.Linq;
using Settings = AlistarMaster.Config.Modes.JungleClear;

namespace AlistarMaster.Modes
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
            var junglemonsters = EntityManager.MinionsAndMonsters.GetJungleMonsters(MyHero.Position, Q.Range, true);
            if (junglemonsters.Count() >= 2 && Q.IsReady()) Q.Cast();
            var tar = junglemonsters.FirstOrDefault();
            if (tar.IsValidTarget(W.Range) && W.IsReady() && tar.Health < Extensions.GetDamageToTarget(SpellSlot.W, tar))
                W.Cast(tar);
            // TODO: Add jungleclear logic here
        }
    }
}
