using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadDialogueScene : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Box"))
    //    {
    //        LoadNextLevel();
    //    }
    //}

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene("DialogueSystem"));
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
    }
}
