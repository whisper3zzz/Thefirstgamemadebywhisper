using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bloodstrip : MonoBehaviour
{
    public Slider sli;
    public void setMaxHealth(int health)
    {
        sli.maxValue = health;//让血条从最大开始
        sli.value = health;

    }

    public void setBloodstrip(int health)
    {

        sli.value = health;

    }
    



}
