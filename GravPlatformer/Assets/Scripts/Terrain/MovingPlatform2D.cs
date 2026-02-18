using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlatform2D_Physics : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;
    public float arriveDistance = 0.05f;
    public bool loop = true;
    public bool pingPong = false;
    public float waitTimeAtPoint = 0f;

    private Rigidbody2D _rb;
    private int _index = 0;
    private int _dir = 1;
    private float _waitTimer = 0f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.bodyType = RigidbodyType2D.Kinematic;
        _rb.gravityScale = 0f;
    }

    void FixedUpdate()
    {
        if (waypoints == null || waypoints.Length < 2) return;

        if (_waitTimer > 0f)
        {
            _waitTimer -= Time.fixedDeltaTime;
            return;
        }

        Vector2 current = _rb.position;
        Vector2 target = waypoints[_index].position;

        Vector2 next = Vector2.MoveTowards(current, target, speed * Time.fixedDeltaTime);
        _rb.MovePosition(next);

        if (Vector2.Distance(next, target) <= arriveDistance)
        {
            if (waitTimeAtPoint > 0f) _waitTimer = waitTimeAtPoint;
            AdvanceIndex();
        }
    }

    private void AdvanceIndex()
    {
        if (pingPong)
        {
            if (_index == waypoints.Length - 1) _dir = -1;
            else if (_index == 0) _dir = 1;

            _index += _dir;
            return;
        }

        if (_index >= waypoints.Length - 1)
        {
            if (loop) _index = 0;
        }
        else
        {
            _index++;
        }
    }
}
