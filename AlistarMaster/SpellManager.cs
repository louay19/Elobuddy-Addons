using EloBuddy;
using EloBuddy.SDK;

namespace AlistarMaster
{
    public static class SpellManager
    {
        // You will need to edit the types of spells you have for each champ as they
        // don't have the same type for each champ, for example Xerath Q is chargeable,
        // right now it's  set to Active.
        public static Spell.Active Q { get; private set; }
        public static Spell.Targeted W { get; private set; }
        public static Spell.Active E { get; private set; }
        public static Spell.Active R { get; private set; }

        static SpellManager()
        {
            // Initialize spells
            Q = new Spell.Active(SpellSlot.Q,365);

            // TODO: Uncomment the other spells to initialize them
            W = new Spell.Targeted(SpellSlot.W,650);
            E = new Spell.Active(SpellSlot.E,575);
            R = new Spell.Active(SpellSlot.R,1500);
        }

        public static void Initialize()
        {
            // Let the static initializer do the job, this way we avoid multiple init calls aswell
        }
    }
}
