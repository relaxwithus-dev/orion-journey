using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class boss3Manager : MonoBehaviour
{

    [Header("Health")]
    public float maxHp;
    public float hp;
    public float hitSpeed;
    public Image hpImage;
    public Image effectImage;
    public TextMeshProUGUI hpText;

    [Header("Reference")]
    public bool isDeath;
    public GameObject hpPanel;
    private GameObject Aim;
    // private shoot shootDmg;
    public GameObject[] spawner;

    public GameObject cameraControl;

    // Start is called before the first frame update
    void Start()
    {
        Aim = GameObject.FindGameObjectWithTag("Aim");
        // shootDmg = Aim.GetComponent<shoot>();

        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        hpImage.fillAmount = hp / maxHp;

        if (effectImage.fillAmount > hpImage.fillAmount)
        {
            effectImage.fillAmount -= hitSpeed;
        }
        else
        {
            effectImage.fillAmount = hpImage.fillAmount;
        }

        hpText.text = hp + ("/") + maxHp;

        //death condition
        if (hp < 1)
        {
            isDeath = true;
            hpPanel.SetActive(false);
            for (int i = 0; i < 6; i++)
            {
                spawner[i].gameObject.SetActive(false);
            }
            Destroy(cameraControl);
            Destroy(gameObject);
        }
    }

}
