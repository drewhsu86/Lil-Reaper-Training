using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    Transform player;
    Vector2 targetLocation;
    [SerializeField] float targetTime = 1.0f;
    float timer;
    [SerializeField] float moveSpd = 1.0f;
    SpriteRenderer sprite;
    [SerializeField] float distToDestThreshold = 0.1f;

    void Start() {
        player = GameObject.FindWithTag("Player").transform;
        targetLocation = new Vector2(player.position.x, player.position.y);
        timer = targetTime;
        sprite = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget() {
        // update the targetLocation if the timer is up
        timer -= Time.deltaTime;
      
        Vector3 moveDir = transform.position - new Vector3(targetLocation.x, targetLocation.y, 0);
        moveDir.Normalize();
        transform.position += -moveSpd * moveDir * Time.deltaTime;

        if (moveDir.x > 0) sprite.flipX = true;
        if (moveDir.x < 0) sprite.flipX = false;

        if (timer <= 0 || Vector2.Distance(targetLocation, transform.position) <= distToDestThreshold)  {
            targetLocation = new Vector2(player.position.x, player.position.y);
            timer = targetTime;
        }
    }

    public void SetChase(float spd, float tTime) {
        moveSpd = spd;
        targetTime = tTime;
    }

}
