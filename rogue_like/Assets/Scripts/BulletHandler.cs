using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{

    public GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        hitEffectPlay();
    }


    void hitEffectPlay()
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        hitEffect.GetComponent<ParticleSystem>().Play();
        Destroy(hitEffect, 5f);
        Destroy(gameObject);

    }


}
