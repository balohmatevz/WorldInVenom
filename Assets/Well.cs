using UnityEngine;
using System.Collections;

public class Well : Interactable {

    public bool poisoned = false;

    public override void Start()
    {
        base.Start();
        inventory[0] = "water";
        inventory[1] = "water";
        inventory[2] = "water";
        
        itemTitle = "Well";
        itemDesc = "The village well, a seemingly infinite source of water.";
    }

    void OnMouseEnter(){
        if(poisoned){
            GameController.tooltipHintText.text = "Well (poisoned)";
        }else{
            GameController.tooltipHintText.text = "Well";
        }
    }
    
    void OnMouseExit(){
        GameController.tooltipHintText.text = "";
    }

    public override void StopInteraction(){
        base.StopInteraction();
        if(inventory[0] == "poison" || inventory[1] == "poison" || inventory[2] == "poison" || inventory[3] == "poison"){
            poisoned = true;
        }
        inventory[0] = "water";
        inventory[1] = "water";
        inventory[2] = "water";
        inventory[3] = "";
    }
}
