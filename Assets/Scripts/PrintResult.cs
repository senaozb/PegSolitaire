using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PrintResult : MonoBehaviour
{
    public Text res;
    public Button button1;
    public Button button2;

    //Add buttons onto the result scene and add listeners to them
    void Start()
    {
        printRes();
        Button btn1 = button1.GetComponent<Button>();
        Button btn2 = button2.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick1);
        btn2.onClick.AddListener(TaskOnClick2);

    }

    void printRes()
    {
        if (CheckGame.result == 1)
            res.text = "Final Score: 1. You won!";
        else
            res.text = "Final Score: " + CheckGame.result;
    }

    void TaskOnClick1()
    {
        SceneManager.LoadScene("Input", LoadSceneMode.Single);
    }
    void TaskOnClick2()
    {
        Application.Quit();
    }
}
