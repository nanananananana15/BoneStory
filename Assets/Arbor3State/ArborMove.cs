using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class ArborMove : StateBehaviour {
	// Use this for initialization
	public StateLink nextState;
    public StateLink nextState2;

	public FixedJoystick joystick;
    public GameObject Chara;
    public Animator ani;
    public Rigidbody2D rb;
    bool isCliming;
    public float distance;
    public LayerMask ladderLayer;


	void Start () {
	
	}

	// Use this for awake state
	public override void OnStateAwake() {
	}

	// Use this for enter state
	public override void OnStateBegin() {
	}

	// Use this for exit state
	public override void OnStateEnd() {
	}
	
	// OnStateUpdate is called once per frame
	public override void OnStateUpdate() 
	{
		 Move();
	}

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}

	void Move()
    {
        float x1 = joystick.Horizontal;
        float y1 = joystick.Vertical;

        Vector3 tmp = GameObject.Find("Handle").transform.position;

        Chara.transform.position += new Vector3(x1/6,0,0);

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
        transform.localScale = new Vector3(scale.x,5f,5f);

        //Laddar上昇
        //上にのぼれる条件
        //・はしごがある
        //Physics2D.Raycast(どこから、どの方向に、どのくらいの距離で、対象のレイヤー);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,Vector3.up,2,ladderLayer);
        if(hitInfo.collider !=null)
        {
            Debug.Log("のぼれるよ");
            if(y1>0)
            {
                isCliming = true;
                
            }
        }
        else
        {
            Debug.Log("のぼれない；；");
            isCliming = false;
        }
        //・Handleが上を向いている
        // if　上に登れるなら
            //上にのぼる
        if(isCliming == true)
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
