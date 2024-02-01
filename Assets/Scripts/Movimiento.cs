using UnityEngine;
using System.Collections;
using TMPro;

public class TransformFunctions : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 180f;
    
    public TextMeshProUGUI puntuacionText;
    private int puntuacion;

    public GameObject winTextObject;

    void Start()
    {
        puntuacion = 0; // Variable de puntuacion a 0 
        
        SetCountText();

        winTextObject.SetActive(false); // Esconde el texto mostrado al ganar
    }

    void Update()
    {
        // Mapea los controles
        if(Input.GetKey(KeyCode.W)) // Si se presiona la tecla 'W'
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); // Su posicion cambia
        
        if(Input.GetKey(KeyCode.S))
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        
        if(Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        
        if(Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }
    
    // En trigger, colision con 'other'.
    void OnTriggerEnter(Collider other) 
    {
        // Check if the object the player collided with has the "PickUp" tag.
        if (other.gameObject.CompareTag("PickUp")) 
        {
            // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);

            puntuacion = puntuacion + 1;

            SetCountText();
        }
    }

    void SetCountText() 
    {
        puntuacionText.text =  "Puntuacion: " + puntuacion.ToString(); // Actualiza el contenido del texto

        if (puntuacion >= 10)
        {
            winTextObject.SetActive(true);
        }
    }

}