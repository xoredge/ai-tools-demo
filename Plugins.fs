module AiToolsFsharp.Plugins

open System
open System.ComponentModel
open System.Threading.Tasks
open Microsoft.SemanticKernel

type LightModel =
    { Id: int
      Name: string
      mutable IsOn: bool }

type LightsPlugin() =
    let lights =
        [| { Id = 1
             Name = "Living Room"
             IsOn = false }
           { Id = 2
             Name = "Kitchen"
             IsOn = true }
           { Id = 3
             Name = "Bedroom"
             IsOn = true } |]

    [<KernelFunction("get_lights")>]
    [<Description("Get a list of all the lights with their status")>]
    member this.GetLightsAsync() =
        let _lights = String.Join(", ", lights |> Array.map (fun l -> $"""{l.Name} is {(if l.IsOn then "on" else "off")}"""))
        printfn $"App: getting all lights: {_lights}"
        Task.FromResult<LightModel array> lights

    [<KernelFunction("change_light_state")>]
    [<Description("Change the state of a light")>]
    member this.ChangeLightStateAsync
        (
            [<Description("The id of the light to change")>] id: int,
            [<Description("The new state of the light")>] isOn: bool
        ) =
        printfn $"App: Changing status of light ID: {id} to {isOn}"
        let light = Array.tryFind (fun l -> l.Id = id) lights

        match light with
        | None -> Task.FromResult<LightModel option>(None)
        | Some _light ->
            _light.IsOn <- isOn
            Task.FromResult<LightModel option>(Some _light)

type UtilsPlugin () =
    [<KernelFunction("get_today_date")>]
    [<Description("Get today date")>]
    member this.GetTodayDateAsync() =
        printfn $"App: Getting toay date"
        Task.FromResult<DateTime>(DateTime.Now)

    [<KernelFunction("multiply_two_numbers")>]
    [<Description("Multiply two numbers")>]
    member this.MultiplyAsync
        (
            [<Description("The first number")>] a: int,
            [<Description("The second number")>] b: int
        ) =
        printfn $"App: Multiplying {a} by {b}"
        Task.FromResult<int>(a * b)

    [<KernelFunction("get_date_difference")>]
    [<Description("Get difference between two dates in number of days")>]
    member this.GetDateDifferenceAsync
        (
            [<Description("The first date")>] date1: DateTime,
            [<Description("The second date")>] date2: DateTime
        ) =
        printfn $"App: Getting difference between {date1} and {date2}"
        Task.FromResult<int>(Convert.ToInt32((date2 - date1).TotalDays))