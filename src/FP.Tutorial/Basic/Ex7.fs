namespace FP.Tutorial.Basic
open System
open System.IO
open Unchecked

module Ex7 =
    let doSomething() =
        let getHttpContent (x: Uri) = defaultof<string>
        let getContentFromFile (x: FileInfo) = defaultof<string>
        let lines =
            [
                "http://domain/file1.txt"
                "http://domain/file2.txt"
                "c:\\folder\\file1.txt"
                "c:\\folder\\file2.txt"
                "c:\\folder\\file4.txt"
                "http://domain/file3.txt"
                "c:\\folder\\file3.txt"
                "http://domain/file4.txt"
            ]
        ()