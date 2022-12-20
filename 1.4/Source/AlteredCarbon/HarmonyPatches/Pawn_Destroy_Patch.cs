﻿using HarmonyLib;
using Verse;

namespace AlteredCarbon
{
    [HarmonyPatch(typeof(Pawn), "Destroy")]
    public static class Pawn_Destroy_Patch
    {
        public static void Prefix(Pawn __instance)
        {
            if (__instance.Corpse is null && __instance.HasCorticalStack(out var stackHediff))
            {
                if (stackHediff.def == AC_DefOf.AC_ArchoStack)
                {
                    stackHediff.preventKill = true;
                    stackHediff.SpawnStack(placeMode: ThingPlaceMode.Direct, psycastEffect: true);
                }
            }
        }
    }
}

