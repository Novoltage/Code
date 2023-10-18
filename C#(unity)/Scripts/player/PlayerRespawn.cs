using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour

{

    private Transform currentCheckpoint;
    private Health playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<Health>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint.position; //moves player to checkpoint 
        playerHealth.Respawn(); //respawns player
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform; //Save checkpoint as new respawn

            collision.GetComponent<Collider2D>().enabled = false; // deactivate checkpoint collider
            collision.GetComponent<Animator>().SetTrigger("Appear");// activate "appear" animation
        }
    }
}
