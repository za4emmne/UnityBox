using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//Пример на появлении и пропадании монетки, при соприкосновении с ней:
public class PlayerUpCoin : MonoBehaviour
{
    [SerializeField] private UnityEvent _getCoin;
    [SerializeField] private float _waitSecondToDestoryCoin = 0.3f;
    [SerializeField] private float _waitSecondToReturnCoin;

    private void OnTriggerEnter2D(Collider2D collision) //если игрок входит в коллайдер(а именно триггер) монетки
    {
        if (collision.TryGetComponent(out Coin coin)) //проверяем что это именно монетка(на объекте находиться скрипт Coin)
        {
            {
                _getCoin.Invoke(); // можно добавить звук или эффект
                StartCoroutine(DestroyCoin(coin.gameObject));
            }
        }

        private IEnumerator DestroyCoin(GameObject coin) //корутина, принимает объект монетки
        {
            float MinSecondToReturn = 3;
            float MaxSecontToReturn = 10;
            _waitSecondToReturnCoin = Random.Range(MinSecondToReturn, MaxSecontToReturn);

            var waitForSecond = new WaitForSeconds(_waitSecondToDestoryCoin); //время ожидания
            yield return waitForSecond;
            coin.SetActive(false);
            var waitForSecondToReturn = new WaitForSeconds(_waitSecondToReturnCoin);
            yield return waitForSecondToReturn;
            coin.SetActive(true);
        }
    }