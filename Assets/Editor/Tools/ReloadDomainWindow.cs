using UnityEngine;
using UnityEditor;

public class EditorTools : EditorWindow
{
    [MenuItem("Tools/Editor Tools")]
    public static void ShowWindow()
    {
        GetWindow<EditorTools>("Editor Tools");
    }

    private void OnGUI()
    {
        GUILayout.Label("Reload Domain", EditorStyles.boldLabel);

        bool isReloadDomainEnabled = EditorSettings.enterPlayModeOptionsEnabled;
        string buttonText = isReloadDomainEnabled ? "Reload Domain is Disabled" : "Reload Domain is Enabled";

        if (GUILayout.Button(buttonText))
        {
            ToggleReloadDomain();
        }
    }

    private void ToggleReloadDomain()
    {
        bool newState = !EditorSettings.enterPlayModeOptionsEnabled;
        EditorSettings.enterPlayModeOptionsEnabled = newState;

        EditorSettings.enterPlayModeOptions = newState
            ? EnterPlayModeOptions.DisableDomainReload | EnterPlayModeOptions.DisableSceneReload
            : EnterPlayModeOptions.None;

        Debug.Log($"Reload Domain: {(newState ? "OFF" : "ON")}");
    }
}

