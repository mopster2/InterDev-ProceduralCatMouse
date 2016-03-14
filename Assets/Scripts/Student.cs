using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Student : MonoBehaviour {

    public Transform Player;
    public GameObject students;

    public Text conversations;
    public Text instructions;

    public static Student lastStudent;


    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

        Transform eagerStudent = gameObject.GetComponent<Transform>();
        Transform studentPosition = students.GetComponent<Transform>();

        if ((eagerStudent.position - Player.position).magnitude > 2f && lastStudent == this)
        //if (gameObject is triggered)
        {
            conversations.enabled = false;
            instructions.enabled = false;
        }
        if ((eagerStudent.position - Player.position).magnitude < 2f)
        {
            lastStudent = this;
            if (conversations.enabled == false)
            {
                instructions.enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                conversations.enabled = !conversations.enabled;
                instructions.enabled = false;

            }
        }
    }
}
