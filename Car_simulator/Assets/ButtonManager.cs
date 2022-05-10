using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void NuovaPartita(string Partita)
    {
        SceneManager.LoadScene(Partita);
            }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Options(string Opzioni)
    {
        SceneManager.LoadScene(Opzioni);
    }
}
