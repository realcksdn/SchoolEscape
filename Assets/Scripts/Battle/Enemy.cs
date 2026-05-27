using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string EnemyName;
    public float speed;
    public float power;
    public int health;
    public Sprite[] sprites;

    public float maxShotDelay;
    public float curShotDelay;

    public GameObject bulletObjA;
    public GameObject player;

    SpriteRenderer Spr;

    

    private void Awake()
    {
        Spr = GetComponent<SpriteRenderer>();

    }
    
    void Update()
    {

        Shoot();
        Reload();
    }
    void OnHit(int dmg)
    {
        health -= dmg;
        Spr.sprite = sprites[1];
        Invoke("ReturnSpr", 0.1f);

        if (health <= 0)
            Destroy(gameObject);
            

    }
    void ReturnSpr()
    {
        Spr.sprite = sprites[0];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBullet")
            Destroy(gameObject);
        else if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit(bullet.dmg);

           
            Destroy(collision.gameObject);
            

        }

    }
    void Shoot()
    {
        if (curShotDelay < maxShotDelay)
            return;

        if (EnemyName == "1")
        {
            GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Vector3 dirVec = player.transform.position - transform.position;
            rb.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);
        }
        else if (EnemyName == "2")
        {

            GameObject bulletR = Instantiate(bulletObjA, transform.position + Vector3.right * 0.3f, transform.rotation);
            GameObject bulletL = Instantiate(bulletObjA, transform.position + Vector3.left * 0.3f, transform.rotation);
            Rigidbody2D rbR = bulletR.GetComponent<Rigidbody2D>();
            Rigidbody2D rbL = bulletL.GetComponent<Rigidbody2D>();
            Vector3 dirVecR = player.transform.position - transform.position;
            Vector3 dirVecL = player.transform.position - transform.position;
            rbR.AddForce(dirVecR.normalized * 5, ForceMode2D.Impulse);
            rbL.AddForce(dirVecL.normalized * 5, ForceMode2D.Impulse);
        }




        curShotDelay = 0;

    }
    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }
}