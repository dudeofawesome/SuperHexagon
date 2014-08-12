using UnityEngine;
using System.Collections;

public class ImmersiveModeDemo : MonoBehaviour
{
    public Font font;
    public string text = "IMMERSIVE\nCONTENT";

    private GUIStyle style;
    private bool isImmersive;
    private float touchSqrMagnitude, touchTime;
#if (UNITY_IPHONE || UNITY_ANDROID || UNITY_BLACKBERRY || UNITY_WINRT) && !UNITY_EDITOR && !UNITY_3_3 && !UNITY_3_4
    private TouchScreenKeyboard keyboard;
#endif

    void Awake()
    {
        style = new GUIStyle();
        style.alignment = TextAnchor.MiddleCenter;
        style.font = font;
        style.normal.textColor = new Color(255 / 255f, 188 / 255f, 52 / 255f);
        style.wordWrap = true;

        foreach (var guiText in GetComponentsInChildren<GUIText>())
        {
#if !UNITY_3_3 && !UNITY_3_4 && !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_0_1 && !UNITY_4_1
            guiText.color = style.normal.textColor;
#else
            guiText.material.color = style.normal.textColor;
#endif

#if (UNITY_IPHONE || UNITY_ANDROID || UNITY_BLACKBERRY || UNITY_WINRT) && !UNITY_EDITOR
            if (guiText.text.ToLower().Contains("keyboard"))
            {
#if !UNITY_3_3 && !UNITY_3_4
                guiText.enabled = true;
#endif
            }
            else
            {
                guiText.enabled = true;
            }
#endif
        }
    }

    void Start()
    {
        isImmersive = ImmersiveMode.ContainsCurrentActivity();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            touchSqrMagnitude += touch.deltaPosition.sqrMagnitude;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchTime = Time.time;
                    break;

                case TouchPhase.Ended:
                    if (touchSqrMagnitude < 10f && (touchTime == 0 || Time.time - touchTime < 0.5f))
                    {
                        if (Input.GetTouch(0).position.y > Screen.height / 2f)
                        {
#if (UNITY_IPHONE || UNITY_ANDROID || UNITY_BLACKBERRY || UNITY_WINRT) && !UNITY_EDITOR && !UNITY_3_3 && !UNITY_3_4
                            keyboard = TouchScreenKeyboard.Open(text, TouchScreenKeyboardType.ASCIICapable, false, true, false, false, string.Empty);
#endif
                        }
                        else if (isImmersive)
                        {
                            ImmersiveMode.Clear();
                            isImmersive = false;
                        }
                        else
                        {
                            ImmersiveMode.AddCurrentActivity();
                            isImmersive = true;
                        }
                    }

                    touchSqrMagnitude = 0;
                    touchTime = 0;
                    break;
            }
        }
    }

    void OnDestroy()
    {
        ImmersiveMode.Clear();
        isImmersive = false;
    }

    void OnGUI()
    {
        style.fontSize = Mathf.Min(Screen.width, Screen.height) / 7;

        foreach (var guiText in GetComponentsInChildren<GUIText>())
        {
            guiText.fontSize = style.fontSize / 3;
        }

#if (UNITY_IPHONE || UNITY_ANDROID || UNITY_BLACKBERRY || UNITY_WINRT) && !UNITY_EDITOR && !UNITY_3_3 && !UNITY_3_4
        if (keyboard != null)
        {
            text = keyboard.text.Trim();
        }
#endif

        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), text, style);
    }
}
