using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class scene_transition : MonoBehaviour
{
       public void sceneToStartTransition()
   {
       SceneManager.LoadScene("init", LoadSceneMode.Single);
   }

    public void sceneTransition()
    {

        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }

}
