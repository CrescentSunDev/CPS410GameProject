using UnityEngine;

public class SwitchCanvas : MonoBehaviour
{
    public GameObject canvas1; // Assign in Inspector
    public GameObject canvas2; // Assign in Inspector
    public bool startOn;

    public void Start()
    {
        canvas1.SetActive(startOn);
    }

    public void ShowCanvas()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }
}