using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MoneySystem : MonoBehaviour
{
    public NumericValue dosh;
    public TextMeshProUGUI Money;
    // Start is called before the first frame update
    void Start()
    {
        dosh.value = 0;
        Money.text = "Money: "+ dosh.value;
    }

    // Update is called once per frame
    void Update()
    {
        Money.text = "Money: "+ dosh.value;
    }
}
