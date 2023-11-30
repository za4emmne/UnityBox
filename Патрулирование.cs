//������ �������������� ��������, �� �������� ������ ����������
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //1. � ���������� ��������� ������� ������ �������, ������� ����� �������� ������� ���������� � ��������� �� � ���� ����������

    [SerializeField] private Transform _path; //���� ���������� - ��� ������������ ������ �� ��������� � ������ ����������
    [SerializeField] private Transform[] _points; //����� ���������� 
    [SerializeField] private float _speed; //�������� �������� �������

    private int _currentPoint; //��������� ����� � �������� ��������


    void Start()
    {
        _points = new Transform[_path.childCount]; //2. ��������� ��� ����� ���������� � ������ �����

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    void Update()
    {
        Transform target = _points[_currentPoint]; //3. ����������� ���������� �������� ��������� ����� ����������
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime); //4. ���������� � ���� �����

        if (transform.position == target.position) //5. ���� �������� ����, �������� ��������� ����� �� �������
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length) //6. ���� ����� �� ����� �������, ��������� � ������ �����
            {
                _currentPoint = 0;
            }
        }
    }
}
