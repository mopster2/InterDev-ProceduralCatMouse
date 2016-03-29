using UnityEngine;
using System.Collections;

public class GroundedJumpDemo : MonoBehaviour {

    bool grounded = false;
    public float jumpHeight;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update(){
        Ray groundedRay = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(groundedRay, 1.1f))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

        void FixedUpdate () {
        if((Input.GetKeyDown(KeyCode.Space))&&(grounded == true))
        {
            GetComponent<Rigidbody>().velocity += Vector3.up * jumpHeight;
        }
	
	}
}
