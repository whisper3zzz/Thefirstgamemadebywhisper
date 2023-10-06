using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscActivator : MonoBehaviour
{
    public GameObject gameObjectToActivate; // 要激活的GameObject
    public GameObject FUN;
    [SerializeField] private bool menuKeys = true;
    [SerializeField] private AudioSource bgmsound;//背景音乐
    [SerializeField] private AudioSource BGM;

    void Update()
    {
        if (menuKeys)
        {
            // 检查是否按下了Esc键
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // 激活GameObject
                gameObjectToActivate.SetActive(true);
                menuKeys = false;
                Time.timeScale = (0);//时间暂停
                bgmsound.Pause();//音乐暂停

            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObjectToActivate.SetActive(false);
            menuKeys = true;
            Time.timeScale = (1);//时间恢复正常
            bgmsound.Play();//音乐继续
            BGM.Pause();
        }
    }
    //按钮方法
    public void Return()
    {
        gameObjectToActivate.SetActive(false);
        menuKeys = true;
        Time.timeScale = (1);//时间恢复正常
        bgmsound.Play();//音乐继续
        BGM.Pause();
    }
    public void ReStart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = (1);//时间恢复正常
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Funegg()
    {
        FUN.SetActive(true);
        BGM.Play();
    }
}
