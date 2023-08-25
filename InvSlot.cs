using UnityEngine;
using UnityEngine.EventSystems;

namespace InvScripts {
using static InvScripts.DraggableItem2;
public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        DraggableItem2 draggableItem = eventData.pointerDrag.GetComponent<DraggableItem2>();
        if (draggableItem != null)
        {
            draggableItem.transform.SetParent(transform); // Corrected version
            Debug.Log("it works man");
        }
    }

    public void AddItemToSlot(GameObject item)
    {
        item.transform.SetParent(transform);
        item.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }
}
}
