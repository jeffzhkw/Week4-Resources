using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{   
    public float speed;
    public GameObject Player;
    public float ClosestDistance = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    Vector3 getDirectionToPlayer()
    {
        return (Player.transform.position - this.transform.position).normalized;
    }
    // Update is called once per frame
    void Update()
    {
        if( (Player.transform.position- this.transform.position).magnitude < ClosestDistance){
            return;
        }
        Debug.Log( Player.transform.position.magnitude - this.transform.position.magnitude);
        this.transform.position += getDirectionToPlayer()*speed;
    }
}
