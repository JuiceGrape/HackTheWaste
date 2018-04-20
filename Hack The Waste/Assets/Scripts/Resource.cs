using UnityEngine;
using UnityEngine.Events;

public class Resource : MonoBehaviour
{
    [SerializeField]
    private int quantity;
    public int InitialQuantity;
    public int maxResource;
    public int minResource;
    
    public UnityEvent OnValueChanged = new UnityEvent(); 

    void Awake()
    {
        quantity = InitialQuantity;
        updateUI();
    }


    public void ResetQuantity()
    {
        quantity = maxResource;
        updateUI();
    }
    
    public void AddAmount(int value)
    {
        if (value < 0)
            return;
        quantity += value;
        if (quantity > maxResource)
            quantity = maxResource;
        updateUI();
    }

    public void RemoveAmount(int value)
    {
        if (value < 0)
            return;
        quantity -= value;
        if (quantity < minResource)
            quantity = minResource;
        updateUI();
    }

    public bool CanAfford(int cost)
    {
        return quantity >= cost;
    }

    public int GetQuantity()
    {
        return quantity;
    }
    

    void updateUI()
    {
        OnValueChanged.Invoke();
    }
}
