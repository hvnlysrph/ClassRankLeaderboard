using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeamMenu : MonoBehaviour
{
    public Button[] buttons;
    int buttonClicked;

    public GameObject teamBackground;
    GameObject go;
    public Sprite throneRm;
    public Transform teamCrest;
    public Text teamTitle;
    public GameObject menu;
    GameObject crestPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //buttons = FindObjectsOfType<Button>();
        foreach(Button button in buttons)
        {
            button.gameObject.SetActive(false);
        }
        for (int i = 0; i < GameManager.instance.team.Length; i++)
        {
            buttons[i].gameObject.SetActive(true);
            buttons[i].GetComponentInChildren<Text>().text = GameManager.instance.team[i];
        }
    }

    public void TeamSelected(Button button)
    {
        buttonClicked = System.Convert.ToInt32(button.name);

        menu.SetActive(false);

       
        crestPrefab = GameManager.instance.teamCst[buttonClicked];
        teamTitle.text = GameManager.instance.team[buttonClicked];
        bool tt = GameManager.instance.highTeam[buttonClicked];
        bool tc = GameManager.instance.overall[buttonClicked];

        if (tc)
        {
            teamBackground.GetComponent<SpriteRenderer>().sprite = throneRm;
        }
        else
        {
            teamBackground.GetComponent<SpriteRenderer>().sprite = GameManager.instance.teamBg[buttonClicked];
        }

            go = (GameObject)Instantiate(crestPrefab, 
            new Vector3(teamCrest.position.x, teamCrest.position.y, teamCrest.position.z), 
            Quaternion.identity);

        go.gameObject.transform.parent = teamCrest.gameObject.transform;
        ParticleSystem crestFX = go.GetComponentInChildren<ParticleSystem>();

        if (tt)
        {
            crestFX.Play();
        }
        else
        {
            crestFX.Stop();
        }


    }

    public void ReturnToTeamMenu(Button button)
    {
        menu.SetActive(true);
        Destroy(go);
    }

    public void ReturnToMainMenu(Button button)
    {
        SceneManager.LoadScene(0);
    }

}
