using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    public Text resume;
    public Text exit;

    private Text currentSelected;
    private string vertical = "Vertical_P1";
    private Color32 avansRed = new Color32(198, 0, 42, 255);
    private Canvas menu;
    private string ButtonA = "ButtonA_P1";
    private string start = "Start_P1";
    private bool paused = false;


    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Canvas>();
        currentSelected = resume;
        currentSelected.color = avansRed;
    }

    // Update is called once per frame
    void Update()
    {

        if (menu.enabled)
        {
            if (Input.GetButtonDown(start))
            {
                Resume();
            }
            else if (Input.GetAxis(vertical) > 0)
            {
                currentSelected = resume;
                exit.color = Color.white;
                resume.color = avansRed;
            }
            else if (Input.GetAxis(vertical) < 0)
            {
                currentSelected = exit;
                resume.color = Color.white;
                exit.color = avansRed;
            }
            else if (Input.GetButtonDown(ButtonA))
            {
                if(currentSelected == resume)
                {
                    Resume();
                }
                else if(currentSelected == exit)
                {
                    Exit();
                }
            }
        }
        else
        {
            // start button
            if (Input.GetButtonDown(start))
            {
                if (paused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    private void Resume()
    {
        paused = false;
        Time.timeScale = 1f;
        menu.enabled = false;
    }

    private void Pause()
    {
        paused = true;
        Time.timeScale = 0f;
        menu.enabled = true;
    }

    private void Exit()
    {
        Resume();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
