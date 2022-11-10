using System.Collections;
using UnityEngine;

public class Burning : MonoBehaviour
{
    public float dps = 1;
    float timer = 0;
    public float timerDuration = 1f;
    public float expireTime = 3f;
    public GameObject fire;
    public bool onFire;

    void Update()
    {
        if (onFire)
        {
            StartCoroutine(FireExpire());
            timer += Time.deltaTime;
            fire.SetActive(true);
            
            if (timer >= timerDuration)
            {
                GetComponent<PlayerStatus>().TakeDamage((int)dps);
                timer -= timerDuration;
            }
        }
        else
        {
            timer = 0;
            fire.SetActive(false);
        }
        
    }

    private void OnEnable()
    {
        fire.SetActive(true);
        timer = 0;
    }

    private void OnDisable()
    {
        fire.SetActive(false);
    }

    public IEnumerator FireExpire()
    {
        yield return new WaitForSeconds(expireTime);
        onFire = false;
    }
    
    
    
        
}