using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioSource audioSource;

    private float speed = 100f;
    public Rigidbody rb;
    private float horizontalMultiplier = .25f;

    private Vector2 touchStart;
    private float horizontalInput;  // Declare here

    void Start(){
        rb = GetComponent<Rigidbody>();
        GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<Animator>().Play("run");
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (transform.position.y < -10) {
            Restart();
        }
        //HandleInput();
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.thisCollider.gameObject.tag == "Respawn" || contact.otherCollider.gameObject.tag == "Respawn") {
                continue;
            }
            if (collision.relativeVelocity.magnitude > 1) {
                audioSource.Play();
                rb.constraints = 0;
                rb.mass = 0.01f;
                Invoke("Restart", 3f);
            }
        }
    }
    void Restart() {
        Application.LoadLevel(Application.loadedLevel);
    }
/*
    void HandleInput()
    {
        // Check for touches
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check for the phase of the touch
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStart = touch.position;
                    break;

                case TouchPhase.Moved:
                    // Calculate the swipe distance
                    float swipeDelta = touch.position.x - touchStart.x;

                    // Convert the swipe distance to a value between -1 and 1
                    horizontalInput = Mathf.Clamp(swipeDelta / Screen.width, -1f, 1f);
                    break;

                case TouchPhase.Ended:
                    // Reset input when the touch ends
                    horizontalInput = 0f;
                    break;
            }
        }
    }
*/
    void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * horizontalMultiplier;
        rb.velocity = forwardMove + horizontalMove + new Vector3(0,rb.velocity.y,0);
    }
}


/*

using UnityEngine;

public class SwipeMovement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;
    public float horizontalMultiplier = 2;

    private Vector2 touchStart;
    private float horizontalInput;  // Declare here

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        // Check for touches
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check for the phase of the touch
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStart = touch.position;
                    break;

                case TouchPhase.Moved:
                    // Calculate the swipe distance
                    float swipeDelta = touch.position.x - touchStart.x;

                    // Convert the swipe distance to a value between -1 and 1
                    horizontalInput = Mathf.Clamp(swipeDelta / Screen.width, -1f, 1f);
                    break;

                case TouchPhase.Ended:
                    // Reset input when the touch ends
                    horizontalInput = 0f;
                    break;
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }
}
*/