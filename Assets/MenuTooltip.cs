using UnityEngine;
using System.Collections;

public class MenuTooltip : MonoBehaviour {

    CanvasGroup cg;

	// Use this for initialization
	void Start () {
	    GameController.menuTooltip = this;
	    cg = this.GetComponent<CanvasGroup>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(GameController.menuTooltipText.text != "" && GameController.player.thisHuman.isInteracting){
            if(cg.alpha < 1){
                cg.alpha += Time.deltaTime * 4;
                cg.alpha = Mathf.Min(1, cg.alpha);
            }
        }else{
            if(cg.alpha > 0){
                cg.alpha -= Time.deltaTime * 4;
                cg.alpha = Mathf.Max(0, cg.alpha);
            }
        }
	}
}
