using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LinksAndBack : MonoBehaviour
{
    public void ItchLink()
    {
        Application.OpenURL("https://angularblade.itch.io");
    }
    public void SpotifyLink ()
    {
        Application.OpenURL("https://sptfy.com/KL5N");
    }
    public void LinkTreeLink ()
    {
        Application.OpenURL("https://linktr.ee/justthedani");
    }
    public void Back ()
    {
        SceneManager.LoadScene(0);
    }
}
