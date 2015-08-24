using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractionInventory : MonoBehaviour {
    
    public Text TextTitle;
    public Text TextDescription;

    public Sprite TxtBlank;
    public Sprite TxtWood;
    public Sprite TxtStick;
    public Sprite TxtFruit;
    public Sprite TxtWater;
    public Sprite TxtBerries;
    public Sprite TxtPoison;


    
    public Sprite SprHuman_M_L_Well;
    public Sprite SprHuman_M_L_Ill;
    public Sprite SprHuman_M_L_Dead;
    
    public Sprite SprHuman_M_D_Well;
    public Sprite SprHuman_M_D_Ill;
    public Sprite SprHuman_M_D_Dead;
    
    public Sprite SprHuman_F_L_Well;
    public Sprite SprHuman_F_L_Ill;
    public Sprite SprHuman_F_L_Dead;

    public Sprite SprHuman_F_D_Well;
    public Sprite SprHuman_F_D_Ill;
    public Sprite SprHuman_F_D_Dead;

    public Image invImg1;
    public Image invImg2;
    public Image invImg3;
    public Image invImg4;
    
    public Image plyrImg1;
    public Image plyrImg2;
    public Image plyrImg3;
    public Image plyrImg4;
    public Image plyrImg5;
    public Image plyrImg6;
    public Image plyrImg7;
    
    public Image famImg1;
    public Image famImg2;
    public Image famImg3;
    public Image famImg4;
    public Image famImg5;


	// Use this for initialization
	void Start () {
	    GameController.interactionInventory = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Sprite StrToSprite(string s){
        switch(s){
            case "wood":
                return TxtWood;
                break;
            case "stick":
                return TxtStick;
                break;
            case "fruit":
                return TxtFruit;
                break;
            case "water":
                return TxtWater;
                break;
            case "berries":
                return TxtBerries;
                break;
            case "poison":
                return TxtPoison;
                break;
            default:
                return TxtBlank;
                break;
        }
    }

    public void UpdateIntentory(){
        
        TextTitle.text = GameController.player.thisHuman.interactionTarget.itemTitle;
        TextDescription.text = GameController.player.thisHuman.interactionTarget.itemDesc;

        plyrImg1.sprite = StrToSprite(GameController.player.inventory[0]);
        InventoryHint ih = plyrImg1.gameObject.transform.parent.gameObject.GetComponent<InventoryHint>();
        ih.txt = GameController.player.inventory[0];

        plyrImg2.sprite = StrToSprite(GameController.player.inventory[1]);
        ih = plyrImg2.gameObject.transform.parent.gameObject.GetComponent<InventoryHint>();
        ih.txt = GameController.player.inventory[1];

        plyrImg3.sprite = StrToSprite(GameController.player.inventory[2]);
        ih = plyrImg3.gameObject.transform.parent.gameObject.GetComponent<InventoryHint>();
        ih.txt = GameController.player.inventory[2];

        plyrImg4.sprite = StrToSprite(GameController.player.inventory[3]);
        ih = plyrImg4.gameObject.transform.parent.gameObject.GetComponent<InventoryHint>();
        ih.txt = GameController.player.inventory[3];

        plyrImg5.sprite = StrToSprite(GameController.player.inventory[4]);
        ih = plyrImg5.gameObject.transform.parent.gameObject.GetComponent<InventoryHint>();
        ih.txt = GameController.player.inventory[4];

        plyrImg6.sprite = StrToSprite(GameController.player.inventory[5]);
        ih = plyrImg6.gameObject.transform.parent.gameObject.GetComponent<InventoryHint>();
        ih.txt = GameController.player.inventory[5];

        plyrImg7.sprite = StrToSprite(GameController.player.inventory[6]);
        ih = plyrImg7.gameObject.transform.parent.gameObject.GetComponent<InventoryHint>();
        ih.txt = GameController.player.inventory[6];

        
        invImg1.sprite = StrToSprite(GameController.player.thisHuman.interactionTarget.inventory[0]);
        ih = invImg1.gameObject.transform.parent.gameObject.GetComponent<InventoryHint>();
        ih.txt = GameController.player.thisHuman.interactionTarget.inventory[0];

        invImg2.sprite = StrToSprite(GameController.player.thisHuman.interactionTarget.inventory[1]);
        ih = invImg2.gameObject.transform.parent.gameObject.GetComponent<InventoryHint>();
        ih.txt = GameController.player.thisHuman.interactionTarget.inventory[1];

        invImg3.sprite = StrToSprite(GameController.player.thisHuman.interactionTarget.inventory[2]);
        ih = invImg3.gameObject.transform.parent.gameObject.GetComponent<InventoryHint>();
        ih.txt = GameController.player.thisHuman.interactionTarget.inventory[2];

        invImg4.sprite = StrToSprite(GameController.player.thisHuman.interactionTarget.inventory[3]);
        ih = invImg4.gameObject.transform.parent.gameObject.GetComponent<InventoryHint>();
        ih.txt = GameController.player.thisHuman.interactionTarget.inventory[3];
        
        famImg1.gameObject.transform.parent.gameObject.SetActive(false);
        famImg2.gameObject.transform.parent.gameObject.SetActive(false);
        famImg3.gameObject.transform.parent.gameObject.SetActive(false);
        famImg4.gameObject.transform.parent.gameObject.SetActive(false);
        famImg5.gameObject.transform.parent.gameObject.SetActive(false);

        Debug.Log("INT "+GameController.player.thisHuman.interactionTarget.GetType()+ "aegew! "+ GameController.player.thisHuman.interactionTarget.family.Count);

        for(int i = 0; i < GameController.player.thisHuman.interactionTarget.family.Count; i++){
            Debug.Log("AGAWEOGAWE");
            Image img = famImg1;
            Human h = GameController.player.thisHuman.interactionTarget.family[i];
            switch(i){
                case 0:
                    img = famImg1;
                    break;
                case 1:
                    img = famImg2;
                    break;
                case 2:
                    img = famImg3;
                    break;
                case 3:
                    img = famImg4;
                    break;
                case 4:
                    img = famImg5;
                    break;
            }
            img.gameObject.transform.parent.gameObject.SetActive(true);
            ih = img.gameObject.transform.parent.gameObject.GetComponent<InventoryHint>();
            ih.txt = h.name+" ";
            switch(h.state){
                case 0:
                    ih.txt += "(Well)";
                    break;
                case 1:
                    ih.txt += "(Ill)";
                    break;
                case 2:
                    ih.txt += "(Dead)";
                    break;
            }

            switch(h.gender){
                case 0:
                    switch(h.skintone){
                        case 0:
                            switch(h.state){
                                case 0:
                                    img.sprite = SprHuman_M_L_Well;
                                    break;
                                case 1:
                                    img.sprite = SprHuman_M_L_Ill;
                                    break;
                                case 2:
                                    img.sprite = SprHuman_M_L_Dead;
                                    break;
                            }
                            break;
                        case 1:
                            switch(h.state){
                                case 0:
                                    img.sprite = SprHuman_M_D_Well;
                                    break;                  
                                case 1:                     
                                    img.sprite = SprHuman_M_D_Ill;
                                    break;                  
                                case 2:                     
                                    img.sprite = SprHuman_M_D_Dead;
                                    break;
                            }
                            break;
                    }
                    break;
                case 1:
                    switch(h.skintone){
                        case 0:
                            switch(h.state){
                                case 0:
                                    img.sprite = SprHuman_F_L_Well;
                                    break;
                                case 1:
                                    img.sprite = SprHuman_F_L_Ill;
                                    break;
                                case 2:
                                    img.sprite = SprHuman_F_L_Dead;
                                    break;
                            }
                            break;
                        case 1:
                            switch(h.state){
                                case 0:
                                    img.sprite = SprHuman_F_D_Well;
                                    break;                  
                                case 1:                     
                                    img.sprite = SprHuman_F_D_Ill;
                                    break;                  
                                case 2:                     
                                    img.sprite = SprHuman_F_D_Dead;
                                    break;
                            }
                            break;
                    }
                    break;
            }


        }
    }
}
