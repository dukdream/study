using UnityEngine;
using UnityEngine. Video; // VideoPlayer 기능을 사용하기 위한 네임스페이스

// 360 스피어에 비디오 플레이어를 통해 영상을 재생한다.
// 두 가지 서로 다른 영상을 교체하며 재생한다.
public class Video360Play : MonoBehaviour
{
    // 비디오 플레이어 컴포넌트
    VideoPlayer vp;
    // 재생해야 할 VR 360 영상을 위한 설정
    public VideoClip[] vcList; // 다수의 비디오 클립을 배열로 만들어 관리한다.
    int curVCidx; // 현재 재생 중인 클립 리스트 번호를 저장한다.

    void Start()
    {
        // 비디오 플레이어 컴포넌트의 정보를 받아온다.
        vp = GetComponent<VideoPlayer>();
        vp.clip = vcList[0];
        curVCidx = 0;
        vp.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // 컴퓨터에서 영상을 변경하기 위한 기능
        if (Input.GetKeyDown(KeyCode.LeftBracket)) // 왼쪽 대괄호 입력 시 이전 영상
        {
            vp.clip = vcList[0];
        }
        else if (Input.GetKeyDown(KeyCode.RightBracket))// 오른쪽 대괄호 입력 시 이전 영상
        {
            vp.clip = vcList[1];
        }

    }

    public void SwapVideoClip(bool isNext)
    {
        // 현재 재생 중인 영상의 넘버를 기준으로 체크한다.
        // 이전 영상 번호는 현재 영상보다 배열에서 인덱스 번호가 1이 작다.
        // 다음 영상 번호는 현재 영상보다 배열에서 인덱스 번호가 1이 크다.
        int setVCnum = curVCidx;             // 현재 재생 중인 영상의 넘버를 입력한다.
        vp.Stop();                                   // 현재 재생 중인 비디오 클립을 중지한다.
        // 재생될 영상을 고르기 위한 과정
        if (isNext)         // isNext 변수가 참이라면 리스트의 다음 영상을 재생한다.
        {
            setVCnum = (setVCnum + 1) % vcList.Length;
        }
        else
        {
            setVCnum = ((setVCnum - 1) + vcList.Length) % vcList.Length;
        }
        vp.clip = vcList[setVCnum];                   // 클립을 변경한다.
        vp.Play();                                    // 바뀐 클립을 재생한다.
        curVCidx = setVCnum;                          // 바뀐 클립의 영상의 번호를 업데이트한다.
    }

    public void SetVideoPlay(int num)
    {
        // 현재 재생 중인 번호가 전달받은 번호와 다를 때만 실행한다.
        if (curVCidx != num)
        {
            vp.Stop();                     // 영상을 멈춘다
            vp.clip = vcList[num];         // 클립을 변경한다. 
            curVCidx = num;                // 현재 재생 중인 번호를 수정한다
            vp.Play();                     // 재생한다.
        }

    }
}

