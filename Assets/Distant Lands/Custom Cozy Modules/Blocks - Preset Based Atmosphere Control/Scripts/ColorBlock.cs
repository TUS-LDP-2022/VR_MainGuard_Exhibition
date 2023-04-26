using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Distant Lands/Cozy/Color Block", order = 361)]
    public class ColorBlock : ScriptableObject
    {

        public enum BlockStyle { advanced, simple }
        public BlockStyle blockStyle;

        #region  UI
        public bool win1;
        public bool win2;
        public bool win3;
        public bool win4;

        public AtmosphereProfile atmosphereProfile;

        #endregion

        #region  Block Atmosphere


        [Tooltip("Sets the color of the zenith (or top) of the skybox at a certain time. Starts and ends at midnight.")]
        [ColorUsage(false, true)]
        public Color skyZenithColor;

        [Tooltip("Sets the color of the horizon (or middle) of the skybox at a certain time. Starts and ends at midnight.")]
        [ColorUsage(false, true)]
        public Color skyHorizonColor;

        [Tooltip("Sets the main color of the clouds at a certain time. Starts and ends at midnight.")]
        [ColorUsage(false, true)]
        public Color cloudColor;

        [Tooltip("Sets the highlight color of the clouds at a certain time. Starts and ends at midnight.")]
        [ColorUsage(false, true)]
        public Color cloudHighlightColor;

        [Tooltip("Sets the color of the high altitude clouds at a certain time. Starts and ends at midnight.")]
        [ColorUsage(false, true)]
        public Color highAltitudeCloudColor;

        [Tooltip("Sets the color of the sun light source at a certain time. Starts and ends at midnight.")]
        [ColorUsage(false, true)]
        public Color sunlightColor;

        [Tooltip("Sets the color of the moon light source at a certain time. Starts and ends at midnight.")]
        [ColorUsage(false, true)]
        public Color moonlightColor;

        [Tooltip("Sets the color of the star particle FX and textures at a certain time. Starts and ends at midnight.")]
        [ColorUsage(false, true)]
        public Color starColor;

        [Tooltip("Sets the color of the zenith (or top) of the ambient scene lighting at a certain time. Starts and ends at midnight.")]
        [ColorUsage(false, true)]
        public Color ambientLightHorizonColor;

        [Tooltip("Sets the color of the horizon (or middle) of the ambient scene lighting at a certain time. Starts and ends at midnight.")]
        [ColorUsage(false, true)]
        public Color ambientLightZenithColor;

        [Tooltip("Multiplies the ambient light intensity.")]
        [Range(0, 4)]
        public float ambientLightMultiplier;

        [Tooltip("Sets the intensity of the galaxy effects at a certain time. Starts and ends at midnight.")]
        [Range(0, 1)]
        public float galaxyIntensity;

        public float fogDensity = 1;



        [Tooltip("Sets the fog color from 0m away from the camera to fog start 1.")]

        [ColorUsage(true, true)]
        public Color fogColor1;

        [Tooltip("Sets the fog color from fog start 1 to fog start 2.")]

        [ColorUsage(true, true)]
        public Color fogColor2;
        [Tooltip("Sets the fog color from fog start 2 to fog start 3.")]


        [ColorUsage(true, true)]
        public Color fogColor3;
        [Tooltip("Sets the fog color from fog start 3 to fog start 4.")]


        [ColorUsage(true, true)]
        public Color fogColor4;
        [Tooltip("Sets the fog color from fog start 4 to fog start 5.")]


        [ColorUsage(true, true)]
        public Color fogColor5;

        [Tooltip("Sets the color of the fog flare.")]

        [ColorUsage(true, true)]
        public Color fogFlareColor;




        [Range(0, 1)]
        [Tooltip("Controls the exponent used to modulate from the horizon color to the zenith color of the sky.")]
        public float gradientExponent;
        [Range(0, 1)]
        public float atmosphereVariationMin;
        [Range(0, 1)]
        public float atmosphereVariationMax;
        [Range(0, 1)]
        [Tooltip("Controls the atmospheric variation multiplier.")]
        public float atmosphereBias;
        [Range(0, 5)]
        [Tooltip("Sets the size of the visual sun in the sky.")]
        public float sunSize;

        [Tooltip("Sets the color of the visual sun in the sky.")]
        [ColorUsage(false, true)]
        public Color sunColor;


        [Range(0, 100)]
        [Tooltip("Sets the falloff of the halo around the visual sun.")]
        public float sunFalloff;

        [Tooltip("Sets the color of the halo around the visual sun.")]

        [ColorUsage(false, true)]
        public Color sunFlareColor;
        [Range(0, 100)]
        [Tooltip("Sets the falloff of the halo around the main moon.")]
        public float moonFalloff;

        [Tooltip("Sets the color of the halo around the main moon.")]

        [ColorUsage(false, true)]
        public Color moonFlareColor;

        [Tooltip("Sets the color of the first galaxy algorithm.")]

        [ColorUsage(false, true)]
        public Color galaxy1Color;

        [Tooltip("Sets the color of the second galaxy algorithm.")]

        [ColorUsage(false, true)]
        public Color galaxy2Color;

        [Tooltip("Sets the color of the third galaxy algorithm.")]

        [ColorUsage(false, true)]
        public Color galaxy3Color;

        [Tooltip("Sets the color of the light columns around the horizon.")]

        [ColorUsage(false, true)]
        public Color lightScatteringColor;

        [Tooltip("Sets the distance at which the first fog color fades into the second fog color.")]
        public float fogStart1;
        public float fogStart2;
        public float fogStart3;
        public float fogStart4;
        [Range(0, 2)]
        public float fogHeight;
        [Range(0, 2)]
        public float fogLightFlareIntensity;
        [Range(0, 40)]
        public float fogLightFlareFalloff;
        [Range(0, 10)]
        [Tooltip("Sets the height divisor for the fog flare. High values sit the flare closer to the horizon, small values extend the flare into the sky.")]
        public float fogLightFlareSquish;



        [ColorUsage(false, true)]
        public Color cloudMoonColor;
        [Range(0, 50)]
        public float cloudSunHighlightFalloff;
        [Range(0, 50)]
        public float cloudMoonHighlightFalloff;

        [ColorUsage(false, true)]
        public Color cloudTextureColor;
        #endregion

        #region Simple Variables

        [Range(0, 1)]
        [Tooltip("Controls the amount of variation in the skybox")]
        public float atmosphereVariation;

        [ColorUsage(false, true)]
        [Tooltip("Controls the color for the skybox")]
        public Color skyColor;

        [ColorUsage(false, true)]
        [Tooltip("Controls the color for the fog")]
        public Color fogColor;

        [ColorUsage(false, true)]
        public Color simpleSunColor;

        [ColorUsage(false, true)]
        public Color simpleCloudColor;

        [ColorUsage(false, true)]
        public Color moonColor;


        [Tooltip("Controls the amount of night FX in the scene")]
        public float nightFXAmount;

        #endregion

        [Range(0, 1)]
        public float baseChance = 1;
        [Tooltip("Animation curves that increase or decrease block chance based on time, temprature, etc.")]
        [ChanceEffector]
        public List<ChanceEffector> chances;

        public void PullFromAtmosphere()
        {


            float i = CozyWeather.instance.GetModifiedDayPercentage();


            gradientExponent = atmosphereProfile.gradientExponent.GetFloatValue(i);
            ambientLightHorizonColor = atmosphereProfile.ambientLightHorizonColor.GetColorValue(i);
            ambientLightZenithColor = atmosphereProfile.ambientLightZenithColor.GetColorValue(i);
            ambientLightMultiplier = atmosphereProfile.ambientLightMultiplier.GetFloatValue(i);
            atmosphereBias = atmosphereProfile.atmosphereBias.GetFloatValue(i);
            atmosphereVariationMax = atmosphereProfile.atmosphereVariationMax.GetFloatValue(i);
            atmosphereVariationMin = atmosphereProfile.atmosphereVariationMin.GetFloatValue(i);
            cloudColor = atmosphereProfile.cloudColor.GetColorValue(i);
            cloudHighlightColor = atmosphereProfile.cloudHighlightColor.GetColorValue(i);
            cloudMoonColor = atmosphereProfile.cloudMoonColor.GetColorValue(i);
            cloudMoonHighlightFalloff = atmosphereProfile.cloudMoonHighlightFalloff.GetFloatValue(i);
            cloudSunHighlightFalloff = atmosphereProfile.cloudSunHighlightFalloff.GetFloatValue(i);
            cloudTextureColor = atmosphereProfile.cloudTextureColor.GetColorValue(i);
            fogColor1 = atmosphereProfile.fogColor1.GetColorValue(i);
            fogColor2 = atmosphereProfile.fogColor2.GetColorValue(i);
            fogColor3 = atmosphereProfile.fogColor3.GetColorValue(i);
            fogColor4 = atmosphereProfile.fogColor4.GetColorValue(i);
            fogColor5 = atmosphereProfile.fogColor5.GetColorValue(i);
            fogStart1 = atmosphereProfile.fogStart1;
            fogStart2 = atmosphereProfile.fogStart2;
            fogStart3 = atmosphereProfile.fogStart3;
            fogStart4 = atmosphereProfile.fogStart4;
            fogFlareColor = atmosphereProfile.fogFlareColor.GetColorValue(i);
            fogHeight = atmosphereProfile.fogHeight.GetFloatValue(i);
            fogLightFlareFalloff = atmosphereProfile.fogLightFlareFalloff.GetFloatValue(i);
            fogLightFlareIntensity = atmosphereProfile.fogLightFlareIntensity.GetFloatValue(i);
            fogLightFlareSquish = atmosphereProfile.fogLightFlareSquish.GetFloatValue(i);
            galaxy1Color = atmosphereProfile.galaxy1Color.GetColorValue(i);
            galaxy2Color = atmosphereProfile.galaxy2Color.GetColorValue(i);
            galaxy3Color = atmosphereProfile.galaxy3Color.GetColorValue(i);
            galaxyIntensity = atmosphereProfile.galaxyIntensity.GetFloatValue(i);
            highAltitudeCloudColor = atmosphereProfile.highAltitudeCloudColor.GetColorValue(i);
            lightScatteringColor = atmosphereProfile.lightScatteringColor.GetColorValue(i);
            moonlightColor = atmosphereProfile.moonlightColor.GetColorValue(i);
            moonFalloff = atmosphereProfile.moonFalloff.GetFloatValue(i);
            moonFlareColor = atmosphereProfile.moonFlareColor.GetColorValue(i);
            skyHorizonColor = atmosphereProfile.skyHorizonColor.GetColorValue(i);
            skyZenithColor = atmosphereProfile.skyZenithColor.GetColorValue(i);
            starColor = atmosphereProfile.starColor.GetColorValue(i);
            sunColor = atmosphereProfile.sunColor.GetColorValue(i);
            sunFalloff = atmosphereProfile.sunFalloff.GetFloatValue(i);
            sunFlareColor = atmosphereProfile.sunFlareColor.GetColorValue(i);
            sunlightColor = atmosphereProfile.sunlightColor.GetColorValue(i);
            sunSize = atmosphereProfile.sunSize.GetFloatValue(i);

        }

        public float GetChance(CozyWeather weather)
        {

            float i = baseChance;

            foreach (ChanceEffector j in chances)
                i *= j.GetChance(weather);

            return i;

        }


    }

#if UNITY_EDITOR
    [CustomEditor(typeof(ColorBlock))]
    [CanEditMultipleObjects]
    public class E_ColorBlock : Editor
    {

        public bool tooltips;

        public CozyWeather defaultWeather;
        ColorBlock cb;

        void OnEnable()
        {

            if (CozyWeather.instance)
                defaultWeather = CozyWeather.instance;

        }

        public override void OnInspectorGUI()
        {

            tooltips = EditorPrefs.GetBool("CZY_Tooltips", true);

            if (defaultWeather)
                OnInspectorGUIInline(defaultWeather);
            else
                EditorGUILayout.HelpBox("To edit the Color Block make sure that your scene is properly setup with a COZY system!", MessageType.Warning);

        }

        public void DrawSimpleSettings()
        {

            GUIStyle labelStyle = new GUIStyle(GUI.skin.GetStyle("Label"));
            labelStyle.fontStyle = FontStyle.Bold;

            EditorGUILayout.LabelField(" Skydome Settings", labelStyle);
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(serializedObject.FindProperty("atmosphereVariation"), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("skyColor"), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("fogColor"), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("fogDensity"), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("simpleSunColor"), new GUIContent("Sun Color"), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("simpleCloudColor"), new GUIContent("Cloud Color"), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("moonColor"), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("nightFXAmount"), false);

            serializedObject.ApplyModifiedProperties();

            SetAtmosphereVariables();

        }

        public void OnInspectorGUIInline(CozyWeather cozyWeather)
        {

            if (!cb)
                cb = (ColorBlock)target;


            serializedObject.Update();
            tooltips = EditorPrefs.GetBool("CZY_Tooltips", true);

            serializedObject.FindProperty("win4").boolValue = EditorGUILayout.BeginFoldoutHeaderGroup(serializedObject.FindProperty("win4").boolValue,
                new GUIContent("    Selection Settings"), EditorUtilities.FoldoutStyle());
            EditorGUILayout.EndFoldoutHeaderGroup();
            if (serializedObject.FindProperty("win4").boolValue)
            {

                EditorGUI.indentLevel++;

                EditorGUILayout.PropertyField(serializedObject.FindProperty("blockStyle"));
                EditorGUILayout.Space();
                EditorGUILayout.PropertyField(serializedObject.FindProperty("baseChance"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("chances"));

                EditorGUI.indentLevel--;

            }

            if ((ColorBlock.BlockStyle)serializedObject.FindProperty("blockStyle").enumValueIndex == ColorBlock.BlockStyle.simple)
            {

                serializedObject.FindProperty("win1").boolValue = EditorGUILayout.BeginFoldoutHeaderGroup(serializedObject.FindProperty("win1").boolValue,
                    new GUIContent("    Settings", "Controls the base versions of properties."), EditorUtilities.FoldoutStyle());

                if (serializedObject.FindProperty("win1").boolValue)
                    DrawSimpleSettings();

                serializedObject.ApplyModifiedProperties();
                return;

            }


            serializedObject.FindProperty("win1").boolValue = EditorGUILayout.BeginFoldoutHeaderGroup(serializedObject.FindProperty("win1").boolValue,
                new GUIContent("    Atmosphere & Lighting", "Skydome, fog, and lighting settings."), EditorUtilities.FoldoutStyle());

            if (serializedObject.FindProperty("win1").boolValue)
            {

                DrawAtmosphereTab(cozyWeather);

            }

            EditorGUILayout.EndFoldoutHeaderGroup();
            serializedObject.FindProperty("win2").boolValue = EditorGUILayout.BeginFoldoutHeaderGroup(serializedObject.FindProperty("win2").boolValue,
                            new GUIContent("    Clouds", "Cloud color, generation, and variation settings."), EditorUtilities.FoldoutStyle());

            if (serializedObject.FindProperty("win2").boolValue)
            {

                DrawCloudsTab(cozyWeather);

            }

            EditorGUILayout.EndFoldoutHeaderGroup();
            serializedObject.FindProperty("win3").boolValue = EditorGUILayout.BeginFoldoutHeaderGroup(serializedObject.FindProperty("win3").boolValue,
                            new GUIContent("    Celestials & VFX", "Sun, moon, and light FX settings."), EditorUtilities.FoldoutStyle());

            if (serializedObject.FindProperty("win3").boolValue)
            {

                DrawCelestialsTab(cozyWeather);

            }


            EditorGUILayout.EndFoldoutHeaderGroup();

            serializedObject.ApplyModifiedProperties();


        }

        void DrawBlocksTab()
        {


            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(serializedObject.FindProperty("timeSettings"));

            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("atmosphereProfile"), GUIContent.none);

            if (GUILayout.Button("Pull values from atmosphere"))
                cb.PullFromAtmosphere();

            EditorGUILayout.EndHorizontal();
            EditorGUI.indentLevel--;


        }

        void SetAtmosphereVariables()
        {


            cb.gradientExponent = 0.5f;
            cb.atmosphereBias = cb.atmosphereVariation;
            cb.atmosphereVariationMax = 0.5f;
            cb.atmosphereVariationMin = 1;
            cb.cloudColor = cb.simpleCloudColor;
            cb.cloudHighlightColor = cb.sunColor;
            cb.cloudMoonColor = cb.moonColor;
            cb.cloudMoonHighlightFalloff = 30;
            cb.cloudSunHighlightFalloff = 15;
            cb.cloudTextureColor = Color.white;
            cb.fogColor1 = ColorHSVAdjustment(cb.fogColor, 0, 0, -1, 0); ;
            cb.fogColor2 = ColorHSVAdjustment(cb.fogColor, 0, 0.42f, -0.8f, 0.1f); ;
            cb.fogColor3 = ColorHSVAdjustment(cb.fogColor, 0, 0.2f, -.5f, 0.45f); ;
            cb.fogColor4 = ColorHSVAdjustment(cb.fogColor, 0, 0.1f, -.3f, 0.75f); ;
            cb.fogColor5 = ColorHSVAdjustment(cb.fogColor, 0, 0, 0.1f, 1);
            cb.fogStart1 = 2;
            cb.fogStart2 = 5;
            cb.fogStart3 = 10;
            cb.fogStart4 = 30;
            cb.fogFlareColor = ColorHSVAdjustment(cb.simpleSunColor, 0, 0.2f, 0);
            cb.fogHeight = 0.88f;
            cb.fogLightFlareFalloff = 4;
            cb.fogLightFlareIntensity = 1;
            cb.fogLightFlareSquish = 1;
            cb.galaxyIntensity = cb.nightFXAmount;
            cb.highAltitudeCloudColor = ColorHSVAdjustment(cb.simpleCloudColor, 0, 0.2f, 0.1f);
            cb.lightScatteringColor = Color.Lerp(Color.black, Color.cyan, cb.nightFXAmount);
            cb.moonlightColor = cb.moonColor;
            cb.moonFalloff = 25;
            cb.moonFlareColor = cb.moonColor;
            cb.skyHorizonColor = ColorHSVAdjustment(cb.skyColor, 0, -0.2f, 0.1f);
            cb.skyZenithColor = cb.skyColor;
            cb.starColor = Color.Lerp(Color.black, Color.white, cb.nightFXAmount);
            cb.sunColor = ColorHSVAdjustment(cb.simpleSunColor, 0, 0, 0.1f);
            cb.sunFalloff = 25;
            cb.sunFlareColor = ColorHSVAdjustment(cb.simpleSunColor, 0, 0, -0.1f);
            cb.sunlightColor = cb.simpleSunColor;
            cb.sunSize = 1;
            cb.ambientLightHorizonColor = cb.skyHorizonColor;
            cb.ambientLightZenithColor = cb.skyZenithColor;

        }


        public Color ColorHSVAdjustment(Color color, float h, float s, float v)
        {
            float x = 0;
            float y = 0;
            float z = 0;

            Color.RGBToHSV(color, out x, out y, out z);

            x = Loop(x + h);
            y = Mathf.Clamp01(y + s);
            z = Mathf.Clamp(z + v, 0, 10);

            return Color.HSVToRGB(x, y, z, true);

        }
        public Color ColorHSVAdjustment(Color color, float h, float s, float v, float a)
        {
            float x = 0;
            float y = 0;
            float z = 0;

            Color.RGBToHSV(color, out x, out y, out z);

            x = Loop(x + h);
            y = Mathf.Clamp01(y + s);
            z = Mathf.Clamp(z + v, 0, 10);

            Color i = Color.HSVToRGB(x, y, z, true);

            i.a = a;

            return i;

        }

        public float Loop(float x)
        {
            while (x > 1)
                x -= 1;
            while (x < 0)
                x += 1;

            return x;

        }


        public string FormatTime(bool militaryTime, float time)
        {


            int minutes = Mathf.RoundToInt(time * 1440);
            int hours = (minutes - minutes % 60) / 60;
            minutes -= hours * 60;

            if (militaryTime)
                return $"{hours.ToString("D2")}:{minutes.ToString("D2")}";
            else if (hours == 0)
                return $"12:{minutes.ToString("D2")}AM";
            else if (hours == 12)
                return $"12:{minutes.ToString("D2")}PM";
            else if (hours > 12)
                return $"{(hours - 12)}:{minutes.ToString("D2")}PM";
            else
                return $"{(hours)}:{minutes.ToString("D2")}AM";

        }

        void DrawAtmosphereTab(CozyWeather cozyWeather)
        {

            GUIStyle labelStyle = new GUIStyle(GUI.skin.GetStyle("Label"));
            labelStyle.fontStyle = FontStyle.Bold;

            bool advancedSky = cozyWeather.skyStyle == CozyWeather.SkyStyle.desktop;

            if (tooltips)
                EditorGUILayout.HelpBox("Interpolate controls change the value depending on the time of day. These range from 00:00 to 23:59, which means that morning is about 25% through the curve, midday 50%, evening 75%, etc. \n \n Constant controls set the value to a single value that remains constant regardless of the time of day.", MessageType.Info);


            EditorGUILayout.LabelField(" Skydome Settings", labelStyle);
            EditorGUI.indentLevel++;

            EditorGUILayout.PropertyField(serializedObject.FindProperty("skyZenithColor"), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("skyHorizonColor"), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("gradientExponent"), false);

            if (advancedSky)
            {

                EditorGUILayout.Space(5);
                float min = serializedObject.FindProperty("atmosphereVariationMin").floatValue;
                float max = serializedObject.FindProperty("atmosphereVariationMax").floatValue;

                Rect position = EditorGUILayout.GetControlRect();
                float startPos = position.width / 2.5f;
                var titleRect = new Rect(position.x, position.y, 70, position.height);
                EditorGUI.PrefixLabel(titleRect, new GUIContent("Atmosphere Variation"));
                var label1Rect = new Rect();
                var label2Rect = new Rect();
                var sliderRect = new Rect();

                if (position.width > 359)
                {
                    label1Rect = new Rect(startPos, position.y, 64, position.height);
                    label2Rect = new Rect(position.width - 71, position.y, 64, position.height);
                    sliderRect = new Rect(startPos + 56, position.y, (position.width - startPos) - 135, position.height);
                    EditorGUI.MinMaxSlider(sliderRect, ref min, ref max, 0, 1);
                }
                else
                {

                    label1Rect = new Rect(position.width - 110, position.y, 50, position.height);
                    label2Rect = new Rect(position.width - 72, position.y, 50, position.height);

                }

                min = EditorGUI.FloatField(label1Rect, (Mathf.Round(min * 100) / 100));
                max = EditorGUI.FloatField(label2Rect, (Mathf.Round(max * 100) / 100));

                if (min > max)
                    min = max;

                serializedObject.FindProperty("atmosphereVariationMin").floatValue = min;
                serializedObject.FindProperty("atmosphereVariationMax").floatValue = max;

                EditorGUILayout.PropertyField(serializedObject.FindProperty("atmosphereBias"), false);
            }

            EditorGUILayout.Space(5);
            EditorGUI.indentLevel--;
            EditorGUILayout.LabelField(" Fog Settings", labelStyle);
            EditorGUI.indentLevel++;

            EditorGUILayout.PropertyField(serializedObject.FindProperty("fogColor1"), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("fogColor2"), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("fogColor3"), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("fogColor4"), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("fogColor5"), false);
            EditorGUILayout.Space(5);

            float fogStart1 = serializedObject.FindProperty("fogStart1").floatValue;
            float fogStart2 = serializedObject.FindProperty("fogStart2").floatValue;
            float fogStart3 = serializedObject.FindProperty("fogStart3").floatValue;
            float fogStart4 = serializedObject.FindProperty("fogStart4").floatValue;

            fogStart1 = Mathf.Clamp(EditorGUILayout.Slider("Fog Start 2", fogStart1, 0, 50), 0, fogStart2 - 0.1f);
            fogStart2 = Mathf.Clamp(EditorGUILayout.Slider("Fog Start 3", fogStart2, 0, 50), fogStart1 + 0.1f, fogStart3 - 0.1f);
            fogStart3 = Mathf.Clamp(EditorGUILayout.Slider("Fog Start 4", fogStart3, 0, 50), fogStart2 + 0.1f, fogStart4 - 0.1f);
            fogStart4 = Mathf.Clamp(EditorGUILayout.Slider("Fog Start 5", fogStart4, 0, 50), fogStart3 + 0.1f, 50);

            serializedObject.FindProperty("fogStart1").floatValue = fogStart1;
            serializedObject.FindProperty("fogStart2").floatValue = fogStart2;
            serializedObject.FindProperty("fogStart3").floatValue = fogStart3;
            serializedObject.FindProperty("fogStart4").floatValue = fogStart4;

            EditorGUILayout.PropertyField(serializedObject.FindProperty("fogHeight"), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("fogDensity"), false);


            EditorGUILayout.Space(5);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("fogFlareColor"), new GUIContent("Light Flare Color",
                "Sets the color of the fog for a false \"light flare\" around the main sun directional light."), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("fogLightFlareIntensity"), new GUIContent("Light Flare Intensity",
                "Modulates the brightness of the light flare."), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("fogLightFlareFalloff"), new GUIContent("Light Flare Falloff",
                "Sets the falloff speed for the light flare."), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("fogLightFlareSquish"), new GUIContent("Light Flare Squish",
                "Sets the height divisor for the fog flare. High values sit the flare closer to the horizon, small values extend the flare into the sky."), false);

            EditorGUILayout.Space(5);
            EditorGUI.indentLevel--;
            EditorGUILayout.LabelField(" Lighting Settings", labelStyle);
            EditorGUI.indentLevel++;

            EditorGUILayout.PropertyField(serializedObject.FindProperty("sunlightColor"), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("moonlightColor"), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("ambientLightHorizonColor"), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("ambientLightZenithColor"), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("ambientLightMultiplier"), false);
            EditorGUI.indentLevel--;


        }

        public void RenderInWindow(Rect pos)
        {

            float space = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            var propPosA = new Rect(pos.x, pos.y + space, pos.width, EditorGUIUtility.singleLineHeight);
            var propPosB = new Rect(pos.x, pos.y + space + space, pos.width, EditorGUIUtility.singleLineHeight);

            serializedObject.Update();

            EditorGUI.PropertyField(propPosA, serializedObject.FindProperty("baseChance"));
            EditorGUI.PropertyField(propPosB, serializedObject.FindProperty("chances"));

            serializedObject.ApplyModifiedProperties();
        }

        
        public float GetLineHeight()
        {

            return 2 + (serializedObject.FindProperty("chances").isExpanded ? 1 + (serializedObject.FindProperty("chances").arraySize == 0 ? 1.5f : serializedObject.FindProperty("chances").arraySize) : 0);

        }

        void DrawCloudsTab(CozyWeather cozyWeather)
        {

            Material cloudShader = cozyWeather.cloudMesh.sharedMaterial;

            if (tooltips)
                EditorGUILayout.HelpBox("Interpolate controls change the value depending on the time of day. These range from 00:00 to 23:59, which means that morning is about 25% through the curve, midday 50%, evening 75%, etc. \n \n Constant controls set the value to a single value that remains constant regardless of the time of day.", MessageType.Info);


            GUIStyle labelStyle = new GUIStyle(GUI.skin.GetStyle("Label"));
            labelStyle.fontStyle = FontStyle.Bold;

            EditorGUILayout.LabelField(" Color Settings", labelStyle);
            EditorGUI.indentLevel++;


            EditorGUILayout.PropertyField(serializedObject.FindProperty("cloudColor"), new GUIContent("Cloud Color", "The main color of the unlit clouds."), false);
            if (cloudShader.HasProperty("_AltoCloudColor"))
                EditorGUILayout.PropertyField(serializedObject.FindProperty("highAltitudeCloudColor"), new GUIContent("High Altitude Color", "The main color multiplier of the high altitude clouds. The cloud types affected are the cirrostratus and the altocumulus types."), false);
            EditorGUILayout.Space(5);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("cloudHighlightColor"), new GUIContent("Sun Highlight Color", "The color multiplier for the clouds in a \"dot\" around the sun."), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("cloudSunHighlightFalloff"), new GUIContent("Sun Highlight Falloff", "The falloff for the \"dot\" around the sun."), false);
            EditorGUILayout.Space(5);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("cloudMoonColor"), new GUIContent("Moon Highlight Color", "The color multiplier for the clouds in a \"dot\" around the moon."), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("cloudMoonHighlightFalloff"), new GUIContent("Moon Highlight Falloff", "The falloff for the \"dot\" around the moon."), false);


            EditorGUI.indentLevel--;


        }

        void DrawCelestialsTab(CozyWeather cozyWeather)
        {


            bool advancedSky = cozyWeather.skyStyle == CozyWeather.SkyStyle.desktop;


            if (tooltips)
                EditorGUILayout.HelpBox("Interpolate controls change the value depending on the time of day. These range from 00:00 to 23:59, which means that morning is about 25% through the curve, midday 50%, evening 75%, etc. \n \n Constant controls set the value to a single value that remains constant regardless of the time of day.", MessageType.Info);

            GUIStyle labelStyle = new GUIStyle(GUI.skin.GetStyle("Label"));
            labelStyle.fontStyle = FontStyle.Bold;

            EditorGUILayout.LabelField(" Sun Settings", labelStyle);
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(serializedObject.FindProperty("sunColor"), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("sunSize"), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("sunFalloff"), new GUIContent("Sun Halo Falloff"), false);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("sunFlareColor"), new GUIContent("Sun Halo Color"), false);
            EditorGUI.indentLevel--;

            EditorGUILayout.Space(16);

            if (advancedSky)
            {
                EditorGUILayout.LabelField(" Moon Settings", labelStyle);
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(serializedObject.FindProperty("moonFalloff"), new GUIContent("Moon Halo Falloff"), false);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("moonFlareColor"), new GUIContent("Moon Halo Color"), false);
                EditorGUI.indentLevel--;
            }


            EditorGUILayout.Space(15);
            EditorGUILayout.LabelField(" VFX", labelStyle);
            EditorGUI.indentLevel++;

            EditorGUILayout.PropertyField(serializedObject.FindProperty("starColor"), false);

            if (advancedSky)
            {
                EditorGUILayout.Space(5);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("galaxyIntensity"), false);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("galaxy1Color"), false);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("galaxy2Color"), false);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("galaxy3Color"), false);
                EditorGUILayout.Space(5);
                EditorGUILayout.PropertyField(serializedObject.FindProperty("lightScatteringColor"), false);
                EditorGUILayout.Space(5);
            }
            EditorGUI.indentLevel--;


        }
    }
#endif
}