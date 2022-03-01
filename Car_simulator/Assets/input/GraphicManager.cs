using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicManager : MonoBehaviour
{
    public static GraphicManager instance;

    public bool mostrataAvvertenzaFps=false;
    public bool Vsync = false;
    public int antialiassetting=1 ;
    public int QualitaVideo;
    public int LivelloOmbre;
    public int QualitaTexture;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        SetAntialiasing(1);
        //QualitySettings.antiAliasing = 1;
        QualitySettings.vSyncCount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {   
        AggiornaVsync();
        AggiornaAntialiasing();
        AggiornaQualita();
        AggiornaOmbre();
        AggiornaTexture();
    }
    private void AggiornaVsync()
    {
        if (GraphicManager.instance.GetVsyncAttivo()) { QualitySettings.vSyncCount = 1; }
        else{ QualitySettings.vSyncCount = 0; }
    }
    private void AggiornaAntialiasing()
    {
        if (antialiassetting == 0)
        {
            QualitySettings.antiAliasing = 0;
        }
        if (antialiassetting == 1)
        {
            QualitySettings.antiAliasing = 2;
        }
        if (antialiassetting == 2)
        {
            QualitySettings.antiAliasing = 4;
        }
        if (antialiassetting == 3)
        {
            QualitySettings.antiAliasing =  8;
        }
    }
    private void AggiornaQualita()
    {
        QualitySettings.SetQualityLevel ( QualitaVideo);
    }
    private void AggiornaOmbre()
    {
        //*sono 6
        
        if (LivelloOmbre == 0)//*qualità ombre Very High
        {
            CambiaOmbre(ShadowmaskMode.DistanceShadowmask, ShadowQuality.All, ShadowResolution.VeryHigh, ShadowProjection.StableFit, 150, 3, 4);
        }
        else if (LivelloOmbre == 1)//*qualità ombre High
        {
            CambiaOmbre(ShadowmaskMode.DistanceShadowmask, ShadowQuality.All, ShadowResolution.High, ShadowProjection.StableFit, 70, 3, 2);
        }
        else if (LivelloOmbre == 2)//*qualità ombre Medium
        {
            CambiaOmbre(ShadowmaskMode.DistanceShadowmask, ShadowQuality.All, ShadowResolution.Medium, ShadowProjection.StableFit, 40, 3, 2);
        }
        else if (LivelloOmbre == 3)//*qualità ombre low
        {
            CambiaOmbre(ShadowmaskMode.DistanceShadowmask, ShadowQuality.HardOnly, ShadowResolution.Low, ShadowProjection.StableFit, 20, 3, 0);
        }
        else if (LivelloOmbre == 4)//*qualità ombre Very Low
        {
            CambiaOmbre(ShadowmaskMode.DistanceShadowmask, ShadowQuality.Disable, ShadowResolution.Low, ShadowProjection.StableFit, 15, 3, 0);
        }
    }
    private void CambiaOmbre(ShadowmaskMode mask, ShadowQuality quality, ShadowResolution res, ShadowProjection proj, float shadowdistance, float shadowPlaneOffset,int shadowCascade)
    {
        QualitySettings.shadowmaskMode = mask;
        QualitySettings.shadows = quality;
        QualitySettings.shadowResolution = res;
        QualitySettings.shadowProjection = proj;
        QualitySettings.shadowDistance = shadowdistance;
        QualitySettings.shadowNearPlaneOffset = shadowPlaneOffset;
        QualitySettings.shadowCascades = shadowCascade;

    }
    private void AggiornaTexture()
    {
        if (QualitaTexture == 0)//*risoluzione massima
        {
            QualitySettings.masterTextureLimit = 0;
        }
        else if (QualitaTexture == 1)//* metà risoluzione
        {
            QualitySettings.masterTextureLimit = 1;
        }
        else
        {
            QualitySettings.masterTextureLimit = 2;
        }
    }
    public bool GetVsyncAttivo() { return Vsync; }
    public void SetVsyncAttivo(bool attivo) { Vsync = attivo; }
    public void SetAntialiasing(int val) { antialiassetting = val;}
    public int GetAntiAliasing() { return antialiassetting; }
    public int GetQualitaVideo() { return QualitaVideo; }
    public void SetQualitaVideo(int qualita) { QualitaVideo = qualita; }
    public void SetLivelloOmbre(int liv) { LivelloOmbre = liv; }
    public int GetQualitaOmbre() { return LivelloOmbre; }
    public int GetTextureQuality() { return QualitaTexture; }
    public void SetQualitaTexture(int qualita) { QualitaTexture = qualita; }
    public void SetAvvertenzaMostrata(bool mostrata) { mostrataAvvertenzaFps = mostrata; }
    public bool GetAvvertenzaMostrata() { return mostrataAvvertenzaFps; }
}
