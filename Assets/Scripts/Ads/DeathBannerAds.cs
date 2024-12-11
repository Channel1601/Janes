using UnityEngine;
using UnityEngine.Advertisements;

public class DeathBannerAds : MonoBehaviour
{
    [SerializeField] string _androidDeathAdUnitId = "EndBannerAND";  // Top-center banner for death screen   
    [SerializeField] string _iOSDeathAdUnitId = "EndBanneriOS";  

    string _deathAdUnitId = null;
 
    void Start()
    {
        #if UNITY_IOS
            _deathAdUnitId = _iOSDeathAdUnitId;
        #elif UNITY_ANDROID
            _deathAdUnitId = _androidDeathAdUnitId;
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

    // Show the death screen banner ad (top-center)
    public void ShowDeathBanner()
    {
        HideBannerAd();
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        LoadBanner(_deathAdUnitId);
        Advertisement.Banner.Show(_deathAdUnitId);
    }

    // Hide any active banner
    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    void OnBannerLoaded() { Debug.Log("Banner loaded"); }
    void OnBannerError(string message) { Debug.Log($"Banner Error: {message}"); }
}
