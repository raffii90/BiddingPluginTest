using UnityEditor;
using UnityEngine;

public class CustomMenuItems {
    [MenuItem("Tools/Reset bidding plugin initialization")]
    private static void ClearBiddingPluginInitialization()
    {
        PlayerPrefs.DeleteKey("IsBiddingPluginInitialized");
    }
}
