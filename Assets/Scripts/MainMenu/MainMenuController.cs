using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuController : MonoBehaviour {
    
    public CanvasGroup MainMenuCanvasGroup;
    public CanvasGroup InstructionsCanvasGroup;
    public CanvasGroup PersistantCanvasGroup;
    public CanvasGroup OptionsCanvasGroup;
    public AudioSource MainMenuAudio;
    public GameObject GeneratingWorld;

    int state = 0;
    float progress = -0.5f;

	// Use this for initialization
	void Start () {
	    progress = 0;
        state = 1;
        MainMenuCanvasGroup.alpha = 0;
        InstructionsCanvasGroup.alpha = 0;
        PersistantCanvasGroup.alpha = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    progress += Time.deltaTime;
        if(state != 0){
            switch(state){
                case 1:
                    InstructionsCanvasGroup.alpha = 0;
                    MainMenuCanvasGroup.alpha = Mathf.Min(1f, progress);
                    PersistantCanvasGroup.alpha = Mathf.Min(1f, progress);
                    if(progress > 1){
                        state = 0;
                        progress = 0;
                    }
                    break;
                case 2:
                    InstructionsCanvasGroup.gameObject.SetActive(true);
                    InstructionsCanvasGroup.alpha = Mathf.Min(1f, progress);
                    MainMenuCanvasGroup.alpha = Mathf.Max(0f, 1f - progress);
                    if(progress > 1){
                        state = 0;
                        progress = 0;
                        MainMenuCanvasGroup.gameObject.SetActive(false);
                    }
                    break;
                case 3:
                    MainMenuCanvasGroup.gameObject.SetActive(true);
                    MainMenuCanvasGroup.alpha = Mathf.Min(1f, progress);
                    InstructionsCanvasGroup.alpha = Mathf.Max(0f, 1f - progress);
                    if(progress > 1){
                        state = 0;
                        progress = 0;
                        InstructionsCanvasGroup.gameObject.SetActive(false);
                    }
                    break;
                case 4:
                    InstructionsCanvasGroup.alpha = 0;
                    MainMenuCanvasGroup.alpha = Mathf.Max(0f, 1f - progress);
                    PersistantCanvasGroup.alpha = Mathf.Max(0f, 1f - progress);
                    MainMenuAudio.volume = Mathf.Max(0f, 1f - progress);
                    if(progress > 1){
                        GeneratingWorld.SetActive(true);
                        Application.LoadLevel("PlayScreen");
                    }
                    break;
                case 5:
                    OptionsCanvasGroup.gameObject.SetActive(true);
                    OptionsCanvasGroup.alpha = Mathf.Min(1f, progress);
                    MainMenuCanvasGroup.alpha = Mathf.Max(0f, 1f - progress);
                    if(progress > 1){
                        state = 0;
                        progress = 0;
                        MainMenuCanvasGroup.gameObject.SetActive(false);
                    }
                    break;
                case 6:
                    MainMenuCanvasGroup.gameObject.SetActive(true);
                    MainMenuCanvasGroup.alpha = Mathf.Min(1f, progress);
                    OptionsCanvasGroup.alpha = Mathf.Max(0f, 1f - progress);
                    if(progress > 1){
                        state = 0;
                        progress = 0;
                        OptionsCanvasGroup.gameObject.SetActive(false);
                    }
                    break;
            }
        }
	}

    public void VisitTwitter(){
        System.Diagnostics.Process.Start("https://twitter.com/liamlime90");
    }

    public void VisitLiamLime(){
        System.Diagnostics.Process.Start("http://liamlime.com");
    }

    public void VisitLudumDare(){
        System.Diagnostics.Process.Start("http://ludumdare.com");
    }

    public void ShowInstructions(){
        if(state != 2){
            progress = 0;
            state = 2;
        }
    }

    public void HideInstructions(){
        if(state != 3){
            progress = 0;
            state = 3;
        }
    }

    public void ShowOptions(){
        if(state != 5){
            progress = 0;
            state = 5;
        }
    }

    public void HideOptions(){
        if(state != 6){
            progress = 0;
            state = 6;
        }
    }

    public void StartGame(){
        if(state != 4){
            progress = 0;
            state = 4;
        }
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void IncNumberOfTowns(){
        TerrainController.NumberOfTowns++;
    }

    public void DecNumberOfTowns(){
        TerrainController.NumberOfTowns--;
    }

    public void IncMinTownSize(){
        TerrainController.MinTownSize++;
    }

    public void DecMinTownSize(){
        TerrainController.MinTownSize--;
    }

    public void IncMaxTownSize(){
        TerrainController.MaxTownSize++;
    }

    public void DecMaxTownSize(){
        TerrainController.MaxTownSize--;
    }

    public void IncSizeX(){
        TerrainController.SizeX++;
    }

    public void DecSizeX(){
        TerrainController.SizeX--;
    }

    public void IncSizeY(){
        TerrainController.SizeY++;
    }

    public void DecSizeY(){
        TerrainController.SizeY--;
    }
}
