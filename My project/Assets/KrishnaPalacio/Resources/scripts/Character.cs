using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Character : MonoBehaviour
{
    public Bloodstrip Bloodstrip;
    [Header("基本属性")]

    public int maxHealth;
    
    public int currentHealth;
    



    [Header("受伤无敌")]
    public float invulnerableDuration;
    public float invulnerableCounter;
    public bool invulnerable;

    public UnityEvent<Character> OnHealthChange;
    public UnityEvent<Transform> OnTakeDamage;
    public UnityEvent Ondie;



   

    private void Awake()
    {
        currentHealth = maxHealth;
       
    }
    public void Update()
    {
        
        if (invulnerable) 
        {
            invulnerableCounter -= Time.deltaTime;
            if (invulnerableCounter <= 0)
            {
                invulnerable = false;
               
            }
        }

    }
    public void TakeDamage(Attack attacker)
    {
        if (invulnerable)
        
            return;
        // Debug.Log(attacker.damage);
        if (currentHealth - attacker.damage > 0)//为了不让血条变成负数
        {
            currentHealth -= attacker.damage;
            Triggerinvulnerable();//执行受伤
            OnTakeDamage?.Invoke(attacker.transform);
            Bloodstrip?.setBloodstrip(currentHealth);//更新
        }
        else
        {
            currentHealth = 0;//死亡
            
            Ondie?.Invoke();
            

        }
       


    }
    
    //受伤无敌，是为了防止大量判断碰撞造成的迅速扣血
    private void Triggerinvulnerable()
    {
        if (!invulnerable)
        {
            invulnerable = true;
            invulnerableCounter = invulnerableDuration;

        }

    }



}
