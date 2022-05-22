using UnityEngine;
using System.Collections;
using UnityEngine.UI;
 
public class DamageUI : MonoBehaviour {
    private GameObject BoneChara;
	public Text damageText;
    float alpha;

    [SerializeField, Tooltip("親")]
    Transform parent = null;
    [SerializeField, Tooltip("子")]
    Transform child = null;


    void Start ()
    {
        child.SetParent(parent);


        GameObject BoneChara = GameObject.Find("キャラクター");

        float GetDamage = Player.EnemyPower;
        string TakeDamage = GetDamage.ToString();
        damageText.text = string.Format("-" + TakeDamage);
    }
    
    

    void LateUpdate()
    {    
		transform.rotation = Camera.main.transform.rotation;
		
 
        
        //　テキストのcolorを設定
        
        
            Destroy(gameObject,1.0f);
        
    }
}    
