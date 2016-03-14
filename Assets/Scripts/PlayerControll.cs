using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour {

    public float moveSpeed = 0.06f;
    public float turnSpeed = 90f;
    public Text instructions;
    public Text endGame;

    public Transform exitPosition; 
    // Use this for initialization
    void Start () {

        endGame.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Transform Player = gameObject.GetComponent<Transform>();
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
        if ((Player.position - exitPosition.position).magnitude < 4)
        {
            instructions.text = "Press [Space] to leave";
            instructions.enabled = true;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                endGame.enabled = true;
                moveSpeed = 0;
                turnSpeed = 0;
            }
        }

    }
}
