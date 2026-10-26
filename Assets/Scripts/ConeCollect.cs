using UnityEngine;

public class ConeCollect : MonoBehaviour
{
    public int coneValue = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            // In case I didn't give player inventory
            if (inventory != null)
            {
                inventory.AddCones(coneValue);
                inventory.UpdateConeUI();
            }
            Destroy(gameObject);
        }
    }
}
