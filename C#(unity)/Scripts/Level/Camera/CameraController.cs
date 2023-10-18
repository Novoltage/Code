using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float Cameraspeed;
    private float lookAhead;
    
    //private float currentPosx;
    //private Vector3 velocity = Vector3.zero;
    
    // Update is called once per frame
    void Update()
    {
        //Room to room camera
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosx, transform.y, transform.z,);  
        transform.position = new Vector3(Player.position.x + lookAhead, transform.position.y, transform.position.z);
        //lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * Player.localScale.x), Time.deltaTime * Cameraspeed);
            }


}
