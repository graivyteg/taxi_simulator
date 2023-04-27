namespace DefaultNamespace
{
    public abstract class CarUpgrade : Upgrade<PrometeoCarController>
    {
        public abstract override void Apply(PrometeoCarController car);
    }
}