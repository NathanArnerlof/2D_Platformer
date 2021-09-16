using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int healthPoints = 2;
    public int intialHealthPoints = 3;

    public int starAmount = 0;

    [SerializeField] private GameObject respawnPosition;

    void Start()
    {

    }

    void Update()    {
        
    }

    public void DoHarm(int doHarmByThisMuch) {
        healthPoints -= doHarmByThisMuch;
        if(healthPoints<= 0) {
            Respawn();
            
        }
    }

    public void Respawn() {
        healthPoints = intialHealthPoints;
        gameObject.transform.position = respawnPosition.transform.position;

    }

    public void StarPickup() {
        starAmount++;
    }

    public void ChangeRespawnPosition(GameObject newRespawnPostion) {
        respawnPosition = newRespawnPostion;
    }


}
