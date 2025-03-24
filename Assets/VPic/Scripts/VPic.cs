using la.niri.VPic.Scripts.Infra;
using la.niri.VPic.Scripts.Usercase;
using UnityEngine;

namespace Assets.VPic.Scripts
{
    public class VPic : MonoBehaviour
    {
        [SerializeField] private string path;
        [SerializeField] private UserVRMLoader userVRMLoader;
        [SerializeField] private GameObject respawn;
        [SerializeField] private VPicUserInput vPicUserInput;
        [SerializeField] private GameObject camera;
        [SerializeField] private Animator animator;

        public async void Start()
        {
            var avatar = await userVRMLoader.LoadAvatar(path);
            avatar.Instance.gameObject.transform.position = respawn.transform.position;
            avatar.Instance.gameObject.transform.rotation = respawn.transform.rotation;
            vPicUserInput.SetAvatar(avatar);
            camera.gameObject.transform.SetParent(avatar.Instance.gameObject.transform);
        }
        
    }
}