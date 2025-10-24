using UnityEngine;

public class ScoreboardMenuButtonManager : MonoBehaviour
{
    [SerializeField] MainMenuManager.ScoreboardButtons _buttonType;
    public void ButtonClicked()
    {
        MainMenuManager._.ScoreboardButtonClicked(_buttonType);
    }
}