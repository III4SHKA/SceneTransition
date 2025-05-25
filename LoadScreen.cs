using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{
    [SerializeField] Animator anim;

    public void Loading(int number)
    {
        StartCoroutine(LoadAsync(number));
        anim.SetTrigger("start");
    }

    IEnumerator LoadAsync(int number)
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(number);
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)
        {
            if (loadAsync.progress >= 0.9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(1f);
                loadAsync.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
