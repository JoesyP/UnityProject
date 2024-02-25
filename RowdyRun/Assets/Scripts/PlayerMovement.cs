using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
