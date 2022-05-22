using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
 
public class PlayerGauge : MonoBehaviour
{
    [SerializeField]
    private Image GreenGauge;
    [SerializeField]
    private Image RedGauge;

    public ArborDamage AD;
 

    private Tween redGaugeTween;
 
    public void GaugeReduction(float reducationValue, float time = 3f)
    {
        var valueFrom = AD.life / AD.maxLife;
        var valueTo = (AD.life - reducationValue) / AD.maxLife;
        
         
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
 
    public void SetPlayer(ArborDamage AD)
    {
        this.AD = AD;
    }
}