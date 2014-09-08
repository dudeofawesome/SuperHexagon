using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class CardboardIntenter {

	#if UNITY_IPHONE
		[DllImport("__Internal")]
		public static extern void CallMethod ();

		[DllImport("__Internal")]
		public static extern IntPtr ReturnString ();

		[DllImport("__Internal")]
		public static extern int ReturnInt ();

		[DllImport("__Internal")]
		public static extern IntPtr CreateInstance ();

		[DllImport("__Internal")]
		public static extern int GetInstanceInt (IntPtr instanceKey);

		[DllImport("__Internal")]
		public static extern void SendUnityBridgeMessage (IntPtr objectName, IntPtr messageName, IntPtr parameterString);
	#elif UNITY_ANDROID
		public static string ReturnString () {
			AndroidJavaClass ajc = new AndroidJavaClass("dudeofawesome.UnityIntenter.Cardboard");
			return ajc.CallStatic<string>("ReturnString");
		}

		public static int ReturnInt () {
			AndroidJavaClass ajc = new AndroidJavaClass("dudeofawesome.UnityIntenter.Cardboard");
			return ajc.CallStatic<int>("ReturnInt");
		}

		public static string ReturnInstanceString () {
			AndroidJavaObject ajo = new AndroidJavaObject("dudeofawesome.UnityIntenter.Cardboard");
			return ajo.Call<string>("ReturnInstanceString");
		}

		public static int ReturnInstanceInt () {
			AndroidJavaObject ajo = new AndroidJavaObject("dudeofawesome.UnityIntenter.Cardboard");
			return ajo.Call<int>("ReturnInstanceInt");
		}
	#endif
}
