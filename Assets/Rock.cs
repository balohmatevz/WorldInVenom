using UnityEngine;
using System.Collections;

public class Rock : Interactable {

    public override void Start()
    {
        base.Start();
        itemTitle = "Rock";
        itemDesc = "Just a rock";
    }

    void OnMouseEnter(){
        GameController.tooltipHintText.text = "Rock";
    }
    
    void OnMouseExit(){
        GameController.tooltipHintText.text = "";
    }
}
