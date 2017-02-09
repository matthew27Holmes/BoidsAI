using UnityEngine;
using System.Collections;

public class PreyManger : MonoBehaviour {

    // Use this for initialization
    public GameObject Fish;
    public static int tankSize = 20;
    static int Fishnum = 1;
    public static GameObject[] allFish = new GameObject[Fishnum];
    public GameObject[] Prey;
    public static Vector3 goalPos = Vector3.zero;
    public GameObject goalObject;
    private SwimScript swimscript;
    void Start()
    {
        
        for (int i = 0; i < Fishnum; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-tankSize, tankSize),
                                       Random.Range(-tankSize, tankSize),
                                       Random.Range(-tankSize, tankSize));
            allFish[i] = (GameObject)Instantiate(Fish, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        swimscript = goalObject.GetComponent<SwimScript>();
        Prey = swimscript.gos;
        int preygroupsize;
        if (Random.Range(0, 1000) < 50)
        {
            foreach (GameObject fish in Prey)
            {
                preygroupsize = swimscript.groupSize;
                
                if (preygroupsize < 1)
                {
                    ///goalObject = fish;
                }
            }
            goalPos = goalObject.transform.position;
        }
    }
}
