using System.Threading.Tasks;
using la.niri.VPic.Scripts.Entity;
using UniVRM10;

namespace la.niri.VPic.Scripts.Infra
{
    public class VrmLoader
    {

        private string _path;
        
        public VrmLoader(string path)
        {
            _path = path;
        }

        public async Task<VPicAvatar> LoadModel()
        {
            var instance = await Vrm10.LoadPathAsync(_path,
                true,
                ControlRigGenerationOption.Generate,
                true);
            if (instance == null)
            {
                return null;
            }
            return new VPicAvatar(instance);
        }

        public ControlRigGenerationOption ControlRigGenerationOption { get; set; }
    }
}