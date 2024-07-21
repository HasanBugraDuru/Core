using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string[] lines;
    [SerializeField] private float textspeed;
    [SerializeField] Datas datas;

    private int index;
    private void Awake()
    {
        index = 0;
        StartDialogue();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
            datas.Storypassed = true;
            SceneManager.LoadScene("Game");
        }
    }
}
