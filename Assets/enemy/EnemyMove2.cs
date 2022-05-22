using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMove2 : MonoBehaviour
{
    Tween tween;
    
    // 開始時
    void Start()
    {
        PlayMoveTween();
    }

    // Tweenの再生
    void PlayMoveTween()
    {
        Sequence sequence = DOTween.Sequence();

        // 移動時間
        float duration = 1.0f;

        // 移動値
        Vector3 addValue = new Vector3(Random.Range(-2f, 2f), 0f, 0f);
        Vector2 endPos = transform.position + addValue;
        endPos = ClampInScreen(endPos);

        // Tweenの作成
        sequence.Append(gameObject.GetComponent<Rigidbody2D>().DOMove(endPos, duration));

        // イーズタイプの指定
        sequence.SetEase(Ease.Linear);

        // ループの終わりにまたこのメソッドを呼ぶように指定
        sequence.OnComplete(PlayMoveTween);

        // 再生
        sequence.Play();
        
        //再生速度
        Time.timeScale = 0.5f;
    }

    Vector2 ClampInScreen(Vector2 objectPos)
    {


        objectPos.x = Mathf.Clamp(objectPos.x, -2.0f, 5.0f);
        

        return objectPos;
    }

    void OnCollisionEnter(Collision collision)
    {
        this.tween.Kill();
    }
}
