using UnityEngine;
using System.Collections;

public class Tree : Interactable {

    public override void Start()
    {
        base.Start();
        inventory[0] = "wood";
        inventory[1] = "stick";
        inventory[2] = "stick";
        inventory[3] = "fruit";
        
        itemTitle = "Tree";
        itemDesc = "A good source of wood";
    }

    void OnMouseEnter(){
        GameController.tooltipHintText.text = "Tree";
    }
    
    void OnMouseExit(){
        GameController.tooltipHintText.text = "";
    }
}
