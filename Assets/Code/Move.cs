using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    SpriteRenderer rend;
    public float speedTime=1f;
    [SerializeField] float Speed = 0;
    [SerializeField] float RayDistant = 1;
    [SerializeField] LayerMask Mask;
    Vector2 movement = Vector2.zero;
    int score = 0;
    public int _score => score;//get not set
    Rigidbody2D rigi;
    [SerializeField] Text score_text;
    public GameObject obstacles;
   
    void Start()
    {
        rigi = this.GetComponent<Rigidbody2D>();
        score = 0;
    }
    void Update()
    {
       score_text.text = "SCORE: " + score.ToString();
    
       rigi.velocity = (Vector3)movement * Speed * Time.deltaTime;//ko có cái này là lợn ko run đc đâu, khổ
    }

    public void Moving(int D) 
    {
        Direction enumDir = (Direction)D;
        switch (enumDir)
        {
            case Direction.UP:
                movement.x = 0;
                movement.y = 1;
                break;
            case Direction.DOWN:
                movement.x = 0;
                movement.y = -1;
                break;

            case Direction.LEFT:
                movement.x = -1;
                movement.y = 0;
                break;
            case Direction.RIGHT:
                movement.x = 1;
                movement.y = 0;
                break;
            case Direction.STOP:
                movement = Vector2.zero;
                break;
        }
    }
   public enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        STOP
    }
        void OnCollisionEnter2D(Collision2D colli)
        {
        Vector2 old_pos = colli.transform.position; // lưu lại vị trí cái food vừa mới bị ăn để tránh bị trùng
        Destroy(colli.gameObject);
            score++;
        //Khoảng random để lớn lên 1 chút. nãy để là -5 với -2 thì food mới sinh ra nó quá gần food cũ
        //làm phát sinh trường hợp là vừa sinh ra đã va vào player và biến mất luôn ==> nhảy score 
        //Để tránh trường hợp này hoàn toàn thì cần có thêm 1 bước nữa
        Vector2 spawnPos = new Vector2(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f));
        while(Vector2.Distance(old_pos,spawnPos) <= 1){
            // kiểm tra vị trí của food mới sinh ra có đủ xa so với vị trí cả foood vừa ăn hay ko 
            //nếu quá gần thì tiếp tục random đến khi nào đủ xa thì thôi.
            spawnPos = new Vector2(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f));
        }
        
        if (obstacles)
        {
            Instantiate(obstacles, spawnPos, Quaternion.identity);
        }
    }
}
       
       