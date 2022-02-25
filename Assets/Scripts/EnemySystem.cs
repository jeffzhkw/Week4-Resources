using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Enemy0,Enemy1,Enemy2;
    public int xpos;
    public int ypos;
    public static int enemyCount;
    public float timeBetweenWaves;
    private float timeRemaining;
    private int waveNumber = 0;
    void Start()
    {
        timeRemaining = timeBetweenWaves;
        StartWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;
        if(enemyCount < 1){
            
            timeRemaining -= Time.deltaTime;
            if(timeRemaining < 0){
                waveNumber +=1;
                waveNumber = waveNumber % 3;
                StartWave(waveNumber);
                timeRemaining = timeBetweenWaves;
            }
        }
        
    }

    void StartWave(int wave) {
        Debug.Log("Start Wave");
        switch(wave){
            case 0:
                EnemyCreate();
                break;
            case 1:
                EnemyCreate1();
                break;
            case 2:
                EnemyCreate2();
                break;
            default:
                break;
        }

    }

    void EnemyCreate(){
        while(enemyCount < 3){
            xpos = Random.Range(-17,18);
            ypos = Random.Range(-9,10);
            Instantiate(Enemy0, new Vector3(xpos,ypos,0), Enemy0.transform.rotation);
            xpos = Random.Range(-17,18);
            ypos = Random.Range(-9,10);
            Instantiate(Enemy1, new Vector3(xpos,ypos,0), Enemy1.transform.rotation);
            xpos = Random.Range(-17,18);
            ypos = Random.Range(-9,10);
            Instantiate(Enemy2, new Vector3(xpos,ypos,0), Enemy2.transform.rotation);
            enemyCount +=3;
        }
    }

    void EnemyCreate1(){
        while(enemyCount < 9){
            xpos = Random.Range(-17,18);
            ypos = Random.Range(-9,10);
            Instantiate(Enemy0, new Vector3(xpos,ypos,0), Enemy0.transform.rotation);
            xpos = Random.Range(-17,18);
            ypos = Random.Range(-9,10);
            Instantiate(Enemy1, new Vector3(xpos,ypos,0), Enemy1.transform.rotation);
            enemyCount +=3;
        }
    }
     void EnemyCreate2(){
        while(enemyCount < 4){
            xpos = Random.Range(-17,18);
            ypos = Random.Range(-9,10);
            Instantiate(Enemy2, new Vector3(xpos,ypos,0), Enemy2.transform.rotation);
            enemyCount +=1;
        }
        while(enemyCount < 2){
            xpos = Random.Range(-17,18);
            ypos = Random.Range(-9,10);
            Instantiate(Enemy1, new Vector3(xpos,ypos,0), Enemy1.transform.rotation);
            enemyCount +=1;
        }
    }
}
