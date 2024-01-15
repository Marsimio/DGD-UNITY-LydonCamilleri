using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemySO : ScriptableObject
{
    public GameObject enemyprefab;
    public int damage;
    public int hp;
    public int firerate;
    public GameObject projectile;
}