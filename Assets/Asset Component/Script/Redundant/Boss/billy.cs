// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;
//
// public class billy : MonoBehaviour
// {
//     public float speed;
//     private float waitTime;
//     public float startWaitTime;
//
//     public Transform[] moveSpots;
//     private int randomSpot;
//
//     // public GameObject billyHP;
//     // public int health;
//     // public Slider healthBar;
//
//     [Header("Death")]
//     public Transform endPositionBillyDeath;
//     private billyLaser billyLaser;
//     private LineRenderer laser;
//     private float destroyBilly = 2f;
//     public GameObject deathVfx;
//     public GameObject deathVfx2;
//     public GameObject spawnerPlatform;
//     private CapsuleCollider2D capsuleCollider;
//
//
//     [Header("Health")]
//     [SerializeField] public float hp;
//     [SerializeField] public float maxHp;
//     // private shoot shootDamage;
//     private GameObject Aim;
//     [SerializeField] public float hitSpeed;
//     [SerializeField] public Image hpImage;
//     [SerializeField] public Image effectImage;
//     [SerializeField] public TextMeshProUGUI hpText;
//     [SerializeField] public GameObject hpbarPanel;
//     [SerializeField] public bool isDeath;
//
//     [Header("Laser")]
//     public GameObject laserObj;
//     
//     // public GameObject platform;
//     // private platformBilly platformBilly;
//
//     private void Awake()
//     {
//     }
//
//     void Start()
//     {
//         Aim = GameObject.FindGameObjectWithTag("Aim");
//         shootDamage = Aim.GetComponent<shoot>();
//
//         capsuleCollider = GetComponent<CapsuleCollider2D>();
//
//         hp = maxHp;
//         waitTime = startWaitTime;
//         randomSpot = Random.Range(0, moveSpots.Length);
//         // healthBar.maxValue = hp;
//
//         billyLaser = laserObj.GetComponent<billyLaser>();
//         laser = laserObj.GetComponent<LineRenderer>();
//     }
//
//     void Update()
//     {
//
//         // healthBar.value = hp;
//
//         hpImage.fillAmount = hp / maxHp;
//         if (effectImage.fillAmount > hpImage.fillAmount)
//         {
//             effectImage.fillAmount -= hitSpeed;
//         }
//         else
//         {
//             effectImage.fillAmount = hpImage.fillAmount;
//         }
//         if (hp >= 1)
//         {
//             hpText.text = hp + (" / ") + maxHp;
//         }
//         else{
//             hpText.text = 0 + (" / ") + maxHp;
//         }
//
//         if (hp < 1)
//         {
//             isDeath = true;
//             capsuleCollider.enabled = false;
//             laser.enabled = false;
//             billyLaser.enabled = false;
//             Invoke("Death", 2f);
//         }
//
//         transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
//
//         if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
//         {
//             if (waitTime <= 0)
//             {
//                 randomSpot = Random.Range(0, moveSpots.Length);
//                 waitTime = startWaitTime;
//             }
//             else
//             {
//                 waitTime -= Time.deltaTime;
//             }
//         }
//     }
//
//     // public void TakingDamage(){
//     //     hp--;
//     // }
//
//
//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.CompareTag("Bullet"))
//         {
//             // hp -= shootDamage.damage;
//             // if(hp < 1)
//             // {
//             //     hp = 0;
//             //     isDeath = true;
//             //     laser.enabled = false;
//             //     billyLaser.enabled = false;
//             //     Invoke("Death", 2f);
//             // }
//         }
//     }
//
//     void Death()
//     {
//         transform.position = Vector3.Lerp(transform.position, endPositionBillyDeath.position, Time.deltaTime);
//         destroyBilly -= Time.deltaTime;
//         if (destroyBilly <= 0)
//         {
//             Destroy(spawnerPlatform);
//             // FindObjectOfType<AudioManager>().Play("Death");
//             Instantiate(deathVfx, transform.position, Quaternion.identity);
//             Instantiate(deathVfx2, transform.position, Quaternion.identity);
//             hpbarPanel.SetActive(false);
//             // billyHP.SetActive(false);
//             Destroy(gameObject);
//         }
//     }
//
// }
