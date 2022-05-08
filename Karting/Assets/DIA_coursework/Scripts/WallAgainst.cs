using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAgainst : MonoBehaviour
{

    int HitWallTimes = 0;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Wall") )
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            HitWallTimes += 1;

            print("Hit Wall: "+HitWallTimes);

        }
    }








}
