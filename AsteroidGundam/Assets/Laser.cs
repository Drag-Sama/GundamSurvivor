using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float defDistanceRay = 100;
    public LineRenderer m_LineRenderer;
    public Transform laserFirePoint;
    public Transform player;
    Transform m_Transform;

    public bool isShooting;

    private void Awake()
    {
        m_Transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (isShooting)
        {
            m_LineRenderer.enabled = true;
            ShootLaser();
        }
        else
        {
            
            m_LineRenderer.enabled = false;
        }
        
    }

    void ShootLaser()
    {
        if(Physics2D.Raycast(m_Transform.position, transform.up))
        {
            RaycastHit2D _hit = Physics2D.Raycast(m_Transform.position, transform.up);
            if(!_hit.collider.gameObject.CompareTag("Player"))
                Draw2DRay(laserFirePoint.position, _hit.point);
            else
            {
                Draw2DRay(laserFirePoint.position, player.transform.up * defDistanceRay);
            }
        }
        else
        {
            Debug.Log("damn");
            Draw2DRay(laserFirePoint.position, player.transform.up * defDistanceRay);
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_LineRenderer.SetPosition(0, startPos);
        m_LineRenderer.SetPosition(1, endPos);
    }
}
