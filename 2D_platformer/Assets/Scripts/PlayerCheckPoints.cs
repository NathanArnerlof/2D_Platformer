using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPoints : MonoBehaviour
{

    private Animator animator;
    [SerializeField] private bool hasBeenaActivated = false;

    void Start(){
        animator = gameObject.GetComponent<Animator>();
     }

    private void Update()
    {
        animator.SetBool("HasBeenActivated", hasBeenaActivated);
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player") == true) { 
            collision.GetComponent<PlayerState>().ChangeRespawnPosition(gameObject);
        }
        animator.SetTrigger("IsActivated");

    }
}
