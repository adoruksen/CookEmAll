using UnityEngine;

namespace CookEmAll.Gameplay.Interaction_System
{
    public class CookerAnimatorController : MonoBehaviour
    {
        public void MaterialColorChange(Animator animator /*Renderer renderer*/)
        {
            animator.Play("cookerAnims");

            //var myColor = renderer.materials[1].GetColor("_EmissionColor");
            //var endColor = new Color(0.302f, 0, 0, 0);
            //renderer.materials[1].SetColor("_EmissionColor",endColor);
        }
    }
}

