﻿using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace AlteredCarbon
{
    [HotSwappable]
    [StaticConstructorOnStartup]
    public static class UIHelper
    {
        public static float optionOffset = 5;
        public static float labelWidth => 120;
        public static float buttonWidth => 150;
        public static float buttonHeight = 30;
        public static float buttonOffsetFromText = 10;
        public static float buttonOffsetFromButton = 15;
        public static readonly Color StackElementBackground = new Color(1f, 1f, 1f, 0.1f);
        public static Texture2D ChangeColor = ContentFinder<Texture2D>.Get("UI/Commands/ChangeColor");
        public static Texture2D RotateSleeve = ContentFinder<Texture2D>.Get("UI/Icons/RotateSleeve");
        public static Texture2D RandomizeSleeve = ContentFinder<Texture2D>.Get("UI/Icons/RandomizeSleeve");
        public static void DoColorButtons<T>(ref Vector2 pos, string label, List<T> colors, 
            Func<T, Color> colorGetter, Action<T> selectAction)
        {
            Text.Anchor = TextAnchor.MiddleLeft;
            Rect labelRect = GetLabelRect(label + ":", ref pos);
            Widgets.Label(labelRect, label + ":");
            var buttonsInRowCount = (int)((labelWidth + buttonWidth) / 50f) + 1;
            float j = 0;
            for (int i = 0; i < colors.Count; i++)
            {
                if (i > 0 && i % buttonsInRowCount == 0)
                {
                    pos.y += buttonHeight - 2;
                    j = 0;
                }
                Rect rect = new Rect(labelRect.xMax + buttonOffsetFromText + (j * 50), pos.y - buttonHeight - 5, 50, buttonHeight - 2);
                GUI.DrawTexture(rect, BaseContent.GreyTex);
                if (Widgets.ButtonInvisible(rect))
                {
                    SoundDefOf.Tick_Tiny.PlayOneShotOnCamera();
                    selectAction(colors[i]);
                }
                Widgets.DrawBoxSolid(rect.ExpandedBy(-2), colorGetter(colors[i]));
                j++;
            }
        }

        public static void DoSelectionButtons<T>(ref Vector2 pos, string label, ref int index, Func<T, string> labelGetter, List<T> list, Action<T> selectAction)
        {
            if (list.Any())
            {
                if (index < 0)
                {
                    index = 0;
                }
                Text.Anchor = TextAnchor.MiddleLeft;
                Rect labelRect = GetLabelRect(label + ":", ref pos);
                Widgets.Label(labelRect, label + ":");
                Rect highlightRect = new Rect(labelRect.xMax + buttonOffsetFromText, labelRect.y, (buttonWidth * 2) + buttonOffsetFromButton, buttonHeight);
                Widgets.DrawHighlight(highlightRect);
                Rect leftSelectRect = new Rect(highlightRect.x + 2, highlightRect.y, highlightRect.height, highlightRect.height);
                if (ButtonTextSubtleCentered(leftSelectRect, "<"))
                {
                    SoundDefOf.Tick_Tiny.PlayOneShotOnCamera();
                    if (index == 0)
                    {
                        index = list.Count() - 1;
                    }
                    else
                    {
                        index--;
                    }
                    selectAction(list.ElementAt(index));
                }
                Rect centerButtonRect = new Rect(leftSelectRect.xMax + 2, leftSelectRect.y, highlightRect.width - (2 * leftSelectRect.width), buttonHeight);
                if (ButtonTextSubtleCentered(centerButtonRect, labelGetter(list[index])))
                {
                    SoundDefOf.Tick_Tiny.PlayOneShotOnCamera();
                    FloatMenuUtility.MakeMenu<T>(list, x => labelGetter(x), (T x) => delegate
                    {
                        selectAction(x);
                    });
                }
                Rect rightButtonRect = new Rect(centerButtonRect.xMax + 2, leftSelectRect.y, leftSelectRect.width, leftSelectRect.height);
                if (ButtonTextSubtleCentered(rightButtonRect, ">"))
                {
                    SoundDefOf.Tick_Tiny.PlayOneShotOnCamera();
                    if (index == list.Count() - 1)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                    selectAction(list.ElementAt(index));
                }
            }
        }

        public static Rect GetLabelRect(string label, ref Vector2 pos, float? labelWidthOverride = null)
        {
            var width = labelWidthOverride ?? labelWidth;
            var height = Mathf.Max(buttonHeight, Text.CalcHeight(label, width));
            Rect rect = new Rect(pos.x, pos.y, width, height);
            pos.y += buttonHeight + 5;
            return rect;
        }
        public static Rect GetLabelRect(ref Vector2 pos, float labelWidth, float labelHeight)
        {
            Rect rect = new Rect(pos.x, pos.y, labelWidth, labelHeight);
            pos.y += labelHeight + 5;
            return rect;
        }

        public static void ListSeparator(ref Vector2 pos, float width, string label)
        {
            Color color = GUI.color;
            pos.y += 3f;
            GUI.color = Widgets.SeparatorLabelColor;
            Rect rect = new Rect(pos.x, pos.y, width, 30f);
            Text.Anchor = TextAnchor.UpperCenter;
            Widgets.Label(rect, label);
            pos.y += 20f;
            GUI.color = Widgets.SeparatorLineColor;
            Widgets.DrawLineHorizontal(pos.x, pos.y, width);
            pos.y += 2f;
            GUI.color = color;
            Text.Anchor = TextAnchor.UpperLeft;
        }

        //button text subtle copied from Rimworld basecode but with minor changes to fit this UI
        public static bool ButtonTextSubtleCentered(Rect rect, string label, Vector2 functionalSizeOffset = default)
        {
            Rect rect2 = rect;
            rect2.width += functionalSizeOffset.x;
            rect2.height += functionalSizeOffset.y;
            bool flag = false;
            if (Mouse.IsOver(rect2))
            {
                flag = true;
                GUI.color = GenUI.MouseoverColor;
            }
            Widgets.DrawAtlas(rect, Widgets.ButtonSubtleAtlas);
            GUI.color = Color.white;
            Rect rect3 = new Rect(rect);
            if (flag)
            {
                rect3.x += 2f;
                rect3.y -= 2f;
            }
            Text.Anchor = TextAnchor.MiddleCenter;
            Text.WordWrap = false;
            Text.Font = GameFont.Small;
            Widgets.Label(rect3, label);
            Text.Anchor = TextAnchor.MiddleLeft;
            Text.WordWrap = true;
            return Widgets.ButtonInvisible(rect2, false);
        }

        public static float ReturnYfromPrevious(Rect rect)
        {
            float y;
            y = rect.y;
            y += rect.height;
            y += optionOffset;

            return y;
        }

        public static void DrawExplanation(ref Vector2 pos, float width, float height, string explanation)
        {
            Rect explanationLabelRect = GetLabelRect(ref pos, width, height);
            Text.Font = GameFont.Tiny;
            GUI.color = Color.grey;
            Widgets.Label(explanationLabelRect, explanation);
            GUI.color = Color.white;
            Text.Font = GameFont.Small;
        }

        public static string SplitCamelCase(this string str)
        {
            return Regex.Replace(
                Regex.Replace(
                    str,
                    @"(\P{Ll})(\P{Ll}\p{Ll})",
                    "$1 $2"
                ),
                @"(\p{Ll})(\P{Ll})",
                "$1 $2"
            );
        }

        public static string FirstCharToUpper(this string input)
        {
            return input[0].ToString().ToUpper() + input.Substring(1).ToLower();
        }
    }
}
