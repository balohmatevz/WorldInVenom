using UnityEngine;
using System.Collections;

public class RandomInitialRotation : MonoBehaviour {

    public Vector3 RotationDirection;
    public bool RightAngles = false;

	// Use this for initialization
	void Start () {
        if(RightAngles){
            this.transform.Rotate(RotationDirection * Random.Range(0, 4) * 90f);
        }else{
	        this.transform.Rotate(RotationDirection * Random.Range(0f, 1f) * 360f);
	
        }
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
