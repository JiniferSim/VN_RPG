using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChapter : MonoBehaviour
{
    public GameObject[] chapters;

    private GameObject activeChapter;

    private void Start()
    {
        // Deactivate all chapters at the start
        foreach (GameObject chapter in chapters)
        {
            chapter.SetActive(false);
        }
    }

    public void ActivateChapter(GameObject newChapter)
    {
        // Deactivate the previous active chapter
        if (activeChapter != null)
        {
            activeChapter.SetActive(false);
        }

        // Activate the new chapter
        newChapter.SetActive(true);
        activeChapter = newChapter;
    }
}
