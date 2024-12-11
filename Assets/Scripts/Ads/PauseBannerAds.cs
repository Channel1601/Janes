using UnityEngine;
using UnityEngine.Advertisements;

public class PauseBannerAds : MonoBehaviour
{
    [SerializeField] string _androidPauseAdUnitId = "BannerAND";   // Top-left banner for pause screen
    [SerializeField] string _iOSPauseAdUnitId = "BannerIOS";   

    string _pauseAdUnitId = null;

    void Start()
    {
        #if UNITY_IOS
            _pauseAdUnitId = _iOSPauseAdUnitId;
        #elif UNITY_ANDROID
            _pauseAdUnitId = _androidPauseAdUnitId;
        #endif
    }

    // Load the banner ad with the given placement ID
    public void LoadBanner(string adUnitId)
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };
        Advertisement.Banner.Load(adUnitId, options);
    }

    // Show the pause screen banner ad (top-left)
    public void ShowPauseBanner()
    {
        HideBannerAd();
        Debug.Log("Pause Ad");
        Advertisement.Banner.SetPosition(BannerPosition.TOP_LEFT);
        LoadBanner(_pauseAdUnitId);
        Advertisement.Banner.Show(_pauseAdUnitId);
    }

    // Hide any active banner
    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    void OnBannerLoaded() { Debug.Log("Banner loaded"); }
    void OnBannerError(string message) { Debug.Log($"Banner Error: {message}"); }
}
