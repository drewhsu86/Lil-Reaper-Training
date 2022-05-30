using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpd = 1f;
    [SerializeField] float orbitRadius = 2f;
    [SerializeField] Transform hand1;
    [SerializeField] Transform hand2;
    [SerializeField] float orbitThreshold = 0.1f;
    private bool faceRight = true;
    private float pi = 3.141592f;
    SpriteRenderer playerSprite;
    [SerializeField] Transform upLeftLimit;
    [SerializeField] Transform downRightLimit;
    
    void Start() {
        playerSprite = GetComponent<SpriteRenderer>();
        hand1.position = transform.position + new Vector3(orbitRadius, 0, 0);
        hand2.position = transform.position + new Vector3(-orbitRadius, 0, 0);
    }

    void Update() {
        Movement();
        SetSprite();
    }

    private void Movement() {
        float horz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector2 moveVector = new Vector2(horz, vert);
        moveVector.Normalize();
        OrbitHands(moveVector);

        moveVector *= Time.deltaTime * moveSpd;

        // do nothing if moveVector.x == 0 for direction
        if (moveVector.x > 0) faceRight = true;
        else if (moveVector.x < 0) faceRight = false; 

        // if we have borders, respect the borders
        Vector3 newPosition = transform.position + new Vector3(moveVector.x, moveVector.y, 0);

        if (upLeftLimit != null) {
            if (newPosition.x < upLeftLimit.position.x) newPosition.x = upLeftLimit.position.x;
            if (newPosition.y > upLeftLimit.position.y) newPosition.y = upLeftLimit.position.y;
        }
        if (downRightLimit != null) {
            if (newPosition.x > downRightLimit.position.x) newPosition.x = downRightLimit.position.x;
            if (newPosition.y < downRightLimit.position.y) newPosition.y = downRightLimit.position.y;
        }

        transform.position = newPosition;
    }

    private void SetSprite() {
        if (faceRight) {
            playerSprite.flipX = false;
        } else {
            playerSprite.flipX = true;
        }
    }

    // allow hands/weapons to orbit player based on direction 
    private void OrbitHands(Vector2 primaryDirection) {
        if (primaryDirection.magnitude <= orbitThreshold) return;

        primaryDirection.Normalize();
        primaryDirection *= orbitRadius;
        Vector2 secondaryDirection = -primaryDirection;

        OrbitAndRotate(hand1, primaryDirection);
        OrbitAndRotate(hand2, secondaryDirection);
    }

    // make sure the sprite of the weapon rotates with the angle of rotation
    private void OrbitAndRotate(Transform hand, Vector2 direction) {
        float x = direction.x;
        float y = direction.y;
        hand.position = transform.position + new Vector3(x, y ,0);
        hand.rotation = Quaternion.Euler(0, 0, (180/pi) * Mathf.Atan2(y, x));
        FlipHands(hand);
    }

    // flip sprites to keep them upright when rotating around 
    private void FlipHands(Transform hand) {
        if (faceRight) hand.GetComponent<SpriteRenderer>().flipY = false;
        else hand.GetComponent<SpriteRenderer>().flipY = true;
    }
}
