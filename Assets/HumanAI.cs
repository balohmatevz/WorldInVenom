using UnityEngine;
using System.Collections;

public class HumanAI : MonoBehaviour {

    Human h;
    int doing = 0;

	// Use this for initialization
	void Start () {
	    h = this.GetComponent<Human>();
	}
	
	// Update is called once per frame
	void Update () {
        if(h.state == 2){
            return;
        }

	    if(doing == 0){
            if(Random.Range(0, 500) == 0){
                
                int action = Random.Range(0, 3);
                if(action == 0){
                    h.MoveTo(new Vector3(h.livesInTown.Store.x, 0, h.livesInTown.Store.y));
                }
                if(action == 1){
                    h.isGointToWell = true;
                    h.goingToWell = h.livesInTown.well;
                    Vector3 v = h.livesInTown.well.transform.position;
                    v.y = 0;
                    h.MoveTo(v);
                }
                if(action == 2){
                    Vector2 housePos = h.livesInTown.HouseList[Random.Range(0, h.livesInTown.HouseList.Count)];
                    Vector2 myHouse = new Vector2(h.livesInHouse.transform.position.x,h.livesInHouse.transform.position.z);
                    if(Vector2.Distance(housePos, myHouse) > 2){
                        h.MoveTo(new Vector3(housePos.x, 0, housePos.y));
                    }
                }
                doing = 1;

            }
        }
        if(doing == 1){
            if(!h.moving){
                doing = 2;
            }
        }
        if(doing == 2){
            if(Random.Range(0, 100) == 0){
                h.MoveTo(h.livesInHouse.transform.position);
                doing = 3;
            }
        }
        if(doing == 3){
            if(!h.moving){
                doing = 0;
            }
        }
	}
}
