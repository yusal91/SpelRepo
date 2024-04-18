using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedSprite : MonoBehaviour
{
    public Image mImage;

    public Sprite[] mSprite;

    public float mSpeed;

    private int mSpriteIndex;

    Coroutine mCoroutine;

    bool isDone;

    public void Func_PlayUiAnim()
    {
        isDone = false;

        StartCoroutine(Func_PlayAnimUi());
    }

    private IEnumerator Func_PlayAnimUi()
    {
        yield return new WaitForSeconds(mSpeed);

        if (mSpriteIndex >= mSprite.Length)
        {
            mSpriteIndex = 0;
        }
        mImage.sprite = mSprite[mSpriteIndex];

        if (!isDone)
        {
            mCoroutine = StartCoroutine(Func_PlayAnimUi());
        }
    }
}
