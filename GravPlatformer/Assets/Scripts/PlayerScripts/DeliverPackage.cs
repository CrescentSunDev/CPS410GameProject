using UnityEngine;

public class DeliverPackage : MonoBehaviour
{
    public GameObject buttonPromptUI;
    public GameObject packagePrefab;
    public GameObject exitZone;
    private bool isPlayerInside = false;
    private bool isDelivered = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonPromptUI.SetActive(false);
        exitZone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PackageDelivery();
    }

    void PackageDelivery()
    {
        if(Input.GetKeyDown(KeyCode.E) && isPlayerInside && !isDelivered) {
            Debug.Log("Package delivered.");
            isDelivered = true;
            Instantiate(packagePrefab, new Vector2(transform.position.x, transform.position.y - 1), Quaternion.identity);
            exitZone.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // show UI
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Player entered.");
            isPlayerInside = true;
            buttonPromptUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // disable UI
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player exited.");
            isPlayerInside = false;
            buttonPromptUI.SetActive(false);
        }
    }
}
