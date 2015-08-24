using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HintText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    GameController.tooltipHintText = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
