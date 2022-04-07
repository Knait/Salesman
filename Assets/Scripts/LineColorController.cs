
/// ����� ������ ����� �� ����� ����������
/// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineColorController : MonoBehaviour
{
    [SerializeField]
    [Header("������ ������� ������")]
    private ParticleSystem[] ParticleSys;

    /// <summary>
    /// ID �������� ������
    /// </summary>
    [SerializeField]
    private int IDMaterialClothes;

    private void OnTriggerEnter(Collider other)
    {
        HeroController heroController = other.gameObject.GetComponent<HeroController>();

        if (heroController)
        {
            ///print(" Color Clothes");  /////////////////////////////////////////////////////
            heroController.PaintingClothes(IDMaterialClothes);

            for (int index = 0; index < ParticleSys.Length; index++)
            {
                if (ParticleSys[index])
                {
                    //print(" Particle Play " + index);
                    ParticleSys[index].Play();
                }
            }

        }
    }

}
