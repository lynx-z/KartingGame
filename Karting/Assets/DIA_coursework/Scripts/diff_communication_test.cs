using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class diff_communication_test : MonoBehaviour
{

    #region Karts
        public Collider[] KartColliders;
    #endregion

    #region Karts transform
        public Transform[] KartTransforms;
    #endregion

    int[] rounds;
    int laps = 0;
    float startTime;

    int[] winTimes = {0,0,0};
    // Vector3 startPos = new Vector3(222f, -0.3f, 2f);//Track 01
    // Vector3 startPos = new Vector3(14.5f, -0.7f, 3f);//Track 03
    // Vector3 startPos = new Vector3(-5f, -24.5f, 5f);//Track 05
    Vector3 startPos = new Vector3(-3f, -6.7f, -8f);//Track 07


    public KartGame.AI.KartAgent normalScript;
    public KartGame.AI.KartAgent sensorScript;
    public KartGame.AI.KartAgent_global globalKartScript;

    float normal_reward = 0;
    float sensor_reward = 0;
    float global_reward = 0;


    
    // Start is called before the first frame update
    void Start()
    {
        // speed up
        Time.timeScale = 10; 

        rounds = new int[KartColliders.Length];

        KartTransforms[0].position =  startPos;
        KartTransforms[1].position =  startPos + new Vector3(2, 0, 0);
        KartTransforms[2].position =  startPos + new Vector3(4, 0, 0);

        startTime = Time.fixedTime;

        resetGame();

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider collision)
    {
        int currentIndex = Array.IndexOf(KartColliders, collision);

        if (currentIndex >= 0){
            float finishTime = Time.fixedTime; 
            float thisRoundTime = finishTime - startTime;
            // print(thisRoundTime);

            // ensure not opposite
            if (thisRoundTime > 18.5)rounds[currentIndex]+=1;


            if (rounds[currentIndex] >= 1) {
               winTimes[currentIndex] += 1;
               laps += 1;

                if (laps == 100){
                    print("Laps: "+laps+"    Win rate, normal: "+ winTimes[0]+"    sensorBlock: "+ winTimes[1]+"   globalBlock: "+ winTimes[2]);
                    print("Average reward, "+ "normal: "+ normal_reward/laps+"    sensorBlock: "+ sensor_reward/laps+"   globalBlock: "+ global_reward/laps);
                }
                print("Laps: "+laps+"    Win rate, normal: "+ winTimes[0]+"    sensorBlock: "+ winTimes[1]+"   globalBlock: "+ winTimes[2]);
                // print("Average reward, "+ "normal: "+ normal_reward/laps+"    sensorBlock: "+ sensor_reward/laps+"   globalBlock: "+ global_reward/laps);

               resetGame();


           }
        }
    }



    void resetGame()
    {
        rounds = new int[KartColliders.Length];
        // startPos = startPos + new Vector3(0f, 0f, -0.25f);

        int[] order = reshuffle();

        global_reward += globalKartScript.GetCumulativeReward();
        sensor_reward += sensorScript.GetCumulativeReward();
        normal_reward += normalScript.GetCumulativeReward();


        globalKartScript.resetIndex();
        sensorScript.resetIndex();
        normalScript.resetIndex();


        KartTransforms[order[0]].position =  startPos;
        print(startPos);
        KartTransforms[order[1]].position =  startPos + new Vector3(2, 0, 0);
        KartTransforms[order[2]].position =  startPos + new Vector3(4, 0, 0);



        KartTransforms[0].rotation =  Quaternion.Euler(0, 0, 0);
        KartTransforms[1].rotation =  Quaternion.Euler(0, 0, 0);
        KartTransforms[2].rotation =  Quaternion.Euler(0, 0, 0);

        

        startTime = Time.fixedTime;

    }



    int[] reshuffle()
    {
        int[] myArray = {0,1,2};
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < myArray.Length; t++ )
        {
            int tmp = myArray[t];
            int r = Random.Range(t, myArray.Length);
            myArray[t] = myArray[r];
            myArray[r] = tmp;
        }

        return myArray;
    }

}
