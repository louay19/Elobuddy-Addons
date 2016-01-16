using EloBuddy;
using EloBuddy.SDK;
using System.Linq;

namespace Chogath.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Since this is permaactive mode, always execute the loop
            return true;
        }

        public override void Execute()
        {
            if (_Player.Spellbook.GetSpell(EloBuddy.SpellSlot.E).ToggleState != 2) E.Cast();
            // TODO: Add permaactive logic here, good for spells like Ignite or Smite
            if(R.IsReady() && Config.Modes.Misc.MiscR )
            {
                var bigmob = BigMobSelect();
                if(bigmob != null && Extensions.GetDamageToTarget(SpellSlot.R, bigmob) > bigmob.Health)
                R.Cast(bigmob);
            }
        }

        private Obj_AI_Minion BigMobSelect()
        {
            return EntityManager.MinionsAndMonsters.GetJungleMonsters(_Player.Position, 450).Where(m => m.Name == "SRU_Baron" || m.Name == "SRU_Dragon").First();
        }
    }
}
