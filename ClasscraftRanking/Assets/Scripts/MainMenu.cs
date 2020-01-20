using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    int buttonClicked;

    public void ChooseClass(Button button)
    {
        buttonClicked = System.Convert.ToInt32(button.name);
        GameManager.instance.GetTeamInfo(buttonClicked);
    }
}
