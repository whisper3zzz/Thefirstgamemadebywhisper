using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckOrc : MonoBehaviour
{
    void Start()
    {
    }
    private void Update()
    {
        
    
    // ��ȡ���� "Orc" ��ǩ�� GameObject  
    GameObject orc = GameObject.FindWithTag("Orc");

        // �ж� GameObject �Ƿ�Ϊ��  
        if (orc == null)
        {
            // ���Ϊ�գ������ "end" ����  
            SceneManager.LoadScene("end");
        }
    }
}