using System;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(255, 255, 255, 255);
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);
    
    [SerializeField] float destroyDelay = 0.2f;
    private bool hasPackage;
    
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("You hit something hard!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "DeliverPoint" && hasPackage)
        {
            Debug.Log("Packed delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
    
}
