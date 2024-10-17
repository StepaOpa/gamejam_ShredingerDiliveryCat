using UnityEngine;

public class PackageDropOff : MonoBehaviour
{
    [SerializeField] private Transform backpack;   // ������ Backpack �� ���������
    [SerializeField] private Transform dropOffPoint; // ������� ����� ��� ����������� �� �����
    [SerializeField] private Vector3 packageOffset = Vector3.zero; // �������� �� ����� (�����������)

    private Transform package;  // ������, ������� ����� ������ �������������

    // �����������, ����� �������� ������ � �������-����
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindAndDetachPackage();
        }
    }

    // ����� ��� ������ � ����������� ������� package �� �����
    private void FindAndDetachPackage()
    {
        // ���� package ������ ������� (������������, ��� ��� ������������ ��� �������� ������)
        if (backpack.childCount > 0)
        {
            package = backpack.GetChild(0); // ������������, ��� package - ������ ������ � �������

            if (dropOffPoint != null && package != null)
            {
                package.SetParent(null); // ������� ������ �� �������� Backpack
                package.position = dropOffPoint.position + packageOffset; // ���������� �� ������� ������� �� �����
                package.rotation = Quaternion.identity; // ����� �������� (���� ���������)
            }
        }
        else
        {
            Debug.Log("No package found in the backpack.");
        }
    }
}
