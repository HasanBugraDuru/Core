using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheel : MonoBehaviour,Iinteractable
{
    public PlayerController player;
    public GameObject[] gameObjects;
    // Start is called before the first frame update
    public bool _isInteracting;
    public float _turnDir;
    public float degreesPerSec = 360f;
    void Start()
    {
        _isInteracting = false;
    }

    // Update is called once per frame
    void Update()
    {
        _turnDir = Input.GetAxis("Horizontal");
        if (player != null)
        {
            WheelTurn();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<PlayerController>();
        }
    }
    public void Interact()
    {
        if (_isInteracting == true)
        {
            _isInteracting = false;
        }
        else
            _isInteracting = true;
    }
    public void WheelTurn()
    {
        if (_isInteracting)
        {
            player.canMove = false;
            if (_turnDir < 0)
            {
                Debug.Log("turning right");
                foreach (GameObject gameObject in gameObjects)
                {
                    float rotAmount = degreesPerSec * Time.deltaTime;
                    float curRot = gameObject.transform.localRotation.eulerAngles.z;
                    gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));
                }
            }
            Debug.Log("Wheel");
            if (_turnDir > 0)
            {
                Debug.Log("turning left");
                foreach (GameObject gameObject in gameObjects)
                {
                    float rotAmount = degreesPerSec * Time.deltaTime;
                    float curRot = gameObject.transform.localRotation.eulerAngles.z;
                    gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot - rotAmount));
                }
            }
        }
        else
        {
            player.canMove = true;
        }
    }
}
