using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckOrc : MonoBehaviour
{
    void Start()
    {
    }
    private void Update()
    {
        
    
    // 获取带有 "Orc" 标签的 GameObject  
    GameObject orc = GameObject.FindWithTag("Orc");

        // 判断 GameObject 是否为空  
        if (orc == null)
        {
            // 如果为空，则加载 "end" 场景  
            SceneManager.LoadScene("end");
        }
    }
}