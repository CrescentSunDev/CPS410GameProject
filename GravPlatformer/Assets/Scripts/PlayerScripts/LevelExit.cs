using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    private bool isExiting = false;
    private bool hasExited = false;

    public GameObject player;
    public Transform stopPos;
    private float initialY;
    public float exitSpeed = 1f;
    private Transform playerStart;
    public CinemachineCamera vcam;

    [Header("Level Change")]
    public string nextSceneName;

    private void Start()
    {
        initialY = stopPos.transform.position.y;
    }

    private void Update()
    {
        Ascend();
        Freeze();
    }

    void Ascend()
    {
        if (isExiting && !hasExited)
        {
            if (player.transform.position.y + exitSpeed * Time.deltaTime > initialY)
            {
                Debug.Log("End level now.");
                hasExited = true;

                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                player.transform.position = new Vector2(
                    player.transform.position.x,
                    player.transform.position.y + exitSpeed * Time.deltaTime
                );

                transform.position = new Vector2(
                    transform.position.x,
                    transform.position.y + exitSpeed * Time.deltaTime
                );
            }
        }
    }

    void Freeze()
    {
        if (hasExited)
        {
            player.transform.position = new Vector2(stopPos.position.x, stopPos.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isExiting && collision.CompareTag("Player"))
        {
            isExiting = true;
            playerStart = player.transform;
            vcam.enabled = false;
        }
    }
}