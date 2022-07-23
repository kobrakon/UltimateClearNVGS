using BepInEx;
using UnityEngine;
using BepInEx.Logging;

namespace UCNVG
{
    [BepInPlugin("com.kobrakon.UCNVG", "UCNVG", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            new UCNVGPatch().Enable();
            new UCNVGThermPatch().Enable();
        }
    }
}
