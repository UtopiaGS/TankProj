using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class FireBullet : MonoBehaviour
{
    public InputActionReference fire;
    public Transform aimPosition;
    public GameObject bullet;
    public ParticleSystem particle;
  

    private void OnEnable()
    {
        fire.action.started += Fire;
    }
    private void OnDisable()
    {
        fire.action.started -= Fire;
    }
    private void Fire(InputAction.CallbackContext obj)
    {
      
        var particleSmoke = Instantiate(particle, aimPosition.position, aimPosition.rotation);
        particleSmoke.Play();
        Instantiate(bullet, aimPosition.position, aimPosition.rotation);
	}
}
