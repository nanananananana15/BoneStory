using DG.Tweening;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Tween tween;

    public Rigidbody2D rbody2D;

    private float jumpForce = 10000f;
    private float jumpForce2 = 10000f;

    private int jumpCount = 0;
    
    // 開始時
    void Start()
    {
        
        rbody2D = GetComponent<Rigidbody2D>();
    }

    // Tweenの再生
    

    Vector2 ClampInScreen(Vector2 objectPos)
    {
        

        //移動するx座標の範囲
        objectPos.x = Mathf.Clamp(objectPos.x, 5.5f, 17.0f);
        //移動するy座標の範囲
        objectPos.y = Mathf.Clamp(objectPos.y, -4.5f, 10f);

        return objectPos;
    }



    void OnCollisionEnter2D(Collision2D other)
    {
        this.tween.Kill();
        if (this.jumpCount < 1)
        {
            
            if(other.gameObject.tag == "rock")
            {
                Debug.Log("Jump");
            rbody2D.AddForce(transform.up * jumpForce);
            rbody2D.AddForce(transform.right * jumpForce2);
            
            }
            Sequence sequence = DOTween.Sequence();

        // 移動時間
        float duration = 2.0f;

        // 移動値
        Vector3 addValue = new Vector3(Random.Range(-5f, 5f), 0f, 0f);
        Vector2 endPos = transform.position + addValue;
        endPos = ClampInScreen(endPos);

        // Tweenの作成
        sequence.Append(gameObject.GetComponent<Rigidbody2D>().DOMove(endPos, duration));

        // イーズタイプの指定
        sequence.SetEase(Ease.Linear);

        // ループの終わりにまたこのメソッドを呼ぶように指定
        

        // 再生
        sequence.Play();
        
        //再生速度
        Time.timeScale = 0.5f;

        }
        

    }

    
    
  
}