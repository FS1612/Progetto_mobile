using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoaded : MonoBehaviour
{
    // Start is called before the first frame update
    public void Fb(string Facebook)
    {
        SceneManager.LoadScene(Facebook);
    }
    public void Google(string Google)
    {
        SceneManager.LoadScene(Google);
    }
    public void Apple(string Apple)
    {
        SceneManager.LoadScene(Apple);
    }
}
