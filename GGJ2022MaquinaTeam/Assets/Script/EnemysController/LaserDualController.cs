using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDualController : MonoBehaviour
{
    // Parametros para el ataque laser
    public Transform laserFirePoint;
    public Transform finalLaserDestiny;
    public float speed = 10;

    [SerializeField] private float defDistanceRay = 100;
    private LineRenderer m_lineRenderer;

    public bool canStartMovingLaser;

    private void Awake()
    {
        m_lineRenderer = GetComponent<LineRenderer>();
        canStartMovingLaser = true;
    }

    // Update is called once per frame
    void Update()
    {
        ShootLaser();
        MoveLaser();
    }

    void ShootLaser()
    {
        Vector3 direction = (laserFirePoint.position - finalLaserDestiny.position).normalized;
        if (Physics2D.Raycast(transform.position, -direction))
        {
            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, -direction);
            Drawn2DRay(laserFirePoint.position, _hit.point);
        }
        else
        {
            Drawn2DRay(laserFirePoint.position, -direction * defDistanceRay);
        }
    }

    void MoveLaser()
    {
        if (canStartMovingLaser)
        {
            transform.Rotate(0,0,Time.deltaTime * speed);
        }
    }

    void Drawn2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }

    public void setMovingLaser(bool canMoving)
    {
        canStartMovingLaser = canMoving;
    }
}
