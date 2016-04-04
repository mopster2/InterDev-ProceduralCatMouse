using UnityEngine;
using System.Collections;

public class MouseChase : MonoBehaviour
{
    public Transform cat;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 directionToCat = (cat.position - transform.position);

        if (Vector3.Angle(transform.forward, directionToCat) < 180f)
        {
            Ray mouseRay = new Ray(transform.position, directionToCat);
            RaycastHit mouseRayHitInfo = new RaycastHit();
            if (Physics.Raycast(mouseRay, out mouseRayHitInfo, 100))
            {
                if (mouseRayHitInfo.collider.tag == "Cat")
                {
                    GetComponent<Rigidbody>().AddForce(-directionToCat.normalized * 1000f);
                    
                }
            }
        }
    }
}
