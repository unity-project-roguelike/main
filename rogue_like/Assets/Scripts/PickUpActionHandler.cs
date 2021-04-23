using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpActionHandler : MonoBehaviour
{
    public GameObject weaponPrefab;

    private WeaponHolderController weaponHolder;


    void Start()
    {
        weaponHolder = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponHolderController>();
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject[] weapons = weaponHolder.GetWeapons();
        Debug.Log("collide");

        if(collider.CompareTag("Player"))
        {
            for (int i = 0; i < weaponHolder.totalWeaponCount; i++)
            {
                if(weapons[i] == null)
                {
                    weapons[i] = weaponPrefab;
                    Instantiate(weaponPrefab, weaponHolder.transform.position, Quaternion.identity);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }


    void Update()
    {
        
    }
}
