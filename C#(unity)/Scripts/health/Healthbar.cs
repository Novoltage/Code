using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Healthbar : MonoBehaviour
{

    [SerializeField] private Health playerHealth;
    [SerializeField] private Image healthbartotal;
    [SerializeField] private Image healthbarcurrent;
    // Start is called before the first frame update
    void Start()
    {
        healthbartotal.fillAmount = playerHealth.currentHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        healthbarcurrent.fillAmount = playerHealth.currentHealth / 10;
    }
}
