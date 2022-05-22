using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    //左手のコライダー
    private CapsuleCollider2D handCollider;
    //木の枝のコライダー
    public CapsuleCollider2D treeCollider;
    //錆びた剣のコライダー
    public CapsuleCollider2D swordCollider;

    public Animator animator;
    public GameObject tree;
    public GameObject Sword;

    // Start is called before the first frame update
    void Start()
    {
        //左手のコライダーを取得
        handCollider = GameObject.Find("RightHand").GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        
    }

    public void OnClick()
    {
        branch();
    }

//branchは分岐という意味
    private void branch()
    {
        if(tree.activeInHierarchy == true)
        {
        this.animator.SetTrigger("slash");
        Invoke("TreeTrigger",0.3f);
        } 
        if(tree.activeInHierarchy == false && Sword.activeInHierarchy == false)
        {
        this.animator.SetTrigger("Attack");
        Invoke("PunchTrigger",0.8f);
        }
        if(Sword.activeInHierarchy == true)
        {
            this.animator.SetTrigger("slash");
            
            Invoke("SwordTrigger",0.3f);
            Debug.Log("0ok");
        }

    }

    private void TreeTrigger()
    {
        treeCollider.enabled = true;
        Invoke("TreeColliderReset",0.3f);
    }

    private void PunchTrigger()
    {
        //左手コライダーをオンにする
            handCollider.enabled = true;
        
        //一定時間後にコライダーの機能をオフにする
            Invoke("ColliderReset",0.1f);
    }

    private void SwordTrigger()
    {
        swordCollider.enabled = true;
        Invoke("SwordColliderReset",0.3f);
    }

    private void TreeColliderReset()
    {
        treeCollider.enabled = false;
    }

    private void ColliderReset()
    {
        handCollider.enabled = false;
    }

    private void SwordColliderReset()
    {
        swordCollider.enabled = false;
    }
}
