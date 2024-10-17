using UnityEngine;

public class PackagePickup : MonoBehaviour
{
    [SerializeField] private Transform backpack; // ������ Backpack �� ���������
    [SerializeField] private Transform package;  // ������, ������� ����� ������������ � Backpack
    [SerializeField] private Vector3 packageOffset = Vector3.zero; // �������� ������� package ������������ Backpack

    private bool packageAttached = false; // ��������, ���������� �� ������ � �������

    // �����������, ����� �������� ������ � ������� ����
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !packageAttached)
        {
            AttachPackageToBackpack();
        }
    }

    // ����� ����������� ������� package � Backpack
    private void AttachPackageToBackpack()
    {
        if (backpack != null && package != null)
        {
            package.SetParent(backpack); // ������������� Backpack ��� �������� ��� package
            package.localPosition = packageOffset; // ������������� ������� package ������������ Backpack
            package.localRotation = Quaternion.identity; // ����� �������� ��� ����������� ����������������
            packageAttached = true; // ��������, ��� package ����������
        }
    }
}
