using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iframesTime;
    [SerializeField] private int Flashes;
    private SpriteRenderer SpriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    private bool invulnerable;



    void Start()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        SpriteRend = GetComponent<SpriteRenderer>();
    }
    public void Takedamage(float _damage)
    {
        if (invulnerable)
        {
            return;
        }
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // player hurt
            anim.SetTrigger("Hurt");
            StartCoroutine(invunerability());

        }

        else
        {
            if (!dead)
            {
                // dead player
                
                
                //disable all components

                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }
                anim.SetBool("grounded", true);
                anim.SetTrigger("Dead");
                dead = true;
            }
        }

    }
    
    public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
        anim.ResetTrigger("Dead");
        anim.Play("idle");
        foreach (Behaviour component in components)
        {
            component.enabled = true;
        }
        GetComponent<RScene>().ResetEnemies(true);
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    private IEnumerator invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < Flashes; i++)
        {
            SpriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iframesTime / (Flashes * 2));
            SpriteRend.color = Color.white;
            yield return new WaitForSeconds(iframesTime / (Flashes * 2));

        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }
    private void    deactivate()
    {
        gameObject.SetActive(false);
    }

    public void Falldamage(float _damage)
    {
        
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // player hurt
            anim.SetTrigger("Hurt");
            StartCoroutine(invunerability());

        }

        else
        {
            if (!dead)
            {
                // dead player


                //disable all components

                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }
                anim.SetBool("grounded", true);
                anim.SetTrigger("Dead");
                dead = true;
            }
        }

    }
}
