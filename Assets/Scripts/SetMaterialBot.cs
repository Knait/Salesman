using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����� �� ���� 
/// </summary>
public class SetMaterialBot : MonoBehaviour
{
    /// <summary>
    /// ������� ID ����� ����
    /// </summary>
    [HideInInspector]
    public int IDMaterialClothes;

    private void OnEnable()
    {
        IDMaterialClothes = Random.Range(1, 5);
    }

}
