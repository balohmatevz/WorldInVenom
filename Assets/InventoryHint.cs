using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class InventoryHint : MonoBehaviour {
    EventSystem es;

    public string txt = "abc";
    public int difY;

	// Use this for initialization
	void Start () {
	    es = GameObject.Find("EventSystem").GetComponent<EventSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (es.IsPointerOverGameObject()){
            Debug.Log(txt);
        }
	}

    public void ShowHint(){
        GameController.menuTooltip.transform.position = this.transform.position;
        GameController.menuTooltip.transform.Translate(Vector3.up * difY);
        GameController.menuTooltipText.text = txt;
    }

    public void HideHint(){
        GameController.menuTooltipText.text = "";
    }
}
