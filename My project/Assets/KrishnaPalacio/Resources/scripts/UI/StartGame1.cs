using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame1 : MonoBehaviour
{
    //开始界面
    public void Jump()
    {
        SceneManager.LoadScene("start");
    }
}
