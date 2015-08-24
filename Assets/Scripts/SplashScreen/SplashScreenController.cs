using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SplashScreenController : MonoBehaviour {

    public CanvasGroup logoScreen;
    public float progress;
    public int stage;
    public AudioSource theme;

	// Use this for initialization
	void Start () {
	    stage = 0;
        progress = -0.5f;
	}
	
	// Update is called once per frame
	void Update () {
	    progress += Time.deltaTime;
        switch(stage){
            case 0:
                logoScreen.alpha = Mathf.Min(1f, progress);
                if(progress > 0.5f && !theme.isPlaying){
                    theme.Play();
                }
                if(progress > 1){
                    stage = 1;
                    progress -= 1;
                }
                break;
            case 1:
                if(progress > 1.3f){
                    stage = 2;
                    progress -= 1.3f;
                }
                break;
            case 2:
                logoScreen.alpha = Mathf.Max(0f, 1 - progress);
                if(progress > 1){
                    stage = 3;
                    progress -= 1;
                }
                break;
            case 3:
                float r = Mathf.Min(1, (50 + progress * (225 - 50)) / 256);
                float g = Mathf.Min(1, (50 + progress * (255 - 50)) / 256);
                float b = Mathf.Min(1, (50 + progress * (221 - 50)) / 256);

                Camera.main.backgroundColor = new Color(r, g, b);
                if(progress > 1){
                    Application.LoadLevel("MainMenu");
                }
                break;


        }
	}
}
