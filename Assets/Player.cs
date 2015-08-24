using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Human thisHuman;
    public bool plannedInteration = false;

    public string[] inventory;

	// Use this for initialization
	void Start () {
	    thisHuman = this.GetComponent<Human>();
        GameController.player = this;
        inventory = new string[7];
        inventory[0] = "";
        inventory[1] = "";
        inventory[2] = "";
        inventory[3] = "";
        inventory[4] = "";
        inventory[5] = "";
        inventory[6] = "";

        int failTest = 1000;
        while(failTest > 0){
            failTest--;
            Town selectedTown = TerrainController.townList[Random.Range(0, TerrainController.townList.Count)];
            if(selectedTown.HouseList.Count == 0){
                continue;
            }else{
                Vector2 newPos = selectedTown.HouseList[Random.Range(0, selectedTown.HouseList.Count)];
                this.transform.position = new Vector3(newPos.x, 0, newPos.y);
                break;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButtonDown(0)){
            Debug.Log("b");
            if(!thisHuman.isInteracting && !plannedInteration){
                thisHuman.expectingInteraction = false;
                thisHuman.MoveTo(GameController.MousePosition);
            }
        }
        plannedInteration = false;
	}
}
