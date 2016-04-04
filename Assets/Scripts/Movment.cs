using UnityEngine;
using System.Collections;

public class Movment : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void FixedUpdate()
    {
            GetComponent<Rigidbody>().velocity = transform.forward * 10f + Physics.gravity;

            Ray moveRay = new Ray(transform.position, transform.forward);
            float randomTurn = Random.Range(0f, 1f);
            //Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance
            if (Physics.SphereCast(moveRay, 0.1f, 1f))

            {
                if (randomTurn < .5f)
                {
                    transform.Rotate(0f, 90f, 0f);
                }
                if (randomTurn > .5f)
                {
                    transform.Rotate(0f, -90f, 0f);
                }

            }

        }
}
