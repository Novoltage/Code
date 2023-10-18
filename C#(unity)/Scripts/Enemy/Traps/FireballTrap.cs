using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] EFireball;
    private float cooldownTimer;

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

        if (cooldownTimer >= attackCooldown)
            Attack();
    }
}