using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 引入SceneManager  

public class Determine1 : MonoBehaviour
{
    Transform childTransform;
    Character childScript;
    private void Start()
    {
        childTransform = GameManager.Instance.player.transform;
    }


    void Update()
    {
       
       // Transform childTransform = transform?.Find("Player");//查找PLayer
        childScript = childTransform?.GetComponent<Character>();//获取组件，调用变量
        float health = childScript.currentHealth;
        if (health <= 0)
        {
            SceneManager.LoadScene("end");  // 当玩家血量归零时，跳转到结束场景  
        }

    }
    


              
            

}