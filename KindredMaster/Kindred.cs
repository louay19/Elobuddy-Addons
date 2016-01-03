using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using Kindred.Modes;

namespace Kindred
{
    public static class Kindred
    {
        public static readonly Random Random = new Random(DateTime.Now.Millisecond);

        static Kindred()
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        public static void Main(string[] args)
        {
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.Hero != Champion.Kindred)
            {
                return;
            }

            // Initialize classes
            Config.Initialize();
            SpellManager.Initialize();
            ModeManager.Initialize();

            // Listen to required events
            // TODO
        }

        public static AIHeroClient GetTarget(float range)
        {
            var validEnemies = EntityManager.Heroes.Enemies.Where(o => o.IsValidTarget(range + Player.Instance.BoundingRadius + o.BoundingRadius)).ToArray();
            var preferredTarget = validEnemies.FirstOrDefault(o => o.HasBuff(SpellManager.PassiveBuffName) || o.HasBuff(SpellManager.EBuffName));

            // Return preferred target with either the passive debuff or the E debuff
            return preferredTarget ?? TargetSelector.GetTarget(validEnemies, DamageType.Physical);
        }

        public static Obj_AI_Minion GetTargetMinion(float range)
        {
            var target = Orbwalker.LaneclearMinion;
            if (ModeBase.Player.IsInRange(target, range))
            {
                return target;
            }
            else return null;       
        }

        public static Obj_AI_Minion GetTargetJungle(float range)
        {
            var target = EntityManager.MinionsAndMonsters.GetJungleMonsters(ModeBase.Player.Position,750).FirstOrDefault();
            if (ModeBase.Player.IsInRange(target, range))
            {
                return target;
            }
            else return null;
        }
    }
}
