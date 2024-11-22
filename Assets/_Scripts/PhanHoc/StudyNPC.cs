using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StudyNPC : MonoBehaviour
{
    public GameObject NpcPanel;
    public TextMeshProUGUI NpcText;
    public string[] content;

    private Coroutine coutine;

    private void Start()
    {
        NpcPanel.SetActive(false);
        NpcText.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NpcPanel.SetActive(true);
            coutine = StartCoroutine(RealContent());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NpcPanel.SetActive(true);
            StopCoroutine(coutine);
        }
    }
    public IEnumerator RealContent()
    {
        foreach (var item in content)
        {
            NpcText.text = "";
            foreach (var item2 in item)
            {
                NpcText.text += item;
                yield return new WaitForSeconds(.2f);
            }
            yield return new WaitForSeconds(.5f);
        }
    }

}
