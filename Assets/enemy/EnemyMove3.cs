using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMove3 : MonoBehaviour
{
    Tween tween;
    public Rigidbody2D rb;




    // Start is called before the first frame update
    void Start()
    {
        PlayMoveTween();
    }

    // Update is called once per frame
    void PlayMoveTween()
    {
        Sequence sequence = DOTween.Sequence();
        
        rb = GetComponent<Rigidbody2D>();
        float[] x = { -6, -5, -3, 3, 5, 6 };
        float x2 = x.Random();


        Vector3 force = new Vector3(x2,0f,0f);
        rb.AddForce(force, ForceMode2D.Impulse);
        

        // ループの終わりにまたこのメソッドを呼ぶように指定
        sequence.OnComplete(PlayMoveTween).SetDelay(2);


        if(x2<=0)
        {
            transform.localScale = new Vector3(0.4f, 0.4f, 0.5f);
        }
        else
        {
            transform.localScale = new Vector3(-0.4f, 0.4f, 0.5f);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        this.tween.Kill();
    }



}
