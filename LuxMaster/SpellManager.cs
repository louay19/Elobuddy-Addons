using EloBuddy;
using EloBuddy.SDK;

namespace LuxMaster
{
    public static class SpellManager
    {
        // You will need to edit the types of spells you have for each champ as they
        // don't have the same type for each champ, for example Xerath Q is chargeable,
        // right now it's  set to Active.
        public static Spell.Skillshot Q { get; private set; }
        public static Spell.Skillshot W { get; private set; }
        public static Spell.Skillshot E { get; private set; }
        public static Spell.Skillshot R { get; private set; }

        static SpellManager()
        {
            // Initialize spells
            Q = new Spell.Skillshot(SpellSlot.Q,1175,EloBuddy.SDK.Enumerations.SkillShotType.Linear,250,1200,60);

            W = new Spell.Skillshot(SpellSlot.W,1075,EloBuddy.SDK.Enumerations.SkillShotType.Linear,250,1700,100);
            E = new Spell.Skillshot(SpellSlot.E,1100,EloBuddy.SDK.Enumerations.SkillShotType.Circular,250,1700,175);
            R = new Spell.Skillshot(SpellSlot.R,3340,EloBuddy.SDK.Enumerations.SkillShotType.Linear,600,int.MaxValue,80);

            Q.AllowedCollisionCount = 1;
            W.AllowedCollisionCount = int.MaxValue;
            R.AllowedCollisionCount = int.MaxValue;
        }
        public static void Initialize()
        {
            // Let the static initializer do the job, this way we avoid multiple init calls aswell
        }
    }
}
