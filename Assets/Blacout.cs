using UnityEngine;
using System.Collections;

public class Blacout : MonoBehaviour {

    float progress = 0;
    int action = 0;
    CanvasGroup cg;

	// Use this for initialization
	void Start () {
	    cg = this.GetComponent<CanvasGroup>();
        GameController.blackout = this;
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        
        if(action != 0){
            progress += Time.deltaTime * 2;
        }

	    if(action == 1){
            cg.alpha = Mathf.Min(1f, progress);
        }

	    if(action == 2){
            cg.alpha = Mathf.Max(0, 1f - progress);
        }

        if(progress > 1){
            action = 0;
            progress = 0;
            if(cg.alpha <= 0.1f){
                this.gameObject.SetActive(false);
            }
        }
	}

    public void FadeIn(){
        if(action != 1){
            action = 1;
            progress = 0;
        }
    }

    public void FadeOut(){
        if(action != 2){
            action = 2;
            progress = 0;
        }
    }
}
