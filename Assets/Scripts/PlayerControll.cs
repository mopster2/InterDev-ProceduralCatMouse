using UnityEngine;
using System.Collections;

public class PlayerControll : MonoBehaviour {

    public float moveSpeed = 0.06f;
    public float turnSpeed = 90f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        CharacterController contoller = GetComponent<CharacterController>();
        Vector3 forwardMovement = transform.forward * moveSpeed * vertical;
        Vector3 sideMovement = transform.right * moveSpeed * horizontal;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            contoller.Move((forwardMovement + Physics.gravity)*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            contoller.Move((forwardMovement + Physics.gravity) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            contoller.Move((sideMovement + Physics.gravity) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            contoller.Move((sideMovement + Physics.gravity) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, horizontal * turnSpeed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, horizontal*turnSpeed * Time.deltaTime, 0f);
        }

    }
}
