using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Classes[] classPeriods;

    [HideInInspector] public string[] team;
    [HideInInspector] public Sprite[] teamBg;
    [HideInInspector] public GameObject[] teamCst;
    [HideInInspector] public bool[] highTeam;
    [HideInInspector] public bool[] overall;
    [HideInInspector] string[] teamRank;
    [HideInInspector] string[] teamKey;

    //Remote Settings

    public static string Class0 { get; private set; }
    public static string Class1 { get; private set; }
    public static string Class2 { get; private set; }
    public static string Class3 { get; private set; }
    public static string Class4 { get; private set; }
    public static string Class5 { get; private set; }
    public static string TopClass { get; private set; }

    Text nullMessage;


    // Start is called before the first frame update
    void Awake()
    {
        nullMessage = GameObject.FindGameObjectWithTag("subtitle").GetComponent<Text>();

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        teamRank = new string[6];

        teamRank[0] = Class0;
        teamRank[1] = Class1;
        teamRank[2] = Class2;
        teamRank[3] = Class3;
        teamRank[4] = Class4;
        teamRank[5] = Class5;

    }

    public void GetTeamInfo(int index)
    {
        nullMessage = GameObject.FindGameObjectWithTag("subtitle").GetComponent<Text>();

        int arraySize = classPeriods[index].teamName.Length;
        if (arraySize != 0)
        {
            team = new string[arraySize];
            teamBg = new Sprite[arraySize];
            teamCst = new GameObject[arraySize];
            highTeam = new bool[arraySize];
            overall = new bool[arraySize];
            teamKey = new string[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                team[i] = classPeriods[index].teamName[i].nameOfTeam;
                teamBg[i] = classPeriods[index].teamName[i].backgroundImg;
                teamCst[i] = classPeriods[index].teamName[i].crestImg;
                teamKey[i] = classPeriods[index].teamName[i].keyString;

                //sets team rank based on remote settings
                if (teamKey[i].Equals(teamRank[i]))
                {
                    highTeam[i] = true;
                }
                else
                {
                    highTeam[i] = false;
                }

                //sets top team overall based on remote settings
                if (teamKey[i].Equals(TopClass))
                {
                    overall[i] = true;
                }
                else
                {
                    overall[i] = false;
                }

                overall[i] = classPeriods[index].teamName[i].topClass;
            }
            SceneManager.LoadScene(1);
        }
        else
        {
            nullMessage.text = "There are no guilds in that region";
        }

        /* team1 = classPeriods[index].teamName[0].name;
         team2 = classPeriods[index].teamName[1].name;
         team3 = classPeriods[index].teamName[2].name;
         team4 = classPeriods[index].teamName[3].name;*/

    }//GetTeamNames

}//Class