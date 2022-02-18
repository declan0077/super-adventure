using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //What the camera follows
    public Transform Player;
    public Transform Enemy;
    public float distance;

    // Update is called once per frame fixed
    void FixedUpdate()
    {
        distance = Vector3.Distance(Player.transform.position, Enemy.transform.position);
        transform.position = new Vector3(distance,0, -0.8399999f);
    }
}
