
using UnityEngine;

public class BigLaserController : MonoBehaviour
{
    // Parametros para el ataque laser
    public Transform laserFirePoint;
    public Transform finalLaserDestiny;
    public Transform finalPointLaserDestiny;

    public Vector3 initialFinalLaserDestiny;
    private Vector3 initialFinalPointLaserDestiny;
    public LayerMask layerMask;

    [SerializeField] private float defDistanceRay = 100;
    private LineRenderer m_lineRenderer;

    public bool canStartMovingLaser;

    private void Awake()
    {
        m_lineRenderer = GetComponent<LineRenderer>();
        initialFinalLaserDestiny = finalLaserDestiny.position;
        initialFinalPointLaserDestiny = finalPointLaserDestiny.position;
        canStartMovingLaser = false;
    }

    private void Start()
    {
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
        if (Physics2D.Raycast(transform.position, -direction, defDistanceRay, layerMask))
        {
            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, -direction, defDistanceRay, layerMask);

            if (_hit.collider.gameObject.layer == 3)
            {
                _hit.collider.gameObject.GetComponent<CharacterController2D>().takedamage(1);
            }
            Drawn2DRay(laserFirePoint.position, _hit.point);
        } else
        {
            Drawn2DRay(laserFirePoint.position, -direction * defDistanceRay);
        }
    }

    void MoveLaser()
    {
        if (canStartMovingLaser)
        {
            finalLaserDestiny.position = Vector2.MoveTowards(finalLaserDestiny.position, initialFinalPointLaserDestiny, 20 * Time.deltaTime);

            if (finalLaserDestiny.position == initialFinalPointLaserDestiny)
            {
                initialFinalPointLaserDestiny = initialFinalLaserDestiny;
            }
        }
    }

    void Drawn2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }

    public void ResetPosition()
    {
        finalLaserDestiny.position = initialFinalLaserDestiny;
        initialFinalPointLaserDestiny = finalPointLaserDestiny.position;
    }

    public void setMovingLaser(bool canMoving)
    {
        canStartMovingLaser = canMoving;
    }
}
