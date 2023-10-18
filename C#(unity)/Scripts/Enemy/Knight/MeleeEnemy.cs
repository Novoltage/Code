using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{

    [SerializeField] private float AttackCd;
    [SerializeField] private float Range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int Damage;
    private float cdtimer = Mathf.Infinity;
    [SerializeField] private BoxCollider2D boxColider;
    [SerializeField] private LayerMask PlayerLayer;
   
    
    private Animator anim;
    private EnemyPatrol enemypatrol;
    private Health playerHealth;


    void Start()
    {
        anim = GetComponent<Animator>();
        enemypatrol = GetComponentInParent<EnemyPatrol>();
    }

    void Update()
    {
        cdtimer += Time.deltaTime;
       
        if (playerSpotted())
        {
            if (cdtimer >= AttackCd)
            {
                cdtimer = 0;
                anim.SetTrigger("melee");

            }
        }

        if (enemypatrol != null)
        {
            enemypatrol.enabled = !playerSpotted();
        }
      
    }
    private bool playerSpotted()
    {
        RaycastHit2D hit = 
            Physics2D.BoxCast(boxColider.bounds.center + transform.right * Range * transform.localScale.x * colliderDistance,
           new Vector3(boxColider.bounds.size.x * Range, boxColider.bounds.size.y,boxColider.bounds.size.z),
           0, Vector2.left, 0, PlayerLayer);
        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxColider.bounds.center + transform.right * Range * transform.localScale.x * colliderDistance,
           new Vector3(boxColider.bounds.size.x * Range, boxColider.bounds.size.y, boxColider.bounds.size.z));
    }
    private void damagePlayer()
    {
        if (playerSpotted())

        {
            playerHealth.Takedamage(Damage);
        }
    }
}
