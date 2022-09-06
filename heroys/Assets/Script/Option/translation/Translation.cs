using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translation : MonoBehaviour
{
    public enum Language
    {
        en,
        ru
    }
    public Language _language;
    public void SetLanguageRu()
    {
        _language = Language.ru;
    }
    public void SetLanguageEn()
    {
        _language = Language.en;
    }
}
