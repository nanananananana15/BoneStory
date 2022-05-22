using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : Unit
{
    //GameOverのパネル
    public GameObject Panel;

        public override void Damage(float power)
    {
        HPGauge.GaugeReduction(power);
        life -= power;

        EnemyPower = power;

        
        //ヒットポイントを-1
        //Hpプロパティにより、HPが0になると自動的にDead()が呼ばれる（※BaseCharacterController参照）
        if(life > 0)
        {
         StartCoroutine("DamageTimer");
        }
        else if (life <= 0)
        {
          animator.SetTrigger("Dead");
          Panel.SetActive(true);
            Invoke("Return",3.0f);
            life = 0;
        }
    }


    void Return()
    {
    SceneManager.LoadScene("Tittle");
    }

}
