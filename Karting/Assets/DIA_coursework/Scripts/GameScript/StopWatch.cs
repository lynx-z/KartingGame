using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class StopWatch : MonoBehaviour
{

 
    float currentTime;
    
    public GameObject currentTimeTextField;
    TextMeshProUGUI currentTimeText;
    bool startGame = false;

    
    GameObject finishLine;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        currentTimeText = currentTimeTextField.GetComponent<TextMeshProUGUI>();
        finishLine = GameObject.Find("StartFinishLine");
        StartCoroutine(ExampleCoroutine());
    }


    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(3);
        startGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(finishLine.GetComponent<GameFinishTime>().GetPlayerOver()){
            startGame = false;
            currentTimeText.text = finishLine.GetComponent<GameFinishTime>().GetPlayerTime().ToString(@"mm\:ss\:fff");
            
        }

        if (startGame){
            currentTime = currentTime + Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(currentTime);

            // currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString() +  ":" + time.Milliseconds.ToString();
            currentTimeText.text = time.ToString(@"mm\:ss\:fff");
            
        }


        
    }
}
