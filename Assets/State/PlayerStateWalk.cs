using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    

    public class StateWalk : PlayerStateBase
    {
            //walk用変数///
    public FixedJoystick joystick;
    public GameObject Chara;

    Animator ani;
    Rigidbody2D rb;

    bool isCliming;
    public float distance;
    public LayerMask ladderLayer;


    public override void OnUpdate(Player owner) 
    {
        Move();

    }

        void Move()
    {
        float x1 = joystick.Horizontal;
        float y1 = joystick.Vertical;

        Vector3 tmp = GameObject.Find("Handle").transform.position;

        Chara.transform.position += new Vector3(x1/10,0,0);

        // キャラクターの大きさ。負数にすると反転される
        Vector3 scale = Chara.transform.localScale;

         if(x1!=0) //joystickを動かしている時
        {
            ani.SetBool("run",true); 
        }
        else //joystickが止まっている時
        {
            ani.SetBool("run",false);
        }

        if(x1 == 0)
        {
            return;
        }

        if(x1 > 0)
        {
            scale.x = 5f;
            Debug.Log("右向いてる");
        }

        if(x1 < 0)
        {
            scale.x = -5f;
            Debug.Log("左向いてる");
        }
        
        // プレイヤーのカタチを更新
        Chara.transform.localScale = new Vector3(scale.x,5f,5f);

        //Laddar上昇
        //上にのぼれる条件
        //・はしごがある
        //Physics2D.Raycast(どこから、どの方向に、どのくらいの距離で、対象のレイヤー);
        RaycastHit2D hitInfo = Physics2D.Raycast(Chara.transform.position,Vector3.up,2,ladderLayer);
        if(hitInfo.collider !=null)
        {
            if(y1>0)
            {
                isCliming = true;
            }
        }
        else
        {
            isCliming = false;
        }
        //・Handleが上を向いている
        // if　上に登れるなら
            //上にのぼる
        if(isCliming)
        {
            Chara.transform.position += new Vector3(0,y1/10,0);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 3;
        }

    }

}
}
