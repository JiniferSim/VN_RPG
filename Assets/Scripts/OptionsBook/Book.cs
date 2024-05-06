using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] float pageSpeed = 0.5f;
    [SerializeField] List<Transform> pages;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject forwardButton;

    int index = -1;
    bool rotate = false;

    private void Start()
    {
        backButton.SetActive(false);
    }
    public void RotateFoward()
    {
        if (rotate == true)
        {
            return;
        }
        index++;
        float angle = 180;
        ForwardButtonActions();
        pages[index].SetAsLastSibling();
        StartCoroutine(Rotate(angle, true));
    }

    public void ForwardButtonActions()
    {
        if (backButton.activeInHierarchy == false)
        {
            backButton.SetActive(true);
        }
        if(index == pages.Count - 1) 
        { 
            forwardButton.SetActive(false);
        }
    }

    public void BackButtonActions()
    {
        if (forwardButton.activeInHierarchy == false)
        {
            forwardButton.SetActive(true);
        }
        if (index -1 == - 1)
        {
            backButton.SetActive(false);
        }
    }

    public void RotateBack() 
    {
        if(rotate == true)
        {
            return;
        }
        float angle = 0;
        BackButtonActions();
        pages[index].SetAsLastSibling();
        StartCoroutine(Rotate(angle, false));
    }

    IEnumerator Rotate(float angle, bool forward)
    {
        float value = 0f;
        while(true)
        {
            rotate = true;
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            value += Time.deltaTime * pageSpeed;
            pages[index].rotation = Quaternion.Slerp(pages[index].rotation, targetRotation, value);
            float angle1 = Quaternion.Angle(pages[index].rotation, targetRotation);

            if(angle1 < 0.1f) 
            {
                if (forward == false)
                {
                    index--;
                }
                rotate = false;
                break;
            }
            yield return null;
        }
    }
}
