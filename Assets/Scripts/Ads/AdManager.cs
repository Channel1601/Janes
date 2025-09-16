using UnityEngine;

public class AdManager: MonoBehaviour
{
    public static string AppKey => GetAppKey();
    public static string BannerAdUnitId => GetBannerAdUnitId();
    public static string InterstitalAdUnitId => GetInterstitialAdUnitId();

    static string GetAppKey()
    {
        #if UNITY_ANDROID
            return "2351f8acd";
        #elif UNITY_IPHONE
            return "235203765";
        #else
            return "unexpected_platform";
        #endif
    }

    static string GetBannerAdUnitId()
    {
        #if UNITY_ANDROID
            return "z5twyt8ocusko8ca";
        #elif UNITY_IPHONE
            return "0as6jpxig1xutal3";
        #else
            return "unexpected_platform";
        #endif
    }
    static string GetInterstitialAdUnitId()
    {
        #if UNITY_ANDROID
            return "i0qkimju909veq2p";
        #elif UNITY_IPHONE
            return "b1mns8t58la1p1on";
        #else
            return "unexpected_platform";
        #endif
    }

}
