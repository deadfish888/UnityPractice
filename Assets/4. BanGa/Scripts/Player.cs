namespace BanGa
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        public float fireRate;
        public GameObject viewFinder;

        float m_fireRate;
        bool m_isShooted;
        GameObject m_viewFinderClone;

        private void Awake()
        {
            m_isShooted = false;
            m_fireRate = fireRate;
        }

        private void Start()
        {
            if (viewFinder)
            {
                m_viewFinderClone = Instantiate(viewFinder, Vector3.zero, Quaternion.identity);
            }
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(0) && !m_isShooted
                && !GameManager.Ins.IsOver)
            {
                Shot(mousePos);
                GameGUIManager.Ins.UpdateReloadFilled(0);
            }

            if (m_isShooted)
            {
                m_fireRate -= Time.deltaTime;
                GameGUIManager.Ins.UpdateReloadFilled(1f - m_fireRate / fireRate);
                if (m_fireRate <= 0)
                {
                    m_fireRate = fireRate;
                    m_isShooted = false;
                }
            }

            if (m_viewFinderClone)
            {
                m_viewFinderClone.transform.position = new Vector3(mousePos.x, mousePos.y);
            }
        }

        void Shot(Vector3 mousePos)
        {
            m_isShooted = true;

            Vector3 shotDir = Camera.main.transform.position - mousePos;

            shotDir.Normalize();

            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, shotDir);

            if (hits != null && hits.Length > 0)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    RaycastHit2D hit = hits[i];

                    if (hit.collider
                        && (Vector3.Distance((Vector2)hit.collider.transform.position
                        , (Vector2)mousePos) <= 0.4f))
                    {
                        Bird bird = hit.collider.GetComponent<Bird>();
                        bird.Die();
                    }
                }
            }

            AudioController.Ins.PlaySound(AudioController.Ins.shooting);
        }
    }
}