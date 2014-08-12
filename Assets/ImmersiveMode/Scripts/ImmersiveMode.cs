using UnityEngine;
using System.Collections;

public static class ImmersiveMode
{
#if UNITY_ANDROID && !UNITY_EDITOR
    /// <summary>
    /// Contains a reference to the associated Android/Java class.
    /// </summary>
    public static AndroidJavaClass AJC { get; private set; }

    /// <summary>
    /// Obtains a reference to the associated Android/Java class.
    /// </summary>
    static ImmersiveMode()
    {
		try { AJC = new AndroidJavaClass("com.ruudlenders.immersivemode.ImmersiveMode"); }
		catch { AJC = null; }
    }

    /// <summary>
    /// Adds an activity to make it enter full-screen mode.
    /// </summary>
    public static bool Add(AndroidJavaObject activity)
    {
        return AJC != null && AJC.CallStatic<bool>("add", activity);
    }

    /// <summary>
    /// Checks if an activity has entered full-screen mode.
    /// </summary>
    public static bool Contains(AndroidJavaObject activity)
    {
        return AJC != null && AJC.CallStatic<bool>("contains", activity);
    }
    
    /// <summary>
    /// Removes an activity to make it exit full-screen mode.
    /// </summary>
    public static bool Remove(AndroidJavaObject activity)
    {
        return AJC != null && AJC.CallStatic<bool>("remove", activity);
    }
#endif

    /// <summary>
    /// Adds the current activity to make it enter full-screen mode.
    /// </summary>
    public static bool AddCurrentActivity()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return AJC != null && AJC.CallStatic<bool>("addCurrentActivity");
#else
        return false;
#endif
    }

    /// <summary>
    /// Removes all activities to make them exit full-screen mode.
    /// </summary>
    public static bool Clear()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return AJC != null && AJC.CallStatic<bool>("clear");
#else
        return false;
#endif
    }

    /// <summary>
    /// Checks if the current activity has entered full-screen mode.
    /// </summary>
    public static bool ContainsCurrentActivity()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return AJC != null && AJC.CallStatic<bool>("containsCurrentActivity");
#else
        return false;
#endif
    }

    /// <summary>
    /// Checks if the device has a specific physical key.
    /// Home: 3, Back: 4, Camera: 27, Menu: 82, Search: 84.
    /// See Android documentation for all key codes:
    /// http://developer.android.com/reference/android/view/KeyEvent.html
    /// </summary>
    public static bool DeviceHasKey(int keyCode)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return AJC != null && AJC.CallStatic<bool>("deviceHasKey", keyCode);
#else
        return false;
#endif
    }

    /// <summary>
    /// Removes the current activity to make it exit full-screen mode.
    /// </summary>
    public static bool RemoveCurrentActivity()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return AJC != null && AJC.CallStatic<bool>("removeCurrentActivity");
#else
        return false;
#endif
    }
}
