module BuildStats.Views

open Giraffe.GiraffeViewEngine
open BuildStats.Common

let minifiedCss =
    "Assets/site.css"
    |> StaticAssets.minifyCssFile

let cssHash = Hash.sha1 minifiedCss

let masterView (pageTitle : string)
               (content   : XmlNode list) =
    html [] [
        head [] [
            meta [ _charset "utf-8" ]
            meta [ _name "description"; _content "Little SVG widget to display AppVeyor, TravisCI, CircleCI or Azure Pipelines build history charts and other SVG badges" ]
            meta [ _name "author"; _content "Dustin Moris Gorski, https://dusted.codes/" ]

            link [ attr "href" (sprintf "/site.css?v=%s" cssHash); attr "rel" "stylesheet" ]

            title [] [ encodedText pageTitle ]
        ]
        body [] content
    ]

let indexView =
    [
        main [] [
            h1 [] [ rawText "BuildStats.info" ]
            h2 [] [ rawText "SVG widget to display build history charts and other badges" ]

            h3 [] [ rawText "Build History Chart" ]
            p [] [ rawText "Add a build history widget to your public GitHub repository:" ]
            img [ _src "/appveyor/chart/dustinmoris/dustedcodes?branch=master" ]

            h3 [] [ rawText "NuGet and MyGet Badges" ]
            p [] [ rawText "Display a badge for your NuGet or MyGet packages:" ]
            img [ _src "/nuget/nunit" ]

            h3 [] [ rawText "About" ]
            p [] [
                rawText "For more information please visit the "
                a [ _href "https://github.com/dustinmoris/CI-BuildStats" ] [ rawText "official GitHub repository" ]
                rawText "."
            ]
            p [] [
                rawText "BuildStats.info is provided by "
                a [ _href "https://dusted.codes/" ] [ rawText "Dustin Moris Gorski" ]
                rawText "."
            ]
        ]
    ] |> masterView "BuildStats.info"

let createApiTokenView =
    [
        main [] [
            h1 [] [ rawText "BuildStats.info" ]
            h2 [] [ rawText "SVG widget to display build history charts and other badges" ]

            form [ _method "POST" ] [
                input [ _id "plaintext"; _name "plaintext"; _type "text" ]
                input [ _type "submit" ]
            ]
        ]
    ] |> masterView "BuildStats.info"

let visualTestsView =
    [
        main [] [
            h1 [] [ rawText "BuildStats.info" ]

            h2 [] [ rawText "Build History Chart" ]

            h3 [] [ rawText "AppVeyor" ]
            table [] [
                tr [] [
                    th [] [ rawText "Basic" ]
                    td [] [ img [ _src "/appveyor/chart/CharliePoole/nunit" ] ]
                ]
                tr [] [
                    th [] [ rawText "Branch Filter" ]
                    td [] [ img [ _src "/appveyor/chart/CharliePoole/nunit?branch=master" ] ]
                ]
                tr [] [
                    th [] [ rawText "Reduced BuildCount" ]
                    td [] [ img [ _src "/appveyor/chart/CharliePoole/nunit?buildCount=10" ] ]
                ]
                tr [] [
                    th [] [ rawText "Increased BuildCount" ]
                    td [] [ img [ _src "/appveyor/chart/CharliePoole/nunit?buildCount=40" ] ]
                ]
                tr [] [
                    th [] [ rawText "Exclude PullRequests" ]
                    td [] [ img [ _src "/appveyor/chart/CharliePoole/nunit?includeBuildsFromPullRequest=false" ] ]
                ]
                tr [] [
                    th [] [ rawText "Hide Stats" ]
                    td [] [ img [ _src "/appveyor/chart/CharliePoole/nunit?showStats=false" ] ]
                ]
            ]

            h3 [] [ rawText "TravisCI" ]
            table [] [
                tr [] [
                    th [] [ rawText "Basic" ]
                    td [] [ img [ _src "/travisci/chart/nunit/nunit" ] ]
                ]
                tr [] [
                    th [] [ rawText "Branch Filter" ]
                    td [] [ img [ _src "/travisci/chart/nunit/nunit?branch=master" ] ]
                ]
                tr [] [
                    th [] [ rawText "Reduced BuildCount" ]
                    td [] [ img [ _src "/travisci/chart/nunit/nunit?buildCount=10" ] ]
                ]
                tr [] [
                    th [] [ rawText "Increased BuildCount" ]
                    td [] [ img [ _src "/travisci/chart/nunit/nunit?buildCount=40" ] ]
                ]
                tr [] [
                    th [] [ rawText "Exclude PullRequests" ]
                    td [] [ img [ _src "/travisci/chart/nunit/nunit?includeBuildsFromPullRequest=false" ] ]
                ]
                tr [] [
                    th [] [ rawText "Hide Stats" ]
                    td [] [ img [ _src "/travisci/chart/nunit/nunit?showStats=false" ] ]
                ]
                tr [] [
                    th [] [ rawText "Travis-CI.com" ]
                    td [] [ img [ _src "/travisci/chart/martincostello/sqllocaldb?branch=master&includeBuildsFromPullRequest=false" ] ]
                ]
            ]

            h3 [] [ rawText "CircleCI" ]
            table [] [
                tr [] [
                    th [] [ rawText "Basic" ]
                    td [] [ img [ _src "/circleci/chart/spotify/helios" ] ]
                ]
                tr [] [
                    th [] [ rawText "Branch Filter" ]
                    td [] [ img [ _src "/circleci/chart/spotify/helios?branch=master" ] ]
                ]
                tr [] [
                    th [] [ rawText "Reduced BuildCount" ]
                    td [] [ img [ _src "/circleci/chart/spotify/helios?buildCount=10" ] ]
                ]
                tr [] [
                    th [] [ rawText "Increased BuildCount" ]
                    td [] [ img [ _src "/circleci/chart/spotify/helios?buildCount=40" ] ]
                ]
                tr [] [
                    th [] [ rawText "Exclude PullRequests" ]
                    td [] [ img [ _src "/circleci/chart/spotify/helios?includeBuildsFromPullRequest=false" ] ]
                ]
                tr [] [
                    th [] [ rawText "Hide Stats" ]
                    td [] [ img [ _src "/circleci/chart/spotify/helios?showStats=false" ] ]
                ]
            ]

            h3 [] [ rawText "Azure Pipelines" ]
            table [] [
                tr [] [
                    th [] [ rawText "Basic" ]
                    td [] [ img [ _src "/azurepipelines/chart/github/Desktop" ] ]
                ]
                tr [] [
                    th [] [ rawText "Branch Filter" ]
                    td [] [ img [ _src "/azurepipelines/chart/github/Desktop?branch=master" ] ]
                ]
                tr [] [
                    th [] [ rawText "Build Definition Filter" ]
                    td [] [ img [ _src "/azurepipelines/chart/dnceng/public?branch=master&definitionId=59" ] ]
                ]
                tr [] [
                    th [] [ rawText "Reduced BuildCount" ]
                    td [] [ img [ _src "/azurepipelines/chart/github/Desktop?buildCount=10" ] ]
                ]
                tr [] [
                    th [] [ rawText "Increased BuildCount" ]
                    td [] [ img [ _src "/azurepipelines/chart/github/Desktop?buildCount=40" ] ]
                ]
                tr [] [
                    th [] [ rawText "Exclude PullRequests" ]
                    td [] [ img [ _src "/azurepipelines/chart/github/Desktop?includeBuildsFromPullRequest=false" ] ]
                ]
                tr [] [
                    th [] [ rawText "Hide Stats" ]
                    td [] [ img [ _src "/azurepipelines/chart/github/Desktop?showStats=false" ] ]
                ]
                tr [] [
                    th [] [ rawText "Branch and Exclude PullRequests" ]
                    td [] [ img [ _src "/azurepipelines/chart/martincostello/sqllocaldb?branch=master&includeBuildsFromPullRequest=false" ] ]
                ]
            ]

            h2 [] [ rawText "Package Badges" ]

            h3 [] [ rawText "NuGet" ]
            table [] [
                tr [] [
                    th [] [ rawText "Lanem" ]
                    td [] [ img [ _src "/nuget/lanem" ] ]
                ]
                tr [] [
                    th [] [ rawText "Guardo" ]
                    td [] [ img [ _src "/nuget/guardo" ] ]
                ]
                tr [] [
                    th [] [ rawText "Newtonsoft.Json" ]
                    td [] [ img [ _src "/nuget/Newtonsoft.Json" ] ]
                ]
                tr [] [
                    th [] [ rawText "Moq" ]
                    td [] [ img [ _src "/nuget/moq" ] ]
                ]
                tr [] [
                    th [] [ rawText "Nunit" ]
                    td [] [ img [ _src "/nuget/nunit" ] ]
                ]
                tr [] [
                    th [] [ rawText "NSubstitute" ]
                    td [] [ img [ _src "/nuget/nsubstitute" ] ]
                ]
                tr [] [
                    th [] [ rawText "jQuery" ]
                    td [] [ img [ _src "/nuget/jQuery" ] ]
                ]
                tr [] [
                    th [] [ rawText "ASP.NET MVC" ]
                    td [] [ img [ _src "/nuget/microsoft.aspnet.mvc" ] ]
                ]
                tr [] [
                    th [] [ rawText "EntityFramework" ]
                    td [] [ img [ _src "/nuget/entityframework" ] ]
                ]
                tr [] [
                    th [] [ rawText "NServiceBus.PostgreSQL" ]
                    td [] [ img [ _src "/nuget/NServiceBus.PostgreSQL?includePreReleases=true" ] ]
                ]
            ]

            h3 [] [ rawText "My/Get" ]
            table [] [
                tr [] [
                    th [] [ rawText "neventsocket-prerelease/NEventSocket" ]
                    td [] [ img [ _src "/myget/neventsocket-prerelease/NEventSocket" ] ]
                ]
            ]

            p [] [
                rawText "BuildStats.info is provided by "
                a [ _href "https://dusted.codes/" ] [ rawText "Dustin Moris Gorski" ]
                rawText "."
            ]
        ]
    ] |> masterView "BuildStats.info"
