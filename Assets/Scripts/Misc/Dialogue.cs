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
 
    Animator animator;
    //private AudioSource Voice;
    private int index;
    private void Awake()
    {
       // Voice = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
        index = 0;
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
          dialoguBox.SetActive(false);
        }
    }
}
