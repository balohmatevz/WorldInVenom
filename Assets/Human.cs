using UnityEngine;
using System.Collections;

public class Human : MonoBehaviour {

    Animator animator;
    public Vector3 movementTarget;
    public Interactable interactionTarget;
    public bool isInteracting = false;

    public Town livesInTown;
    public House livesInHouse;
    
    public int skintone = 1;
    public int gender = 1;
    public int state = 1;

    public string name = "";
    public string housename = "";
    
    float movementSpeed = 1f;
    public Well goingToWell;
    public bool isGointToWell;
    public bool moving = false;
    public bool expectingInteraction = false;
    float willDieIn;
    float willDieInTotal;

    public Town InhabitantOfTown;

	// Use this for initialization
	void Start () {
	    animator = this.GetComponent<Animator>();
        movementTarget = Vector3.zero;

        gender = Random.Range(0,2);
        skintone = Random.Range(0,2);
        state = 0;

        if(gender == 0){
            name = TerrainController.maleNames[Random.Range(0, TerrainController.maleNames.Length)] +" "+housename; 
        }else{
            name = TerrainController.femaleNames[Random.Range(0, TerrainController.femaleNames.Length)] +" "+housename; 
        }

	}
	
	// Update is called once per frame
	void Update () {

        if(this.state == 1){
            willDieIn -= Time.deltaTime;
            if(willDieIn < 0){
                this.state = 2;
            }
        }
        if(!moving && this.state == 2){
            return;
        }

        if(moving && movementTarget != null){
            this.transform.LookAt(movementTarget);
            this.transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            this.transform.Rotate(Vector3.up, 90);
            if(Vector3.Distance(this.transform.position, movementTarget) < (movementSpeed / 10)){
                moving = false;
                animator.SetBool("Walking", false);
                if(expectingInteraction){
                    interactionTarget.Interact();
                    isInteracting = true;
                }
                if(isGointToWell){
                    isGointToWell = false;
                    if(goingToWell.poisoned && this.state == 0){
                        this.state = 1;
                        this.willDieIn = Random.Range(10,150);
                        this.willDieInTotal = willDieIn;
                    }
                }
            }
        }

	}

    public void MoveTo(Vector3 target){
        movementTarget = target;
        animator.SetBool("Walking", true);
        moving = true;
    }

    void OnMouseEnter(){
        GameController.tooltipHintText.text = name+" ";
        if(state == 0){
            GameController.tooltipHintText.text += "(Well)";
        }
        if(state == 1){
            float ratio = willDieIn / willDieInTotal;
            if(ratio > 0.9f){
                GameController.tooltipHintText.text += "(Slightly Ill)";
            }else 
            if(ratio > 0.6f){
                GameController.tooltipHintText.text += "(Ill)";
            }else 
            if(ratio > 0.4f){
                GameController.tooltipHintText.text += "(Very Ill)";
            }else 
            if(ratio > 0.2f){
                GameController.tooltipHintText.text += "(Badly ill)";
            }else 
            if(ratio > 0.1f){
                GameController.tooltipHintText.text += "(Terminal)";
            }else{
                GameController.tooltipHintText.text += "(Dying)";
            }
        }
        if(state == 2){
            GameController.tooltipHintText.text += "(Dead)";
        }
    }
    
    void OnMouseExit(){
        GameController.tooltipHintText.text = "";
    }
}
