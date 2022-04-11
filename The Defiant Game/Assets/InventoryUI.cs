using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;	// The entire UI
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
void Update ()
	{
		if (Input.GetButtonDown("Inventory"))
		{
			inventoryUI.SetActive(!inventoryUI.activeSelf);
			//UpdateUI();
		}
	}
}
