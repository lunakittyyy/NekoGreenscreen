using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(NekoGreenscreen.NekoGSMod), "Neko Greenscreen", "1.0.0", "lunakittyyy")]

namespace NekoGreenscreen
{
    public class NekoGSMod : MelonMod
    {
        GameObject gsObj;
        Material gsMat;

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (sceneName == "SceneSub")
            {
                if (gsObj != null && gsMat != null) { gsObj.SetActive(true); return; }
                
                LoggerInstance.Msg("making mat");
                gsMat = new Material(Shader.Find("Toon/BasicEx/Color"));
                gsMat.SetVector("_Color", new Vector4(0, 1, 0, 1));

                LoggerInstance.Msg("making go");
                gsObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Object.DontDestroyOnLoad(gsObj);
                gsObj.transform.position = new Vector3(-0.55f, 1f, -0.7f);
                gsObj.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                gsObj.transform.localScale = new Vector3(0.001f, 5f, 1f);
                
                LoggerInstance.Msg("setting go mat");
                gsObj.GetComponent<MeshRenderer>().sharedMaterial = gsMat;
                gsObj.layer = LayerMask.NameToLayer("ModelItem");
            }
            else if (gsObj != null && gsMat != null) gsObj.SetActive(false);
        }
    }
}
