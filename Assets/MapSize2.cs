using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapSize2 : MonoBehaviour {

    Text t;

	// Use this for initialization
	void Start () {
	    t = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	    t.text = "Min town size: "+TerrainController.MinTownSize;
	}
}
