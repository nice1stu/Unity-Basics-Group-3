using UnityEngine;

    [CreateAssetMenu]
    public class InventoryValues : ScriptableObject
    {
        public int money;
        [Header("Owned Weapons")] 
        public bool hasPistol;
        public bool hasRifle;
        
    }