using System.Collections;
using UnityEngine;
using DG.Tweening;

public class PlayerParticleController : MonoBehaviour
{
    #region Singleton
    public static PlayerParticleController instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] private ParticleSystem[] particles;

    public void PlayParticle(int particleIndex)
    {
        StartCoroutine(ParticleCo(particleIndex));
    }
    IEnumerator ParticleCo(int particleIndex)
    {
        yield return new WaitForSeconds(.1f);
        if (transform.childCount > particleIndex && particles[particleIndex] != null)
        {
            var particleImg = particles[particleIndex].transform.GetChild(1).gameObject;
            particles[particleIndex].Play();
            particleImg.SetActive(true);
            particleImg.transform.DOPunchScale(new Vector3(.1f, .1f, .1f), 1f,1,1);
            yield return new WaitForSeconds(1);
            particleImg.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Particles out of range");
        }
    }


}
