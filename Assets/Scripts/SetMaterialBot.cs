
/// �� ���� 
/// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaterialBot : MonoBehaviour
{
    //[Header("������ �� ������ �������")]
    //[SerializeField]
    //private Transform skinModel;

    /// <summary>
    /// ������� ID ����� ����
    /// </summary>
    //[HideInInspector]
    public int IDMaterialClothes;

    private void OnEnable()
    {
        IDMaterialClothes = Random.Range(1, 5);
    }

}
