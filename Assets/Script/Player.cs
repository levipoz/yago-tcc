using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject bullet;
    public Transform aim;
    public float fireForce = 10f;
    float shootCooldown = 0.2f;
    float shootTime = 0.5f;

    public float hp = 100;
    public float moveX;
    public float moveY;
    public float moveSpeed = 2.5f;
    public Rigidbody2D rig2D;


    // Start is called before the first frame update
    void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        shootTime += Time.deltaTime;
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        Move();
        AimMouse();
        if (Input.GetMouseButton(0)) 
        {
            Shoot();
            Debug.Log("Atirando");
         }
    }

    void Move()
    {
        rig2D.MovePosition(transform.position + new Vector3(moveX, moveY, 0) * Time.deltaTime * moveSpeed);
    }

    void AimMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - aim.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        aim.rotation = Quaternion.Euler(0,0, angle + 90f);
    }
    void Shoot()
    {
        if (shootTime > shootCooldown)
        {
            shootTime = 0f;
            GameObject intBullet = Instantiate(bullet,aim.position,aim.rotation);
            intBullet.GetComponent<Rigidbody2D>().AddForce(-aim.up * fireForce, ForceMode2D.Impulse);
            Destroy(intBullet,2.5f);
        }

    }
}

