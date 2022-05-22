using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTree : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public GameObject Tree;
    public GameObject Sword;

    public Fungus.Flowchart flowchart = null;
    [SerializeField]string Message = "tree";
    [SerializeField]string Message2 = "tree2";

    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(Sword.activeInHierarchy == false)
            {
            flowchart.SendFungusMessage(Message);
            Tree.SetActive(true);
            }
            else
            {
            flowchart.SendFungusMessage(Message2);
            }
            Destroy(this.gameObject);
        }
    }
}
