using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *  'CollisionTrigger' envia uma mensagem para seu 'Target'. 
 *  Uma CollisionTrigger pode ter vários 'Target'.
 *  
 **/

public class CollisionTrigger : MonoBehaviour {

    public int damage = 1;
    public Target[] target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for(int i = 0; i < target.Length; i++)
        {
            //Debug.Log("CollisionTrigger::OnTriggerEnter2D " + collision.tag);
            if (collision.isTrigger != true && collision.CompareTag(target[i].tag))
            {
                //Debug.Log("CollisionTrigger::OnTriggerEnter2D");
                collision.SendMessageUpwards(target[i].methodName, damage);
            }
        }
        
    }
}
