
/// ����� ������ ����� �� ����� ����������
/// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineColorController : MonoBehaviour
{
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
        }
    }

}
