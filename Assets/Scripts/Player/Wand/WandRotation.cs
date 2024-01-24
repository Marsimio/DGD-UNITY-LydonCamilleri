using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class WandRotation : MonoBehaviour
{
    public float continuousFireRate = 1.0f;
    private bool canFire = true;
    public Coroutine continuousFireCoroutine;
    public ObjectPooling objectPool;
    public GameObject wandTip;

    private void OnEnable()
    {
        StartCoroutine(SwapDelay());
    }

    void Update()
    {
        PointAtMouse();
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            if (continuousFireCoroutine == null)
            {
                continuousFireCoroutine = StartCoroutine(ContinuousFiring(objectPool));
            }
        }

        else if (Input.GetMouseButtonUp(0))
        {
            if (continuousFireCoroutine != null)
            {
                StopCoroutine(continuousFireCoroutine);
                continuousFireCoroutine = null;
            }
        }
    }

    void PointAtMouse()
    {
        Quaternion newrotation = Quaternion.LookRotation(this.transform.position - GameData.MousePos, Vector3.forward);
        newrotation.x = 0;
        newrotation.y = 0;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, newrotation, Time.deltaTime * 50f);
    }

    IEnumerator ContinuousFiring(ObjectPooling myObjectPool)
    {
        while (true)
        {
            if (canFire)
            {
                GameObject projectile = myObjectPool.GetPooledObject();
                StartCoroutine(FiringSequence(projectile));
            }
            yield return new WaitForSeconds(continuousFireRate);
        }
    }

    IEnumerator FiringSequence(GameObject projectile)
    {
        if (projectile != null)
        {
            canFire = false;

            Vector3 newPosition = wandTip.transform.position;
            projectile.transform.position = newPosition;
            projectile.transform.rotation = wandTip.transform.rotation;
            projectile.SetActive(true);

            yield return new WaitForSeconds(continuousFireRate);

            canFire = true;
        }

    }
    IEnumerator SwapDelay()
    {
        yield return new WaitForSeconds(0.1f);
        canFire = true;
    }
}
