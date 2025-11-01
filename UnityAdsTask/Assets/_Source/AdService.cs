using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdService : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private bool testMode;
#if UNITY_IOS
    private const string GAME_ID = "5971363";
    private const string INTERSTITIAL_ID = "Interstitial_iOS";
    private const string REWARDED_ID = "Rewarded_iOS";
    private const string BANNER_ID = "Banner_iOS";
#endif
#if UNITY_ANDROID || UNITY_EDITOR
    private const string GAME_ID = "5971362";
    private const string INTERSTITIAL_ID = "Interstitial_Android";
    private const string REWARDED_ID = "Rewarded_Android";
    private const string BANNER_ID = "Banner_Android";
#endif

    private void Awake()
    {
        Advertisement.Initialize(GAME_ID, testMode, this);
    }

    #region Initialization
    public void OnInitializationComplete()
    {
        Debug.Log("init complete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"init failed, {error} {message}");
    }
    #endregion

    #region Load
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log($"load complete {placementId}");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError($"load failed {placementId}, {error}, {message}");
    }
    #endregion

    #region Show
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("ad show fail");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("ad show start");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("ad show click");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if(showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            GetReward();
        }
    }
    #endregion

    #region Rewarded

    [ContextMenu("Show Rewarded")]
    public void ShowRewarded()
    {
        StartCoroutine(ShowRewardedCoroutine());
    }

    public IEnumerator ShowRewardedCoroutine()
    {
        Advertisement.Load(REWARDED_ID, this);
        yield return new WaitForSeconds(1f);
        Advertisement.Show(REWARDED_ID, this);
    }

    [ContextMenu("Load Rewarded")]
    public void LoadRewarded()
    {
        Advertisement.Load(REWARDED_ID, this);
    }

    private void GetReward()
    {
        Debug.Log("Reward acquired!");
    }
    #endregion

    #region Banner
    [ContextMenu("Show Banner")]
    public void ShowBanner()
    {
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        BannerLoadOptions bannerLoadOptions = new()
        {
            loadCallback = () =>
            {
                BannerOptions bannerOptions = new()
                {
                    clickCallback = () => Debug.Log("clicked"),
                    showCallback = () => Debug.Log("showed"),
                    hideCallback = () => Debug.Log("hid")
                };
                Advertisement.Banner.Show(BANNER_ID, bannerOptions);
            },
            errorCallback = msg => Debug.Log("banner fail")
        };
        Advertisement.Banner.Load(BANNER_ID, bannerLoadOptions);
    }

    [ContextMenu("Hide Banner")]
    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }
    #endregion
}
