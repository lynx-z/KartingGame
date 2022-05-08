using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameFinishTime : MonoBehaviour
{

    #region Karts
        public GameObject[] Karts;
    #endregion

    Collider[] KartColliders;

    float[] timeUse;
    float startTime;

    ObjectiveManager m_ObjectiveManager;
    GameObject manager;
    bool[] CheckAll;
    bool gameOver = false;

    bool playerOver = false;
    TimeSpan playerTime;
    public DisplayMessage playerFinishMeassage;

    static string[] scoreText;

    public bool GetGameOver(){
        return gameOver;
    }

    public bool GetPlayerOver(){
        return playerOver;
    }

    public TimeSpan GetPlayerTime(){
        return playerTime;
    }


    // Start is called before the first frame update
    void Start()
    {
        //initialize
        timeUse = new float[Karts.Length];
        CheckAll = new bool[Karts.Length];
        KartColliders = new Collider[Karts.Length];
        scoreText = new string[2];

        playerFinishMeassage.gameObject.SetActive(false);

        for (var i = 0; i < KartColliders.Length; i++){
            KartColliders[i] = Karts[i].GetComponent<Collider>();
        }


        StartCoroutine(ExampleCoroutine());// wait 3 seconds

        // get game manager
        manager = GameObject.Find("GameManager");
        
    }
    
    // wait 3 second
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(3);
        startTime = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider collision)
    {
        racingGame(collision);
    }


    void racingGame(Collider collision){

        int currentIndex = Array.IndexOf(KartColliders, collision);
        // m_ObjectiveManager = manager.GetComponent<my_GameFlowManager>().getObjectiveManager();

        // if collision is kart
        if (currentIndex >= 0) {

            // if go through all checkpoint
            bool isCheck = Karts[currentIndex].GetComponent<Checkpoint_checker>().getCheck();
            if (isCheck && CheckAll[currentIndex] == false){
                float finishTime = Time.fixedTime; 
                float thisRoundTime = finishTime - startTime;
                timeUse[currentIndex] = thisRoundTime;
                CheckAll[currentIndex] = isCheck;

                gameOver = IsAllChecked();
                // print(gameOver);
                // print("No: "+currentIndex+ "    Time use: "+timeUse[currentIndex]);

                //stopWatch
                TimeSpan time = TimeSpan.FromSeconds(thisRoundTime);

                if (Karts[currentIndex].name == "YOU") {
                    playerOver = true;
                    playerTime = time;
                    playerFinishMeassage.gameObject.SetActive(true);
                }

                scoreText[0] += Karts[currentIndex].name+"\n";
                scoreText[1] += time.ToString(@"mm\:ss\:fff") +"\n";


            }
            
        }

    }

    bool IsAllChecked() {
        for ( int i = 0; i < CheckAll.Length; i++ ) {
            if ( CheckAll[i] == false ) {
            return false;
            }
        }
        return true;
    }

    public static string[] GetScore(){
        // return "score\nscore\nscore";
        return scoreText;
    }

    public void AddLose(){
        // return "score\nscore\nscore";
        for (var i = 0; i < CheckAll.Length; i++){
            if (CheckAll[i] == false){
                scoreText[0] += Karts[i].name+"\n";
                scoreText[1] += "Unfinished" +"\n";

            }
        }
        
    }





}
