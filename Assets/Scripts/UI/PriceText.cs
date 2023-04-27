namespace UI
{
    public class PriceText : InjectableText
    {
        private string _currentPrice = "---";

        public void SetPrice(int newPrice)
        {
            _currentPrice = newPrice.ToString();
        }

        public void SetNonePrice()
        {
            _currentPrice = "---";
        }

        protected override string GetValue() => _currentPrice;
    }
}