using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetInput2 : MonoBehaviour
{
    public Button Button1;
    public Button Button2;

    // Start is called before the first frame update
    void Start()
    {
        Button btn1 = Button1.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick1);
        Button btn2 = Button2.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClick2);
    }

    void TaskOnClick1()
    {
        CreateBoard.gameType = 1;
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
    void TaskOnClick2()
    {
        CreateBoard.gameType = 2;
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
