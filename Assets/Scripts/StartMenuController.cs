using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour {
    public Text start, exit;
    public Color select, deSelect;
    private bool startSelected, exitSelected;

	void Start () {
        startSelected = false;
        exitSelected = false;
	}
	

	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            start.color = select;
            exit.color = deSelect;
            startSelected = true;
            exitSelected = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            exit.color = select;
            start.color = deSelect;
            startSelected = false;
            exitSelected = true;
        }
        if (Input.GetKeyDown(KeyCode.Return) && (startSelected == true))
        {
            Debug.Log("Load Main Scene");
            SceneManager.LoadScene(1);

        }
        if (Input.GetKeyDown(KeyCode.Return) && (exitSelected == true))
        {
            Debug.Log("Exit Application");
        }
    }
}
