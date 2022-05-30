using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float minOpacity = 0.5f;
    [SerializeField] int enemyScore = 1;
    [SerializeField] SoundController soundController;

    void Start() {
        health = maxHealth;
        if (soundController == null) soundController = GameObject.FindWithTag("SoundController").GetComponent<SoundController>();
    }

    public void Damage(float dmg) {
        health -= dmg;
        if (health <= 0) {
            Die();
        }
        // reduce the sprite's opacity as a result of taking damage
        float newOpacity = ((health/maxHealth) * (1f - minOpacity)) + minOpacity;
        Color color = GetComponent<SpriteRenderer>().color;
        color.a = newOpacity;
        GetComponent<SpriteRenderer>().color = color;

        // play a sound
        soundController.playAudio(0);

    }

    private void Die() {
        GameObject.FindWithTag("Spawner").GetComponent<Score>().AddToScore(enemyScore);
        Destroy(gameObject);
    }
}
