using UnityEngine;
using DG.Tweening;

namespace Assets.GameFolders.Scripts.UI
{
    public class SceneLoadLayer : MonoBehaviour
    {
        [SerializeField]GameObject img_sceneLoad;

        #region Singleton Pattern
        public static SceneLoadLayer instance;
        private void Awake()
        {
            instance = this;
        }
        #endregion

        public void SceneLoadAnimation(bool isStart = true)
        {
            if (isStart)
            {
                img_sceneLoad.transform.localScale = new Vector2(75, 75);
                img_sceneLoad.transform.DOScale(0, 1);
            }
            else
            {
                img_sceneLoad.transform.DOScale(75, 1);
            }
        }
    }
}

