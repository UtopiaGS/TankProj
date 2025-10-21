using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // O objeto que a c�mera vai seguir
    public Vector3 offset = new Vector3(0, 5, -10); // Offset fixo da c�mera em rela��o ao alvo

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcula a posi��o desejada ignorando a rota��o do objeto alvo
            Vector3 desiredPosition = target.position + offset;

            // Move a c�mera para a posi��o desejada
            transform.position = desiredPosition;
        }
    }
}
