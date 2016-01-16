using EloBuddy;
using EloBuddy.SDK;

namespace Chogath
{
    public static class SpellManager
    {
        // You will need to edit the types of spells you have for each champ as they
        // don't have the same type for each champ, for example Xerath Q is chargeable,
        // right now it's  set to Active.
        public static Spell.Skillshot Q { get; private set; }
        public static Spell.Skillshot W { get; private set; }
        public static Spell.Active E { get; private set; }
        public static Spell.Targeted R { get; private set; }

        static SpellManager()
        {
            // Initialize spells
            Q = new Spell.Skillshot(SpellSlot.Q,950,EloBuddy.SDK.Enumerations.SkillShotType.Circular,450,1250,50);

            // TODO: Uncomment the other spells to initialize them
            W = new Spell.Skillshot(SpellSlot.W, 575, EloBuddy.SDK.Enumerations.SkillShotType.Cone, 250,int.MaxValue,50);
            W.AllowedCollisionCount = int.MaxValue;
            E = new Spell.Active(SpellSlot.E);
            R = new Spell.Targeted(SpellSlot.R,500);
        }

        public static void Initialize()
        {
            // Let the static initializer do the job, this way we avoid multiple init calls aswell
        }
    }
}
