using UnityEngine;
using System.Collections;

public class preadtorScript : MonoBehaviour {

    public float speed = 10f;
    float rotationSpeed = 5.0f;
    bool turning = false;
    public bool eating = false;

    // Use this for initialization
void Start()
    {
       // speed = Random.Range(1f, 3f);
    }

    // Update is called once per frame
void Update()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) >= PreyManger.tankSize)//||transform.position.y>0||transform.position.y<0
        {
            turning = true;
        }
        else
            turning = false;
        
        if (turning)
        {
            Vector3 direction = Vector3.zero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                      Quaternion.LookRotation(direction),
                                      rotationSpeed * Time.deltaTime);
            //speed = Random.Range(1f, 3f);
        }
        else
        {
            if (Random.Range(0, 5) < 1)
            {
                ApplyRules();
            }
        }
        transform.Translate(0, 0, Time.deltaTime * speed);
    }
void ApplyRules()
    {
        Vector3 vcentre = Vector3.zero;
        Vector3 goalPos = PreyManger.goalPos;
    
        vcentre = vcentre + (goalPos - this.transform.position); 
       
        Vector3 direction = vcentre-transform.position;
        if (direction != Vector3.zero)
        {
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                     Quaternion.LookRotation(direction),
                                     rotationSpeed * Time.deltaTime);
        }
    }
void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Prey"))
        {
            other.gameObject.SetActive(false);
            eating = true;
        }
    }
}

