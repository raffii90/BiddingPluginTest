using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class EditorStartUp {
	static EditorStartUp()
	{
		PlayerPrefs.DeleteKey("IsBiddingPluginInitialized");
	}
}
