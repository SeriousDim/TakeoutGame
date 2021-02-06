using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/* Вызывает метод диалога при соприкосновении с 
 * объектом-триггером. Приклепляется к объекту-триггеру.
 */
public class DialogTrigger : MonoBehaviour
{
    public UnityEvent dialogMethod = new UnityEvent();

    private bool collided = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "MainCollider")
        {
            transform.gameObject.SetActive(false);

            if (!collided)
            {
                collided = true;
                dialogMethod.Invoke();
            }
        }
    }
}
