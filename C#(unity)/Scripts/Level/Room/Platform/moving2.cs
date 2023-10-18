using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving2 : MonoBehaviour
{
    [Header("Edges")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Platform")]
    [SerializeField] private Transform Platform;

    [Header("Movement")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Time")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

   
    private void Awake()
    {
        initScale = Platform.localScale;
    }
   

    private void Update()
    {
        if (movingLeft)
        {
            if (Platform.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                DirectionChange();
        }
        else
        {
            if (Platform.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                DirectionChange();
        }
    }

    private void DirectionChange()
    {
       
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
       

       
        //Move in that direction
        Platform.position = new Vector3(Platform.position.x + Time.deltaTime * _direction * speed,
            Platform.position.y, Platform.position.z);
    }
   
}
