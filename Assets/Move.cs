using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaMove2 : MonoBehaviour
{
    //インスペクター上で速度を調整可能に
    public FixedJoystick joystick;
    [SerializeField]private float MoveSpeed;
    public float moveSpeed {
        get { return MoveSpeed; }
        set { MoveSpeed = value; }
    }

    Animator ani;

    float degStop;
    
    void Start()
    {
        ani = this.gameObject.GetComponent<Animator>(); //UnityChanについているAnimatorを取得
    }

    
    void Update()
    {

       Move();
    }

    void Move()
    {
        float x = joystick.Horizontal;
        float y = joystick.Vertical;

        transform.position += new Vector3(x/MoveSpeed,0,0);

        float rad = Mathf.Atan2(x-0, y-0); //　 原点(0,0)と点（dx,dy)の距離から角度をとってくれる便利な関数

        float deg = rad*Mathf.Rad2Deg; //radianからdegreenに変換します

        this.transform.rotation = Quaternion.Euler(0, deg,0); //Unityちゃんの向きを先ほど取得した角度に当てはめて代入します。今回はy軸方向が回転軸になります。

         if(deg!=0) //joystickの原点と(dx,dy)の２点がなす角度が０ではないとき = joystickを動かしている時
        {
            ani.SetBool("player_run",true); //wait→walkへ
            degStop = deg; //停止前のプレイヤーの向きを保存
        }
        else //joystickの原点と(dx,dy)の２点がなす角度が０の時 = joystickが止まっている時
        {
            ani.SetBool("player_run",false); //walk→waitへ
        }

    }
}
