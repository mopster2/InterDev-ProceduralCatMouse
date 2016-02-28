using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

    public float aimSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Transform getTransform = GetComponent<Transform>();

        float vertical = -Input.GetAxis("Vertical");

        //float aimDirrection = -Input.GetAxis("Mouse ScrollWheel");
        float cameraRotation = aimSpeed * Time.deltaTime * vertical;


        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(cameraRotation,0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(cameraRotation,0f, 0f);
        }
    }
}
