using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject selectedObject;
    private bool buttonSelected;
    //public int highScore;
    //public int lastGameScore;
    void Awake()
    {
        //DontDestroyOnLoad(score);   
        //lastGameScore=ScoreText;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
        }
        /*if (Input.GetKeyDown(KeyCode.DownArrow)) TODO: Menu Navigation /w arrows/joystickbuttons
        {
            Button.highlightedColor
        }*/
    }
    /*void OnGUI () {
        //Text text = OptionsText.GetComponent<Text>;
        //OptionsText.SetActive(true);
        //OptionsText.text.;
    }*/

    private void OnDisable()
    {
        buttonSelected = false;
    }

    public void ButtonClicked()
    {
        Debug.Log("Button Clicked");
    }

    
}
