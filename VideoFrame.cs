using UnityEngine;
using UnityEngine.Video;    // VideoPlayer 기능을 사용하기 위한 네임스페이스
// Video Player 컴포넌트를 제어하자!
public class VideoFrame : MonoBehaviour
{
    // Video Player 컴포넌트
    VideoPlayer vp;

    // Start is called before the first frame update
    void Start()
    {
        // 현재 오브젝트의 비디오 플레이어 컴포넌트 정보를 가지고 온다.
        vp = GetComponent<VideoPlayer>();
        // 자동 재생되는 것을 막는다.
        vp.Stop();

        // … 생략 …

    }
        // Update is called once per frame
        void Update()
        {
        // S를 누르면 정지하라.
        if(Input.GetKeyDown(KeyCode.S))
            { vp.Stop(); 
        }
            // 스페이스 바를 눌렀을 때 재생 또는 일시 정지를 하라.
            if(Input.GetKeyDown("space"))
        { 
            // 현재 비디오 플레이어가 플레이 상태인지 확인하라.
            if(vp.isPlaying)
            {
                // 플레이(재생) 중이라면 일시 정지하라.
                vp.Pause();
               }else
               {
                    // 그렇지 않다면(일시 정지 중 또는 멈춤) 플레이(재생)하라,
                    vp.Play();
                }
            }
    }
}
