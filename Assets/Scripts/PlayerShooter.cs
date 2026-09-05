using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [Header("Gun Settings")]
    public float damage = 25f;       // Bawas sa health kada baril
    public float range = 100f;       // Gaano kalayo aabot ang bala
    public float fireRate = 0.2f;    // Gaano kabilis pwedeng bumaril ulit (seconds)
    
    private float nextFireTime = 0f; // Timer para sa fire rate

    [Header("References")]
    public Camera playerCamera;      // Ang camera na gagamitin bilang paningin (crosshair)

    void Update()
    {
        // Kapag pinindot ang Left Mouse Button (Fire1) at pwede nang bumaril ulit
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        // Gumagawa ng Ray mula sa gitna ng camera papunta sa harap
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));

        // Sine-check kung may tinamaan ang Raycast sa loob ng 'range'
        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            // Para makita sa console kung ano ang tinamaan
            Debug.Log("Binaril ang: " + hit.transform.name);

            // Kinukuha ang TrainingDummy script sa object na tinamaan
            TrainingDummy target = hit.transform.GetComponent<TrainingDummy>();

            // Kung may TrainingDummy script yung object, babawasan ng health
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            
            // Dito mo pwedeng ilagay ang Particle Effects (e.g., spark sa pader) gamit ang hit.point at hit.normal
        }
    }
}