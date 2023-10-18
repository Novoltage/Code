using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAttack : MonoBehaviour
{

    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;
    private float cooldownTimer = Mathf.Infinity;
    private float hold;
    private PMovement pMovement;
    private Animator anim;


    // Start is called before the first frame update
    private void Awake()
    {
        pMovement = GetComponent<PMovement>();
        anim = GetComponent<Animator>();
        

        // Update is called once per frame
        
       
    }

   private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && cooldownTimer > attackCooldown && pMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {

        anim.SetTrigger("Attack");
        cooldownTimer = 0;
        // pool fireball

        fireballs[Findfireball()].transform.position = firepoint.position;
        fireballs[Findfireball()].GetComponent<fireball>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int Findfireball()
    {
        for(int i = 0; i < fireballs.Length; i++)
        {
            if(!fireballs[i].activeInHierarchy)
                return i;
        }

        return (0);
    }
    

}
