using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace Chogath
{
    public static class Extensions
    {
        public static float GetDamageToTarget(this SpellSlot spell, Obj_AI_Base tar)
        {      
            float damage = 0;
            switch (spell)
            {
                case SpellSlot.Q:
                    damage = new float[] { 80, 135, 190, 245, 305 }[SpellManager.Q.Level - 1] + 1.0f * Player.Instance.TotalMagicalDamage;
                    return Player.Instance.CalculateDamageOnUnit(tar, DamageType.Magical, damage) - 20.0f;
                case SpellSlot.W:
                    damage = new float[] { 75, 125, 175, 225, 275 }[SpellManager.W.Level - 1] + 0.7f * Player.Instance.TotalMagicalDamage;
                    return Player.Instance.CalculateDamageOnUnit(tar, DamageType.Magical, damage) - 20.0f;
                case SpellSlot.E:
                    damage = new float[] { 20, 35, 50, 65, 80 }[SpellManager.E.Level - 1] + 0.3f * Player.Instance.TotalMagicalDamage;
                    float Pdamage = Player.Instance.TotalAttackDamage;
                    return Player.Instance.CalculateDamageOnUnit(tar, DamageType.Magical, damage) + Player.Instance.CalculateDamageOnUnit(tar,DamageType.Physical,Pdamage) - 10.0f;
                case SpellSlot.R: 
                    if (tar.Type != GameObjectType.AIHeroClient)
                    damage = new float[] { 1000, 1000, 1000 }[SpellManager.R.Level - 1] + 0.7f * Player.Instance.TotalMagicalDamage - 20.0f;
                    else
                    damage = new float[] { 300, 475, 650 }[SpellManager.R.Level - 1] + 0.7f * Player.Instance.TotalMagicalDamage;                 
                    return Player.Instance.CalculateDamageOnUnit(tar, DamageType.True, damage) - 20.0f;
            }
            return 0;
        }

        public static bool HasUndyingBuff(this AIHeroClient target)
        {
            // Various buffs
            if (target.Buffs.Any(
                b => b.IsValid() &&
                     (b.DisplayName == "Chrono Shift" /* Zilean R */||
                      b.DisplayName == "JudicatorIntervention" /* Kayle R */||
                      b.DisplayName == "Undying Rage" /* Tryndamere R */)))
            {
                return true;
            }

            // Poppy R
            if (target.ChampionName == "Poppy")
            {
                if (EntityManager.Heroes.Allies.Any(o => !o.IsMe && o.Buffs.Any(b => b.Caster.NetworkId == target.NetworkId && b.IsValid() && b.DisplayName == "PoppyDITarget")))
                {
                    return true;
                }
            }

            return target.IsInvulnerable;
        }

        public static bool HasSpellShield(this AIHeroClient target)
        {
            // Various spellshields
            return target.HasBuffOfType(BuffType.SpellShield) || target.HasBuffOfType(BuffType.SpellImmunity);
        }

        public static float TotalShieldHealth(this Obj_AI_Base target)
        {
            return target.Health + target.AllShield + target.AttackShield + target.MagicShield;
        }

        public static int GetStunDuration(this Obj_AI_Base target)
        {
            return (int) (target.Buffs.Where(b => b.IsActive && Game.Time < b.EndTime &&
                                           (b.Type == BuffType.Charm ||
                                            b.Type == BuffType.Knockback ||
                                            b.Type == BuffType.Stun ||
                                            b.Type == BuffType.Suppression ||
                                            b.Type == BuffType.Snare)).Aggregate(0f, (current, buff) => Math.Max(current, buff.EndTime)) - Game.Time) * 1000;
        }
    }
}
