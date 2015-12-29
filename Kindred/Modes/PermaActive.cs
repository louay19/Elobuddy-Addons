namespace Kindred.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return true;
        }

        public override void Execute()
        {
            if ((Player.Health/Player.MaxHealth) < 0.3f)
            {
                R.Cast(Player.Position);
                R.Cast();
            }
        }
    }
}
