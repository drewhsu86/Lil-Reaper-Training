using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsDamage : MonoBehaviour
{
    [SerializeField] float dmg = 100f;
    [SerializeField] float bounceSelf = 1.0f;
    [SerializeField] float bounceTarget = 1.0f;

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Enemy") {
            collider.GetComponent<EnemyHealth>().Damage(dmg);
            Bounce.bounce(transform, collider.transform, bounceSelf, bounceTarget);
        }
    }
}
