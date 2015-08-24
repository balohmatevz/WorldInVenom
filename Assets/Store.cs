using UnityEngine;
using System.Collections;

public class Store : Interactable {

    public override void Start()
    {
        base.Start();
        inventory[0] = "fruit";
        inventory[1] = "fruit";
        inventory[2] = "fruit";
        inventory[3] = "poison";
        
        itemTitle = "General store";
        itemDesc = "The village general store sells food and other supplies";
    }

    void OnMouseEnter(){
        GameController.tooltipHintText.text = "General store";
    }
    
    void OnMouseExit(){
        GameController.tooltipHintText.text = "";
    }
}
