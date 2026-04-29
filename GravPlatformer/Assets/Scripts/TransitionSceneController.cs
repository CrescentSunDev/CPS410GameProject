using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionSceneController : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    [SerializeField] private float transitionDuration = 4f;

    private void Start()
    {
        Invoke(nameof(LoadNextScene), transitionDuration);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}