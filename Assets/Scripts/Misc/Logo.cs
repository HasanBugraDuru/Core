using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    AudioSource meow;
    private void Awake()
    {
        meow = GetComponent<AudioSource>();
    }
    void Start()
    {
        meow.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (meow.isPlaying == false)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
