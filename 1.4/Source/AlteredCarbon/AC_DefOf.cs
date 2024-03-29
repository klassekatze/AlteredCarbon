﻿using RimWorld;
using Verse;
using VFECore;

namespace AlteredCarbon
{
    public class MayRequireHelixienModAttribute : MayRequireAttribute
    {
        public MayRequireHelixienModAttribute()
            : base("hlx.UltratechAlteredCarbon")
        {
        }
    }
    [DefOf]
    public static class AC_DefOf
    {
        [MayRequireHelixienMod] public static ThoughtDef AC_JustCopy;
        [MayRequireHelixienMod] public static ThoughtDef AC_LostMySpouse;
        [MayRequireHelixienMod] public static ThoughtDef AC_LostMyFiance;
        [MayRequireHelixienMod] public static ThoughtDef AC_LostMyLover;
        [MayRequireHelixienMod] public static PawnRelationDef AC_Original;
        [MayRequireHelixienMod] public static PawnRelationDef AC_Copy;
        [MayRequireHelixienMod] public static ThingDef AC_FilledArchoStack;
        [MayRequireHelixienMod] public static ThingDef AC_EmptyArchoStack;
        [MayRequireHelixienMod] public static HediffDef AC_ArchoStack;
        [MayRequireHelixienMod] public static RecipeDef AC_InstallArchoStack;
        [MayRequireHelixienMod] public static RecipeDef AC_InstallEmptyArchoStack;
        [MayRequireHelixienMod] public static VFECore.Abilities.AbilityDef AC_ArchoStackSkip;

        public static VEBackstoryDef VFEU_VatGrownChild;
        public static VEBackstoryDef VFEU_VatGrownAdult;
        public static ThingDef VFEU_EmptyCorticalStack;
        public static ThingDef VFEU_FilledCorticalStack;
        public static JobDef VFEU_ExtractStack;
        public static JobDef VFEU_StartIncubatingProcess;
        public static JobDef VFEU_CancelIncubatingProcess;
        public static HediffDef VFEU_CorticalStack;
        public static HediffDef VFEU_Sleeve_Quality_Awful;
        public static HediffDef VFEU_Sleeve_Quality_Poor;
        public static HediffDef VFEU_Sleeve_Quality_Normal;
        public static HediffDef VFEU_Sleeve_Quality_Good;
        public static HediffDef VFEU_Sleeve_Quality_Excellent;
        public static HediffDef VFEU_Sleeve_Quality_Masterwork;
        public static HediffDef VFEU_Sleeve_Quality_Legendary;
        public static HediffDef VFEU_EmptySleeve;
        public static HediffDef VFEU_SleeveShock;
        public static ThingDef VFEU_AncientStack;
        public static ThingDef VFEU_SleeveIncubator;
        public static ThingDef VFEU_SleeveCasket;
        public static ThingDef VFEU_DecryptionBench;
        public static RecipeDef VFEU_WipeFilledCorticalStack;
        public static RecipeDef VFEU_InstallCorticalStack;
        public static RecipeDef VFEU_InstallEmptyCorticalStack;
        public static SpecialThingFilterDef VFEU_AllowStacksColonist;
        public static SpecialThingFilterDef VFEU_AllowStacksStranger;
        public static SpecialThingFilterDef VFEU_AllowStacksHostile;
        public static ThoughtDef VFEU_WrongGender;
        public static ThoughtDef VFEU_WrongGenderDouble;
        public static ThoughtDef VFEU_WrongGenderPregnant;
        public static ThoughtDef VFEU_WrongGenderChild;
        public static ThoughtDef VFEU_WrongRace;
        public static ThoughtDef VFEU_NewSleeve;
        public static ThoughtDef VFEU_NewSleeveDouble;
        public static ThoughtDef VFEU_MansBody;
        public static ThoughtDef VFEU_WomansBody;
        public static ThoughtDef VFEU_SomethingIsWrong;
        public static DesignationDef VFEU_ExtractStackDesignation;
        public static DamageDef VFEU_Deterioration;
        public static ThingDef VFEU_Mote_VatGlow;
        public static EffecterDef VFEU_Vat_Bubbles;
        public static LetterDef HumanPregnancy;
        public static FleckDef PsycastAreaEffect;
    }
}