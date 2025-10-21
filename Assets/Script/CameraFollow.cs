using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // O objeto que a câmera vai seguir
    public Vector3 offset = new Vector3(0, 5, -10); // Offset fixo da câmera em relação ao alvo

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcula a posição desejada ignorando a rotação do objeto alvo
            Vector3 desiredPosition = target.position + offset;

            // Move a câmera para a posição desejada
            transform.position = desiredPosition;
        }
    }
}
