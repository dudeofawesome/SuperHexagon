INSTRUCTIONS
--------------------------------
There are 3 ways to enter Android's immersive mode:

1. Use the ImmersiveMode script OR prefab.
   Your game will enter immersive mode as soon as the scene starts.
   Place the immersive mode script/prefab in your startup scene.

2. Enter immersive mode programmatically.
   Your game will enter immersive mode whenever you want.
   Call this method: ImmersiveMode.AddCurrentActivity().

3. Use the manifest that came with this package.
   Your game will enter immersive mode even before the splash screen!
   Drag AndroidManifest.xml from the documentation to: Plugins/Android/.
   If you're using another Android plugin, this may not work.
   See the comments in the manifest file for more details.
   
To exit immersive mode, call this method: ImmersiveMode.Clear().
There are more methods you can call, see ImmersiveMode script.



DESCRIPTION
--------------------------------
This package enables the Android Immersive Mode that was introduced in Android 4.4.
This mode allows your Unity game to run full-screen on Android devices, hiding the stock navigation bar.
With this package, you can enter and exit the immersive mode whenever you want.

There is a free demo available on the Play Store: https://play.google.com/store/apps/details?id=com.ruudlenders.immersivemode

Android devices with an API level lower than 19 (4.4) will be able to run your Unity game using this package, just not in immersive mode.
This package works without a manifest, meaning that it is highly compatible with other Android plugins.



CONTACT
--------------------------------
For all your questions and problems, feel free to send an email to: rmwlenders@gmail.com
Or discuss it at the forum: http://forum.unity3d.com/threads/released-immersive-mode-for-android.244659/#post-1618183

If this plugin helped you, please write a review so other developers can see, thanks!
Asset store page: https://www.assetstore.unity3d.com/en/#!/content/16852