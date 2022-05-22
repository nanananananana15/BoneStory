using UnityEngine;

public partial class Player
{

    public class StateDamage : PlayerStateBase
    {
    // Start is called before the first frame update
    public override void OnEnter(Player owner, PlayerStateBase prevState)
    {
        Damage(1);
          Debug.Log("ダメージを受ける");
    }

    void Start()
    {
        Damage(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damage(float power)
    {
        HPGauge.GaugeReduction(power);
        life -= power;
        EnemyPower = power;
    }
    }
}
