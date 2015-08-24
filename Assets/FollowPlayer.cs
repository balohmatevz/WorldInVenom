using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
    
    float cameraDistance = 10f;
    float scrollSpeed = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    Vector3 playerPos = GameController.player.transform.position;
        
        this.transform.position = playerPos;
        this.transform.LookAt(new Vector3(playerPos.x + 1.25f, 4.48f, playerPos.z -1.91f));
        this.transform.Translate( Vector3.forward * cameraDistance, Space.Self );
        this.transform.LookAt(playerPos);

        if (Input.GetAxis("Mouse ScrollWheel") != 0f ){
            cameraDistance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        }

	}
}
