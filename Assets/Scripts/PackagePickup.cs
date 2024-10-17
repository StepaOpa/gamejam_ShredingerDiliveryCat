using UnityEngine;

public class PackagePickup : MonoBehaviour
{
    [SerializeField] private Transform backpack; // Объект Backpack на персонаже
    [SerializeField] private Transform package;  // Объект, который будет перемещаться в Backpack
    [SerializeField] private Vector3 packageOffset = Vector3.zero; // Смещение объекта package относительно Backpack

    private bool packageAttached = false; // Проверка, прикреплен ли объект к рюкзаку

    // Срабатывает, когда персонаж входит в триггер зону
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !packageAttached)
        {
            AttachPackageToBackpack();
        }
    }

    // Метод перемещения объекта package в Backpack
    private void AttachPackageToBackpack()
    {
        if (backpack != null && package != null)
        {
            package.SetParent(backpack); // Устанавливаем Backpack как родителя для package
            package.localPosition = packageOffset; // Устанавливаем позицию package относительно Backpack
            package.localRotation = Quaternion.identity; // Сброс поворота для правильного позиционирования
            packageAttached = true; // Отмечаем, что package прикреплен
        }
    }
}
