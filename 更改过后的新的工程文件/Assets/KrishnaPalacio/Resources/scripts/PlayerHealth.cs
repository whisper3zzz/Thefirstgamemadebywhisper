using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;  // 最大生命值  
    public int currentHealth;  // 当前生命值  

    public Animator animator;  // 动画控制器  

    void Start()
    {
        currentHealth = maxHealth;//
        animator = GetComponent<Animator>();//获取动画组件
    }

    public void TakeDamage(int damageAmount)//
    {
        currentHealth -= damageAmount; //减去伤害值

        if (currentHealth <= 0)//死亡
        {
            Die();
            Destroy(gameObject);
        }
    }
    public void Heal(int healAmount)//(治疗逻辑，暂时没用)
    {
        currentHealth += healAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    void Die()
    {
        // 玩家死亡逻辑，播放死亡动画、重生等  
        animator.SetTrigger("Die");  // 调用死亡动画  
        Debug.Log("Player died!");
    }

}