using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitPreview : MonoBehaviour
{
    [SerializeField] Sprite previewSpritesheet;

    PGManager pgm;
    PortraitPieceMerger ppm;
    private void Awake()
    {
        pgm = GetComponent<PGManager>();

        ppm = GetComponent<PortraitPieceMerger>();

        pgm.OnDropdownChanged += Pgm_OnDropdownChanged;
    }

    private async void Pgm_OnDropdownChanged(object sender, System.EventArgs e)
    {
        //previewSpritesheet = previewSpritesheetCanvas;
        //LogManager.Instance.Log("Combining sprites for preview");
        Debug.Log("Combing sprites for preview");
        Sprite CombinedSprite = await ppm.CombinePortraitPieces(PortraitSize.Sixteen);

        ppm.OverrideTexture(previewSpritesheet, CombinedSprite);

        //previewSpritesheet.texture = newTexture.texture;

        //ppm.CombineTextures(previewSpritesheet, await ppm.CombinePortraitPieces());
        

        //imageComponent.sprite = previewSpritesheet;
    }
}
