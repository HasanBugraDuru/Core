using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CampStory : MonoBehaviour
{
    [SerializeField] GameObject paper;
    [SerializeField] private GameObject dialoguBox;
    [SerializeField] private TextMeshProUGUI textComponent,papertext;
    [SerializeField] private string[] lines;
    [SerializeField] private float textspeed;
    [SerializeField] Datas datas;
    [SerializeField] private Image human;
    public bool dialoguactive;
    private int index;
    private void Awake()
    {
        index = 0;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) & dialoguactive)
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    public void StartDialogue()
    {
        dialoguactive = true;
        dialoguBox.SetActive(true);
        GetPassword();
        textComponent.text = string.Empty;
        human.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
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
    public void GetPassword()
    {
        int randomNumber = Random.Range(1000, 10000);
        datas.password = randomNumber.ToString();
        papertext.text = datas.password;
    }
    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(Typeline());
        }
        else
        {
            dialoguactive = false;
            paper.SetActive(true);
            dialoguBox.SetActive(false);
        }
    }
}
