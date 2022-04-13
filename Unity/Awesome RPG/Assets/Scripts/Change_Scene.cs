using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Change_Scene : MonoBehaviour
{
   public void loadNextScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
