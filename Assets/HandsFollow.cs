using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsFollow : MonoBehaviour
{
    [SerializeField] Transform player;

    void Start()
    {
        if (player == null) player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null) transform.position = player.position;
    }
}
