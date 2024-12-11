using UnityEngine;
using UnityEngine.Advertisements;

public class VictoryBannerAds : MonoBehaviour
{
    [SerializeField] string _androidVictoryAdUnitId = "WinBannerAND";  // Bottom-left banner for win screen
    [SerializeField] string _iOSVictoryAdUnitId = "WinBannerIOS";

    string _victoryAdUnitId = null;

    void Start()
    {
        #if UNITY_IOS
            _victoryAdUnitId = _iOSVictoryAdUnitId;
        #elif UNITY_ANDROID
            _victoryAdUnitId = _androidVictoryAdUnitId;
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

    // Show the victory screen banner ad (bottom-left)
    public void ShowVictoryBanner()
    {
        HideBannerAd();
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_LEFT);
        LoadBanner(_victoryAdUnitId);
        Advertisement.Banner.Show(_victoryAdUnitId);
    }

    // Hide any active banner
    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    void OnBannerLoaded() { Debug.Log("Banner loaded"); }
    void OnBannerError(string message) { Debug.Log($"Banner Error: {message}"); }
}
