using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1ClearManager : MonoBehaviour
{
    private GameObject[] enemyBox;
    public GameObject ClearPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyBox = GameObject.FindGameObjectsWithTag("Enemy");
 
        print("敵の数：" + enemyBox.Length);
 
        if(enemyBox.Length == 0)
        {
            ClearPanel.SetActive(true);
            Invoke("Return",3.0f);
        }
    }

    void Return()
    {
    SceneManager.LoadScene("Tittle");
    }
}
