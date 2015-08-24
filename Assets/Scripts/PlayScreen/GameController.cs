using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
    Plane planeZero;
    public static Player player;
    public static TooltipHint tooltipHint;
    public static Text tooltipHintText;
    public CanvasGroup BlackoustCG;

    public static Blacout blackout;
    public static Vector3 MousePosition;
    public static InteractionInventory interactionInventory;

    public static MenuTooltip menuTooltip;
    public static Text menuTooltipText;

	// Use this for initialization
	void Start () {
	    planeZero = new Plane(Vector3.up, Vector3.zero);
        MousePosition = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float rayDistance;
        if (planeZero.Raycast(ray, out rayDistance)){
            //Debug.Log(ray.GetPoint(rayDistance));
            MousePosition = ray.GetPoint(rayDistance);
        }

        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        tooltipHint.transform.position = Input.mousePosition;
        tooltipHint.transform.Translate(Vector3.up * 30);
        //Debug.Log(mousePos);
	}

    public void StopInteraction(){
        player.thisHuman.interactionTarget.StopInteraction();
    }

    public void TransferToPlayerInventory(int num){
        for(int i = 0; i < player.inventory.Length; i++){
            if(player.inventory[i] == ""){
                player.inventory[i] = player.thisHuman.interactionTarget.inventory[num];
                player.thisHuman.interactionTarget.inventory[num] = "";
            }
        }
        interactionInventory.UpdateIntentory();
    }

    public void TransferToInteractionInventory(int num){
        for(int i = 0; i < player.thisHuman.interactionTarget.inventory.Length; i++){
            if(player.thisHuman.interactionTarget.inventory[i] == ""){
                player.thisHuman.interactionTarget.inventory[i] = player.inventory[num];
                player.inventory[num] = "";
            }
        }
        interactionInventory.UpdateIntentory();
    }
}
