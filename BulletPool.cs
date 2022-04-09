    using System.Collections.Generic;
    using UnityEngine;

	   public class BulletPool : MonoBehaviour
	   {
                public GameObject _bulletPrefab;
                public int _poolSize;

                private List<GameObject> _bulletPool;

                public void InitPool()
                {
                    _bulletPool = new List<GameObject>();
                    for (int i = 0; i < _poolSize; i++)
                    {
                        GameObject newBullet = Instantiate(_bulletPrefab);
                        _bulletPool.Add(newBullet);
                        _bulletPool[i].SetActive(false);
                     }
                }

                public GameObject GetObjFromPool(Vector3 targetPos, Quaternion rotation)
                {
                    GameObject newBullet = _bulletPool[_bulletPool.Count - 1 ];
                    newBullet.SetActive(true);
                    newBullet.transform.position = targetPos;
                    newBullet.transform.rotation = rotation;
                    _bulletPool.RemoveAt(_bulletPool.Count - 1);

                    return newBullet;
                }

                public void ReturnObjFromPool(GameObject go)
                {
                go.SetActive(false);
                _bulletPool.Add(go);
                }
        
	  }
