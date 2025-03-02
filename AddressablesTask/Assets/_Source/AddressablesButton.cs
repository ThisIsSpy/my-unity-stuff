using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressablesButton : MonoBehaviour
{
    [SerializeField] private AddressableType type;
    [SerializeField] private bool releaseAsset;

    private GameObject model;
    private Sprite sprite;
    private AudioClip sound;

    private Image image;
    private AudioSource audioSource;

    public void OnButtonPress()
    {
        switch(type)
        {
            case AddressableType.Model:
                if (!releaseAsset)
                {
                    AsyncOperationHandle<GameObject> asyncOperationHandleGameObject = Addressables.InstantiateAsync("Snowman");
                    asyncOperationHandleGameObject.Completed += InstantiateModel;
                }
                else
                {
                    Addressables.ReleaseInstance(model);
                }
                break;
            case AddressableType.Image:
                if (!releaseAsset)
                {
                    image = transform.GetChild(1).GetComponent<Image>();
                    AsyncOperationHandle<Sprite> asyncOperationHandleSprite = Addressables.LoadAssetAsync<Sprite>("ConstructionGuyFacingRight");
                    asyncOperationHandleSprite.Completed += LoadImage;
                }
                else
                {
                    Addressables.Release(sprite);
                }
                break;
            case AddressableType.Sound:
                if(!releaseAsset)
                {
                    audioSource = GetComponentInChildren<AudioSource>();
                    AsyncOperationHandle<AudioClip> asyncOperationHandleAudioClip = Addressables.LoadAssetAsync<AudioClip>("ROCKLX1A");
                    asyncOperationHandleAudioClip.Completed += LoadSound;
                }
                else
                {
                    Addressables.Release(sound);
                }
                break;
        }
    }

    private void InstantiateModel(AsyncOperationHandle<GameObject> asyncOperation)
    {
        if(asyncOperation.Status == AsyncOperationStatus.Succeeded)
        {
            if (model == null) 
            { 
                model = asyncOperation.Result; 
            }
        }
        else
        {
            Debug.Log("you suck");
        }
    }

    private void LoadImage(AsyncOperationHandle<Sprite> asyncOperation)
    {
        if(asyncOperation.Status == AsyncOperationStatus.Succeeded)
        {
            sprite = asyncOperation.Result;
            image.sprite = sprite;
        }
        else
        {
            Debug.Log("you suck");
        }
    }

    private void LoadSound(AsyncOperationHandle<AudioClip> asyncOperation)
    {
        if(asyncOperation.Status == AsyncOperationStatus.Succeeded)
        {
            sound = asyncOperation.Result;
            audioSource.clip = sound;
            audioSource.Play();
        }
        else
        {
            Debug.Log("you suck");
        }
    }

    
}

public enum AddressableType
{
    Model,
    Image,
    Sound,
}
