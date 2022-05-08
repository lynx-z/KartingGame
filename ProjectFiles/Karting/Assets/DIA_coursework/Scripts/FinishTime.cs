using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FinishTime : MonoBehaviour
{

    #region Karts
        public Collider[] KartColliders;
    #endregion

    // record rounds
    int[] rounds;
    // record time in each round
    List <float>[] timeUse;

    float totalTime;


    float startTime;
    


    // Start is called before the first frame update
    void Start()
    {
        rounds = new int[KartColliders.Length];
        timeUse = new List <float>[KartColliders.Length];
        for (var i = 0; i < KartColliders.Length; i++)
        {
            timeUse[i] = new List <float>();
        }

        startTime = Time.fixedTime;


    }

    // Update is called once per frames
    void Update()
    {
        
    }




    void OnTriggerEnter(Collider collision)
    {
        // count ervey agent
        // racingGame(collision);
        


        MeanSpeed(collision);


  
    }

    void racingGame(Collider collision){

        int currentIndex = Array.IndexOf(KartColliders, collision);

        if (currentIndex >= 0){
            
            // start from second hit line
            if (rounds[currentIndex] == 0)
            {
                startTime = Time.fixedTime;
            }

            if (rounds[currentIndex] > 4)
            {
                float finishTime = Time.fixedTime; 
                float thisRoundTime = finishTime - startTime;
                timeUse[currentIndex].Add(thisRoundTime);


                print("No: "+currentIndex+ "    Round: "+rounds[currentIndex]+ "    Time use: "+timeUse[currentIndex][rounds[currentIndex]-1]);
            }
            rounds[currentIndex]+=1;
        }

    }


    void MeanSpeed(Collider collision){

        int currentIndex = Array.IndexOf(KartColliders, collision);
        if (currentIndex >= 0){
            rounds[currentIndex]+=1;
            if (rounds[currentIndex] == 4){
                float finishTime = Time.fixedTime; 
                float thisRoundTime = finishTime - startTime;
                totalTime += thisRoundTime;
            }

            if (Mathf.Min(rounds) == 4){
                print("Amount: "+KartColliders.Length+"     rounds: 3"+"       Mean time: "+(totalTime/(KartColliders.Length*3)));

            }
        } 
    }




}
