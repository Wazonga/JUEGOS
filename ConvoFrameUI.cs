using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConvoFrameUI : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        ConvoManager.Instance.OnConvoStart += OnConvoStartDelegate;
        ConvoManager.Instance.OnConvoNext += OnConvoNextDelegate;
        ConvoManager.Instance.OnConvoStop += OnConvoStopDelegate;
        transform.gameObject.SetActive(false);
    }


    private void OnConvoStartDelegate(Interaction interaction)
    {
        transform.gameObject.SetActive(true);
        ShowInteraction(interaction);
    }

    private void OnConvoNextDelegate(Interaction interaction)
    {
        ShowInteraction(interaction);
    }
    private void OnConvoStopDelegate()
    {
        transform.gameObject.SetActive(false);
    }

    private void ShowInteraction(Interaction interaction)
    {
        transform.Find("CharImage").Find("Image").GetComponent<Image>().sprite = interaction.CharImage;
        transform.Find("CharName").GetComponent<TextMeshProUGUI>().text = interaction.CharName;
        transform.Find("CharText").GetComponent<TextMeshProUGUI>().text = interaction.CharText;
    }
}
