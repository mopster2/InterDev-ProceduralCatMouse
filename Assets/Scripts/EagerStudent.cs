using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class EagerStudent : MonoBehaviour {

    public Text conversations;
    public Text instructions;
    public Text endGame;

    public static int scoreFun;
    public static int scoreMean;
    public static int scoreBoring;
    public static int scoreAnswered;

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

    public static EagerStudent lastStudent;

  
    

    // Use this for initialization
    void Start () {


        conversations.text = studentQuestion + ("\n"+answereA) + ("\n"+answereB) + ("\n"+answereC);
        conversations.enabled = false;
        instructions.text = "Press [Space] to talk";
        instructions.enabled = false;
        
        
    }
	
	// Update is called once per frame
	void Update () {

        MeshRenderer[] eagerStudentRenderer = GetComponentsInChildren<MeshRenderer>();
       // foreach (MeshRenderer renderStudent in eagerStudentRenderer) ;

        Transform eagerStudent = gameObject.GetComponent<Transform>();
        Transform studentPosition = Student.GetComponent<Transform>();

        if ((eagerStudent.position - Player.position).magnitude > 2f && lastStudent==this)
        //if (gameObject is triggered)
        {
            conversations.enabled = false;
            instructions.enabled = false;
        }
            if ((eagerStudent.position - Player.position).magnitude < 2f)
        {
            lastStudent = this;
            if(conversations.enabled == false)
            {
                instructions.enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                conversations.enabled = !conversations.enabled;
                instructions.enabled = false;

            }
            if (isQuestionAnswered == false && conversations.enabled==true)
            {
                if (Input.GetKeyDown(correctAnswere))
                {
                    conversations.text = responceCorrectAnswere;
                    isQuestionAnsweredCorrect = true;
                    EagerStudent.scoreFun += EagerStudent.scoreFun;
                    EagerStudent.scoreAnswered = EagerStudent.scoreAnswered +1;
                    Instantiate(Student, new Vector3(eagerStudent.position.x, studentPosition.position.y, eagerStudent.position.z), eagerStudent.rotation);
                    foreach (MeshRenderer renderStudent in eagerStudentRenderer)
                         renderStudent.enabled = false;
                    isQuestionAnswered = true;

                }
                if (Input.GetKeyDown(neutralAnswere1) || Input.GetKeyDown(neutralAnswere2))
                {
                    conversations.text = responceNeutralAnswere;
                    isQuestionAnsweredCorrect = true;
                    EagerStudent.scoreBoring += EagerStudent.scoreBoring;
                    EagerStudent.scoreAnswered = EagerStudent.scoreAnswered +1;
                    Instantiate(Student, new Vector3(eagerStudent.position.x, studentPosition.position.y, eagerStudent.position.z), eagerStudent.rotation);
                    foreach (MeshRenderer renderStudent in eagerStudentRenderer)
                        renderStudent.enabled = false;
                    isQuestionAnswered = true;
                }
                if (Input.GetKeyDown(incorrectAnswere1) || Input.GetKeyDown(incorrectAnswere2))
                {
                    conversations.text = responceIncorrectAnswere;
                    isQuestionAnsweredIncorrect = true;
                    EagerStudent.scoreMean += EagerStudent.scoreMean;
                    EagerStudent.scoreAnswered = EagerStudent.scoreAnswered +1;
                    Instantiate(Student, new Vector3(eagerStudent.position.x, studentPosition.position.y, eagerStudent.position.z), eagerStudent.rotation);
                    foreach (MeshRenderer renderStudent in eagerStudentRenderer)
                        renderStudent.enabled = false;
                    isQuestionAnswered = true;
                }
            }
            

        }
        if (EagerStudent.scoreAnswered < 3)
        {
            endGame.text = "The students seemed very upset that you didn’t want to answer any of their questions. They didn't enjoy your visit.  Press [ESC] to leave. ";
        }
        if (EagerStudent.scoreAnswered > 3)
        {
            if (EagerStudent.scoreBoring > 3)
            {
                endGame.text = "Your answers were all correct but the student found you very boring, they wish you had been more fun. Press [ESC] to leave.";
            }
            else if (EagerStudent.scoreFun > 3)
            {
                endGame.text = "The students loved your answers, even if a few of them weren't entirely correct. Their teacher and parents might not appreciate them as much though. Press [ESC] to leave.";
            }
            else if (EagerStudent.scoreMean > 3)
            {
                endGame.text = "The Students found you very mean, they said they would rather have extra math homework then have you visit again. Press [ESC] to leave.";
            }
            else 
            {
                endGame.text = "The students all had very different opinions of you. Some thought you were funny, some thought you were smart and one kid really didn’t like you, but all in all it was a good visit. Press [ESC] to leave.";
            }
        }
    }
}
