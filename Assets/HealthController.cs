using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    HealthUI healthUI;
    [SerializeField] float bounceSelfDefault = 1.0f;
    [SerializeField] float bounceTargetDefault = 1.0f;
    [SerializeField] SoundController soundController;

    private float health;
    [SerializeField] float maxHealth = 100f;

    void Start()
    {
        healthUI = GameObject.FindWithTag("HealthUI").GetComponent<HealthUI>();
        health = maxHealth;
        SetHealth();
        if (soundController == null) soundController = GameObject.FindWithTag("SoundController").GetComponent<SoundController>();
    }

    private void SetHealth() {
        if (healthUI != null) healthUI.SetHealth(health/maxHealth);
    }
    
    // public method to allow other entities to damage player
    public void Damage(float dmg) {
        float newHealth = health - dmg;
        if (newHealth <= 0) {
            newHealth = 0;
            EndGame();
        }
        health = newHealth;
        SetHealth();

        // play oof sound
        soundController.playAudio(1);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Enemy") { 
            // apply damage to player
            Damage(collider.GetComponent<EnemyDamage>().dmg);

            // bounce self and player away from each other
            bounce(collider.transform);
        }
    }

    private void bounce(Transform target) {
        // direction of bounce is the vector between self and vector
        float bounceSelf = target.GetComponent<EnemyDamage>().bouncePlayer;
        float bounceTarget = target.GetComponent<EnemyDamage>().bounceSelf;
        if (bounceSelf == null) bounceSelf = bounceSelfDefault;
        if (bounceTarget == null) bounceTarget = bounceTargetDefault;

        Bounce.bounce(transform, target, bounceSelf, bounceTarget);
    }

    private void EndGame() {
        PlayerPrefs.SetString("endType", "death");
        GameObject.FindWithTag("Spawner").GetComponent<Timer>().EndGame();
    }
}
