using UnityEngine;
//¬хождение в триигеры и коллизии
public class BotMovement : MonoBehaviour
{
    private Resourse _resourse;
    private bool _isHandsBusy = false;

    private void OnCollisionEnter(Collision collision) //с коллизией можно только —“ќЋ Ќ”“№—я, это “¬≈–ƒќ≈ “≈Ћќ, важно чтобы на обоих обектах был
        //rigidbody dynamic
    {
        if (collision.collider.TryGetComponent(out Resourse resourse)) //проверка, если на на объекте с которым мы столкнулись скрипт Resourse
        {
            Destroy(resourse.gameObject);
            _isHandsBusy = true;
        }
    }

    private void OnTriggerEnter(Collider other) //в триггер можно войти, он Ќ≈ “¬≈–ƒџ…
    {
        if(other.TryGetComponent<Baza>(out Baza baza))  //проверка, если на на объекте с которым мы столкнулись скрипт Baza
        {
            _isHandsBusy = false;
        }
    }
}
