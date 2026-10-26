using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int totalCones = 0;
    public TextMeshProUGUI coneUIText;
    public void AddCones(int amount)
    {
        totalCones += amount;
        Debug.Log("Total Cone Amount: " + totalCones);
    }
    public void UpdateConeUI()
    {
        if (coneUIText != null)
        {
            coneUIText.text = "" + totalCones;
            if (totalCones == 10)
            {
                transform.Rotate(180,0,0);
            }
        }
    }
}
