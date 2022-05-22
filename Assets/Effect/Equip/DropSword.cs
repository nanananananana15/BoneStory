using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSword : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public GameObject Equip;

    public Fungus.Flowchart flowchart = null;
    [SerializeField]string Message = "sword";

    
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
            flowchart.SendFungusMessage(Message);
            Equip.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}