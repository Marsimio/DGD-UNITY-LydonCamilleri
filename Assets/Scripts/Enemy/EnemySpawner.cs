using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<EnemySO> enemyList = new List<EnemySO>();
    private int Difficulty;

    void Start()
    {
        Difficulty = GameManager.Instance.Difficulty; //fetches difficulty from GameManager
        SpawnEnemies();
    }

    public void SpawnEnemies()
    {
        Vector3 roomPos = gameObject.transform.position;
        int numSpawns;
        if (gameObject.name == "Entry")
        {
            numSpawns = 4;
        }
        else 
        {
            numSpawns = Random.Range(1, Difficulty + 1);
        }
        
        Debug.Log("Spawning Goons " + numSpawns);

        for (int x = 0; x < numSpawns; x++)
        {

            int enemyChoice = Random.Range(0, enemyList.Count);
            GameData.enemyCount += 1;
            GameManager.Instance.SetTotalEnemies(GameData.enemyCount); //adds enemy to total amount
            Vector3 enemypos = new Vector3(Random.Range(roomPos.x - 2, roomPos.x + 5), Random.Range(roomPos.y - 5, roomPos.y + 2), 0);
            GameObject enemyInstance = Instantiate(enemyList[enemyChoice].enemyprefab, enemypos, Quaternion.identity);
            enemyInstance.GetComponent<Enemy>().start_hitpoints = enemyList[enemyChoice].hp;
            enemyInstance.GetComponent<Enemy>().start_strength = enemyList[enemyChoice].damage;
            enemyInstance.GetComponent<Enemy>().start_firerate = enemyList[enemyChoice].firerate;
            enemyInstance.GetComponent<Enemy>().start_projectile = enemyList[enemyChoice].projectile;
        }
    }

}