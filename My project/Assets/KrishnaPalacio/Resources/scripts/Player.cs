using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class Player : MonoBehaviour
{
    Rigidbody2D rb;//创建实例rb
    Vector2 moveinput;//表示移动方向的二维向量
    public float movespeed;//浮点属性的速度
    Animator animator;//创建对象用于调用动画
    SpriteRenderer spriteRenderer;

    public float HurtForce;
    public bool isHurt;
    public bool isDead;
    private void Awake()//在start之前开始运行
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
    }
    
    private void OnMove(InputValue value)//生成方法OnMove，接受一个名为value的InputValue类型的参数
    {
        //判断是否调用移动动画
        moveinput = value.Get<Vector2>();
        if (moveinput == Vector2.zero)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
            //翻转形象
            if (moveinput.x > 0)
            {
                spriteRenderer.flipX = false;
               
               
            }
            if (moveinput.x < 0)
            {
                spriteRenderer.flipX = true;
               
            }

        }
    }
    void OnFire()
    {

        animator.SetTrigger("swordAttack");
    }
    private void Update()//移动
    {
        if(!isHurt)
        rb.AddForce(moveinput * movespeed);
    }
   
    public void PlayerHurt()
    {
        animator.SetTrigger("Hurt");
    }
    public void GetHurt(Transform attcker)

    {
        isHurt = true;
        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2((transform.position.x - attcker.position.x), 0).normalized;
        rb.AddForce(dir * HurtForce, ForceMode2D.Impulse);

    }

    public void PlayDead()//死亡方法
    {
        isDead = true;
        animator.SetBool("isDead", true);
        StartCoroutine(WaitAndDestroy());
    }
    //// 定义一个名为 WaitAndDestroy 的协程方法  
    IEnumerator WaitAndDestroy()
    {
        // WaitForSeconds 是一个 Unity 的内置协程，用于等待指定的时间（以秒为单位）
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
