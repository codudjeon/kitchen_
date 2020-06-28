using UnityEngine;
using UnityEditor;
using System;

namespace Kandooz
{
    public class HandShaderEditor : ShaderGUI
    {
        MaterialEditor _materialEditor;
        MaterialProperty[] _properties;


        //General Settings
        private MaterialProperty _NormalStrength = null;
        private MaterialProperty _Glossiness = null;
        private MaterialProperty _AO = null;

        //TEXTURE SETTINGS
        private MaterialProperty _HandAlbedo = null;
        private MaterialProperty _HandNormal = null;
        private MaterialProperty _HandCombined = null;


        private MaterialProperty _WrinkleAlbedo = null;
        private MaterialProperty _WrinkleNormal = null;
        private MaterialProperty _WrinkeCombined = null;
        private MaterialProperty _WrinkeMaskMap = null;



        //Transluceny
        private MaterialProperty _Translucency;
        private MaterialProperty _TransNormalDistortion;
        private MaterialProperty _TransScattering;
        private MaterialProperty _TransDirect;
        private MaterialProperty _TransAmbient;
        private MaterialProperty _TransShadow;
        private MaterialProperty _TranslucencyColor;



        //SWITCHES
        protected static bool ShowGeneralSettings = true;
        protected static bool ShowTranslucencySettings = true;
        protected static bool ShowTextureSettings = true;
       



        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            _properties = properties;
            _materialEditor = materialEditor;
            EditorGUI.BeginChangeCheck();
            DrawGUI();
        }

        void GetProperties()
        {


            //General Settings
            _NormalStrength = FindProperty("_NormalStrength", _properties); ;
            _Glossiness = FindProperty("_Glossiness", _properties); ;
            _AO = FindProperty("_AO", _properties); ;


            //TEXTURE SETTINGS

            _HandAlbedo = FindProperty("_AlbedoMap", _properties);
            _WrinkleAlbedo = FindProperty("_WrinkleAlbedoMap", _properties);
            _HandNormal = FindProperty("_NormalMap", _properties);
            _WrinkleNormal = FindProperty("_WrinkleNormalMap", _properties);
            _HandCombined = FindProperty("_CombinedMap", _properties);
            _WrinkeCombined = FindProperty("_WrinkleCombinedMap", _properties);
            _WrinkeMaskMap = FindProperty("_WrinkleMaskMap", _properties);



            //Transluceny SETTINGS

            _Translucency = FindProperty("_Translucency", _properties);
            _TransNormalDistortion = FindProperty("_TransNormalDistortion", _properties);
            _TransScattering = FindProperty("_TransScattering", _properties);
            _TransDirect = FindProperty("_TransDirect", _properties);
            _TransAmbient = FindProperty("_TransAmbient", _properties);
            _TransShadow = FindProperty("_TransShadow", _properties);
            _TranslucencyColor = FindProperty("_TranslucencyColor", _properties);

         

        }

        static Texture2D bannerTexture = null;
        static GUIStyle title = null;
        static GUIStyle linkStyle = null;
        static string repoURL = "https://assetstore.unity.com/publishers/36568";

        void DrawBanner()
        {
            if (bannerTexture == null)
                bannerTexture = Resources.Load<Texture2D>("KandoozBanner");

            if (title == null)
            {
                title = new GUIStyle();
                title.fontSize = 20;
                title.alignment = TextAnchor.MiddleCenter;
                title.normal.textColor = new Color(1f, 1f, 1f);
            }


            if (linkStyle == null) linkStyle = new GUIStyle();

            if (bannerTexture != null)
            {
                GUILayout.Space(4);
                var rect = GUILayoutUtility.GetRect(0, int.MaxValue, 60, 60);
                EditorGUI.DrawPreviewTexture(rect, bannerTexture, null, ScaleMode.ScaleAndCrop);
                //

                if (GUI.Button(rect, "", linkStyle))
                {
                    Application.OpenURL(repoURL);
                }
                GUILayout.Space(4);
            }
        }

        void DrawGUI()
        {
            GetProperties();
            DrawBanner();

            startFoldout();
            ShowGeneralSettings = EditorGUILayout.Foldout(ShowGeneralSettings, "General settings");
            if (ShowGeneralSettings)
            {
                DrawGeneralSettings();
            }
            endFoldout();

            startFoldout();
            ShowTranslucencySettings = EditorGUILayout.Foldout(ShowTranslucencySettings, "Translucency Settings");
            if (ShowTranslucencySettings)
            {
                DrawTranslucencySettings();
            }
            endFoldout();

         

            startFoldout();
            ShowTextureSettings = EditorGUILayout.Foldout(ShowTextureSettings, "Textures");
            if (ShowTextureSettings)
            {
                DrawTextureSettings();
            }
            endFoldout();
        }

        private void DrawGeneralSettings()
        {

          
            _materialEditor.ShaderProperty(_NormalStrength, "Normal Strength");
            _materialEditor.ShaderProperty(_Glossiness, "Glossiness");
            _materialEditor.ShaderProperty(_AO, "Ambient");
        }

        private void DrawTranslucencySettings()
        {
            _materialEditor.ShaderProperty(_Translucency, "Strength");
            _materialEditor.ShaderProperty(_TransNormalDistortion, "Normal Distortion");
            _materialEditor.ShaderProperty(_TransScattering, "Scattering");
            _materialEditor.ShaderProperty(_TransDirect, "Direct");
            _materialEditor.ShaderProperty(_TransAmbient, "Ambient");
            _materialEditor.ShaderProperty(_TransShadow, "Shadow");
            _materialEditor.ShaderProperty(_TranslucencyColor, "Color");

         
        }

        void DrawTextureSettings()
        {
           
            _materialEditor.TexturePropertySingleLine(new GUIContent("Hand Albedo"), _HandAlbedo);
            _materialEditor.TexturePropertySingleLine(new GUIContent("Hand Normal"), _HandNormal);
            _materialEditor.TexturePropertySingleLine(new GUIContent("Hand Combined"), _HandCombined);

            _materialEditor.TexturePropertySingleLine(new GUIContent("Wrinkle Albedo"), _WrinkleAlbedo);
            _materialEditor.TexturePropertySingleLine(new GUIContent("Wrinkle Normal"), _WrinkleNormal);
            _materialEditor.TexturePropertySingleLine(new GUIContent("Wrinke Combined"), _WrinkeCombined);
            _materialEditor.TexturePropertySingleLine(new GUIContent("Wrinke Mask Map"), _WrinkeMaskMap);




        }

        void startFoldout()
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUI.indentLevel++;
        }

        void endFoldout()
        {
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();
        }

    }
}