using EloBuddy;
using EloBuddy.SDK;


namespace Velkoz.Modes
{
    public abstract class ModeBase
    {
        public static AIHeroClient Player
        {
            get { return EloBuddy.Player.Instance; }
        }
        // Change the spell type to whatever type you used in the SpellManager
        // here to have full features of that spells, if you don't need that,
        // just change it to Spell.SpellBase, this way it's dynamic with still
        // the most needed functions
        protected Spell.Skillshot Q
        {
            get { return SpellManager.Q; }
        }
        protected Spell.Skillshot QDummy
        {
            get { return SpellManager.QDummy; }
        }
        protected Spell.Skillshot QSplit
        {
            get { return SpellManager.QSplit; }
        }
        protected Spell.Skillshot W
        {
            get { return SpellManager.W; }
        }
        protected Spell.Skillshot E
        {
            get { return SpellManager.E; }
        }
        protected Spell.Skillshot R
        {
            get { return SpellManager.R; }
        }

        public abstract bool ShouldBeExecuted();

        public abstract void Execute();
    }
}
