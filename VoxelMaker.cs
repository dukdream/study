using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ڰ� ���콺�� Ŭ���� ������ ������ 1�� ����� �ʹ�.
// �ʿ� �Ӽ�.: ���� ����
public class VoxelMaker : MonoBehaviour
{
    //��������
    public GameObject voxelFactory;
    //������Ʈ Ǯ�� ũ��
    public int voxelPoolSize = 20;
    //������Ʈ Ǯ
    public static List<GameObject> voxelPool = new List<GameObject>();
    //ũ�ν���� ����
    public Transform crosshair;
    void Update()
    {
        //ũ�ν���� �׸���
        ARAVRInput.DrawCrosshair(crosshair);

        // ����ڰ� ���콺�� Ŭ���� ������ ������ 1�� ����� �ʹ�.
        //1.����ڰ� ���콺�� Ŭ���ߴٸ�
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            // 2. ���콺�� ��ġ�� �ٴ� ���� ��ġ�� �ִٸ�
            if (Physics.Raycast(ray, out hitInfo))
            {
                //���� ������Ʈ Ǯ �̿��ϱ�
                //1. ���� ������Ʈ Ǯ�� ������ �ִٸ�
                if (voxelPool.Count > 0)
                {
                    //2. ������Ʈ Ǯ���� ������ �ϳ� �����´�.
                    GameObject voxel = voxelPool[0];
                    //3. ������ Ȱ��ȭ�Ѵ�.
                    voxel.SetActive(true);
                    //4. ������ ��ġ�ϰ� �ʹ�.
                    voxel.transform.position = hitInfo.point;
                    //5. ������Ʈ Ǯ���� ������ �����Ѵ�.
                    voxelPool.RemoveAt(0);

                    // 3.���� ���忡�� ������ ������ �Ѵ�.
                    //GameObject voxel = Instantiate(voxelFactory);
                    //4.������ ��ġ�ϰ� �ʹ�.
                    //voxel.transform.position = hitInfo.point;
                }
            }

        }

    }

    void Start()
    {
        //������Ʈ Ǯ�� ��Ȱ��ȭ�� ������ ��� �ʹ�.
        for (int i = 0; i < voxelPoolSize; i++)
        {
            //1. ���� ���忡�� ���� �����ϱ�
            GameObject voexl = Instantiate(voxelFactory);
            //2. ���� ��Ȱ��ȭ�ϱ�
            voexl.SetActive(false);
            //3.������ ������Ʈ Ǯ�� ��� �ʹ�.
            voxelPool.Add(voexl);
        }

    }
}
