using TMPro;
using UnityEngine;

public class ContatoreFps : MonoBehaviour
{
   public TextMeshProUGUI FpsDisplay;
    private bool attivato;
    private float pollingTime=1f;//* tempo aggiornamento display 
    private float time;
    private int FrameCount;
    private int fps;

    //private void Start()
    //{
    //      GameManager.instance.GetLimiterFps();
    //}
    void Update()
    {
        if (!attivato)
        {
            FpsDisplay.enabled = false;
        }

        time += Time.deltaTime;//* tempo fra il frame corrente e quello passato
        FrameCount++;
        attivato = GameManager.instance.GetContatoreFpsAttivo();
         fps= GameManager.instance.GetLimiterFps();
        if (fps == 0) { Application.targetFrameRate = -1; }
        else if (fps > 0){ Application.targetFrameRate = fps; }
       
            if (time >= pollingTime)
            {
                int frameRate = Mathf.RoundToInt(FrameCount / time);
                if (attivato)
                    FpsDisplay.enabled = true;
                {
                    FpsDisplay.text = frameRate.ToString() + " FPS";
                }

                time -= pollingTime;
                FrameCount = 0;
            }
        
    }
}
