using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class com : MonoBehaviour
{
    [SerializeField]
    GameObject targ;

    [SerializeField]
    float aiMoveSpeed = 4f;

    [SerializeField]
    float distanceBetween;

    private float distance;

   Rigidbody2D rb;

    void Update()
    {
        
        rb = GetComponent<Rigidbody2D>();
        
        distance = Vector2.Distance(transform.position, targ.transform.position);
        Vector2 direction = targ.transform.position - transform.position;
        direction.Normalize();
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        
        //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        
        //if(distance < distanceBetween) 
        //{
        //    transform.position = Vector2.MoveTowards(this.transform.position, targ.transform.position, aiMoveSpeed * Time.deltaTime);
        //}
        rb.velocity = (targ.transform.position - transform.position).normalized * aiMoveSpeed;
        rb.AddForce(rb.velocity);
    }
    

    
}
