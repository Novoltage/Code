using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUpDown : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float Distance;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().Takedamage(damage);

        }
    }

    void Start()
    {
        leftEdge = transform.position.y - Distance;
        rightEdge = transform.position.y + Distance;
    }


    void Update()
    {
        if (movingLeft)
        {
            if (transform.position.y > leftEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {

            if (transform.position.y < rightEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                movingLeft = true;
            }
        }
    }
}
