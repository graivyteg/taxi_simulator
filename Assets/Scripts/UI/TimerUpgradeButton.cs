namespace UI
{
    public class TimerUpgradeButton : UpgradeButton<GameTimer>
    {
        protected override void ApplyUpgrade()
        {
            Upgrades[CurrentUpgradeId].Apply(GameTimer.Instance);
        }
    }
}