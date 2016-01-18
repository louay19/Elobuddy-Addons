using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace AlistarMaster
{
    public static class Extensions
    {
        public static float GetDamageToTarget(SpellSlot spell, Obj_AI_Base tar)
        {      
            float damage;
            switch (spell)
            {
                case SpellSlot.Q:
                    damage = new float[] { 60, 105, 150, 195, 240 }[SpellManager.Q.Level - 1] + 0.5f * Player.Instance.TotalMagicalDamage;
                    return Player.Instance.CalculateDamageOnUnit(tar, DamageType.Magical, damage) - 10.0f;
                case SpellSlot.W:
                    damage = new float[] { 55, 110, 165, 220, 275 }[SpellManager.W.Level - 1] + 0.7f * Player.Instance.TotalMagicalDamage;
                    return Player.Instance.CalculateDamageOnUnit(tar, DamageType.Magical, damage) - 10.0f;
                default:
                    return 0;
            }
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
