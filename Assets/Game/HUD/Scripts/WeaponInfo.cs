using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DLSU.SpacePirates.WeaponSystem;


public class WeaponInfo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public WeaponEquipment weaponequipment;
    
    [SerializeField]
    public Image Weapon;
    
    [SerializeField]
    public TextMeshProUGUI Ammo;
    
    void Start()
    {
        Weapon.sprite = weaponequipment.EquippedWeapon.Sprite;
        Ammo.text = weaponequipment.ammo.ToString();
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}

