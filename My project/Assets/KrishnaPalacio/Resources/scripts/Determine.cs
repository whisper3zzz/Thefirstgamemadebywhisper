using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 引入SceneManager  

public class Determine1 : MonoBehaviour
{
    private void Start()
    {
        
    }


    void Update()
    {
       
        Transform childTransform = transform?.Find("Player");
        Character childScript = childTransform?.GetComponent<Character>();
        float health = childScript.currentHealth;
        if (health <= 0)
        {
            SceneManager.LoadScene("end");
        }

    }
    


                // 当玩家血量归零时，跳转到结束场景  
            

}