using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpbar : MonoBehaviour
{
    public Slider hpbars;
    public Gradient color;
    public Image fill;
    public void maxhp(int hp)
    {
        hpbars.maxValue = hp;  // 최대 플레이어 hp 를 hpbar슬라이더에 값을 표현해줌
        hpbars.value = hp;
        fill.color = color.Evaluate(1f);
    }

    public void healthvalue(int hp)
    {
        hpbars.value = hp; // 현재 플레이어 hp 를 hpbar슬라이더에 값을 표현해줌
        fill.color = color.Evaluate(hpbars.normalizedValue);
    }
    // Start is called before the first frame update
    
}
