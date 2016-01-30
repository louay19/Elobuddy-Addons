using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace LuxMaster
{
    public static class Extensions
    {
        public static Obj_AI_Base SelectLaneMinion(float range,SpellSlot spell)
        {
            switch (spell)
            {
                case SpellSlot.Q:
                    return EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.Position, SpellManager.Q.Range, true)
                                .Where(o => o.Health < Extensions.GetDamageToTarget(SpellSlot.Q, o))
                                 .FirstOrDefault();
                case SpellSlot.E:
                    return EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.Position, SpellManager.E.Range, true)
                                .Where(o => o.Health < Extensions.GetDamageToTarget(SpellSlot.E, o))
                                 .FirstOrDefault();
                case SpellSlot.R:
                    return EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.Position, SpellManager.R.Range, true)
                                .Where(o => o.Health < Extensions.GetDamageToTarget(SpellSlot.R, o))
                                 .FirstOrDefault();
                default:
                    return null;
            }
            
        }
        public static float GetDamageToTarget(SpellSlot spell, Obj_AI_Base tar)
        {
            float damage;
            switch (spell)
            {
                case SpellSlot.Q:
                    damage = new float[] { 60, 110, 160, 210, 260 }[SpellManager.Q.Level - 1] + 0.7f * Player.Instance.TotalMagicalDamage;
                    return Player.Instance.CalculateDamageOnUnit(tar, DamageType.Magical, damage) - 10.0f;
                case SpellSlot.E:
                    damage = new float[] { 60, 105, 150, 195, 240 }[SpellManager.E.Level - 1] + 0.6f * Player.Instance.TotalMagicalDamage;
                    return Player.Instance.CalculateDamageOnUnit(tar, DamageType.Magical, damage) - 10.0f;
                case SpellSlot.R:
                    damage = new float[] { 300, 400, 500 }[SpellManager.R.Level - 1] + 0.75f * Player.Instance.TotalMagicalDamage;
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

        public static bool IsPassiveReady(this AIHeroClient target)
        {
            return target.IsMe && target.HasBuff("XerathAscended2OnHit");
        }
    }
}
