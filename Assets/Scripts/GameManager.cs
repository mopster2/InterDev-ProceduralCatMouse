using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

    public static List<MouseChase> listOfMouse = new List<MouseChase>();

    public static List<CatChase> listOfCat = new List<CatChase>();

    // Use this for initialization
    void Start () {
        listOfMouse.Clear();
        listOfCat.Clear();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
	}
}
