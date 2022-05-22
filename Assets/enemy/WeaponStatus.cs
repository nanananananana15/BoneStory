using UnityEngine;
using System.Collections;
 
public class WeaponStatus : MonoBehaviour {
 
    public enum WeaponType {
        Hand,
        Sword,
        Other
    }
 
    [SerializeField]
    private int attackPower;
    [SerializeField]
    private int shotPower;
    [SerializeField]
    private WeaponType weaponType;
    [SerializeField]
    private float weaponRange;
 
    public int GetAttackPower() {
        return attackPower;
    }
 
    public int GetShotPower() {
        return shotPower;
    }
 
    public WeaponType GetWeaponType() {
        return weaponType;
    }
 
    public float GetWeaponRange() {
        return weaponRange;
    }
}