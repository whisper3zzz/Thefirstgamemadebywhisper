using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;
    public int attackPower;
    public int attackRate;

    private void OnTriggerStay2D(Collider2D other)//
    {
        other.GetComponent<Character>()?.TakeDamage(this);//加“？”是为了判断目标身上有没有Character这个代码，防止出现大量报错信息
    }
}
