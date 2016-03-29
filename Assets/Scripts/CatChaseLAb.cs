using UnityEngine;
using System.Collections;

public class CatChaseLAb : MonoBehaviour {
    public Transform mouse;
    public GameObject Mouse;

    public AudioSource seeMouse;
    public AudioSource eatMouse;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//        if mouse is equal to NULL

        if(mouse == null)
        {
            return;
        }
        //       then: return (note: "return;" will end the function early)

        Vector3 directionToMouse = (mouse.position-transform.position);

        if (Vector3.Angle(transform.forward, directionToMouse) < 90f)
        {
            Ray catRay = new Ray(transform.position, directionToMouse);
            RaycastHit catRayHitInfo = new RaycastHit();
            if (Physics.Raycast(catRay, out catRayHitInfo, 100))
            {
                if (catRayHitInfo.collider.tag == "Mouse")
                {
                    if ((catRayHitInfo.distance < 4) || (catRayHitInfo.distance == 4))
                    {
                        Destroy(Mouse);
                        eatMouse.Play();
                    }
                    else
                    {
                        GetComponent<Rigidbody>().AddForce(directionToMouse.normalized * 1000f);
                        seeMouse.Play();
                    }
                }
            }
        }


        //
        //declare a var of type Vector3, called "directionToMouse", set to a vector that goes from[current position] to[mouse's current position]
        // to determine angle between two directions, google "Vector3.Angle"
        //if the angle between[current forward direction] vs. [directionToMouse] is less than 90 degrees, then...
        //   declare a var of type Ray, called "catRay" that starts from[current position] and goes along[directionToMouse]
        //    declare a var of type RaycastHit, called "catRayHitInfo"
        //    if raycast with catRay and catRayHitInfo for 100 units is TRUE...
        //        if catRayHitInfo.collider.tag is exactly equal to the word "Mouse"... (Cat sees the mouse!)
        //            if catRayHitInfo.distance is less than or equal to 5...
        //                then destroy the mouse gameObject (we caught the mouse!)
        //            else...
        //                add force on rigidbody, along[directionToMouse.normalized * 1000f] (chase it!)
    }
}
