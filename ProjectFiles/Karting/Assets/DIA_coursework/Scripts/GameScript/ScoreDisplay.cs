using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreDisplay : MonoBehaviour
{
    public GameObject kartField;
    public GameObject timeField;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI KartText = kartField.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI TimeText = timeField.GetComponent<TextMeshProUGUI>();
        // scoreText.text="test";
        
        KartText.text = GameFinishTime.GetScore()[0];
        TimeText.text = GameFinishTime.GetScore()[1];



        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
