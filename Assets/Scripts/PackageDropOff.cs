using UnityEngine;

public class PackageDropOff : MonoBehaviour
{
    [SerializeField] private Transform backpack;   // Объект Backpack на персонаже
    [SerializeField] private Transform dropOffPoint; // Целевая точка для перемещения на земле
    [SerializeField] private Vector3 packageOffset = Vector3.zero; // Смещение на земле (опционально)

    private Transform package;  // Объект, который будет найден автоматически

    // Срабатывает, когда персонаж входит в триггер-зону
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindAndDetachPackage();
        }
    }

    // Метод для поиска и перемещения объекта package на землю
    private void FindAndDetachPackage()
    {
        // Ищем package внутри рюкзака (предполагаем, что это единственный или основной объект)
        if (backpack.childCount > 0)
        {
            package = backpack.GetChild(0); // Предполагаем, что package - первый объект в рюкзаке

            if (dropOffPoint != null && package != null)
            {
                package.SetParent(null); // Убираем объект из иерархии Backpack
                package.position = dropOffPoint.position + packageOffset; // Перемещаем на целевую позицию на земле
                package.rotation = Quaternion.identity; // Сброс вращения (если требуется)
            }
        }
        else
        {
            Debug.Log("No package found in the backpack.");
        }
    }
}
