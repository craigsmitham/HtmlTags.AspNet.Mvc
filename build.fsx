// include Fake lib
#r @"packages\FAKE\tools\FakeLib.dll"
open Fake
open System
open Fake.AssemblyInfoFile

RestorePackages()

type Project = { name: string;  version: string; authors: List<string>; description: string; summary: string; tags: string}
let authors = ["Craig Smitham"]

let version = "0.0.1";

// The project name should be the same as the project directory
let core= { 
    name = "HtmlTags.AspNet.Mvc"; 
    version = version; 
    authors = authors; 
    summary = "";
    description = "HtmlTag toolkit for ASP.NET MVC";
    tags = "" }

let structureMap = { 
    name = "HtmlTags.AspNet.Mvc.StructureMap"; 
    version = version;
    authors = authors; 
    summary = "";
    description = "StructureMap 3 IOC Integration for HtmlTags.AspNet.Mvc";
    tags = "" }

let bootstrap = { 
    name = "HtmlTags.AspNet.Mvc.Bootstrap"; 
    version = "0.3.2";  
    authors = authors; 
    summary = "";
    description = "";
    tags = ""}

let foundation = { 
    name = "HtmlTags.AspNet.Mvc.Foundation"; 
    version = "0.5.0";  
    authors = authors; 
    summary = "";
    description = "";
    tags = "" }

let projects = [ core; structureMap; bootstrap; foundation ]

let buildMode = getBuildParamOrDefault "buildMode" "Release"
let testResultsDir = "./testresults"
let packagesDir = "./packages/"
let packagingRoot = "./packaging/"
let projectBins =  projects |> List.map(fun p -> "./" @@ p.name @@ "/bin")
let projectPackagingDirs =  projects |> List.map(fun p -> packagingRoot @@ p.name)

let buildNumber = environVarOrDefault "APPVEYOR_BUILD_NUMBER" "0"
let buildVersion = environVarOrDefault "APPVEYOR_BUILD_VERSION" "0.0.0.0"
let packageVersion = ""
let assemblyVersion = ""
let assemblyFileVersion = ""

// Targets



Target "Clean" (fun _ -> 
   List.concat [projectBins; projectPackagingDirs; [testResultsDir; packagingRoot]] |> CleanDirs
)

Target "AssemblyInfo" (fun _ ->
    CreateCSharpAssemblyInfo "./SolutionInfo.cs"
      [ Attribute.Product core.name 
        Attribute.Version assemblyVersion
        Attribute.FileVersion assemblyFileVersion
        Attribute.ComVisible false ]
)

Target "BuildApp" (fun _ ->
   MSBuild null "Build" ["Configuration", buildMode] ["./HtmlTags.AspNet.Mvc.sln"] |> Log "AppBuild-Output: "
)


let useDefaults = None
let withCustomParams (configuration: NuGetParams -> NuGetParams) = 
    Some(configuration)

let createNuGetPackage (project:Project) (customParams: (NuGetParams -> NuGetParams) option) = 
    let packagingDir = (packagingRoot @@ project.name @@ "/");
    let net45Dir =  (packagingDir @@ "lib/net45")
    let buildDir = ("./" @@ project.name @@ "/bin")
    let nugetLocalFeed = environVar "NuGetLocalFeed" 
    let remoteUrl = getBuildParam "nugeturl" 
    let nugetKey = getBuildParam "nugetkey" 
    let publish = nugetLocalFeed <> "" || remoteUrl <> "" && nugetKey <> ""
    let publishUrl =
        if remoteUrl <> "" && nugetKey <> "" then remoteUrl
        else nugetLocalFeed
        
    CleanDir net45Dir
    CopyFile net45Dir (buildDir @@ "Release/" @@ project.name + ".dll")
    CopyFiles packagingDir ["LICENSE.txt"; "README.md"]

    NuGet((fun p -> 
        {p with 

            Project = project.name
            Authors = project.authors 
            Description = project.description 
            OutputPath = packagingRoot 
            Summary = project.summary 
            WorkingDir = packagingDir
            Version = project.version 
            Tags = project.tags
            PublishUrl = publishUrl
            AccessKey = nugetKey
            Publish = publish } 
            |>  match customParams with
                | Some(customParams) -> customParams
                | None -> (fun p -> p))) "./nuget/base.nuspec"


Target "CreateCorePackage" (fun _ -> 
    createNuGetPackage core 
        (withCustomParams(fun p -> 
            {p with 
                Dependencies =
                    ["FubuMVC.Core.UI", GetPackageVersion packagesDir "FubuMVC.Core.UI"] }))
)

Target "CreateStructureMapPackage" (fun _ -> 
    createNuGetPackage structureMap 
        (withCustomParams(fun p -> 
            {p with 
                Dependencies =
                    ["FubuMVC.Core.UI", GetPackageVersion packagesDir "FubuMVC.Core.UI"
                     "FubuMVC.StructureMap3", GetPackageVersion packagesDir "FubuMVC.StructureMap3"] }))
)

Target "CreatePackages" DoNothing
Target "Default" DoNothing

"Clean"
    ==> "AssemblyInfo"
        ==> "BuildApp"

"CreateCorePackage"
    ==> "CreatePackages"

"CreateStructureMapPackage"
    ==> "CreatePackages"


// start build
RunTargetOrDefault "Default"