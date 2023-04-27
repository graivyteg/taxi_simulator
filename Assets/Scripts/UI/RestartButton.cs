using UI;

public class RestartButton : SpecialButton
{
    protected override void OnClick()
    {
        LoadingScreen.Instance.FadeIn(() =>
        {
            Player.Instance.Respawn();
        }, true);
    }
}