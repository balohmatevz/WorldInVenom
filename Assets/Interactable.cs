using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Interactable : MonoBehaviour {

    public string[] inventory;
    public List<Human> family;
    
    public string itemTitle = "";
    public string itemDesc = "";

    void Awake(){
        family = new List<Human>();
        inventory = new string[4];
        inventory[0] = "";
        inventory[1] = "";
        inventory[2] = "";
        inventory[3] = "";
    }

    public virtual void Start(){
    }

    public virtual void PlanInteraction(){
        GameController.player.thisHuman.expectingInteraction = true;
        GameController.player.thisHuman.interactionTarget = this;
        GameController.player.thisHuman.MoveTo(GameController.MousePosition);
    }

    public virtual void Interact(){
        GameController.blackout.gameObject.SetActive(true);

        GameController.interactionInventory.UpdateIntentory();

        GameController.blackout.FadeIn();
        Debug.Log("Interacting with: "+this.name);
    }

    void OnMouseDown(){
        if(!GameController.player.thisHuman.isInteracting){
            GameController.player.plannedInteration = true;
            Debug.Log("c");
            PlanInteraction();
        }
    }

    public virtual void StopInteraction(){
        GameController.player.thisHuman.isInteracting = false;
        GameController.blackout.gameObject.SetActive(true);
        GameController.blackout.FadeOut();
    }
}
