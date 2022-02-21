using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> weaponList;
    public List<GameObject> EnemyList;
    public List<Transform> weaponSpawnPos;

    void Start()
    {
        //TODO: Select Weapon Spawn Position/ Randomly Spawn/ Coroutine.
        Instantiate(weaponList[0],transform.position, weaponList[0].transform.rotation);
        Instantiate(weaponList[1], new Vector3(5,5,1), weaponList[1].transform.rotation);
        Instantiate(weaponList[2], new Vector3(-5, 5, 1), weaponList[2].transform.rotation);
        //Instantiate(weaponList[0]);
        //Instantiate(weaponList[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
