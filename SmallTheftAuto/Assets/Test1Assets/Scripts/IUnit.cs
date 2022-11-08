using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit
{
    Vector3 GetPosition();
    void SetPosition(Vector3 position);

    int GetDollarAmount();
    void SetDollarAmount(int dollarAmount);

    int GetHealth();
    void SetHealthAmount(int HealthPoints);
}
