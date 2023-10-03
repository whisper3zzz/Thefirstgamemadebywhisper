using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscActivator : MonoBehaviour
{
    public GameObject gameObjectToActivate; // Ҫ�����GameObject
    public GameObject FUN;
    [SerializeField] private bool menuKeys = true;
    [SerializeField] private AudioSource bgmsound;//��������
    [SerializeField] private AudioSource BGM;

    void Update()
    {
        if (menuKeys)
        {
            // ����Ƿ�����Esc��
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // ����GameObject
                gameObjectToActivate.SetActive(true);
                menuKeys = false;
                Time.timeScale = (0);//ʱ����ͣ
                bgmsound.Pause();//������ͣ

            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObjectToActivate.SetActive(false);
            menuKeys = true;
            Time.timeScale = (1);//ʱ��ָ�����
            bgmsound.Play();//���ּ���
            BGM.Pause();
        }
    }
    //��ť����
    public void Return()
    {
        gameObjectToActivate.SetActive(false);
        menuKeys = true;
        Time.timeScale = (1);//ʱ��ָ�����
        bgmsound.Play();//���ּ���
        BGM.Pause();
    }
    public void ReStart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = (1);//ʱ��ָ�����
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
