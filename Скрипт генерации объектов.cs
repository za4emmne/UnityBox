using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    [SerializeField] private GameObject[] _templates; //массив из объектов которые будем создавать
    [SerializeField] private float _minDelay; //мин задержка при создании объекта
    [SerializeField] private float _maxDelay; //макс задержка при создании объекта
    [SerializeField] private float _devationPositionY = 0; //отклонения по оси Y от точки спавна, т.е. облатсь где случайно будут появляться объекты

    private float _spawnTime;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        float minPositionY = transform.position.y - _devationPositionY; //нижняя граница области, где будут появляться объекты
        float maxPositionY = transform.position.y + _devationPositionY; //верхняя граница области, где будут появляться объекты

        while (true)
        {
            float positionY = Random.Range(minPositionY, maxPositionY); //случайная позиция, где появится новый объект
            _spawnTime = Random.Range(_minDelay, _maxDelay); //случайное время, через сколько появится объект
            var waitForSeconds = new WaitForSeconds(_spawnTime); 
            GameObject gameObject = Instantiate(_templates[Random.Range(0, _templates.Length)],
                new Vector3(transform.position.x, positionY, transform.position.z), Quaternion.identity);

            yield return waitForSeconds;
        }

    }
}
