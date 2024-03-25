using UnityEngine;
//��������� � �������� � ��������
public class BotMovement : MonoBehaviour
{
    private Resourse _resourse;
    private bool _isHandsBusy = false;

    private void OnCollisionEnter(Collision collision) //� ��������� ����� ������ �����������, ��� ������� ����, ����� ����� �� ����� ������� ���
        //rigidbody dynamic
    {
        if (collision.collider.TryGetComponent(out Resourse resourse)) //��������, ���� �� �� ������� � ������� �� ����������� ������ Resourse
        {
            Destroy(resourse.gameObject);
            _isHandsBusy = true;
        }
    }

    private void OnTriggerEnter(Collider other) //� ������� ����� �����, �� �� �������
    {
        if(other.TryGetComponent<Baza>(out Baza baza))  //��������, ���� �� �� ������� � ������� �� ����������� ������ Baza
        {
            _isHandsBusy = false;
        }
    }
}
