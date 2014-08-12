using UnityEngine;
using System.Collections;

/// <summary>
/// Drag this script onto anything in your startup scene.
/// It will make your Android game enter immersive mode.
/// 
/// This package also comes with a prefab that uses this script.
/// 
/// You don't have to place this script in your scene
/// if you're using the included manifest file.
/// See readme.txt for more information.
/// </summary>
public class ImmersiveModeInitializer : MonoBehaviour
{
    void Awake()
    {
        ImmersiveMode.AddCurrentActivity();
    }
}
