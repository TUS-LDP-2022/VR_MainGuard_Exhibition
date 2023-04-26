using System.Collections;
using System.Runtime;
using UnityEngine;
using DistantLands.Cozy.Data;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DistantLands.Cozy
{
    [ExecuteAlways]
    public class BlocksModule : CozyModule
    {

        #region Runtime Values
        public float sunDirection;
        public float sunPitch;
        [ColorUsage(true, true)] public Color skyZenithColor;
        [ColorUsage(true, true)] public Color skyHorizonColor;
        [ColorUsage(true, true)] public Color cloudColor;
        [ColorUsage(true, true)] public Color cloudHighlightColor;
        [ColorUsage(true, true)] public Color highAltitudeCloudColor;
        [ColorUsage(true, true)] public Color sunlightColor;
        [ColorUsage(true, true)] public Color starColor;
        [ColorUsage(true, true)] public Color ambientLightHorizonColor;
        [ColorUsage(true, true)] public Color ambientLightZenithColor;
        public float ambientLightMultiplier;
        public float galaxyIntensity;
        [ColorUsage(true, true)] public Color fogColor1;
        [ColorUsage(true, true)] public Color fogColor2;
        [ColorUsage(true, true)] public Color fogColor3;
        [ColorUsage(true, true)] public Color fogColor4;
        [ColorUsage(true, true)] public Color fogColor5;
        [ColorUsage(true, true)] public Color fogFlareColor;
        public float gradientExponent = 0.364f;
        public float atmosphereVariationMin;
        public float atmosphereVariationMax;
        public float atmosphereBias = 1;
        public float sunSize = 0.7f;
        [ColorUsage(true, true)] public Color sunColor;
        public float sunFalloff = 43.7f;
        [ColorUsage(true, true)] public Color sunFlareColor;
        public float moonFalloff = 24.4f;
        [ColorUsage(true, true)] public Color moonlightColor;
        [ColorUsage(true, true)] public Color moonFlareColor;
        [ColorUsage(true, true)] public Color galaxy1Color;
        [ColorUsage(true, true)] public Color galaxy2Color;
        [ColorUsage(true, true)] public Color galaxy3Color;
        [ColorUsage(true, true)] public Color lightScatteringColor;
        public float rainbowPosition = 78.7f;
        public float rainbowWidth = 11;
        public float fogStart1 = 2;
        public float fogStart2 = 5;
        public float fogStart3 = 10;
        public float fogStart4 = 30;
        public float fogHeight = 0.85f;
        public float fogDensityMultiplier;
        public float fogLightFlareIntensity = 1;
        public float fogLightFlareFalloff = 21;
        public float fogLightFlareSquish = 1;
        [ColorUsage(true, true)] public Color cloudMoonColor;
        public float cloudSunHighlightFalloff = 14.1f;
        public float cloudMoonHighlightFalloff = 22.9f;
        public float cloudWindSpeed = 3;
        public float clippingThreshold = 0.5f;
        public float cloudMainScale = 20;
        public float cloudDetailScale = 2.3f;
        public float cloudDetailAmount = 30;
        public float acScale = 1;
        public float cirroMoveSpeed = 0.5f;
        public float cirrusMoveSpeed = 0.5f;
        public float chemtrailsMoveSpeed = 0.5f;
        [ColorUsage(true, true)] public Color cloudTextureColor = Color.white;
        public float cloudCohesion = 0.75f;
        public float spherize = 0.361f;
        public float shadowDistance = 0.0288f;
        public float cloudThickness = 2f;
        public float textureAmount = 1f;
        public Texture cloudTexture;
        public Vector3 texturePanDirection;

        public float rainbowIntensity;
        public bool useRainbow;

        #endregion

        #region UI

        public bool selection;
        public bool developmentToolkit;
        public bool blockSettings;
        #endregion


        public BlockProfile blockProfile;

        public List<Block> blocks = new List<Block>();
        public List<float> keys = new List<float>();
        [System.Serializable]
        public class Block
        {

            [Range(0, 1)]
            public float startKey;

            [Range(0, 1)]
            public float endKey;

            public ColorBlock[] colorBlocks;

            [HideInInspector]
            public int seed;


            public ColorBlock selectedBlock;
            public void GetColorBlock(CozyWeather weather)
            {

                if (colorBlocks.Length <= 0)
                    return;

                ColorBlock i = null;
                List<float> floats = new List<float>();
                float totalChance = 0;

                foreach (ColorBlock k in colorBlocks)
                {
                    floats.Add(k.GetChance(weather));
                    totalChance += k.GetChance(weather);
                }

                if (totalChance == 0)
                {
                    selectedBlock = colorBlocks[0];
                    return;
                }


                float selection = (float)new System.Random(seed).NextDouble() * totalChance;



                int m = 0;
                float l = 0;

                while (l <= selection)
                {

                    if (selection >= l && selection < l + floats[m])
                    {
                        i = colorBlocks[m];
                        break;
                    }
                    l += floats[m];
                    m++;

                }

                if (!i)
                {
                    i = colorBlocks[0];
                }

                selectedBlock = i;
            }

            public Block(float _startKey, float _endKey, ColorBlock[] _blocks)
            {

                startKey = _startKey;
                endKey = _endKey;
                colorBlocks = _blocks;

            }
            public Block(PerennialProfile.TimeBlock block, ColorBlock[] _blocks)
            {

                startKey = block.start;
                endKey = block.end;
                colorBlocks = _blocks;

            }

        }


        public ColorBlock currentBlock;
        public ColorBlock testColorBlock;


        void OnEnable()
        {

            base.SetupModule();
            weatherSphere.overrideAtmosphere = this;
            weatherSphere.atmosphereControl = CozyWeather.AtmosphereSelection.native;

        }

        void Awake()
        {

            testColorBlock = null;
            GetBlocks();

        }

        void Update()
        {

            if (testColorBlock)
                SingleBlock(testColorBlock);
            else if (blocks.Count > 0)
                SetColorsFromBlocks();
            else if (blockProfile)
                GetBlocks();

        }

        public void GetBlocks()
        {

            if (blockProfile == null)
                return;

            List<Block> i = new List<Block>();

            List<ColorBlock> j = new List<ColorBlock>();

            if (blockProfile.timeBlocks.HasFlag(BlockProfile.TimeBlocks.dawn))
                i.Add(new Block(weatherSphere.perennialProfile.dawnBlock, blockProfile.dawn.ToArray()));
            if (blockProfile.timeBlocks.HasFlag(BlockProfile.TimeBlocks.morning))
                i.Add(new Block(weatherSphere.perennialProfile.morningBlock, blockProfile.morning.ToArray()));
            if (blockProfile.timeBlocks.HasFlag(BlockProfile.TimeBlocks.day))
                i.Add(new Block(weatherSphere.perennialProfile.dayBlock, blockProfile.day.ToArray()));
            if (blockProfile.timeBlocks.HasFlag(BlockProfile.TimeBlocks.afternoon))
                i.Add(new Block(weatherSphere.perennialProfile.afternoonBlock, blockProfile.afternoon.ToArray()));
            if (blockProfile.timeBlocks.HasFlag(BlockProfile.TimeBlocks.evening))
                i.Add(new Block(weatherSphere.perennialProfile.eveningBlock, blockProfile.evening.ToArray()));
            if (blockProfile.timeBlocks.HasFlag(BlockProfile.TimeBlocks.twilight))
                i.Add(new Block(weatherSphere.perennialProfile.twilightBlock, blockProfile.twilight.ToArray()));
            if (blockProfile.timeBlocks.HasFlag(BlockProfile.TimeBlocks.night))
                i.Add(new Block(weatherSphere.perennialProfile.nightBlock, blockProfile.night.ToArray()));

            blocks = i;

            foreach (Block k in blocks)
                k.GetColorBlock(weatherSphere);

        }


        void SetColorsFromBlocks()
        {

            float time = weatherSphere.GetModifiedDayPercentage();


            ColorBlock currentBlock;


            if (keys.Count > 0)
                keys.Clear();

            foreach (Block j in blocks)
            {

                if (j.colorBlocks.Length == 0)
                    continue;

                keys.Add(j.startKey);
                keys.Add(j.endKey);
            }

            int k = 0;

            foreach (float i in keys)
            {

                if (time > i)
                {
                    k++;

                    if (k == keys.Count)
                    {
                        SingleBlock(blocks[blocks.Count - 1].selectedBlock);
                        blocks[0].GetColorBlock(weatherSphere);
                    }
                    continue;
                }

                currentBlock = k > 1 ? blocks[k / 2 - 1].selectedBlock : blocks[blocks.Count - 1].selectedBlock;

                if (k % 2 == 1)
                {

                    //In between two key frames from the same block.
                    TwoBlock(currentBlock, blocks[Mathf.FloorToInt(k / 2)].selectedBlock, (time - keys[k - 1]) / (i - keys[k - 1]));
                    break;

                }
                else
                {
                    //In between two key frames from different blocks.
                    SingleBlock(currentBlock);
                    if (k == keys.Count - 2)
                    {
                        blocks[0].seed = new System.Random().Next();
                        blocks[0].GetColorBlock(weatherSphere);
                    }
                    else
                        blocks[Mathf.FloorToInt(k / 2) + 1].seed = new System.Random().Next();
                    blocks[Mathf.FloorToInt(k / 2) + 1].GetColorBlock(weatherSphere);
                    break;

                }
            }
        }

        void SingleBlock(ColorBlock colorBlock)
        {

            if (colorBlock == null)
                return;

            ColorBlock block = colorBlock;

            weatherSphere.gradientExponent = block.gradientExponent;
            weatherSphere.ambientLightHorizonColor = block.ambientLightHorizonColor;
            weatherSphere.ambientLightZenithColor = block.ambientLightZenithColor;
            weatherSphere.ambientLightMultiplier = block.ambientLightMultiplier;
            weatherSphere.atmosphereBias = block.atmosphereBias;
            weatherSphere.atmosphereVariationMax = block.atmosphereVariationMax;
            weatherSphere.atmosphereVariationMin = block.atmosphereVariationMin;
            weatherSphere.cloudColor = block.cloudColor;
            weatherSphere.cloudHighlightColor = block.cloudHighlightColor;
            weatherSphere.cloudMoonColor = block.cloudMoonColor;
            weatherSphere.cloudMoonHighlightFalloff = block.cloudMoonHighlightFalloff;
            weatherSphere.cloudSunHighlightFalloff = block.cloudSunHighlightFalloff;
            weatherSphere.cloudTextureColor = block.cloudTextureColor;
            weatherSphere.fogColor1 = block.fogColor1;
            weatherSphere.fogColor2 = block.fogColor2;
            weatherSphere.fogColor3 = block.fogColor3;
            weatherSphere.fogColor4 = block.fogColor4;
            weatherSphere.fogColor5 = block.fogColor5;
            weatherSphere.fogStart1 = block.fogStart1;
            weatherSphere.fogStart2 = block.fogStart2;
            weatherSphere.fogStart3 = block.fogStart3;
            weatherSphere.fogStart4 = block.fogStart4;
            weatherSphere.fogFlareColor = block.fogFlareColor;
            weatherSphere.fogHeight = block.fogHeight;
            weatherSphere.fogDensityMultiplier = block.fogDensity;
            weatherSphere.fogLightFlareFalloff = block.fogLightFlareFalloff;
            weatherSphere.fogLightFlareIntensity = block.fogLightFlareIntensity;
            weatherSphere.fogLightFlareSquish = block.fogLightFlareSquish;
            weatherSphere.galaxy1Color = block.galaxy1Color;
            weatherSphere.galaxy2Color = block.galaxy2Color;
            weatherSphere.galaxy3Color = block.galaxy3Color;
            weatherSphere.galaxyIntensity = block.galaxyIntensity;
            weatherSphere.highAltitudeCloudColor = block.highAltitudeCloudColor;
            weatherSphere.lightScatteringColor = block.lightScatteringColor;
            weatherSphere.moonlightColor = block.moonlightColor;
            weatherSphere.moonFalloff = block.moonFalloff;
            weatherSphere.moonFlareColor = block.moonFlareColor;
            weatherSphere.skyHorizonColor = block.skyHorizonColor;
            weatherSphere.skyZenithColor = block.skyZenithColor;
            weatherSphere.starColor = block.starColor;
            weatherSphere.sunColor = block.sunColor;
            weatherSphere.sunFalloff = block.sunFalloff;
            weatherSphere.sunFlareColor = block.sunFlareColor;
            weatherSphere.sunlightColor = block.sunlightColor;
            weatherSphere.sunSize = block.sunSize;

            currentBlock = colorBlock;

        }

        void TwoBlock(ColorBlock colorBlock1, ColorBlock colorBlock2, float value)
        {
            if (colorBlock1 == null || colorBlock2 == null)
                return;


            ColorBlock block1 = colorBlock1;
            ColorBlock block2 = colorBlock2;

            weatherSphere.gradientExponent = Mathf.Lerp(block1.gradientExponent, block2.gradientExponent, value);
            weatherSphere.ambientLightHorizonColor = Color.Lerp(block1.ambientLightHorizonColor, block2.ambientLightHorizonColor, value);
            weatherSphere.ambientLightZenithColor = Color.Lerp(block1.ambientLightZenithColor, block2.ambientLightZenithColor, value);
            weatherSphere.ambientLightMultiplier = Mathf.Lerp(block1.ambientLightMultiplier, block2.ambientLightMultiplier, value);
            weatherSphere.atmosphereBias = Mathf.Lerp(block1.atmosphereBias, block2.atmosphereBias, value);
            weatherSphere.atmosphereVariationMax = Mathf.Lerp(block1.atmosphereVariationMax, block2.atmosphereVariationMax, value);
            weatherSphere.atmosphereVariationMin = Mathf.Lerp(block1.atmosphereVariationMin, block2.atmosphereVariationMin, value);
            weatherSphere.cloudColor = Color.Lerp(block1.cloudColor, block2.cloudColor, value);
            weatherSphere.cloudHighlightColor = Color.Lerp(block1.cloudHighlightColor, block2.cloudHighlightColor, value);
            weatherSphere.cloudMoonColor = Color.Lerp(block1.cloudMoonColor, block2.cloudMoonColor, value);
            weatherSphere.cloudMoonHighlightFalloff = Mathf.Lerp(block1.cloudMoonHighlightFalloff, block2.cloudMoonHighlightFalloff, value);
            weatherSphere.cloudSunHighlightFalloff = Mathf.Lerp(block1.cloudSunHighlightFalloff, block2.cloudSunHighlightFalloff, value);
            weatherSphere.cloudTextureColor = Color.Lerp(block1.cloudTextureColor, block2.cloudTextureColor, value);
            weatherSphere.fogColor1 = Color.Lerp(block1.fogColor1, block2.fogColor1, value);
            weatherSphere.fogColor2 = Color.Lerp(block1.fogColor2, block2.fogColor2, value);
            weatherSphere.fogColor3 = Color.Lerp(block1.fogColor3, block2.fogColor3, value);
            weatherSphere.fogColor4 = Color.Lerp(block1.fogColor4, block2.fogColor4, value);
            weatherSphere.fogColor5 = Color.Lerp(block1.fogColor5, block2.fogColor5, value);
            weatherSphere.fogStart1 = Mathf.Lerp(block1.fogStart1, block2.fogStart1, value);
            weatherSphere.fogStart2 = Mathf.Lerp(block1.fogStart2, block2.fogStart2, value);
            weatherSphere.fogStart3 = Mathf.Lerp(block1.fogStart3, block2.fogStart3, value);
            weatherSphere.fogStart4 = Mathf.Lerp(block1.fogStart4, block2.fogStart4, value);
            weatherSphere.fogFlareColor = Color.Lerp(block1.fogFlareColor, block2.fogFlareColor, value);
            weatherSphere.fogHeight = Mathf.Lerp(block1.fogHeight, block2.fogHeight, value);
            weatherSphere.fogDensityMultiplier = Mathf.Lerp(block1.fogDensity, block2.fogDensity, value);
            weatherSphere.fogLightFlareFalloff = Mathf.Lerp(block1.fogLightFlareFalloff, block2.fogLightFlareFalloff, value);
            weatherSphere.fogLightFlareIntensity = Mathf.Lerp(block1.fogLightFlareIntensity, block2.fogLightFlareIntensity, value);
            weatherSphere.fogLightFlareSquish = Mathf.Lerp(block1.fogLightFlareSquish, block2.fogLightFlareSquish, value);
            weatherSphere.galaxy1Color = Color.Lerp(block1.galaxy1Color, block2.galaxy1Color, value);
            weatherSphere.galaxy2Color = Color.Lerp(block1.galaxy2Color, block2.galaxy2Color, value);
            weatherSphere.galaxy3Color = Color.Lerp(block1.galaxy3Color, block2.galaxy3Color, value);
            weatherSphere.galaxyIntensity = Mathf.Lerp(block1.galaxyIntensity, block2.galaxyIntensity, value);
            weatherSphere.highAltitudeCloudColor = Color.Lerp(block1.highAltitudeCloudColor, block2.highAltitudeCloudColor, value);
            weatherSphere.lightScatteringColor = Color.Lerp(block1.lightScatteringColor, block2.lightScatteringColor, value);
            weatherSphere.moonlightColor = Color.Lerp(block1.moonlightColor, block2.moonlightColor, value);
            weatherSphere.moonFalloff = Mathf.Lerp(block1.moonFalloff, block2.moonFalloff, value);
            weatherSphere.moonFlareColor = Color.Lerp(block1.moonFlareColor, block2.moonFlareColor, value);
            weatherSphere.skyHorizonColor = Color.Lerp(block1.skyHorizonColor, block2.skyHorizonColor, value);
            weatherSphere.skyZenithColor = Color.Lerp(block1.skyZenithColor, block2.skyZenithColor, value);
            weatherSphere.starColor = Color.Lerp(block1.starColor, block2.starColor, value);
            weatherSphere.sunColor = Color.Lerp(block1.sunColor, block2.sunColor, value);
            weatherSphere.sunFalloff = Mathf.Lerp(block1.sunFalloff, block2.sunFalloff, value);
            weatherSphere.sunFlareColor = Color.Lerp(block1.sunFlareColor, block2.sunFlareColor, value);
            weatherSphere.sunlightColor = Color.Lerp(block1.sunlightColor, block2.sunlightColor, value);
            weatherSphere.sunSize = Mathf.Lerp(block1.sunSize, block2.sunSize, value);


            currentBlock = value > 0.5 ? colorBlock2 : colorBlock1;

        }

    }

#if UNITY_EDITOR
    [CustomEditor(typeof(BlocksModule))]
    [CanEditMultipleObjects]
    public class E_BlocksModule : E_CozyModule
    {

        BlocksModule t;


        public override GUIContent GetGUIContent()
        {

            //Place your module's GUI content here.
            return new GUIContent("    Blocks", (Texture)Resources.Load("Blocks"), "Override the atmosphere colors with a preset based GUI.");

        }

        public static Texture2D Repaint(Color color, Color secondary, int width, int height)
        {

            var gradTex = new Texture2D(width, height, TextureFormat.ARGB32, false);
            gradTex.filterMode = FilterMode.Bilinear;
            float inv = 1f / (height - 1);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var t = y * inv;
                    Color col = Color.Lerp(color, secondary, t);

                    gradTex.SetPixel(x, y, new Color(col.r, col.g, col.b, 1));

                }
            }
            gradTex.Apply();
            return gradTex;
        }

        void OnEnable()
        {

            t = (BlocksModule)target;

        }

        public override void DisplayInCozyWindow()
        {
            serializedObject.Update();


            serializedObject.FindProperty("selection").boolValue = EditorGUILayout.BeginFoldoutHeaderGroup(serializedObject.FindProperty("selection").boolValue, "    Selection Settings", EditorUtilities.FoldoutStyle());
            EditorGUILayout.EndFoldoutHeaderGroup();

            if (serializedObject.FindProperty("selection").boolValue)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(serializedObject.FindProperty("blockProfile"));
                serializedObject.ApplyModifiedProperties();
                EditorGUI.indentLevel--;
            }

            if (serializedObject.FindProperty("blockProfile").objectReferenceValue)
            {
                serializedObject.FindProperty("blockSettings").boolValue = EditorGUILayout.BeginFoldoutHeaderGroup(serializedObject.FindProperty("blockSettings").boolValue, "    Color Blocks", EditorUtilities.FoldoutStyle());
                EditorGUILayout.EndFoldoutHeaderGroup();

                if (serializedObject.FindProperty("blockSettings").boolValue)
                {


                    EditorGUI.indentLevel++;
                    (Editor.CreateEditor(t.blockProfile) as E_BlockProfile).EditInline(t);
                    EditorGUI.indentLevel--;


                }

                serializedObject.FindProperty("developmentToolkit").boolValue = EditorGUILayout.BeginFoldoutHeaderGroup(serializedObject.FindProperty("developmentToolkit").boolValue, "    Development Toolkit", EditorUtilities.FoldoutStyle());
                EditorGUILayout.EndFoldoutHeaderGroup();

                if (serializedObject.FindProperty("developmentToolkit").boolValue)
                {

                    EditorGUI.indentLevel++;
                    if (t.currentBlock)
                        EditorGUILayout.LabelField($"Current Block is {t.currentBlock.name}");
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("testColorBlock"));
                    EditorGUILayout.Space();
                    t.weatherSphere.currentTicks = EditorGUILayout.Slider("Current Time", t.weatherSphere.currentTicks, 0, t.weatherSphere.perennialProfile.ticksPerDay);
                    t.weatherSphere.currentDay = EditorGUILayout.IntSlider("Current Day", t.weatherSphere.currentDay, 0, t.weatherSphere.perennialProfile.daysPerYear);
                    EditorGUILayout.Space();
                    if (GUILayout.Button("Reset Block Times"))
                        t.GetBlocks();
                    EditorGUI.indentLevel--;

                }

                if (t.testColorBlock)
                    Editor.CreateEditor(t.testColorBlock).OnInspectorGUI();
            }

            serializedObject.ApplyModifiedProperties();

        }

    }

#endif
}