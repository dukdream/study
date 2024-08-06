using UnityEngine;
using UnityEngine.Video;    // VideoPlayer ����� ����ϱ� ���� ���ӽ����̽�
// Video Player ������Ʈ�� ��������!
public class VideoFrame : MonoBehaviour
{
    // Video Player ������Ʈ
    VideoPlayer vp;

    // Start is called before the first frame update
    void Start()
    {
        // ���� ������Ʈ�� ���� �÷��̾� ������Ʈ ������ ������ �´�.
        vp = GetComponent<VideoPlayer>();
        // �ڵ� ����Ǵ� ���� ���´�.
        vp.Stop();

        // �� ���� ��

    }
        // Update is called once per frame
        void Update()
        {
        // S�� ������ �����϶�.
        if(Input.GetKeyDown(KeyCode.S))
            { vp.Stop(); 
        }
            // �����̽� �ٸ� ������ �� ��� �Ǵ� �Ͻ� ������ �϶�.
            if(Input.GetKeyDown("space"))
        { 
            // ���� ���� �÷��̾ �÷��� �������� Ȯ���϶�.
            if(vp.isPlaying)
            {
                // �÷���(���) ���̶�� �Ͻ� �����϶�.
                vp.Pause();
               }else
               {
                    // �׷��� �ʴٸ�(�Ͻ� ���� �� �Ǵ� ����) �÷���(���)�϶�,
                    vp.Play();
                }
            }
    }
}
