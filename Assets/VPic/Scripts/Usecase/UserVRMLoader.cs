using System.Threading.Tasks;
using la.niri.VPic.Scripts.Entity;
using la.niri.VPic.Scripts.Infra;
using UnityEngine;

namespace la.niri.VPic.Scripts.Usercase
{
    public class UserVRMLoader : MonoBehaviour
    {
        // [SerializeField] private string path;
        // [SerializeField] private MimiAvatarConnector connector;
        [SerializeField] private VRMShaderConverter shaderConverter;

        private VPicAvatar _avatar;
        
        public async void Start()
        {
            // var avatar = await Load(path);
            // connector.ApplyAvatar(avatar);
        }

        // public async Task<VPicAvatar> LoadAvatar()
        // {
        //     var extension = new [] {
        //         new ExtensionFilter("vrm Files", "vrm", "VRM"),
        //     };
        //     var path = StandaloneFileBrowser.OpenFilePanel("Load VRM File", "", extension,false);
        //     
        //     if (path.Length <= 0) return null;
        //     
        //     return await Load(path[0]);
        //
        // }
        
        public async Task<VPicAvatar> LoadAvatar(string path)
        {
            // var extension = new [] {
            //     new ExtensionFilter("vrm Files", "vrm", "VRM"),
            // };
            // var path = StandaloneFileBrowser.OpenFilePanel("Load VRM File", "", extension,false);
            //
            // if (path.Length <= 0) return null;
            
            return await Load(path);
        
        }

        private async Task<VPicAvatar> Load(string targetpath)
        {
            var loader = new VrmLoader(targetpath);
            _avatar = await loader.LoadModel();
            
            if (_avatar == null)
            {
                return null;
            }
            
            Debug.Log(_avatar);
            shaderConverter.ConvertVRMShaders(_avatar.Instance.gameObject);

            return _avatar;
        } 
    }
}