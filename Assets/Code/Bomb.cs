using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float PhamviTacdong;
    public float force;
    public LayerMask LayerTohit;
    public GameObject HieuUngNo;
    public GameObject bomb;
    public float Speed=4;
    public GameObject ItemPrefabs;
    public float radius=1;// vi bom hinh tron
    //public bool ThrowBomb;
    //public Vector3 LauchOffSet;
    void Start()
    {
     /*if(ThrowBomb){
        var direction = -transform.right + Vector3.up;
        GetComponent<Rigidbody2D>().AddForce(direction *Speed, ForceMode2D.Impulse);
       Explore();
     }
     transform.Translate(LauchOffSet);*/
    
    }
    void Update()
    {
        
        /*if(!ThrowBomb){
            transform.position += -transform.right*Speed*Time.deltaTime;
            Explore();
            
        }*/
        BombRandom();
        Explore();
    }
   void BombRandom(){
        Vector3 randomPos=Random.insideUnitCircle*radius;
        Instantiate(ItemPrefabs, randomPos, Quaternion.identity);
   }
   private void OnDrawGizmos(){//xac dinh pham vi anh huong
        Gizmos.color=Color.green;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
    void Explore(){
        Collider2D[] objects=Physics2D.OverlapCircleAll(transform.position, PhamviTacdong, LayerTohit);
        foreach(Collider2D obj in objects){
            Vector2 direction = obj.transform.position -transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
         GameObject hieuUngNo = Instantiate(HieuUngNo, transform.position, Quaternion.identity);
         DestroyImmediate(gameObject, true);
    }
}

