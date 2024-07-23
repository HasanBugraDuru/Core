using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string[] lines;
    [SerializeField] private float textspeed;
    [SerializeField] private Image image;
    [SerializeField] private GameObject dialoguBox;
    public bool dialoguactive;
 
    Animator animator;
    //private AudioSource Voice;
    private int index;
    private void Awake()
    {
        index = 0;
        dialoguactive = false;
       // Voice = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) & dialoguactive)
        {
            if(textComponent.text == lines[index]) 
            {
                //Voice.UnPause();
                NextLine();
            }
            else
            {
                //Voice.Stop();
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    public void StartDialogue()
    {
        dialoguBox.SetActive(true);
        textComponent.text = string.Empty;
        image.sprite= gameObject.GetComponent<SpriteRenderer>().sprite;
        StartCoroutine(Typeline());
    }
    IEnumerator Typeline()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }
    private void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(Typeline());
        }
        else
        {
          dialoguactive = false;
          dialoguBox.SetActive(false);
        }
    }
}
