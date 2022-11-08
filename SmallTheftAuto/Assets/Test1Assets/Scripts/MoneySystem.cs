using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MoneySystem : MonoBehaviour
{
    public TextMeshProUGUI Money;
    // Start is called before the first frame update
    void Start()
    {
        Money.text = "Money: "+ 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
