using UnityEngine;

public class ItemUiController : MonoBehaviour
{
    public ItemSO ItemSO;
    public void setName(ItemSO item)
    {
        this.ItemSO = item;
    }

    public void remove()
    {
        Inventory.instance.removeItem(this.ItemSO,this.ItemSO.DefaultStack);
        
    }
}
