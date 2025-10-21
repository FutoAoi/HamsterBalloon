//https://note.com/what_is_picky/n/nf9b5dca6e5b6

using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using System.Collections.Generic;


[System.Serializable]
public class BackgroundLayer
{
    [Tooltip("�X�N���[���Ώۂ̉摜")]
    public Image image;

    [Tooltip("x���̃X�N���[�����x")]
    [Range(0.1f, 10f)]
    public float scrollSpeedX = 1f;

}

public class background : MonoBehaviour
{
    //UV�I�t�Z�b�g�̍ő�l
    private const float k_maxLength = 1f;
    //�e�N�X�`���̃v���p�e�B��
    private const string k_propName = "_MainTex";

    [Header("�w�i")]
    [SerializeField]
    //�w�i���C���[�̃��X�g
    private List<BackgroundLayer> _layers;
    //���������}�e���A����ێ�
    private List<Material> _copiedMaterials = new();

    void Start()
    {
        //�e���C���[�ɑ΂��ă}�e���A���𕡐����ݒ聕�ێ�
        foreach (var layer in _layers)
        {
            Assert.IsNotNull(layer.image, "BackgroundLayer��Image��null�ł�");

            var originalMaterial = layer.image.material;
            Assert.IsNotNull(originalMaterial, "Image�̃}�e���A����null�ł�");

            var copiedMaterial = new Material(originalMaterial);
            layer.image.material = copiedMaterial;
            _copiedMaterials.Add(copiedMaterial);
        }
    }

    void Update()
    {
        if (Time.timeScale == 0f)
        {
            //�ꎞ��~���Ȃ珈�����X�L�b�v
            return;
        }

        //�e���C���[�ɑ΂��ăX�N���[��������K�p
        for (int i = 0; i < _layers.Count; i++)
        {

            float speed = _layers[i].scrollSpeedX;
            //���Ԃɉ����Čv�Z
            float x = Mathf.Repeat(Time.time * speed, k_maxLength);
            Vector2 offset = new(x, 0f);

            _copiedMaterials[i].SetTextureOffset(k_propName, offset);


        }
    }

    private void OnDestroy()
    {
        //���������}�e���A����j��
        foreach (var mat in _copiedMaterials)
        {
            Destroy(mat);
        }
        _copiedMaterials.Clear();


    }

}
