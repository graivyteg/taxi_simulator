namespace DefaultNamespace.Audio
{
    public class AudioButton : SpecialButton
    {
        protected override void OnClick()
        {
            AudioButtonSource.Instance.PlayClickSound();
        }
    }
}