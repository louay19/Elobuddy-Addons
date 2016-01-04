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

        public static float GetDamageToTarget(AttackableUnit tar)
        {
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
