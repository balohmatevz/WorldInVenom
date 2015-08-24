using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberOfTowns : MonoBehaviour {

    Text t;

	// Use this for initialization
	void Start () {
	    t = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	    t.text = "Number of towns: "+TerrainController.NumberOfTowns;
	}
}
