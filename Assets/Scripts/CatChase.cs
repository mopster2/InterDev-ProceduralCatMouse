using UnityEngine;
using System.Collections;

public class CatChase : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        foreach (MouseChase thisMouse in GameManager.listOfMouse)
        {
            if (thisMouse.transform.position == null)
            {
                return;
            }

            Vector3 directionToMouse = (thisMouse.transform.position - transform.position);
            if (Vector3.Angle(transform.forward, directionToMouse) < 90f)
            {
                Ray catRay = new Ray(transform.position, directionToMouse);
                RaycastHit catRayHitInfo = new RaycastHit();
                if (Physics.Raycast(catRay, out catRayHitInfo, 100))
                {
                    if (catRayHitInfo.collider.tag == "Mouse")
                    {
                        if ((catRayHitInfo.distance < 2) || (catRayHitInfo.distance == 2))
                        {
                            GameManager.listOfMouse.Remove(thisMouse);
                            Destroy(thisMouse.gameObject);
                        }
                        else
                        {
                            GetComponent<Rigidbody>().AddForce(directionToMouse.normalized * 1000f);
                        }
                    }
                }
            }
        }
	
	}
}
