using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapSize : MonoBehaviour {

    Text t;

	// Use this for initialization
	void Start () {
	    t = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	    t.text = "Max town size: "+TerrainController.MaxTownSize;
	}
}
