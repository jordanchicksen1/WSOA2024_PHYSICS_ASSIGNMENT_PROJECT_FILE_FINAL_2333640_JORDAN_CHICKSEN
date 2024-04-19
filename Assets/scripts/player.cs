using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]
    float horizontalSpeed = 0.1f;
    [SerializeField]
    float verticalSpeed = 0.1f;

    //bool canPush = true;
    //bool isPushing;

    //[SerializeField]
    //float pushForce = 24f;
    //[SerializeField]
    //float pushTime = 0.2f;
    //[SerializeField]
    //float pushCooldown = 1f;
    //[SerializeField]
    //TrailRenderer tr;

    //Rigidbody rb;

   


    void Update()
    {
        //if (isPushing == true)
        //{
        //    return;
        //}
        
        float moveUp = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
        float moveSide = Input.GetAxis("Vertical") * verticalSpeed * Time.deltaTime;

        transform.Translate(moveUp, moveSide,0);

    //if (Input.GetKeyDown(KeyCode.M) && canPush)
    //    {
    //        StartCoroutine(Push());
    //    }
        
    }

    //public IEnumerator coroutine;
    //private IEnumerator Push()
    //{
    //canPush = false;
    //isPushing = true;

    //rb.velocity = new Vector2(transform.localScale.x * pushForce, 0f);
    //tr.emitting = true;
    //yield return new WaitForSeconds(pushTime);
    //tr.emitting = false;
    //isPushing = false;
    //yield return new WaitForSeconds(pushCooldown);
    //canPush = true;
    //}
}
