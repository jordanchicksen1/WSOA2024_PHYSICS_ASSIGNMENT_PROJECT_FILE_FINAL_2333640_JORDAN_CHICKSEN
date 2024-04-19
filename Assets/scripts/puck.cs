using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class puck : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    Vector2 ForceVectorPlayer = new Vector2(80f, 10f);
    [SerializeField]   
    Vector2 ForceVectorBottomBarrierRed = new Vector2(20f, 80f);
    [SerializeField]
    Vector2 ForceVectorBottomBarrierBlue = new Vector2(-20f, 80f);
    [SerializeField]
    Vector2 ForceVectorTopBarrierBlue = new Vector2(-20f, -80f);
    [SerializeField]
    Vector2 ForceVectorTopBarrierRed = new Vector2(20f, -80f);
    [SerializeField]
    Vector2 ForceVectorTopLeftBarrierRed = new Vector2(-50f, 50f);
    [SerializeField]
    Vector2 ForceVectorTopRightBarrierBlue = new Vector2(-50f, -50f);
    [SerializeField]
    Vector2 ForceVectorBottomRightBarrierBlue = new Vector2(-50f, 50f);
    [SerializeField]
    Vector2 ForceVectorBottomLeftBarrierRed = new Vector2(50f, -50f);
   
    [SerializeField]
    ParticleSystem testParticleSystem = default;
    [SerializeField]
    ParticleSystem testParticleSystemAI = default;  
   
    public scoreManager scoreManager;
    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3;

    public bool hasDoublePoints;
    
    [SerializeField]
    float destroyDelay = 0.1f;

    [SerializeField]
    float destroyDelay2 = 20f;

    public Transform destination;

    public float distance = 0.2f;

    public float puckTeleporterSpeed = 4f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // scoreManager = GameObject.FindGameObjectWithTag("scoreManager").GetComponent<scoreManager>();
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb.AddForce(-ForceVectorPlayer, ForceMode2D.Force);
            src.clip = sfx1;
            src.Play();
        }

        if (other.gameObject.CompareTag("Comp"))
        {
            rb.AddForce(ForceVectorPlayer, ForceMode2D.Force);
            src.clip = sfx1;
            src.Play();
        }

        if (other.gameObject.CompareTag("RedBottomBarrier"))
        {
            rb.AddForce(ForceVectorBottomBarrierRed, ForceMode2D.Force);
            src.clip = sfx1;
            src.Play();
        }

        if (other.gameObject.CompareTag("BlueBottomBarrier"))
        {
            rb.AddForce(ForceVectorBottomBarrierBlue, ForceMode2D.Force);
            src.clip = sfx1;
            src.Play();
        }

        if (other.gameObject.CompareTag("RedTopBarrier"))
        {
            rb.AddForce(ForceVectorTopBarrierRed, ForceMode2D.Force);
            src.clip = sfx1;
            src.Play();
        }

        if (other.gameObject.CompareTag("BlueTopBarrier"))
        {
            rb.AddForce(ForceVectorTopBarrierBlue, ForceMode2D.Force);
            src.clip = sfx1;
            src.Play();
        }

        if (other.gameObject.CompareTag("RedTopLeftBarrier"))
        {
            rb.AddForce(ForceVectorTopLeftBarrierRed, ForceMode2D.Force);
            src.clip = sfx1;
            src.Play();
        }

        if (other.gameObject.CompareTag("BlueTopRightBarrier"))
        {
            rb.AddForce(ForceVectorTopRightBarrierBlue, ForceMode2D.Force);
            src.clip = sfx1;
            src.Play();
        }

        if (other.gameObject.CompareTag("BlueBottomRightBarrier"))
        {
            rb.AddForce(ForceVectorBottomRightBarrierBlue, ForceMode2D.Force);
            src.clip = sfx1;
            src.Play();
        }

        if (other.gameObject.CompareTag("RedBottomLeftBarrier"))
        {
            rb.AddForce(ForceVectorBottomLeftBarrierRed, ForceMode2D.Force);
            src.clip = sfx1;
            src.Play();
        }

        if (other.gameObject.CompareTag("Goalbox1"))
        {
            //Destroy(other.gameObject, 0f);
            //Destroy(this.gameObject, 0f);
            //or
           
            testParticleSystem.Play();
            rb.velocity = Vector3.zero;
           
            this.gameObject.transform.position = new Vector3(2.59f, 0.01f, 0);
        }

        if (other.gameObject.CompareTag("Goalbox2"))
        {
            //Destroy(other.gameObject, 0f);
            //Destroy(this.gameObject, 0f);

            testParticleSystemAI.Play();
            rb.velocity = Vector3.zero;
            
            this.gameObject.transform.position = new Vector3(-2.59f, 0.01f, 0);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //goals
        if (other.tag == "Goal1" && hasDoublePoints == true)
        {
            Debug.Log("AI SCORED x2!!!");
            scoreManager.addComScoreDouble();
           hasDoublePoints = false;
            src.clip = sfx2;
            src.Play();
            //if (hasDoublePoints == true)
            //{ 
            //hasDoublePoints = false;    
            //}

        }
        else
        if (other.tag == "Goal1" )
        {
            Debug.Log("AI SCORED!!!");
            scoreManager.addComScore();
            src.clip = sfx2;
            src.Play();

        }
        

        if (other.tag == "Goal2" && hasDoublePoints == true)
        {
            Debug.Log("PLAYER SCORED x2!!!");
            scoreManager.addPlayerScoreDouble();
            hasDoublePoints = false;
            src.clip = sfx2;
            src.Play();

            //if (hasDoublePoints == true)
            //{
            //    hasDoublePoints = false;
            //}

        }
        else
        if (other.tag == "Goal2")
        {
            Debug.Log("PLAYER SCORED!!!");
            scoreManager.addPlayerScore();
            src.clip = sfx2;
            src.Play();
        }

        //double points
        if (other.tag == "DoublePoints" && hasDoublePoints == false)
        {
            Debug.Log("has double points");
            hasDoublePoints = true;
            Destroy(other.gameObject, destroyDelay);
            src.clip = sfx3;
            src.Play();
        }

        
        //teleporter
        if (other.tag == "teleporter")
        {
            Debug.Log("went into teleporter 1");
            rb.velocity = new Vector2( -transform.position.x, transform.position.y) * puckTeleporterSpeed;

            this.gameObject.transform.position = new Vector3(-7.41f, 3.41f, 3.766766f);
            Destroy(other.gameObject, destroyDelay2);


        }

        if (other.tag == "teleporter2")
        {
            Debug.Log("went into teleporter 2");
            rb.velocity = new Vector2( -transform.position.x, transform.position.y) * puckTeleporterSpeed;

            this.gameObject.transform.position = new Vector3(-7.41f, -3.64f, 3.766766f);
            Destroy(other.gameObject, destroyDelay2);


        }

    }
}
