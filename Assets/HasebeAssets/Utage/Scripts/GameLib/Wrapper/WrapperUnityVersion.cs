//----------------------------------------------
// UTAGE: Unity Text Adventure Game Engine
// Copyright 2014 Ryohei Tokimura
//----------------------------------------------


#if UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6
#define UNITY_4_6_OR_EARLIER
#endif

#if UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_5_0
#define UNITY_5_0_OR_EARLIER
#endif

#if UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2
#define UNITY_5_2_OR_EARLIER
#endif

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
#if UNITY_EDITOR
using UnityEditor;
#if UNITY_5_2_OR_EARLIER
#else
using UnityEditor.SceneManagement;
#endif
#endif



namespace Utage
{
	//Unityのバージョン違いを吸収する
	public class WrapperUnityVersion
	{
		public static Vector2 GetBoxCollider2DOffset(BoxCollider2D col)
		{
#if UNITY_4_6_OR_EARLIER
			return col.center;
#else
            return col.offset;
#endif
		}

		public static void SetBoxCollider2DOffset(BoxCollider2D col, Vector2 offset)
		{
#if UNITY_4_6_OR_EARLIER
			col.center = offset;
#else
            col.offset = offset;
#endif
		}


		public static void SetCharacterInfoToVertex(UIVertex[] verts, UguiNovelTextCharacter character, Font font )
		{

			float minX,maxX,minY,maxY;
			Vector2 uvBottomLeft,uvBottomRight,uvTopRight,uvTopLeft;
			float offsetY;
#if UNITY_4_6_OR_EARLIER
			//Y座標はフォントアセットのサイズと、文字のサイズを使ってこんな式で計算できる。
			//理屈はわからん！
			offsetY = font.fontSize + 0.1f*(character.FontSize-font.fontSize);

			//positionの設定
			minX = character.charInfo.vert.xMin;
			maxX = character.charInfo.vert.xMax;

			minY = character.charInfo.vert.yMin;
			maxY = character.charInfo.vert.yMax;

			Rect uv = character.charInfo.uv;
			//Flipp処理
			if (character.charInfo.flipped)
			{
				uvBottomLeft = new Vector2(uv.xMax, uv.yMin);
				uvBottomRight = new Vector2(uv.xMax, uv.yMax);
				uvTopLeft = new Vector2(uv.xMin, uv.yMin);
				uvTopRight = new Vector2(uv.xMin, uv.yMax);
			}
			else
			{
				uvBottomLeft = new Vector2(uv.xMin, uv.yMax);
				uvBottomRight = new Vector2(uv.xMax, uv.yMax);
				uvTopLeft = new Vector2(uv.xMin, uv.yMin);
				uvTopRight = new Vector2(uv.xMax, uv.yMin);
			}
#else
            offsetY = 0.1f * (character.FontSize);

			//座標の設定
			minX = character.charInfo.minX;
			maxX = character.charInfo.maxX;
			minY = character.charInfo.minY;
			maxY = character.charInfo.maxY;

			if (!font.dynamic)
			{
				minX *= character.BmpFontScale;
				minY *= character.BmpFontScale;
				maxX *= character.BmpFontScale;
				maxY *= character.BmpFontScale;
			}

			uvBottomLeft = character.charInfo.uvBottomLeft;
			uvBottomRight = character.charInfo.uvBottomRight;
			uvTopRight = character.charInfo.uvTopRight;
			uvTopLeft = character.charInfo.uvTopLeft;
#endif
			//座標の設定
			verts[0].position.x = verts[3].position.x = minX + character.PositionX;
			verts[1].position.x = verts[2].position.x = maxX + character.PositionX;
			verts[0].position.y = verts[1].position.y = minY + character.PositionY + offsetY;
			verts[2].position.y = verts[3].position.y = maxY + character.PositionY + offsetY;

			verts[0].uv0 = uvBottomLeft;
			verts[1].uv0 = uvBottomRight;
			verts[2].uv0 = uvTopRight;
			verts[3].uv0 = uvTopLeft;
		}

		public static float GetCharacterInfoWidth(ref CharacterInfo charInfo)
		{
#if UNITY_4_6_OR_EARLIER
			return charInfo.width;
#else
            return charInfo.advance;
#endif
		}


		public static float GetCharacterEndPointX(UguiNovelTextCharacter character)
		{
#if UNITY_4_6_OR_EARLIER
			return character.charInfo.flipped ? character.Verts[1].position.x : character.Verts[2].position.x;
#else
            return character.Verts[1].position.x;
#endif
		}

		public static void SetFontRenderInfo(char c, ref CharacterInfo info, float offsetY, float fontSize, out Vector3 offset, out float width, out float kerningWidth)
		{
#if UNITY_4_6_OR_EARLIER
			float x1 = info.vert.x + (info.vert.width) / 2;
			float y1 = info.vert.y + (info.vert.height) / 2 + offsetY;
			offset = new Vector3(x1, y1, 0);
			width = GetCharacterInfoWidth(ref info);

			//カーニングする場合の、表示位置
			kerningWidth = info.vert.width;
#else
            float x1 = info.minX + (info.maxX - info.minX) / 2;
			float y1 = info.maxY - (info.glyphHeight + fontSize) / 2 + offsetY + fontSize/5;
			offset = new Vector3(x1, y1, 0);
			width = GetCharacterInfoWidth(ref info);
			//カーニングする場合の、表示位置
			kerningWidth = info.maxX - info.minX;
#endif
		}

		public static Rect GetUvRect(ref CharacterInfo info, Texture2D texture)
		{
#if UNITY_4_6_OR_EARLIER
			float x = info.uv.x * texture.width;
			float w = info.uv.width * texture.width;
			float y = info.uv.y * texture.height;
			float h = info.uv.height * texture.height;
			return new Rect(x, y, w, h);
#else
            //Fillped判定
            if ( Mathf.Approximately( info.uvTopLeft.x, info.uvTopRight.x ) )
			{
				float x = info.uvBottomLeft.x;
				float w = info.uvTopLeft.x - x;
				float y = info.uvTopRight.y;
				float h = info.uvTopLeft.y - y;
				return new Rect(x * texture.width, y * texture.height, w * texture.width, h * texture.height);
			}
			else
			{
				float x = info.uvTopLeft.x;
				float w = info.uvTopRight.x - x;
				float y = info.uvTopLeft.y;
				float h = info.uvBottomLeft.y - y;
				return new Rect(x * texture.width, y * texture.height, w * texture.width, h * texture.height);
			}
#endif
		}

		public static Vector3 GetFontSpriteAngles( FontRenderInfo fontInfo)
		{
            //Fillped判定
#if UNITY_4_6_OR_EARLIER
			if (fontInfo.CharInfo.flipped)
#else
            if ( Mathf.Approximately( fontInfo.CharInfo.uvTopLeft.x, fontInfo.CharInfo.uvTopRight.x ) )
#endif
			{
				return new Vector3(0, 0, 90);
			}
			else
			{
				return new Vector3(180, 0, 0);
			}
		}

#if UNITY_EDITOR
		public static void SetAudioImporterTreeD(UnityEditor.AudioImporter importer, bool p)
		{
#if UNITY_4_6_OR_EARLIER
			//3Dサウンドをオフに
			importer.threeD = false;
#else
#endif

        }
#endif

        public static bool IsReadyPlayAudioClip(AudioClip clip)
		{
#if UNITY_4_6_OR_EARLIER
			return clip.isReadyToPlay;
#else
            return clip.loadState == AudioDataLoadState.Loaded;
#endif
		}

		public static AudioClip CreateAudioClip(string name, int lengthSamples, int channels, int frequency, bool is3D, bool stream)
		{
#if UNITY_4_6_OR_EARLIER
			return AudioClip.Create(name
				, lengthSamples
				, channels
				, frequency
				, is3D
				, stream);
#else
            return AudioClip.Create(name
				, lengthSamples
				, channels
				, frequency
				, stream);
#endif
		}

		public static void SetNoBackupFlag(string path)
		{
#if UNITY_IPHONE

#if UNITY_4_6_OR_EARLIER
			iPhone.SetNoBackupFlag(path);
#else
			UnityEngine.iOS.Device.SetNoBackupFlag(path);
#endif

#endif
        }

        public static void SetActivityIndicatorStyle()
		{
#if UNITY_IPHONE
#if UNITY_4_6_OR_EARLIER
			Handheld.SetActivityIndicatorStyle(iOSActivityIndicatorStyle.Gray);
#else
			Handheld.SetActivityIndicatorStyle(UnityEngine.iOS.ActivityIndicatorStyle.Gray);
#endif
#elif UNITY_ANDROID
			Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
#endif
        }

        internal static void AddEntryToEventTrigger(EventTrigger eventTrigger, EventTrigger.Entry entry)
		{
#if UNITY_5_0_OR_EARLIER
			if (eventTrigger.delegates == null)
			{
				eventTrigger.delegates = new List<EventTrigger.Entry>();
			}
			eventTrigger.delegates.Add(entry);
#else
            if (eventTrigger.triggers == null)
			{
				eventTrigger.triggers = new List<EventTrigger.Entry>();
			}
			eventTrigger.triggers.Add(entry);
#endif
		}

		internal static Vector3 GetWorldPositionFromPointerEventData(PointerEventData data)
		{
#if UNITY_5_0_OR_EARLIER
			return data.worldPosition;
#else
            return data.pointerCurrentRaycast.worldPosition;
#endif
		}

        //****************　5.3以降のシーン関係　****************
        internal static void LoadScene(int index)
        {
#if UNITY_5_2_OR_EARLIER
			Application.LoadLevel(index);
#else
            UnityEngine.SceneManagement.SceneManager.LoadScene(index);
#endif
        }

        internal static void LoadScene(string name)
        {
#if UNITY_5_2_OR_EARLIER
			Application.LoadLevel(name);
#else
            UnityEngine.SceneManagement.SceneManager.LoadScene(name);
#endif
        }

        //****************　5.3以降のシーン関係(Editor)　****************
#if UNITY_EDITOR

        public static bool SaveScene()
        {
#if UNITY_5_2_OR_EARLIER
			return EditorApplication.SaveScene();
#else
            return EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
#endif
        }

        public static bool SaveCurrentSceneIfUserWantsTo()
        {
#if UNITY_5_2_OR_EARLIER
			return EditorApplication.SaveCurrentSceneIfUserWantsTo();
#else
            return EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
#endif
        }

        public static void OpenScene(string path)
        {
#if UNITY_5_2_OR_EARLIER
            EditorApplication.OpenScene(path);
#else
            EditorSceneManager.OpenScene(path);
#endif
        }

        public static void OpenSceneAdditive(string path)
        {
#if UNITY_5_2_OR_EARLIER
            EditorApplication.OpenSceneAdditive(path);
#else
            var scene = EditorSceneManager.OpenScene(path,OpenSceneMode.Additive);
            EditorSceneManager.MergeScenes(scene, EditorSceneManager.GetActiveScene());
#endif
        }

        public static string currentScene
        {
            get
            {
#if UNITY_5_2_OR_EARLIER
				return EditorApplication.currentScene;
#else
                return EditorSceneManager.GetActiveScene().name;
#endif
            }
        }

#endif


        //************************************************

    }
}