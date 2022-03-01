using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottoniImpostazioni : MonoBehaviour
{
    [SerializeField] GameObject menuimpostazioni;
    // Start is called before the first frame update
    void Start()
    {
        //menuimpostazioni.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void AttivaImpostazioni()
    //{//* le scene sono indicizzate nella build il gioco ha indice 0, il menu ha indice 1
    //    menuimpostazioni.SetActive(false);
    //    //cambioScene();
    //    SceneManager.LoadScene(1);
         
    //}
    public void rimuoviImpostazioni()
    {

        SceneManager.LoadScene(0);
        
    }
    //IEnumerator  cambioScene()
    //{
    //    SceneManager.LoadScene(1);
    //    //menuimpostazioni.SetActive(false);
    //    yield return new WaitForSeconds(0.2f);
    //    //SceneManager.LoadScene(1);
    //}
    //private void cambioScene()
    //{
    //    SceneManager.LoadScene(1);
    //}
}
