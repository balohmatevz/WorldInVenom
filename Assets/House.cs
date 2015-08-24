using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class House : Interactable {

    public override void Start()
    {
        base.Start();
        if(itemTitle == ""){
            itemTitle = "Vacant house";
        }
        itemDesc = "A residential house";
    }
    
    void OnMouseEnter(){
        GameController.tooltipHintText.text = itemTitle;
    }
    
    void OnMouseExit(){
        GameController.tooltipHintText.text = "";
    }
}
