using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public float moveSpeed = 5.0f;  // 移动速度  
    public float attackRange = 10.0f;  // 攻击范围      
    public float attackCooldown = 1.0f;  // 攻击冷却时间  
    private Transform Player;  // 目标玩家  
    private Transform Orc;  // 自身怪物  
    private float timer;  // 计时器  
    private bool isAttacking;  // 是否正在攻击  
    SpriteRenderer spriteRenderer;
    public float Sight = 10.0f;
    public bool isDead;
    public bool isHurt;
  
    

    Animator animator;//创建对象用于调用动画
    void Start()
    {
        Player = GameManager.Instance.player.transform;
        spriteRenderer = GetComponent<SpriteRenderer>();//自动水平翻转形象
        Orc = transform;//将transform属性赋值给变量myTransform
        //Player = GameObject.FindGameObjectWithTag("Player").transform;//寻找玩家
        isAttacking = false;
         animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        
        Vector3 direction;
        if (Player != null && Orc != null)
        {
            direction = Player.position - Orc.position;
        }
        else
        {
            // 如果 Player 或 Orc 已经被销毁，那么就不执行这个计算步骤
            direction = Vector3.zero;
            
        }
        // 移动到目标玩家位置  
        
        
            float step = moveSpeed * Time.deltaTime; //计算移动距离
            Orc.position += direction.normalized * step;//实现移动
        
        // 判断是否在攻击范围内，并且攻击冷却时间到达，则进行攻击  
        if (Player != null)
        {


            if (Vector3.Distance(Orc.position, Player.position) <= attackRange && !isAttacking && timer <= 0.0f && Player != null)//三个判断条件：距离、攻击状态、计时器
            {
                Attack();  // 攻击玩家  

                timer = attackCooldown;  // 重置计时器  
                isAttacking = true;
            }
            else if (isAttacking)
            {
                timer -= Time.deltaTime;  // 计时器递减，等待攻击冷却时间到达  
                if (timer <= 0.0f)
                {
                    isAttacking = false;
                }
            }
        }
        //执行翻转形象的具体代码
        if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    void Attack()  // 攻击函数，包括调用攻击动画和攻击逻辑  
    {
        // 调用攻击动画，播放怪物的攻击动作  
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("Attack");                   

    }
    public void Hurt()
    {
        animator.SetTrigger("Hurt");
    }
    
    public void Dead()
    {
        isDead = true;
        animator.SetBool("isDead", true);
        StartCoroutine(WaitAndDestroy());
    }
    IEnumerator WaitAndDestroy()
    {
        // We are assuming the animation clip length is 1 second. Adjust accordingly.  
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}