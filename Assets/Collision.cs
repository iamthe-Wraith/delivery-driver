using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(80, 225, 70, 255); // alpha 0 === transparent
    [SerializeField] Color32 noPackageColor = new Color32(34, 45, 173, 255);

    bool hasPackage = false;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Boom!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            Destroy(other.gameObject);
            spriteRenderer.color = hasPackageColor;
        } 

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Packaged delivered to customer");
            hasPackage = false;
            Destroy(other.gameObject);
            spriteRenderer.color = noPackageColor;
        }
    }
}
