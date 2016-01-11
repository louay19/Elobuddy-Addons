using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

namespace Velkoz.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Since this is permaactive mode, always execute the loop
            return true;
        }


        public override void Execute()
        {
            // TODO: Add permaactive logic here, good for spells like Ignite or Smite
            missileTracker();
        }

        private void missileTracker()
        {
            if (ModeManager.missile == null|| ModeManager.missile.IsDead)
            {
                ModeManager.missile = null;
                ModeManager.cp = Vector2.Zero;
                ModeManager.cpbool = false;
                return;
            }
            Vector2 posi = ModeManager.missile.Position.Extend(ModeManager.missile.EndPosition, Q.Speed * (Game.Ping / 800));
            if (ModeManager.cp != Vector2.Zero)
            {
                if (ModeManager.missile.StartPosition.Distance(ModeManager.cp.To3DWorld()) <= 150 + ModeManager.missile.StartPosition.Distance(posi.To3DWorld()))
                {
                    if (Q.Name == "velkozqsplitactivate" && ModeManager.cpbool)
                    {
                        Q.Cast(ModeManager.cp.To3DWorld());
                        ModeManager.cpbool = false;
                        ModeManager.cp = Vector2.Zero;
                    }
                }
            }          
        }
    }
}
