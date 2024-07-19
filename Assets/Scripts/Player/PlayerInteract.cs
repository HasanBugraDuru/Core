using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
   [SerializeField] GameObject interactableObject;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Iinteractable>() != null)
        {
            interactableObject = collision.gameObject;
            Debug.Log("interactable object is" + interactableObject.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Iinteractable>() != null)
        {
            interactableObject = null;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactableObject != null)
        {
            interactableObject.GetComponent<Iinteractable>().Interact();
        }
        
    }

}
