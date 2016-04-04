using UnityEngine;
using System.Collections;

public class MapGen : MonoBehaviour {
    private int counter = 0;
    private float randomNumber;

    public Transform floorMaker;
    
    public GameObject Walls;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (counter < 10)
        {
            randomNumber = Random.Range(0f, 1.0f);

            if (randomNumber < 0.3f)
            {
                floorMaker.eulerAngles += new Vector3(0f, 90f, 0f);
                Instantiate(Walls, new Vector3(floorMaker.position.x, floorMaker.position.y, floorMaker.position.z), floorMaker.rotation);

            }
            else if ((randomNumber > 0.3f) && (randomNumber < 0.6f))
            {
                floorMaker.eulerAngles += new Vector3(0f, -90f, 0f);
                Instantiate(Walls, new Vector3(floorMaker.position.x, floorMaker.position.y, floorMaker.position.z), floorMaker.rotation);

            }
            else if ((randomNumber > 0.6f) && (randomNumber < 1.0f))
            {
                
            }
            
            transform.position += transform.forward * 5f;
            //Instantiate(Walls, new Vector3(floorMaker.position.x, floorMaker.position.y, floorMaker.position.z), floorMaker.rotation);
            counter = counter + 1;
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
