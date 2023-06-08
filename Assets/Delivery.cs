using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

   [SerializeField] Color32 hasPackageColor = new Color32(20,200,200,200);
    [SerializeField] Color32 noPackageColor = new Color32(250,0,215,255);

   [SerializeField] float destroyDelay=0.5f;
   bool hasPackage=false;

SpriteRenderer spriteRenderer;

private void Start()
 {
   spriteRenderer=GetComponent<SpriteRenderer>();
   spriteRenderer.color=noPackageColor;
 }

     void OnCollisionEnter2D(Collision2D other)
     {
        Debug.Log("Outch!");
     }

    void OnTriggerEnter2D(Collider2D other)
     {
        //jak trafimy na paczke to :
        if(other.tag=="Package" && !hasPackage)
        {
         Debug.Log("Package picked up");
         hasPackage=true;
         spriteRenderer.color=hasPackageColor;
         Destroy(other.gameObject,destroyDelay);
        }

        else if(other.tag=="Customer" && hasPackage==true)
        {
         Debug.Log("Package delivered");
         hasPackage=false;
         spriteRenderer.color=noPackageColor;
        }
     }
}   
