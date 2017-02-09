using UnityEngine;
using System.Collections;

public class GolbalFlock : MonoBehaviour {

    // Use this for initialization
    public GameObject Fish;
    public static int tankSize=20;
    static int Fishnum = 10;
    public static GameObject[] allFish = new GameObject[Fishnum];
    public static Vector3 goalPos = Vector3.zero;
    public GameObject goalObject;
	void Start ()
    {
	for(int i=0;i<Fishnum;i++)
        {
            Vector3 pos = new Vector3( Random.Range(-tankSize, tankSize), 
                                       Random.Range(-tankSize, tankSize), 
                                       Random.Range(-tankSize, tankSize));
            allFish[i]=(GameObject)Instantiate(Fish, pos, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	if (Random.Range(0,1000)<50)
        {
            goalPos = new Vector3(Random.Range(-tankSize, tankSize),
                                Random.Range(-tankSize, tankSize),
                                Random.Range(-tankSize, tankSize));
            // goalPos = goalObject.transform.position;
        }
	}
}
