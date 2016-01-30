using EloBuddy;
using EloBuddy.SDK;
using System.Linq;

namespace LuxMaster.Modes
{
    public sealed class PermaActive : ModeBase
    {
        Obj_AI_Base Baron, Dragon;
        public override bool ShouldBeExecuted()
        {
            // Since this is permaactive mode, always execute the loop
            return true;
        }

        public override void Execute()
        {
            Baron = EntityManager.MinionsAndMonsters.Monsters.Where(o => o.Name == "SRU_Baron").First();
            Dragon = EntityManager.MinionsAndMonsters.Monsters.Where(o => o.Name == "SRU_Dragon").First();
            if (Program.luxEObject != null)
            {
                var enemyheroes = EntityManager.Heroes.Enemies;
                foreach(var h in enemyheroes)
                {
                    if (h.Distance(Program.luxEObject.Position) < 350) E.Cast(h.Position);
                }
            }


        }
    }
}
