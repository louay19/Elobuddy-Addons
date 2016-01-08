using System;
using EloBuddy;
using EloBuddy.SDK;

namespace Velkoz
{
    public static class SpellManager
    {
        // You will need to edit the types of spells you have for each champ as they
        // don't have the same type for each champ, for example Xerath Q is chargeable,
        // right now it's  set to Active.
        public static Spell.Skillshot Q { get; private set; }
        public static Spell.Skillshot QSplit { get; private set; }
        public static Spell.Skillshot QDummy { get; private set; }
        public static Spell.Skillshot W { get; private set; }
        public static Spell.Skillshot E { get; private set; }
        public static Spell.Skillshot R { get; private set; }

        static SpellManager()
        {
            // Initialize spells


            // TODO: Uncomment the other spells to initialize them
            Q = new Spell.Skillshot(SpellSlot.Q, 1050, EloBuddy.SDK.Enumerations.SkillShotType.Linear, 250, 1200, 50);
            QSplit = new Spell.Skillshot(SpellSlot.Q, 1000, EloBuddy.SDK.Enumerations.SkillShotType.Linear, 250, 2100, 55);
            QDummy = new Spell.Skillshot(SpellSlot.Q, (uint)Math.Sqrt(Math.Pow(Q.Range, 2) + Math.Pow(QSplit.Range, 2)), EloBuddy.SDK.Enumerations.SkillShotType.Linear, 250, int.MaxValue, 55)
            {
                AllowedCollisionCount = int.MaxValue
            };

            W = new Spell.Skillshot(SpellSlot.W, 1050, EloBuddy.SDK.Enumerations.SkillShotType.Linear, 350, int.MaxValue, 85)
            {
                AllowedCollisionCount = int.MaxValue
            };
            E = new Spell.Skillshot(SpellSlot.E, 850, EloBuddy.SDK.Enumerations.SkillShotType.Circular, 500, int.MaxValue, 155);
            R = new Spell.Skillshot(SpellSlot.R, 1550, EloBuddy.SDK.Enumerations.SkillShotType.Linear, 250, int.MaxValue, 200)
            {
                AllowedCollisionCount = int.MaxValue
            };
        }

        public static void Initialize()
        {
            // Let the static initializer do the job, this way we avoid multiple init calls aswell
        }
    }        
}
