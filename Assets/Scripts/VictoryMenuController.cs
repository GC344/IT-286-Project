using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryMenuController : MonoBehaviour
{
    public Text replay, exit;
    public Color select, deSelect;
    private bool replaySelected, exitSelected;

    void Start()
    {
        replaySelected = false;
        exitSelected = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            replay.color = select;
            exit.color = deSelect;
            replaySelected = true;
            exitSelected = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            exit.color = select;
            replay.color = deSelect;
            replaySelected = false;
            exitSelected = true;
        }
        if (Input.GetKeyDown(KeyCode.Return) && (replaySelected == true))
        {
            Debug.Log("Load Main Scene");
            SceneManager.LoadScene(1);

        }
        if (Input.GetKeyDown(KeyCode.Return) && (exitSelected == true))
        {
            Debug.Log("Exit Application");
            Application.Quit();
        }
    }
}
