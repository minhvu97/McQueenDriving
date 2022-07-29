using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField] float destroyDelay = 0.5f;
    private bool hasPackage = false;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package")
        {
            if (!hasPackage)
            {
                Debug.Log("You have picked up the package.");
                hasPackage = true;
                Destroy(other.gameObject, destroyDelay);
                spriteRenderer.color = hasPackageColor;
            }
            else
            {
                Debug.Log("You only allow to deliver 1 package a time.");
            }
        }
        else if (other.tag == "Customer")
        {
            if (hasPackage)
            {
                Debug.Log("Delivered the package.");
                hasPackage = false;
                spriteRenderer.color = noPackageColor;
            }
            else
            {
                Debug.Log("You don't have any package to deliver.");
            }
        }
    }
}
