﻿using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;
using EloBuddy.SDK;
using System.Linq;

namespace LuxMaster
{
    public static class Program
    {
        // Change this line to the champion you want to make the addon for,
        // watch out for the case being correct!
        public const string ChampName = "Lux";
        public static GameObject luxEObject;

        public static void Main(string[] args)
        {
            // Wait till the loading screen has passed
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            // Verify the champion we made this addon for
            if (Player.Instance.ChampionName != ChampName)
            {
                // Champion is not the one we made this addon for,
                // therefore we return
                return;
            }

            // Initialize the classes that we need
            Config.Initialize();
            SpellManager.Initialize();
            ModeManager.Initialize();

            // Listen to events we need
            Drawing.OnDraw += OnDraw;
            GameObject.OnCreate += Obj_AI_Base_OnCreate;
            GameObject.OnDelete += GameObject_OnDelete;
            Gapcloser.OnGapcloser += Gapcloser_OnGapcloser;
            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
            AttackableUnit.OnDamage += Obj_AI_Base_OnDamage;
            Chat.Print("Lux Master ver 8.23.13.2.2016");
        }

        private static void Obj_AI_Base_OnCreate(GameObject sender, EventArgs args)
        {
            if (sender.Name.Contains("Lux_Base_E_mis.troy") || sender.Name.Contains("Lux_Base_E_tar_nova.troy"))
            {
                luxEObject = sender;
            }
        }

        private static void GameObject_OnDelete(GameObject sender, EventArgs args)
        {
            if (sender.Name.Contains("Lux_Base_E_mis.troy") || sender.Name.Contains("Lux_Base_E_tar_nova.troy"))
            {
                luxEObject = null;
            }
        }

        private static void Obj_AI_Base_OnDamage(AttackableUnit sender, AttackableUnitDamageEventArgs args)
        {
            if (args.Target is Obj_AI_Base && args.Target.IsAlly)
            if (args.Target.IsMe && args.Damage > 35)
            {
                var allynearest = EntityManager.Heroes.Allies.Where(a => a.Distance(Player.Instance) < 1075f && a.IsValid && !a.IsMe);
                if (allynearest.Any()) SpellManager.W.Cast(allynearest.First());
                else SpellManager.W.Cast(Player.Instance);
            }
        }

        private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender.IsEnemy && sender.IsValidTarget(3000) )
            {
                var ally = EntityManager.Heroes.Allies.Where(a => a.Distance(Player.Instance.Position) < SpellManager.W.Range);
                foreach(var a in ally)
                {
                    if (a.IsValid && Prediction.Position.Collision.CircularMissileCollision(a, args.Start.To2D(), args.End.To2D(), 1800, 250, 250))
                    {
                        SpellManager.W.Cast(a.ServerPosition);
                    }
                }                 
            }                
        }

        private static void Gapcloser_OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (sender.IsEnemy && sender.IsValidTarget(1560))
            {
                if (SpellManager.Q.IsReady()) SpellManager.Q.Cast(sender);
                if (SpellManager.E.IsReady()) SpellManager.E.Cast(sender);
            }
        }

        private static void OnDraw(EventArgs args)
        {
            // Draw range circles of our spells
            //if (luxEObject != null)
            //Circle.Draw(Color.Red, luxEObject.BoundingRadius+150, luxEObject.Position);
            // TODO: Uncomment if you want those enabled aswell, but remember to enable them
            // TODO: in the SpellManager aswell, otherwise you will get a NullReferenceException
            //Circle.Draw(Color.Red, SpellManager.W.Range, Player.Instance.Position);
            //Circle.Draw(Color.Red, SpellManager.E.Range, Player.Instance.Position);
            //Circle.Draw(Color.Red, SpellManager.R.Range, Player.Instance.Position);
        }
    }
}
