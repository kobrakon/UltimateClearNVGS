using UnityEngine;
using BSG.CameraEffects;
using Aki.Reflection.Patching;
using System.Reflection;

namespace UCNVG
{
    public class UCNVGPatch : ModulePatch
    {
         protected override MethodBase GetTargetMethod()
         {
            var result = typeof(NightVision).GetMethod("method_1", BindingFlags.Instance | BindingFlags.NonPublic);
            return result;
         }

         [PatchPostfix]
         static void Postfix()
         {
            var cam = GameObject.Find("FPS Camera");

            var nv = cam.GetComponent<NightVision>();

            bool On = nv.On;

            var mask = cam.GetComponent<TextureMask>();
            
            var vig = cam.GetComponent<CC_Vintage>();

            if (On)
            {
                mask.enabled = false;
                vig.enabled = false;
                return;
            }
            else
                vig.enabled = true;
            return;
         }
    }

    public class UCNVGThermPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            var result = typeof(ThermalVision).GetMethod("method_1", BindingFlags.Instance | BindingFlags.NonPublic);
            return result;
        }

        [PatchPostfix]
        static void PostFix()
        {
            var cam = GameObject.Find("FPS Camera");

            var th = cam.GetComponent<ThermalVision>();

            bool On = th.On;

            th.IsNoisy = false;
            th.IsPixelated = false;
            th.IsMotionBlurred = false;

            var mask = cam.GetComponent<TextureMask>();

            var vig = cam.GetComponent<CC_Vintage>();

            if (On)
            {
                mask.enabled = false;
                vig.enabled = false;
                return;
            }
            else
                vig.enabled = true;
            return;
        }
    }
}
