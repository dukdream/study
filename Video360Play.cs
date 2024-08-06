using UnityEngine;
using UnityEngine. Video; // VideoPlayer ����� ����ϱ� ���� ���ӽ����̽�

// 360 ���Ǿ ���� �÷��̾ ���� ������ ����Ѵ�.
// �� ���� ���� �ٸ� ������ ��ü�ϸ� ����Ѵ�.
public class Video360Play : MonoBehaviour
{
    // ���� �÷��̾� ������Ʈ
    VideoPlayer vp;
    // ����ؾ� �� VR 360 ������ ���� ����
    public VideoClip[] vcList; // �ټ��� ���� Ŭ���� �迭�� ����� �����Ѵ�.
    int curVCidx; // ���� ��� ���� Ŭ�� ����Ʈ ��ȣ�� �����Ѵ�.

    void Start()
    {
        // ���� �÷��̾� ������Ʈ�� ������ �޾ƿ´�.
        vp = GetComponent<VideoPlayer>();
        vp.clip = vcList[0];
        curVCidx = 0;
        vp.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // ��ǻ�Ϳ��� ������ �����ϱ� ���� ���
        if (Input.GetKeyDown(KeyCode.LeftBracket)) // ���� ���ȣ �Է� �� ���� ����
        {
            vp.clip = vcList[0];
        }
        else if (Input.GetKeyDown(KeyCode.RightBracket))// ������ ���ȣ �Է� �� ���� ����
        {
            vp.clip = vcList[1];
        }

    }

    public void SwapVideoClip(bool isNext)
    {
        // ���� ��� ���� ������ �ѹ��� �������� üũ�Ѵ�.
        // ���� ���� ��ȣ�� ���� ���󺸴� �迭���� �ε��� ��ȣ�� 1�� �۴�.
        // ���� ���� ��ȣ�� ���� ���󺸴� �迭���� �ε��� ��ȣ�� 1�� ũ��.
        int setVCnum = curVCidx;             // ���� ��� ���� ������ �ѹ��� �Է��Ѵ�.
        vp.Stop();                                   // ���� ��� ���� ���� Ŭ���� �����Ѵ�.
        // ����� ������ ���� ���� ����
        if (isNext)         // isNext ������ ���̶�� ����Ʈ�� ���� ������ ����Ѵ�.
        {
            setVCnum = (setVCnum + 1) % vcList.Length;
        }
        else
        {
            setVCnum = ((setVCnum - 1) + vcList.Length) % vcList.Length;
        }
        vp.clip = vcList[setVCnum];                   // Ŭ���� �����Ѵ�.
        vp.Play();                                    // �ٲ� Ŭ���� ����Ѵ�.
        curVCidx = setVCnum;                          // �ٲ� Ŭ���� ������ ��ȣ�� ������Ʈ�Ѵ�.
    }

    public void SetVideoPlay(int num)
    {
        // ���� ��� ���� ��ȣ�� ���޹��� ��ȣ�� �ٸ� ���� �����Ѵ�.
        if (curVCidx != num)
        {
            vp.Stop();                     // ������ �����
            vp.clip = vcList[num];         // Ŭ���� �����Ѵ�. 
            curVCidx = num;                // ���� ��� ���� ��ȣ�� �����Ѵ�
            vp.Play();                     // ����Ѵ�.
        }

    }
}

