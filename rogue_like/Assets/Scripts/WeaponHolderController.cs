using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolderController : MonoBehaviour
{

    public int totalWeaponCount = 2;
    public GameObject weaponHolder;

    private int currentWeaponIndex;
    /*private*/ public GameObject[] weapons;    
    private GameObject equippedWeapon;


    // Start is called before the first frame update
    void Start()
    {
        weapons = new GameObject[totalWeaponCount];
        currentWeaponIndex = 0;

        for(int i = 0; i  < totalWeaponCount; i++)
        {
            weapons[i] = weaponHolder.transform.GetChild(i).gameObject;
            weapons[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeaponIndex = 0;
            equippedWeapon = weapons[currentWeaponIndex];     
            DeactivateOtherWeapons(currentWeaponIndex);
            weapons[currentWeaponIndex].SetActive(true);        
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeaponIndex = 1;
            equippedWeapon = weapons[currentWeaponIndex]; 
            DeactivateOtherWeapons(currentWeaponIndex);
            weapons[currentWeaponIndex].SetActive(true); 
        }        
    }


    private void DeactivateOtherWeapons(int currentIndex)
    {
        for(int i = 0; i  < totalWeaponCount; i++)
        {
            if( i != currentIndex)
            {
                if(weapons[i] != null)
                {
                    weapons[i].SetActive(false);
                }
                
            }
        }
    }


    public GameObject[] GetWeapons()
    {
        return weapons;
    }
}
