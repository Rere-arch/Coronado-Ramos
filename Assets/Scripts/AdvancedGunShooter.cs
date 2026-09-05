using UnityEngine;

public class AdvancedGunShooter : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 50f;
    public float fireRate = 0.2f;
    private float nextFireTime = 0f;

    [Header("Zoom Settings")]
    public Camera playerCamera; // I-drag ang iyong Camera dito sa Inspector
    public float normalFOV = 60f;
    public float zoomFOV = 30f;
    public float zoomSpeed = 10f;
    private bool isZooming = false;

    void Update()
    {
        // 1. Zoom Logic (Right Click)
        if (Input.GetMouseButton(1))
        {
            isZooming = true;
        }
        else
        {
            isZooming = false;
        }

        // Unti-unting pag-zoom in at out
        if (playerCamera != null)
        {
            float targetFOV = isZooming ? zoomFOV : normalFOV;
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, targetFOV, zoomSpeed * Time.deltaTime);
        }

        // 2. Shooting Logic (Left Click)
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // Pag-spawn ng bala
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            
            if (rb != null)
            {
                // Pagpapalipad ng bala papunta sa direksyon ng FirePoint
                rb.linearVelocity = firePoint.forward * bulletSpeed;
            }

            // Burahin ang bala matapos ang 3 segundo
            Destroy(bullet, 3f); 
        }
        else
        {
            Debug.LogWarning("Kulang ang nakalagay sa Inspector (Bullet Prefab o Fire Point)!");
        }
    }
}