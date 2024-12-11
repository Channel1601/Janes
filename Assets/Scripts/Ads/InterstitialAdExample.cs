using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAdExample : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "InterAND";
    [SerializeField] string _iOsAdUnitId = "InterIOS";
    private string _adUnitId;
    private bool adIsReady = false; // Flag to track if the ad is loaded and ready to be shown
    private DeathBannerAds deathBannerAds;

    // Use static variable to persist death count across level restarts
    private static int deathCount = 0;
    private int nextAdThreshold;

    void Awake()
    {
        deathBannerAds = GetComponent<DeathBannerAds>();
        // Get the Ad Unit ID for the current platform:
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOsAdUnitId
            : _androidAdUnitId;

        SetNextAdThreshold();
        LoadAd(); // Load the first ad when the game starts
    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        Advertisement.Load(_adUnitId, this);
    }

    // Show the loaded content in the Ad Unit:
    public void ShowAd()
    {
        if (adIsReady)
        {
            deathBannerAds.HideBannerAd();
            Advertisement.Show(_adUnitId, this);
        }
        else
        {
            Debug.Log("Ad not ready yet.");
        }
    }

    // Implement Load Listener and Show Listener interface methods: 
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded Successfully: " + adUnitId);
        adIsReady = true; // Set the flag to true when the ad is loaded
    }

    public void OnUnityAdsFailedToLoad(string _adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}");
        adIsReady = false; // Reset the flag if the ad failed to load
    }

    public void OnUnityAdsShowFailure(string _adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {_adUnitId}: {error.ToString()} - {message}");
        adIsReady = false; // Reset the flag if the ad fails to show
    }

    public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        adIsReady = false; // Reset the flag after the ad is shown
        LoadAd(); // Load the next ad after showing
    }

    // Implement missing method: OnUnityAdsShowStart
    public void OnUnityAdsShowStart(string adUnitId)
    {
        Debug.Log("Ad started showing: " + adUnitId);
    }

    // Implement missing method: OnUnityAdsShowClick
    public void OnUnityAdsShowClick(string adUnitId)
    {
        Debug.Log("Ad clicked: " + adUnitId);
    }

    // This method should be called when the character dies
    public void OnCharacterDeath()
    {
        deathCount++;

        if (deathCount >= nextAdThreshold)
        {
            ShowAd();
            deathCount = 0; // Reset the death counter after showing the ad
            SetNextAdThreshold();
        }
    }

    private void SetNextAdThreshold()
    {
        nextAdThreshold = Random.Range(3, 6); // Random number between 3 and 5
    }
}
