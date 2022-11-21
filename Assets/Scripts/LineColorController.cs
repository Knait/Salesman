using UnityEngine;

/// <summary>
///������ ����� �� ����� ����������
/// </summary>
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
            bool isPaint = heroController.PaintingClothes(IDMaterialClothes);
            if (isPaint)
            {
                for (int index = 0; index < ParticleSys.Length; index++)
                {
                    if (ParticleSys[index])
                    {
                        ParticleSys[index].Play();
                    }
                }
            }
        }
    }

}
