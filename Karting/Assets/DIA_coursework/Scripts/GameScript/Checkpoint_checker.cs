using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_checker : MonoBehaviour
{


    List<Collider> CheckpointColliders = new List<Collider>();

    Collider Collider1;
    Collider Collider2;
    Collider Collider3;

    bool CheckAll = false;

    public bool getCheck(){
        return CheckAll;
    }


    // Start is called before the first frame update
    void Start()
    {

        Collider Collider1 = GameObject.Find("Checkpoint1").GetComponent<BoxCollider>();
        Collider Collider2 = GameObject.Find("Checkpoint2").GetComponent<BoxCollider>();
        Collider Collider3 = GameObject.Find("Checkpoint3").GetComponent<BoxCollider>();

        CheckpointColliders.Add(Collider1);
        CheckpointColliders.Add(Collider2);
        CheckpointColliders.Add(Collider3);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



     void OnTriggerEnter(Collider collision)
    {


        if (CheckpointColliders.Contains(collision)) {
            CheckpointColliders.Remove(collision);
        }

        if (CheckpointColliders.Count == 0){
            CheckAll = true;
        }






    }
}
