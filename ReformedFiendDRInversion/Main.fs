namespace ReformedFiendDRInversion

open System
open System.Reflection

open UnityModManagerNet
open HarmonyLib

module Main =
    let mutable public Enabled = false

    let mutable private ModEntry = null

    let OnToggle (modEntry : UnityModManager.ModEntry) (value : bool) =
        Enabled <- value
        true

    let Load(modEntry : UnityModManager.ModEntry) =
        ModEntry <- modEntry
        modEntry.OnToggle <- OnToggle
        
        let harmony = new Harmony(modEntry.Info.Id)
        harmony.PatchAll(Assembly.GetExecutingAssembly())
        true

    let Log = ModEntry.Logger.Log