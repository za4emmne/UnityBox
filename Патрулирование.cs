//Скрипт патрулирования объектом, по заданным точкам траектории
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //1. В инспекторе необходмо создать пустые объекты, которые будут являться точками траектории и поместить их в ПУТЬ ТРАЕКТОРИИ

    [SerializeField] private Transform _path; //ПУТЬ ТРАЕКТОРИИ - это родительский объект по отношению к точкам траектории
    [SerializeField] private Transform[] _points; //точки траектории 
    [SerializeField] private float _speed; //скорость движения объекта

    private int _currentPoint; //следующая точка в маршруте движения


    void Start()
    {
        _points = new Transform[_path.childCount]; //2. Добавляем все точки траектории в массив точек

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    void Update()
    {
        Transform target = _points[_currentPoint]; //3. Присваеваем переменной значение следующей точки траектории
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime); //4. перемещаем к этой точке

        if (transform.position == target.position) //5. Если достигли цели, выбираем следующую точку из массива
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length) //6. Если дошли до конца массива, возвращем к первой точке
            {
                _currentPoint = 0;
            }
        }
    }
}
