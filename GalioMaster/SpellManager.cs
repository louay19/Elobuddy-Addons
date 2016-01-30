using EloBuddy;
using EloBuddy.SDK;

namespace GalioMaster
{
    public static class SpellManager
    {
        // You will need to edit the types of spells you have for each champ as they
        // don't have the same type for each champ, for example Xerath Q is chargeable,
        // right now it's  set to Active.
        public static Spell.Skillshot Q { get; private set; }
        public static Spell.Active W { get; private set; }
        public static Spell.Skillshot E { get; private set; }
        public static Spell.Active R { get; private set; }

        static SpellManager()
        {
            // Initialize spells
            Q = new Spell.Skillshot(SpellSlot.Q,1000, EloBuddy.SDK.Enumerations.SkillShotType.Circular,250,1200,80);
            W = new Spell.Active(SpellSlot.W,2000);
            E = new Spell.Skillshot(SpellSlot.E,1200,EloBuddy.SDK.Enumerations.SkillShotType.Linear,250,1200,80);
            R = new Spell.Active(SpellSlot.R,750);
        }

        public static void Initialize()
        {
            // Let the static initializer do the job, this way we avoid multiple init calls aswell
        }
    }
}
