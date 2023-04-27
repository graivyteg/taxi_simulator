namespace UI
{
    public class CarUpgradeButton : UpgradeButton<PrometeoCarController>
    {
        protected override void ApplyUpgrade()
        {
            Upgrades[CurrentUpgradeId].Apply(Player.Instance.GetCar());
        }
    }
}