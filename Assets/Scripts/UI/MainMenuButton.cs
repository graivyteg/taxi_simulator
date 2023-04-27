using UI;

public class MainMenuButton : SpecialButton
{
    protected override void OnClick()
    {
        LoadingScreen.Instance.ReloadScene();
    }
}