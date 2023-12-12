using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//������ �� ��������� � ���������� �������, ��� ��������������� � ���:
public class PlayerUpCoin : MonoBehaviour
{
    [SerializeField] private UnityEvent _getCoin;
    [SerializeField] private float _waitSecondToDestoryCoin = 0.3f;
    [SerializeField] private float _waitSecondToReturnCoin;

    private void OnTriggerEnter2D(Collider2D collision) //���� ����� ������ � ���������(� ������ �������) �������
    {
        if (collision.TryGetComponent(out Coin coin)) //��������� ��� ��� ������ �������(�� ������� ���������� ������ Coin)
        {
            {
                _getCoin.Invoke(); // ����� �������� ���� ��� ������
                StartCoroutine(DestroyCoin(coin.gameObject));
            }
        }

        private IEnumerator DestroyCoin(GameObject coin) //��������, ��������� ������ �������
        {
            float MinSecondToReturn = 3;
            float MaxSecontToReturn = 10;
            _waitSecondToReturnCoin = Random.Range(MinSecondToReturn, MaxSecontToReturn);

            var waitForSecond = new WaitForSeconds(_waitSecondToDestoryCoin); //����� ��������
            yield return waitForSecond;
            coin.SetActive(false);
            var waitForSecondToReturn = new WaitForSeconds(_waitSecondToReturnCoin);
            yield return waitForSecondToReturn;
            coin.SetActive(true);
        }
    }