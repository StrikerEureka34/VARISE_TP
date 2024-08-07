using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Enemy : MonoBehaviour
{
    public GameObject bulletSpawn1;
    public GameObject bulletSpawn2;
    public GameObject barrel1;
    public GameObject barrel2;
    public float shotTimer1;
    public float shotTimer2;

    [Header("Sight values")]
    public float sightDistance = 200f;
    public float distance = 100f;
    public float fieldOfView = 100f;
    public Vector3 targetDirection;
}
