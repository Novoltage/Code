using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firetrap : MonoBehaviour
{
    [Header("Timers")]
    [SerializeField] private float onDelay;
    [SerializeField] private float onTime;
    [SerializeField] private int Flashes;
    [Header("Damage")]
    [SerializeField] private float damage;


    private Animator anim;
    private SpriteRenderer SpriteRend;

    private bool Triggered;
    private bool Active;

    private Health playerHealth;

    void Start()
    {
        anim = GetComponent<Animator>();
        SpriteRend = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth != null && Active)
        {
            playerHealth.Takedamage(damage);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth = collision.GetComponent<Health>();
            if (!Triggered)
            {
                StartCoroutine(Activate());
            }
            if (Active)
                       collision.GetComponent<Health>().Takedamage(damage);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth = null;
        }
    }

    private IEnumerator Activate()
    {
        Triggered = true;
        for (int i = 0; i < Flashes; i++)
        {
            //flashes red when triggered 
            SpriteRend.color = Color.red;
            yield return new WaitForSeconds(onDelay / (Flashes * 2));
            SpriteRend.color = Color.white;
            yield return new WaitForSeconds(onDelay / (Flashes * 2));
        }
        //activates trapdamage
        Active = true;
        anim.SetBool("activated", true);


        yield return new WaitForSeconds(onTime);
        //deactivate trap, reset variables, idle animation
        Active = false;
        Triggered = false;
        anim.SetBool("activated", false);
    }
}