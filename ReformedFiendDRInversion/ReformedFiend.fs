namespace ReformedFiendDRInversion

open System

open Kingmaker
open Kingmaker.Blueprints.JsonSystem
open Kingmaker.Blueprints.Classes
open Kingmaker.Blueprints
open Kingmaker.UnitLogic.FactLogic
open Kingmaker.Enums.Damage

open UnityModManagerNet
open HarmonyLib

[<HarmonyPatch(typeof<BlueprintsCache>, "Init")>]
module BlueprintsCache_Init_Patch =
    let mutable private InitDone = false

    let PatchReformedFiendDR() =
        let feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("2a3243ad1ccf43d5a5d69de3f9d0420e")

        if feature = null then Main.Log "Blueprint not found"
        else
            Main.Log "Setting Description"

            Utility.Feat.ChangeDescription(feature, fun s -> s.Replace("evil", "good"))
            
            Main.Log "Patching DR"

            let dr = feature.GetComponent<AddDamageResistancePhysical>()
            
            dr.Alignment <- DamageAlignment.Good

    let Postfix() : unit =
        if not InitDone then
            InitDone <- true

            PatchReformedFiendDR()
