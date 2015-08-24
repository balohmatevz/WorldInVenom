using UnityEngine;
using System.Collections;

public class Bush : Interactable {

    public override void Start()
    {
        base.Start();
        inventory[0] = "berries";
        itemTitle = "Berry bush";
        itemDesc = "Grows berries";
    }
    
    void OnMouseEnter(){
        GameController.tooltipHintText.text = "Bush";
    }
    
    void OnMouseExit(){
        GameController.tooltipHintText.text = "";
    }
}
