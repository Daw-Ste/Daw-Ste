using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTheScene : MonoBehaviour
{
    public int scenebuildindex;

    public void LoadAScene()
    {
        SceneManager.LoadScene(scenebuildindex);
    }

}
