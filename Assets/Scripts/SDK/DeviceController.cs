using System.Runtime.InteropServices;
using UnityEngine;

public class DeviceController : MonoBehaviour
{
    public static DeviceController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    [DllImport("__Internal")]
    public static extern bool IsMobileDevice();

    public static bool IsEditor()
    {
#if UNITY_EDITOR
        return true;
#else
        return false;
#endif
    }

    public static DeviceType GetDevice()
    {
        if (IsEditor()) return DeviceType.Editor;

        if (IsMobileDevice())
        {
            return DeviceType.MobileWebGL;
        }

        return DeviceType.PCWebGl;
    }

    public static bool IsTypeMobile()
    {
        return GetDevice() == DeviceType.MobileWebGL;
    }
}

public enum DeviceType
{
    Editor,
    PCWebGl,
    MobileWebGL
}

