using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnPressButtonChangeTextColor : MonoBehaviour
{
    public Color wantedColor;
    public TMP_Text textMeshPro;
    private Color originalColor;

    void Start()
    {
        originalColor = textMeshPro.color;

        Button button = GetComponent<Button>();
        button.onClick.AddListener(ChangeTextColor);
    }

    public void ChangeTextColor()
    {
        textMeshPro.color = wantedColor;

        OnPressButtonChangeTextColor[] allChangers = FindObjectsOfType<OnPressButtonChangeTextColor>();
        foreach (OnPressButtonChangeTextColor changer in allChangers)
        {
            if (changer != this)
            {
                changer.textMeshPro.color = changer.originalColor;
            }
        }
    }
}
