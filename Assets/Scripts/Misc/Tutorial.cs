using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject dialoguBox;
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string[] lines;
    [SerializeField] private float textspeed;
    [SerializeField] Datas datas;
    [SerializeField] private Image robot, human;
    public bool dialoguactive;
    private int index;
    private void Awake()
    {
        index = 0;
        dialoguactive = true;
        StartDialogue();
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
        textComponent.text = string.Empty;
        dialoguBox.SetActive(true);
        human.gameObject.SetActive(false);
        robot.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
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
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(Typeline());
        }
        else
        {
            dialoguactive = false;
            robot.gameObject.SetActive(false);
            human.gameObject.SetActive(true);
            dialoguBox.SetActive(false);
        }
    }
}
