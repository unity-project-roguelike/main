using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{

    public GameObject hitEffect;
    

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Obstacle")
        {
            hitEffectPlay();
        }
    }


    void OnTriggerExit2D()
    {
        Destroy(gameObject);
    }


    void hitEffectPlay()
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        effect.GetComponent<ParticleSystem>().Play();
        Destroy(effect, 5f);
    }


}
