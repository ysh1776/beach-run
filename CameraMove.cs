
using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public float moveSpeed;
	public GameObject mainCamera;
    GameObject po;


	// Use this for initialization
	void Start () {

        this.po = GameObject.Find("CameraMove");
        mainCamera.transform.localPosition = new Vector3 ( 0, 0, 0 );
		mainCamera.transform.localRotation = Quaternion.Euler (18, 180, 0);
	
	}
	
	// Update is called once per frame
	void Update () {

		
	}

	void FixedUpdate()
	{
        
        /*
		if (Input.GetKeyDown (KeyCode.A)) {
			ChangeView01();
		}
		
		if (Input.GetKeyDown (KeyCode.S)) {
			ChangeView02();
		}*/
        if (this.po.transform.position.z > -353.1032)
        {
            MoveObj();
        }
	}
	
	
	void MoveObj() {		
		float moveAmount = Time.smoothDeltaTime * moveSpeed;
		transform.Translate ( 0f, 0f, moveAmount );
    }



    /*
	void ChangeView01() {
		transform.position = new Vector3 (0, 2, 10);
		// x:0, y:1, z:52
		mainCamera.transform.localPosition = new Vector3 ( -8, 2, 0 );
		mainCamera.transform.localRotation = Quaternion.Euler (14, 90, 0);
	}

	void ChangeView02() {
		transform.position = new Vector3 (0, 2, 10);
		// x:0, y:1, z:52
		mainCamera.transform.localPosition = new Vector3 ( 0, 0, 0 );
		mainCamera.transform.localRotation = Quaternion.Euler ( 19, 180, 0 );
		moveSpeed = -20f;
		
	}*/
}























