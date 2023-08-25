using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class box : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    public Image Image;

    private void Start()
    {
        // Get the reference to the BoxCollider2D component
        boxCollider = GetComponent<BoxCollider2D>();

        // Get the reference to the Image component representing the inventory slot
        Image slotImage = GetComponent<Image>();

        // Calculate the size of the Image
        Vector2 newSize = slotImage.rectTransform.sizeDelta;

        // Set the new size of the BoxCollider2D
        if (boxCollider != null)
        {
            boxCollider.size = newSize;
        }
    }
}
