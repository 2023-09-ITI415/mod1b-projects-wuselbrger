using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI Cscore;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCount");
        Cscore = scoreGO.GetComponent<TextMeshProUGUI>();
        Cscore.text = "0";
    }

    void OnCollisionEnter(Collision coll){
        if(coll.gameObject.tag == "Rubble"){    
            int score = int.Parse(Cscore.text);
            score += 1;
            Cscore.text = score.ToString();
        }
    }
}
