using UnityEngine;
using System.Collections;

public class HideAndSeekDemo : MonoBehaviour {

    public Transform cylinder;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Ray sightRay = new Ray(transform.position, (cylinder.position-transform.position));

        RaycastHit rayhitInfo = new RaycastHit();
        float distance = (cylinder.position - transform.position).magnitude;

        if (Physics.Raycast(sightRay, out rayhitInfo, distance))
        {
            if (rayhitInfo.collider.tag == "Cylinder")
            {
                transform.localScale *= 1.01f;
            }
        }

    }
}
