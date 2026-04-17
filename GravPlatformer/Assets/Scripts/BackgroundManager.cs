using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
	
	public GameObject caveBackground, worldBackground;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        caveBackground.SetActive(false);
		worldBackground.SetActive(true);
    }
	
	private void OnTriggerEnter2D (Collider2D other){
		if (other.CompareTag("Player")){
			caveBackground.SetActive(true);
			worldBackground.SetActive(false);
		}
	}
	
	private void OnTriggerExit2D (Collider2D other){
		if (other.CompareTag("Player")){
			caveBackground.SetActive(false);
			worldBackground.SetActive(true);
		}
	}

    
}
