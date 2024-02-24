using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public float speed = 5;
    public Rigidbody rb;

    private void FixedUpdate() {

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);

    }

    // Update is called once per frame
    void Update(){
        
    }
}
