using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerMovement playerMovement;
    public Vector2 currentPosGrid;
    Vector2 movement;
    Vector2 startPos = new Vector3(0,-3);

    Vector2 truePos = new Vector2(.5f,.5f);

    public Transform lookAtTarget;

    

    void Start(){
        playerMovement = GetComponent<PlayerMovement>();


        playerMovement.transform.position = startPos + truePos;
        currentPosGrid = transform.position;
        // GridManager.inst.UpdateMoveAbleGridForPlayer();

    }

    void Update(){

       currentPosGrid = transform.position;

       if (currentPosGrid != null) {
            
            playerMovement.HandleMovement();
            LookAt();
       }
    }

    public Vector2 LocationInGrid()
    {
        return currentPosGrid + Vector2.one * 2.5f;
    }

    void LookAt(){
        Quaternion lookRotation = Quaternion.LookRotation(lookAtTarget.position - transform.position);

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation,0.1f);
    }
    
}
