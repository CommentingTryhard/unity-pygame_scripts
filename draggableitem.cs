using UnityEngine;
using UnityEngine.EventSystems;

namespace InvScripts {
public class DraggableItem2 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform initialParent;
    private Vector3 initialPosition;
    public Vector3 fixedSize = new Vector3(1.0f, 1.0f, 1.0f);
    private bool hasBeenDropped = false;
    private bool condition2 = false;
    public Camera cam;

    public void OnBeginDrag(PointerEventData eventData)
    {
        initialParent = transform.parent;
        initialPosition = transform.position;

        transform.SetParent(transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = initialPosition.z; // Maintain the initial Z-axis position
        transform.position = newPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(initialParent);

        if (transform.parent.GetComponent<InventorySlot>() != null)
        {
            transform.position = initialPosition;
            
            if (!hasBeenDropped)
            {
                transform.localScale = fixedSize; // Set to the fixed size only once
                Debug.Log("ur code trap");
                hasBeenDropped = true;
            }
            
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else if (condition2)
        {
            if (transform.parent.gameObject.tag == "Inventory Slot")
            {
                condition2 = true;
            }
            transform.SetAsLastSibling();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetParent(Transform parent)
    {
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
    }
}
}
