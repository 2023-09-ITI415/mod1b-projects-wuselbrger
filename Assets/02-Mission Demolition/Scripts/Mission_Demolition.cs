using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public enum GameMode{
    idle,
    playing,
    levelEnd
}
public class Mission_Demolition : MonoBehaviour
{
    static private Mission_Demolition S; 
    public TextMeshProUGUI uitLevel;
    public TextMeshProUGUI uitShots;
    public TextMeshProUGUI uitButton;
    public Vector3 castlePos;
    public GameObject[] castles;

    public int level;
    public int levelMax;
    public int shotsTaken;
    public GameObject castle;
    public GameMode mode = GameMode.idle;
    public string showing = "Show Slingshot";


    // Start is called before the first frame update
    void Start()
    {
        S = this;
        level = 0;
        levelMax = castles.Length;
        StartLevel();
    }

    void StartLevel(){
        if(castle != null){
            Destroy(castle);
        }
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach(GameObject pTemp in gos)
            Destroy(pTemp);
        castle = Instantiate<GameObject>(castles[level]);
        castle.transform.position = castlePos;
        shotsTaken = 0;

        SwitchView("Show Both");
        ProjectileLine.S.Clear();
        Goal.goalMet = false;
        UpdateGUI();
        mode = GameMode.playing;
    }
    
    void UpdateGUI(){
        uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        uitShots.text = "Shots Taken: " + shotsTaken;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGUI();
        if((mode == GameMode.playing) && Goal.goalMet){
            mode = GameMode.levelEnd;
            SwitchView("Show Both");
            Invoke("NextLevel",2f);
        }
    }

    void NextLevel(){
        level++;
        if(level == levelMax)
            level = 0;
        StartLevel();
    }

    public void SwitchView(string eView = ""){
        if(eView == "")
            eView = uitButton.text;
        showing = eView;
        switch(showing){
            case "Show Slingshot":
                FollowCam.POI = null;
                uitButton.text = "Show Castle";
                break;
            case "Show Castle":
                FollowCam.POI = S.castle;
                uitButton.text = "Show Both";
                break;
            case "Show Both":
                FollowCam.POI = GameObject.Find("View Both");
                uitButton.text = "Show Slingshot";
                break;
        } 
    }

    public static void ShotFired(){
        S.shotsTaken++;
    }
}
