using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InstantiateCatMouse : MonoBehaviour {

    public MouseChase MousePrefab;
    List<MouseChase> listOfMouse = new List<MouseChase>();

    public CatChase CatPrefab;
    List<CatChase> listOfCat = new List<CatChase>();
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHitInfo = new RaycastHit();

        if (Physics.Raycast(ray, out rayHitInfo, 1000f) && (Input.GetMouseButtonDown(1)))
        {
                MouseChase newMouse = (MouseChase)Instantiate(MousePrefab, new Vector3(rayHitInfo.point.x, rayHitInfo.point.y, rayHitInfo.point.z), transform.rotation);
                GameManager.listOfMouse.Add(newMouse);
        }

        if (Physics.Raycast(ray, out rayHitInfo, 1000f) && (Input.GetMouseButtonDown(0)))
        {
            CatChase newCat = (CatChase)Instantiate(CatPrefab, new Vector3(rayHitInfo.point.x, rayHitInfo.point.y, rayHitInfo.point.z), transform.rotation);
            GameManager.listOfCat.Add(newCat);
        }

    }
}
