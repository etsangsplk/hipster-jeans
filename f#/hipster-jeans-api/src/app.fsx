#r "../packages/Suave/lib/net40/Suave.dll"
#r "../packages/Suave.Swagger/lib/Suave.Swagger.dll"
#r "../packages/Newtonsoft.Json/lib/portable-net45+wp80+win8+wpa81/Newtonsoft.Json.dll"
#load "data.fs"

open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful
open Suave.CORS
open Hipster.Data

let app =
  choose
    [ GET >=> choose
        [ path "/sales" >=> cors defaultCORSConfig  >=> getData  ]
    ]


let getLocalServerConfig port =
  { defaultConfig with
      homeFolder = Some __SOURCE_DIRECTORY__
      bindings = [ HttpBinding.createSimple HTTP  "0.0.0.0" port ] }

startWebServer (getLocalServerConfig 8083) app
