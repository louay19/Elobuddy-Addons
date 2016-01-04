using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace JinxMaster
{
    public static class Extensions
    {
        public static bool Fishbone()
        {
            if (ObjectManager.Player.AttackRange > 525) return true;
            else return false;
        }

        public static float FishBoneRange()
        {
            return 670f + Player.Instance.BoundingRadius + 25 * SpellManager.Q.Level;
        }

        public static float GetDamageToTarget(SpellSlot spell, Obj_AI_Base tar)
        {
            float damage = 0;
            switch (spell)
            {
                case SpellSlot.Q:
                    damage = new float[] { 0, 0, 0, 0, 0 }[SpellManager.Q.Level - 1] + 1.1f * Player.Instance.TotalAttackDamage;
                    return Player.Instance.CalculateDamageOnUnit(tar, DamageType.Physical, damage);
                case SpellSlot.W:
                    damage = new float[] { 10, 60, 110, 160, 210 }[SpellManager.W.Level - 1] + 1.4f * Player.Instance.TotalAttackDamage;
                    return Player.Instance.CalculateDamageOnUnit(tar, DamageType.Physical, damage);
                case SpellSlot.E:
                    damage = new float[] { 80, 135, 190, 245, 300 }[SpellManager.E.Level - 1] + 1.0f * Player.Instance.TotalMagicalDamage;
                    return Player.Instance.CalculateDamageOnUnit(tar, DamageType.Magical, damage);
                case SpellSlot.R:
                    damage = new float[] { 25, 35, 45 }[SpellManager.R.Level - 1] + new float[] { 25, 30, 35 }[SpellManager.R.Level - 1] / 100 * (tar.MaxHealth - tar.Health) + 0.1f * Player.Instance.FlatPhysicalDamageMod;
                    return Player.Instance.CalculateDamageOnUnit(tar, DamageType.Physical, damage);
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
