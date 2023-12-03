using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlayer : MonoBehaviour
{
    UnityEngine.Video.VideoPlayer v;
    private GameObject video;


    // Start is called before the first frame update
    void Start()
    {

        video= GameObject.Find("Plane");

         v = video.GetComponent<UnityEngine.Video.VideoPlayer>();
         v.frame = 0;
   }

 public void PlayCurrutina()
    {
        StartCoroutine(playPauseVideo());
    }


IEnumerator playPauseVideo(){
    v.Prepare();
    while (!v.isPrepared){
        yield return null;
    }
    if(v.isPlaying){
        v.Pause();
    }else{
        v.Play();
    }
    yield return null;
}

public void RetrocederAlPrincipio()
    {
        if (v != null)
        {
            v.frame = 0; // Retrocede al primer fotograma del video
            v.Play(); // Inicia la reproducción desde el principio
        }
    }


    
}