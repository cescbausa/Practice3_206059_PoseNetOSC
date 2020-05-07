using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public float runSpeed;
    public float destroyDelay;
    private bool hitByHand;
    private bool hitByNose;
    private Collider myCollider;
    private Rigidbody myRigidbody;
    private ProjectileSpawner projectileSpawner;
    private Vector3 direction;
    public Vector3 rotationSpeed;
    
    private bool hasCollided;
    
    private Vector3 RandomDirection()
    
    {
        return new Vector3(Random.Range(-0.2f,0.2f), Random.Range(0.0f, -1.0f), 0);

    }

    void increaseSpeed ()
     {
         runSpeed = runSpeed + 20f;
     }
    
    // Start is called before the first frame update
    void Start()
    {
        
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();  
        hasCollided = false;
        direction = RandomDirection();
        //transform.Translate(RandomDirection());
        InvokeRepeating("increaseSpeed", 0.3f, 1f);
    }
    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(rotationSpeed*Time.deltaTime, Space.Self);
        transform.Translate(direction * runSpeed * Time.deltaTime, Space.World);

    }

    public void SetSpawner(ProjectileSpawner spawner)
    {
        projectileSpawner = spawner;
    }
    
    
    /*private void HitByHand()
    {
        hitByHand = true;
        runSpeed = 0;

        Destroy(gameObject, destroyDelay);
        projectileSpawner.RemoveProjFromList(gameObject);

    }*/
    private void HitByNose()
    {
        hitByNose = true;
        runSpeed = 0;

        Destroy(gameObject, destroyDelay);
        projectileSpawner.RemoveProjFromList(gameObject);
        GameStateManager.Instance.lessLife();
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nose") && !hitByHand)
        {
            HitByNose();
        }
        /*else if (other.CompareTag("Nose") && !HitByHand)
        {
            if(!hasCollided)
            {
                hasCollided = true;
                Collect();
            }
            
        }*/

    }
    private void Collect()
    {
        hitByHand = true;
        runSpeed = 0;
    }
}
