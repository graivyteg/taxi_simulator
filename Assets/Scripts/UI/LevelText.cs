namespace UI
{
    public class LevelText : InjectableText
    {
        private string _currentLevel;

        public void SetLevel(int level)
        {
            _currentLevel = level.ToString();
        }

        public void SetMaxLevel()
        {
            _currentLevel = "MAX";
        }

        protected override string GetValue() => _currentLevel;
    }
}