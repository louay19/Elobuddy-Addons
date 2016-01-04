using EloBuddy;
using EloBuddy.SDK;

namespace JinxMaster
{
    public static class SpellManager
    {
        // You will need to edit the types of spells you have for each champ as they
        // don't have the same type for each champ, for example Xerath Q is chargeable,
        // right now it's  set to Active.
        public static Spell.Active Q { get; private set; }
        public static Spell.Skillshot W { get; private set; }
        public static Spell.Skillshot E { get; private set; }
        public static Spell.Skillshot R { get; private set; }

        static SpellManager()
        {
            // Initialize spells
         
            // TODO: Uncomment the other spells to initialize them          
        }

        public static void Initialize()
        {
            // Let the static initializer do the job, this way we avoid multiple init calls aswell
            Q = new Spell.Active(SpellSlot.Q, 700);
            W = new Spell.Skillshot(SpellSlot.W, 1500, EloBuddy.SDK.Enumerations.SkillShotType.Linear, 750, 3200, 80);
            E = new Spell.Skillshot(SpellSlot.E, 900, EloBuddy.SDK.Enumerations.SkillShotType.Circular, 750, 1700, 50);
            R = new Spell.Skillshot(SpellSlot.R, 25000, EloBuddy.SDK.Enumerations.SkillShotType.Linear, 500, 1700, 225)
            {
                AllowedCollisionCount = int.MaxValue
            };    
        }
    }
}
