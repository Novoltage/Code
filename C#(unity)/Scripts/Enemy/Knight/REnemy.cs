using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REnemy : MonoBehaviour
{
    
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] EFireball;
    
   
    private Animator anim;
      [SerializeField] private float AttackCd;
    [SerializeField] private float Range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int Damage;
    private float cdtimer = Mathf.Infinity;
    [SerializeField] private BoxCollider2D boxColider;
    [SerializeField] private LayerMask PlayerLayer;
    private float cooldownTimer = Mathf.Infinity;


    private EnemyPatrol enemypatrol;
    private Health playerHealth;


    private void Attack()
    {

        cooldownTimer = 0;
        EFireball[FindEFireball()].transform.position = firePoint.position;
        EFireball[FindEFireball()].GetComponent<EProjectile>().ActivateProjectile();
    }
    private int FindEFireball()
    {
        for (int i = 0; i < EFireball.Length; i++)
        {
            if (!EFireball[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        cooldownTimer = 0;
       
        if (playerSpotted())
        {
            if (cooldownTimer >= AttackCd)
            {
                cooldownTimer = 0;
                    anim.SetTrigger("rangeAttack");
            }
        }
            
    }
    private void Awake()
    {
       
        anim = GetComponent<Animator>();
        enemypatrol = GetComponentInParent<EnemyPatrol>();

    }
    private bool playerSpotted()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxColider.bounds.center + transform.right * Range * transform.localScale.x * colliderDistance,
           new Vector3(boxColider.bounds.size.x * Range, boxColider.bounds.size.y, boxColider.bounds.size.z),
           0, Vector2.left, 0, PlayerLayer);
       

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxColider.bounds.center + transform.right * Range * transform.localScale.x * colliderDistance,
           new Vector3(boxColider.bounds.size.x * Range, boxColider.bounds.size.y, boxColider.bounds.size.z));
    }
   
}
