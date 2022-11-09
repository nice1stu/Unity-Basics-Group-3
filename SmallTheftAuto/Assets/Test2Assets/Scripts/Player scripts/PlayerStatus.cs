using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatus : MonoBehaviour, IDamageable
{
    public NumericValue hp;
    public NumericValue dosh;
    
    public GameObject GreyDeathScreen;
    public GameObject Wasted;
    public Transform destination;
    public TextMeshProUGUI Money;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        Mathf.Clamp(hp.value -= damage, 0, 100);
        if (hp.value <= 0)
        {
            StartCoroutine(Death());
        }
    }

    public void Heal(int healAmount)
    {
        Mathf.Clamp(hp.value += healAmount, 0, 100);
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
        hp.value = PlayerPrefs.GetInt("playerHealth");
        Debug.Log("playerPosition" + playerPosition + "PlayerHealth" + hp.value + "moneyCollected" + dosh.value);

        transform.position = playerPosition;
    }
}
