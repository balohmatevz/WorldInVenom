using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuTooltipText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    GameController.menuTooltipText = this.GetComponent<Text>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
