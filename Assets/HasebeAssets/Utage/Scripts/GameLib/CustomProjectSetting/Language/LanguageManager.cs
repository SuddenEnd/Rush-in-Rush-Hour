//----------------------------------------------
// UTAGE: Unity Text Adventure Game Engine
// Copyright 2014 Ryohei Tokimura
//----------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utage
{
	/// <summary>
	/// 表示言語切り替え用のクラス
	/// </summary>
	public class LanguageManager : LanguageManagerBase
	{
		protected override void OnRefreshCurrentLanguage()
		{
			if (!IgnoreLocalizeUiText)
			{
#if LegacyUtageUi
				{
					LegacyLocalize[] localizeTbl = GameObject.FindObjectsOfType<LegacyLocalize>();
					foreach (var item in localizeTbl)
					{
						item.OnLocalize();
					}
				}
#endif
				{
					UguiLocalizeBase[] localizeTbl = GameObject.FindObjectsOfType<UguiLocalizeBase>();
//					foreach (var item in localizeTbl)
                        if (Change_lang_Button.now_lang == "English")
                        {
                            if (Change_lang_Button.now_lang=="English") 
						item.OnLocalize();
					}
				}
			}
		}
	}
}
