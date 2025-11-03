using UnityEngine;

public class SwitchCanvas : MonoBehaviour
{
    public GameObject canvas1; // Assign in Inspector
    public GameObject canvas2; // Assign in Inspector

    public void ShowCanvas1()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
    }

    public void ShowCanvas2()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }
}