using BepInEx;
using UnityEngine;
using BepInEx.Logging;

namespace UCNVG
{
    [BepInPlugin("com.kobrakon.UCNVG", "UCNVG", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        internal static ManualLogSource logger;
        private void Awake()
        {
            logger = Logger;
            new UCNVGPatch().Enable();
            new UCNVGThermPatch().Enable();
        }
    }
}