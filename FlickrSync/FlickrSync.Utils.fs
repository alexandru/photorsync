module FlickrSync.Utils

open System.Security.Cryptography
open System.Text
open System.IO

let calculateMD5 path =
  use md5 = MD5.Create()
  use stream = File.Open (path, FileMode.Open, FileAccess.Read)
  let hash = md5.ComputeHash stream
  let builder = new StringBuilder()
  for b in hash do builder.Append(b.ToString("X2")) |> ignore
  builder.ToString()