using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterButtons : MonoBehaviour
{
    public GameObject chapter;
    public OpenChapter chapterManager;

    private Button button;

    private void Start()
    {
        // Get the Button component attached to this GameObject
        button = GetComponent<Button>();

        // Add a listener to the button click event
        button.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        // Call the ActivateChapter method of the ChapterManager
        chapterManager.ActivateChapter(chapter);
    }
}
