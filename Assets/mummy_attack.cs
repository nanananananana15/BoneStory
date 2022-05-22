using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mummy_attack : MonoBehaviour
{
    public Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Player"))
		{
            ani.SetTrigger("Attack");
        }
    }
}
