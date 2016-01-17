using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = AlistarMaster.Config.Modes.Combo;

namespace AlistarMaster.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on combo mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }
        private void Todo()
        {
            Settings.comboQW = false;
            Q.Cast();
            
        }
        public override void Execute()
        {

            // TODO: Add combo logic here
            // See how I used the Settings.UseQ here, this is why I love my way of using
            // the menu in the Config class!
            var target = TargetSelector.GetTarget(W.Range, DamageType.Magical);
            if (Settings.UseW && W.IsReady() && Q.IsReady() && target.IsValidTarget(W.Range))
            {
                Settings.comboQW = true;
                int delay = (int) MyHero.Distance(target.ServerPosition) * 150 / 650;
                if (W.Cast(target)) Core.DelayAction(Todo,delay);
            }

            if(Settings.comboQW == false && Q.IsReady() && target.IsValidTarget(Q.Range))
            {
                Q.Cast();
            }
        }
    }
}
