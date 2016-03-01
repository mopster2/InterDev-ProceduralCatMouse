using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class EagerStudent : MonoBehaviour {

    public Text conversations;
    public Text instructions;
    public Text score;

    public int scoreCorrect;
    public int scoreIncorrect;

    public Transform Player;
    public GameObject Student;
    

    public string studentQuestion;
    public string answereA;
    public string answereB;
    public string answereC;

    public KeyCode correctAnswere;
    public KeyCode incorrectAnswere1;
    public KeyCode incorrectAnswere2;
    public KeyCode neutralAnswere1;
    public KeyCode neutralAnswere2;

    public string responceCorrectAnswere;
    public string responceIncorrectAnswere;
    public string responceNeutralAnswere;

    bool isQuestionAnswered = false;
    bool isQuestionAnsweredCorrect = false;
    bool isQuestionAnsweredIncorrect = false;

    // Use this for initialization
    void Start () {

        conversations.text = studentQuestion + ("\n"+answereA) + ("\n"+answereB) + ("\n"+answereC);
        conversations.enabled = false;
        instructions.text = "Press [Space]to talk";
        instructions.enabled = false;
        
        
    }
	
	// Update is called once per frame
	void Update () {

        MeshRenderer eagerStudentRenderer = gameObject.GetComponent<MeshRenderer>();
        Transform eagerStudent = gameObject.GetComponent<Transform>();
        Transform studentPosition = Student.GetComponent<Transform>();

        if ((eagerStudent.position - Player.position).magnitude > 5f)
        {
            conversations.enabled = false;
        }
            if ((eagerStudent.position - Player.position).magnitude < 5f)
        {
            if(conversations.enabled == false)
            {
                instructions.enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                conversations.enabled = !conversations.enabled;
                instructions.enabled = false;

            }
            if (isQuestionAnswered == false)
            {
                if (Input.GetKeyDown(correctAnswere))
                {
                    conversations.text = responceCorrectAnswere;
                    isQuestionAnsweredCorrect = true;
                    scoreCorrect += scoreCorrect;
                    Instantiate(Student, new Vector3(eagerStudent.position.x, studentPosition.position.y, eagerStudent.position.z), eagerStudent.rotation);
                    eagerStudentRenderer.enabled = false;
                    isQuestionAnswered = true;

                }
                if (Input.GetKeyDown(neutralAnswere1) || Input.GetKeyDown(neutralAnswere2))
                {
                    conversations.text = responceNeutralAnswere;
                    isQuestionAnsweredCorrect = true;
                    Instantiate(Student, new Vector3(eagerStudent.position.x, studentPosition.position.y, eagerStudent.position.z), eagerStudent.rotation);
                    eagerStudentRenderer.enabled = false;
                    isQuestionAnswered = true;
                }
                if (Input.GetKeyDown(incorrectAnswere1) || Input.GetKeyDown(incorrectAnswere2))
                {
                    conversations.text = responceIncorrectAnswere;
                    isQuestionAnsweredIncorrect = true;
                    scoreIncorrect += scoreIncorrect;
                    Instantiate(Student, new Vector3(eagerStudent.position.x, studentPosition.position.y, eagerStudent.position.z), eagerStudent.rotation);
                    eagerStudentRenderer.enabled = false;
                    isQuestionAnswered = true;
                }
            }
            
        }
    }
}
