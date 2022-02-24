using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Enemy0,Enemy1,Enemy2;
    public int xpos;
    public int ypos;
    public int enemyCount;
    void Start()
    {
        StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartWave() {
        Debug.Log("Start Wave");
        EnemyCreate();

    }

    void EnemyCreate(){
        while(enemyCount < 3){
            xpos = Random.Range(-17,18);
            ypos = Random.Range(-9,10);
            Instantiate(Enemy0, new Vector3(xpos,ypos,0), Enemy0.transform.rotation);
            enemyCount +=1;
        }
    }
}
