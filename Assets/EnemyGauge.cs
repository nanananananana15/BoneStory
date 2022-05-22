using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class EnemyGauge : MonoBehaviour
{
    [SerializeField]
    private Image GreenGauge;
    [SerializeField]
    private Image RedGauge;
 
    public ArborEnemyDamage zombie;
    private Tween redGaugeTween;
 
    public void GaugeReduction(float reducationValue, float time = 3f)
    {
        var valueFrom = zombie.life / zombie.maxLife;
        var valueTo = (zombie.life - reducationValue) / zombie.maxLife;
 
        // 緑ゲージ減少
        GreenGauge.fillAmount = valueTo;
 
        if (redGaugeTween != null) {
            redGaugeTween.Kill();
        }
 
        // 赤ゲージ減少
        redGaugeTween = DOTween.To(
            () => valueFrom,
            x => {
                RedGauge.fillAmount = x;
            },
            valueTo,
            time
        );
    }

}