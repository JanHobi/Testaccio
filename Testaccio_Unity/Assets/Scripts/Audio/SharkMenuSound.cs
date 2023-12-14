using System.Collections;
using FMODUnity;
using UnityEngine;

namespace Audio
{
    public class SharkMenuSound : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SharkSoundRoutine());
        }

        IEnumerator SharkSoundRoutine()
        {
            yield return new WaitForSeconds(1.7f);
            
            while (true)
            {
                Vector3 sharkPos = transform.position;
                RuntimeManager.PlayOneShot("event:/Sound/SharkMenu", sharkPos);
                
                yield return new WaitForSeconds(3.7f);
            }
        }
    }
}
