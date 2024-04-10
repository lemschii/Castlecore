using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    private Rigidbody2D rb;
    
    private Vector2[] actions;
    private int action = -1;
    private int[] durations;
    private int duration = 0;
    private int count = 0;

    public float speed = 2.0f;
    private Vector2 leftSpeed;
    private Vector2 rightSpeed;

    // ground checking - add publics via drag and drop
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D> ();

        leftSpeed = new Vector2(-speed, 0.0f);
        rightSpeed = new Vector2(speed, 0.0f);

        createMovementPattern();
    }

    void createMovementPattern() {
        actions = new Vector2[8];
        durations = new int[8];
        actions[0] = rightSpeed;
        durations[0] = 20;
        actions[1] = Vector2.zero;
        durations[1] = 20;
        actions[2] = rightSpeed;
        durations[2] = 20;
        actions[3] = Vector2.zero;
        durations[3] = 40;

        actions[4] = leftSpeed;
        durations[4] = 20;
        actions[5] = Vector2.zero;
        durations[5] = 20;
        actions[6] = leftSpeed;
        durations[6] = 20;
        actions[7] = Vector2.zero;
        durations[7] = 40;
    }

    // Update is called once per frame
    void Update () {
        if (this.enabled == true)
        {
            Debug.Log("boobds");
            if (!onGround)
            {
                count = 0;
                duration = 0;
                Vector2 current = rb.velocity;
                rb.velocity = new Vector2(0.0f, current.y);
            }
            else if (count == duration)
            {
                pickAction();
            }
            else
            {
                count++;
            }
        }

    }

    void pickAction() {
        action++;
        if (action == actions.Length) {
            action = 0;
        }
        count = 0;

        rb.velocity = actions[action];
        duration = durations[action];
    }

    void FixedUpdate() {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

}