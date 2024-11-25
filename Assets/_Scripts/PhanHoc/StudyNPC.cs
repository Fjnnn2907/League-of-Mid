using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StudyNPC : MonoBehaviour
{
    public GameObject NpcPanel;
    public GameObject Button;
    public TextMeshProUGUI NpcText;
    public TextMeshProUGUI NameText;
    //public string[] content;
    public List<HoiThoai> content;
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
            NpcPanel.SetActive(false);
            StopCoroutine(coutine);
        }
    }
    public IEnumerator RealContent()
    {
        Button.SetActive(false);
        foreach (var item in content)
        {
            NpcText.text = "";
            NameText.text = item.model;
            foreach (char item2 in item.noidung)
            {
                NpcText.text += item2;
                yield return new WaitForSeconds(.05f);
            }
            yield return new WaitForSeconds(.5f);
        }
        Button.SetActive(true);
    }

}
[Serializable]
public class HoiThoai
{
    public string model;
    public string noidung;
}