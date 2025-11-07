using UnityEngine;
using UnityEngine.SceneManagement;
public class Control : MonoBehaviour
{

    public string SceneName;
    public void NextScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
