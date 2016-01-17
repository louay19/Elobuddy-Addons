using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = AlistarMaster.Config.Modes.Harass;

namespace AlistarMaster.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on harass mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }
        private void Todo()
        {
            Config.Modes.Combo.comboQW = false;
            Q.Cast();           
        }
        public override void Execute()
        {
            // TODO: Add harass logic here
            // See how I used the Settings.UseQ and Settings.Mana here, this is why I love
            // my way of using the menu in the Config class!
            var target = TargetSelector.GetTarget(W.Range, DamageType.Magical);
            if (Settings.UseW && W.IsReady() && Q.IsReady() && target.IsValidTarget(W.Range))
            {
                Config.Modes.Combo.comboQW = true;
                int delay = (int)MyHero.Distance(target.ServerPosition) * 150 / 650;
                if (W.Cast(target)) Core.DelayAction(Todo, delay);
            }
            else
            if (Config.Modes.Combo.comboQW == false && Q.IsReady() && target.IsValidTarget(Q.Range))
            {
                Q.Cast();
            }
            if (Config.Modes.Misc.Keepuppassivebuff && E.IsReady()) E.Cast();
        }
    }
}
