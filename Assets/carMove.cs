using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMove : MonoBehaviour
{
   
   [SerializeField] float steerSpeed=400f;  // predkosc obrotu
   [SerializeField] float moveSpeed=20f; // predkosc samochodu
   [SerializeField] float slowSpeed=15f;
    [SerializeField] float boostSpeed=30f;
   

   
   
    void Update()
    {
        float steerAmount=Input.GetAxis("Horizontal")*steerSpeed *Time.deltaTime;; // pobiera dane od uzytkownika z zakładki horizontal i mnozy razy predkosc obruty (poruszanie strzalkami lewo prawo)
        float moveAmount = Input.GetAxis("Vertical") *moveSpeed *Time.deltaTime; //pobiera dane od uzytkownika z zakładki verical i mnozy razy predkosc poruszania (poruszanie strzalkami gora dol)
        transform.Rotate(0,0,-steerAmount);  // 3 zmienne to wartosci obietku do wartosci rorate zmieniamy zmienna Z aby obiekt sie obracal czyli wczesniej ustalony steer amount
        transform.Translate(0,moveAmount,0); // 3 zmienne to wartosci obietku do wartosci na osi x,y,z
    }

     void OnTriggerEnter2D(Collider2D other) 
      {  
        if(other.tag=="boost") 
            {
                Debug.Log("BOOOOOOOOOOOOOST");
                moveSpeed=boostSpeed;
            }
      }

      private void OnCollisionEnter2D(Collision2D other) 
      {
       moveSpeed=slowSpeed; 
      }

}
