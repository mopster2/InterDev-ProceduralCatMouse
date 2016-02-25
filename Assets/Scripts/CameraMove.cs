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

        float aimDirrection = -Input.GetAxis("Mouse ScrollWheel");
        float cameraRotation = aimSpeed * Time.deltaTime * aimDirrection;

        transform.Rotate(cameraRotation, 0f, 0f);

    }
}
