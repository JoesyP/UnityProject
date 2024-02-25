using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public float speed = 5;
    public Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 2;

    private void FixedUpdate() {

        Vector3 forwardMove = transform.forward * speed;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * horizontalMultiplier;
        rb.velocity = horizontalMove + forwardMove;

    }

    // Update is called once per frame
    void Update(){
        horizontalInput = Input.GetAxis("Horizontal");
        
    }
}
