#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace la.niri.VPic.Scripts
{
    public class VRMShaderConverter : MonoBehaviour
    {
        public void ConvertVRMShaders(GameObject root)
        {
            Renderer[] renderers = root.GetComponentsInChildren<Renderer>(true);
            foreach (Renderer renderer in renderers)
            {
                Material[] materials = renderer.sharedMaterials;
                for (int i = 0; i < materials.Length; i++)
                {
                    Material mat = materials[i];
                    if (mat == null)
                        continue;
    
                    if (mat.shader != null && mat.shader.name.Contains("VRM10/MToon10"))
                    {
                        var texture = mat.GetTexture("_MainTex");

                        Shader hdrpShader = Shader.Find("HDRP/LitTessellation");
                        if (hdrpShader != null)
                        {
                            mat.shader = hdrpShader;
                            mat.SetTexture("_BaseColorMap", texture);
                        }
                    }
                }
            }
        }
    }
}
#endif