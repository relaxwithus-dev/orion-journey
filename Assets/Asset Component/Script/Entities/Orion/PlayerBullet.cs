using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    // private billy billy;
    private GameObject billyBoss;

    public ParticleSystem VFX;

    void Awake(){
        
        // billyBoss = GameObject.Find("Billy");
        // billy = billyBoss.GetComponent<billy>();
        
    }

    void OnTriggerEnter2D(Collider2D other){
        switch(other.gameObject.tag){
            case "Platform" :
                Destroy(gameObject);
                break;
            case "Boss" :
                Destroy(gameObject);
                break;
            case "Boss2" :
                // billy.TakingDamage();
                //boss2...
                //boss3...
                Destroy(gameObject);
                break;
            case "box":
                Destroy(other.gameObject);
                Destroy(gameObject);
                break;
            case "Boss3":
                //Destroy(gameObject);
                Debug.Log("kehit coy");
                break;
            //add enemy or others
        }

        //hit box
        // if(other.CompareTag("box"))
        // {
        //     Destroy(other.gameObject);
        //     //other.gameObject.GetComponent<Collider2D>().enabled = false;
        // }
    }

    void OnDestroy(){
        Instantiate(VFX, transform.position, Quaternion.identity);
    }

}
