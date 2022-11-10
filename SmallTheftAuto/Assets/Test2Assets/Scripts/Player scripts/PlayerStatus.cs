using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

public class PlayerStatus : MonoBehaviour, IDamageable
{
    public NumericValue hp;
    public NumericValue dosh;

    public GameObject GreyDeathScreen;
    public GameObject Wasted;
    public TextMeshProUGUI Money;
    public TextMeshProUGUI healthUI;

    private Burning burn;

    // Start is called before the first frame update
    void Start()
    {
        hp.value = 100;
        if(healthUI != null)
            healthUI.text = $"Health: {hp.value}";
        burn = GetComponent<Burning>();
        burn.onFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(healthUI != null)
            healthUI.text = $"Health: {hp.value}";
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 6 && !burn.onFire)
        {
            burn.onFire = true;
        }
    }

    public void TakeDamage(int damage)
    {
        Mathf.Clamp(hp.value -= damage, 0, 100);
        if (healthUI != null)
            healthUI.text = $"Health: {hp.value}";
        
        if (hp.value <= 0)
        {
            StartCoroutine(Death());
        }
    }

    public void Heal(int healAmount)
    {
        Mathf.Clamp(hp.value += healAmount, 0, 100);
        if (hp.value > 100)
        {
            hp.value = 100;
        }
        healthUI.text = $"Health: {hp.value}";
    }

    IEnumerator Death()
    {
        GreyDeathScreen.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Wasted.SetActive(true);
        
        Time.timeScale = 0.3f;

        yield return new WaitForSeconds(1);
        Time.timeScale = 1;
        Money.text = "Money: " + dosh.value;
        GreyDeathScreen.SetActive(false);
        Wasted.SetActive(false);
        Debug.Log("Load Game...");
        float playerPositionX = PlayerPrefs.GetFloat("playerPositionX");
        float playerPositionY = PlayerPrefs.GetFloat("playerPositionY");
        float playerPositionZ = PlayerPrefs.GetFloat("playerPositionZ");
        Vector3 playerPosition = new Vector3(playerPositionX, playerPositionY, playerPositionZ);
        dosh.value = PlayerPrefs.GetInt("moneyCollected")/2;
        hp.value = 100;
        Debug.Log("playerPosition" + playerPosition + "PlayerHealth" + hp.value + "moneyCollected" + dosh.value);

        transform.position = playerPosition;
    }
    
}
