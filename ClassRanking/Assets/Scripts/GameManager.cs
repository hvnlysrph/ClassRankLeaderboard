using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector]public Classes[] classPeriods;

    [HideInInspector] public string[] team;
    [HideInInspector] public Sprite[] teamBg;
    [HideInInspector] public GameObject[] teamCst;
     public bool[] highTeam;
    public bool[] overall;
    [SerializeField] string[] teamRank;
    string[] teamKey;
    public string team1Key,team2Key,team3Key,team4Key,team5Key,team6Key,topTeamKey;

    //Remote Settings
    
    public string Class0 { get { return team1Key; } set { team1Key = value; } }
    public string Class1 { get { return team2Key; } set { team2Key = value; } }
    public string Class2 { get { return team3Key; } set { team3Key = value; } }
    public string Class3 { get { return team4Key; } set { team4Key = value; } }
    public string Class4 { get { return team5Key; } set { team5Key = value; } }
    public string Class5 { get { return team6Key; } set { team6Key = value; } }
    public string TopClass { get { return topTeamKey; } set { topTeamKey = value; } }

    Text nullMessage;
    

    // Start is called before the first frame update
    void Awake()
    {
        nullMessage = GameObject.FindGameObjectWithTag("subtitle").GetComponent<Text>();

        if (instance == null)
            instance = this;
        else if(instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        StartCoroutine(RankTeams(.1f));
    }

    IEnumerator RankTeams(float time)
    {
        yield return new WaitForSeconds(time);
        teamRank = new string[] { team1Key, team2Key, team3Key, team4Key, team5Key, team6Key };
    }

    void Update()
    {
        
    }

    public void GetTeamInfo(int index)
    {

        nullMessage = GameObject.FindGameObjectWithTag("subtitle").GetComponent<Text>();

        int arraySize = classPeriods[index].teamName.Length;

        //checks if class exists by checkiing the array size of team info
        if (arraySize != 0)
        {
            team = new string[arraySize];
            teamBg = new Sprite[arraySize];
            teamCst = new GameObject[arraySize];
            highTeam = new bool[arraySize];
            overall = new bool[arraySize];
            teamKey = new string[arraySize];

            string keyPass = teamRank[index];

            //upacks team info
            for (int i = 0; i < arraySize; i++)
            {
                team[i] = classPeriods[index].teamName[i].nameOfTeam;
                teamBg[i] = classPeriods[index].teamName[i].backgroundImg;
                teamCst[i] = classPeriods[index].teamName[i].crestImg;
                teamKey[i] = classPeriods[index].teamName[i].keyString;
                //highTeam[i] = classPeriods[index].teamName[i].topTeam;
                //overall[i] = classPeriods[index].teamName[i].topClass;

                //if the remote setting matches the team key, this is the high team for the class
                if (teamKey[i].Equals(keyPass))
                {
                    highTeam[i] = true;
                    Debug.Log(classPeriods[index].teamName[i].keyString);
                    Debug.Log(highTeam[i]);
                }
                else
                {
                    highTeam[i] = false;
                }

                //sets top team overall based on remote settings
                if (teamKey[i].Equals(topTeamKey))
                {
                    overall[i] = true;
                }
                else
                {
                    overall[i] = false;
                }
                

            }//for loop
            SceneManager.LoadScene(1);
        }//end check if a class exist
        else
        {
            nullMessage.text = "There are no guilds in that region";
        }

    }//End GetTeamInfo

}//Class
