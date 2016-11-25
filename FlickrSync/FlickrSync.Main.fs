module FlickrSync.Main

open System
open FlickrSync.Utils

[<EntryPoint>]
let main argv =
  match argv with
  | [||] ->
    eprintf "ERROR: Missing path\n"
    1 // non-zero means error 
  | [| path |] ->
    let startsAt = DateTime.Now
    printf "Starts at: %A\n" startsAt
    let hash = calculateMD5 path
    let endsAt = DateTime.Now
    printf "Ends at: %A\n" endsAt
    let millis =  (endsAt - startsAt).TotalMilliseconds
    printfn "MD5 %f = %s\n" millis hash
    0 // return an integer exit code
  | _ ->
    eprintfn "ERROR: Incorrect number of arguments"
    2 // non-zero means error
