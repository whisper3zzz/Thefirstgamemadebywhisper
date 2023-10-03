using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MonsterHealth : MonoBehaviour
{
    Animator animator;
    public float health;
    private void Awake()//在start之前开始运行currenthealth
    {
        animator = GetComponent<Animator>();
        Character currenthealth = GetComponent<Character>();
        
    }
    public void Update()
    {
        if (health < 0)
        {
            // 播放死亡动画  
            animator.SetTrigger("Die");

            // 停止怪物的其他行为  
            enabled = false;
        }

    }


   
}
