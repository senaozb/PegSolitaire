using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetInput : MonoBehaviour
{
    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;
    public Button Button5;
    public Button Button6;
    public Button Button7;

    // Adds buttons onto the input scene and add listeners to them
    void Start()
    {
        Button btn1 = Button1.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick1);
        Button btn2 = Button2.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClick2);
        Button btn3 = Button3.GetComponent<Button>();
        btn3.onClick.AddListener(TaskOnClick3);
        Button btn4 = Button4.GetComponent<Button>();
        btn4.onClick.AddListener(TaskOnClick4);
        Button btn5 = Button5.GetComponent<Button>();
        btn5.onClick.AddListener(TaskOnClick5);
        Button btn6 = Button6.GetComponent<Button>();
        btn6.onClick.AddListener(TaskOnClick6);
        Button btn7 = Button7.GetComponent<Button>();
        btn7.onClick.AddListener(TaskOnClick7);

    }

    void TaskOnClick1()
    {
        CreateBoard.chosenType = 1;
        SceneManager.LoadScene("Input2", LoadSceneMode.Single);
    }
    void TaskOnClick2()
    {
        CreateBoard.chosenType = 2;
        SceneManager.LoadScene("Input2", LoadSceneMode.Single);
    }
    void TaskOnClick3()
    {
        CreateBoard.chosenType = 3;
        SceneManager.LoadScene("Input2", LoadSceneMode.Single);
    }
    void TaskOnClick4()
    {
        CreateBoard.chosenType = 4;
        SceneManager.LoadScene("Input2", LoadSceneMode.Single);
    }
    void TaskOnClick5()
    {
        CreateBoard.chosenType = 5;
        SceneManager.LoadScene("Input2", LoadSceneMode.Single);
    }
    void TaskOnClick6()
    {
        FileOp.ReadFile();
        SceneManager.LoadScene("Input2", LoadSceneMode.Single);
    }
    void TaskOnClick7()
    {
        Application.Quit();
    }
}
