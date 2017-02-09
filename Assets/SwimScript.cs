using UnityEngine;
using System.Collections;

public class SwimScript : MonoBehaviour {

    public  float speed = 5f;
    float rotationSpeed = 4.0f;
    Vector3 aveHeading;
    Vector3 avePostion;
    public int groupSize;
    public GameObject[] gos;
    float neighbourDis = 6.0f;
    bool turning = false;

	// Use this for initialization
	void Start ()
    {
        speed = Random.Range(1f, 3f);
        gos = GolbalFlock.allFish;
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, Vector3.zero) >= GolbalFlock.tankSize)//||transform.position.y>0||transform.position.y<0
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
            speed = Random.Range(1f, 3f);
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
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.1f;

        Vector3 goalPos = GolbalFlock.goalPos;

        float dist;

        groupSize = 0;
        foreach(GameObject go in gos)
        {
            if(go !=this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position, this.transform.position);
                if(dist<= neighbourDis)//is it less then max neigbour distances
                {
                    vcentre += go.transform.position;// head towards neighbour
                    groupSize++;
                    if(dist<1.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);// move away form neighbour
                    }
                    SwimScript anotherFlock = go.GetComponent<SwimScript>();
                    gSpeed = gSpeed + anotherFlock.speed; // swim at average flock speed 
                }
            }
        }

        if(groupSize>0)
        {
            vcentre = vcentre / groupSize + (goalPos - this.transform.position);
            speed = gSpeed / groupSize;
            //vavoid= vavoid / groupSize + (goalPos - this.transform.position);
            Vector3 direction = (vcentre+vavoid)-transform.position;
            if(direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, 
                                     Quaternion.LookRotation(direction),
                                     rotationSpeed * Time.deltaTime);

            }
        }
    }
}
