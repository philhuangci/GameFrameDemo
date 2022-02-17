using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityGameFramework.Runtime;
namespace Laputa
{
    public class Player : Entity
    {

        private float m_Speed = 3f;
        private float m_RotationSpeed = 0.2f;


        private CharacterController m_CharacterController;
        private Quaternion m_TargetQuaternion;

        private Vector3 m_TargetPos = Vector3.zero;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            Log.Error("Create Player");

            transform.position = ((PlayerData)userData).Position;


            m_CharacterController = GetComponentInChildren<CharacterController>();

            if (!m_CharacterController)
                Log.Error("Can not find character controller");


        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);


            //MovetoGround(elapseSeconds);
            CharacterMove(elapseSeconds);

            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Item")))
                {
                    Log.Debug("hit the object name :" + hit.collider.gameObject.name);
                    GameEntry.Event.Fire(this, BoxDestroyEventArgs.Create(hit.collider.gameObject));
                }
            }


            //if (Input.GetMouseButtonUp(0))
            //{
            //    Collider[] colliderArr = Physics.OverlapSphere(transform.position, 3, 1 << LayerMask.NameToLayer("Item"));
            //    if (colliderArr.Length > 0)
            //    {
            //        for (int i = 0; i < colliderArr.Length; i++)
            //        {
            //            Log.Debug("find the box" + colliderArr[i].gameObject.name);
            //        }
            //    }
            //}

        }

        private void MovetoGround(float elapseSeconds)
        {
            if (!m_CharacterController.isGrounded)
            {
                CachedTransform.position = CachedTransform.position + new Vector3(0, -1 * elapseSeconds * m_Speed, 0);
            }
        }


        private void CharacterMove(float elapseSeconds)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.collider.gameObject.name.Equals("Ground", System.StringComparison.CurrentCultureIgnoreCase))
                    {
                        m_TargetPos = hitInfo.point;
                        m_RotationSpeed = 0;
                    }
                }
            }
            if (m_TargetPos != Vector3.zero)
            {
                if (Vector3.Distance(m_TargetPos, CachedTransform.position) > 0.1f)
                {
                    Vector3 direction = m_TargetPos - CachedTransform.position;
                    direction = direction.normalized;
                    direction = direction * elapseSeconds * m_Speed;
                    direction.y = 0;
                    if (m_RotationSpeed <= 1)
                    {
                        m_RotationSpeed += 5.0f * elapseSeconds;
                        m_TargetQuaternion = Quaternion.LookRotation(direction);
                        transform.rotation = Quaternion.Lerp(transform.rotation, m_TargetQuaternion, m_RotationSpeed);
                    }
                    m_CharacterController.Move(direction);
                }
            }

        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, 3);
        }



    }


}



