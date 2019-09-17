Imports System.Net
Module Module1

    Sub Main()
        Console.Title = "LABS - File Counter v1.3.0.1906"
        Console.WriteLine("Made by Léo Peyronnet - (c) LPC (LABS) 2019")
        Count()
    End Sub
    Sub Count()
        Dim dir As String
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine("Entrez une commande, 'count' pour compter, 'diskinfo' pour obtenir des infos sur un lecteur.")
        Console.WriteLine("Tapez '?' pour plus d'informations.")
        Console.ForegroundColor = ConsoleColor.Blue
        Dim str As String
        str = Console.ReadLine.ToString
        Dim aarayList() As String = str.Split(" ")
        If aarayList(0) = "diskinfo" Then
            Try
                Dim directory As String = aarayList(1)
                Dim space2 As Object = My.Computer.FileSystem.GetDriveInfo(directory).AvailableFreeSpace / 1000000000
                Dim diskSpaceTotal2 As Object = My.Computer.FileSystem.GetDriveInfo(directory).TotalSize / 1000000000
                Dim a2 As Object = My.Computer.FileSystem.GetDriveInfo(directory)
                Dim pour2 As Integer = space2 / diskSpaceTotal2 * 100 / 2
                Dim res2 As Integer = 50 - pour2
                Dim p2 As Integer = 0
                Dim r2 As Integer = 0
                Console.ForegroundColor = ConsoleColor.White
                Console.WriteLine("Le lecteur " + a2.ToString + " a " + space2.ToString + " GB libre(s) sur un total de " + diskSpaceTotal2.ToString + " GB.")
                Console.ForegroundColor = ConsoleColor.DarkGray
                Console.WriteLine("")
                While r2 < res2
                    Console.Write("|")
                    r2 += 1
                End While
                Console.ForegroundColor = ConsoleColor.DarkGreen
                While p2 < pour2
                    Console.Write("|")
                    p2 += 1
                End While
                p2 = 0
                r2 = 0
                Console.WriteLine("")
                Console.ForegroundColor = ConsoleColor.DarkGray
                Console.Write("|")
                Console.ForegroundColor = ConsoleColor.White
                Console.Write(" = Espace ocuppé    ")
                Console.ForegroundColor = ConsoleColor.DarkGreen
                Console.Write("|")
                Console.ForegroundColor = ConsoleColor.White
                Console.Write(" = Espace libre")
                Console.WriteLine("")
            Catch ex As IndexOutOfRangeException
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("Veuillez spécifier un lecteur.")
                Console.WriteLine("")
            Catch ex As System.IO.DriveNotFoundException
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("Le lecteur choisi est illisible, non-disponible, ou n'existe pas.")
                Console.WriteLine("")
            Catch ex As ArgumentException
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("L'objet doit être un répertoire racine ('C:\') ou une lettre de lecteur ('C').")
                Console.WriteLine("")
            Catch ex As Exception
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("Une erreur s'est produite : " + ex.ToString)
                Console.WriteLine("")
            End Try

            Count()
        ElseIf aarayList(0) = "count" Then
            Try
                dir = aarayList(1)
                Dim f As Integer = 0
                Dim fo As Integer = 0
                Dim files As Object = My.Computer.FileSystem.GetFiles(dir)
                Dim folders As Object = My.Computer.FileSystem.GetDirectories(dir)
                Dim a As Object = My.Computer.FileSystem.GetDriveInfo(dir)
                Dim space As Object = My.Computer.FileSystem.GetDriveInfo(dir).AvailableFreeSpace / 1000000000
                Dim diskName As Object = My.Computer.FileSystem.GetDriveInfo(dir).VolumeLabel
                Dim diskSpaceTotal As Object = My.Computer.FileSystem.GetDriveInfo(dir).TotalSize / 1000000000
                Dim pour As Integer = space / diskSpaceTotal * 100 / 2
                Dim res As Integer = 50 - pour
                Dim p As Integer = 0
                Dim r As Integer = 0
                Console.ForegroundColor = ConsoleColor.White
                Console.WriteLine("Le répertoire choisi se situe sur le lecteur '" & a.ToString & "', nommé '" + diskName.ToString + "'.")
                Console.WriteLine("")
                For Each file In files
                    f += 1
                Next
                For Each folder In folders
                    fo += 1
                Next
                If f > 0 And fo = 0 Then
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.WriteLine("Il y a " & f & " fichier(s) dans ce répertoire.")
                    Console.ForegroundColor = ConsoleColor.White
                ElseIf f = 0 And fo > 0 Then
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.WriteLine("Il y a " & fo & " dossier(s) dans ce répertoire.")
                    Console.ForegroundColor = ConsoleColor.White
                ElseIf f > 0 And fo > 0 Then
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.WriteLine("Il y a " & f & " fichier(s) et " & fo & " dossier(s) dans ce répertoire.")
                    Console.ForegroundColor = ConsoleColor.White
                ElseIf f = 0 And fo = 0 Then
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.WriteLine("Il n'y a pas de fichiers/dossiers dans ce répertoire.")
                    Console.ForegroundColor = ConsoleColor.White
                End If
                Console.WriteLine()
            Catch ex As IndexOutOfRangeException
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("Veuillez spécifier un lecteur.")
                Console.WriteLine("")
            Catch ex As System.IO.DriveNotFoundException
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("Le lecteur choisi est illisible, non-disponible, ou n'existe pas.")
                Console.WriteLine("")
            Catch ex As ArgumentException
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("L'objet doit être un répertoire racine ('C:\') ou une lettre de lecteur ('C').")
                Console.WriteLine("")
            Catch ex As System.IO.DirectoryNotFoundException
                Console.ForegroundColor = ConsoleColor.Red
                If dir = "" Then
                    Console.WriteLine("Impossible de trouver une partie du chemin d'accès.")
                Else
                    Console.WriteLine("Impossible de trouver une partie du chemin d'accès '" + dir + "'.")
                End If

                Console.WriteLine("")
            Catch ex As Exception
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("Une erreur s'est produite : " + ex.ToString)
                Console.WriteLine("")
            End Try


            Count()
        ElseIf aarayList(0) = "?" Then
            Console.ForegroundColor = ConsoleColor.White
            Console.WriteLine("")
            Console.WriteLine("----- Aide -----")
            Console.WriteLine("count : permet de compter le nombre de fichiers et de dossiers dans un répertoire.")
            Console.WriteLine("        Utilisation : count [rep], exemple count C:\")
            Console.WriteLine("diskinfo : Obtient des infos dans un répertoire.")
            Console.WriteLine("           Utilisation : diskinfo [disk], exemple diskinfo C:\")
            Console.WriteLine("update : permet de rechercher les mises à jour")
            Console.WriteLine("         Utilisation : update")
            Console.WriteLine("")

            Count()
        ElseIf aarayList(0) = "update" Then
            Console.ForegroundColor = ConsoleColor.White
            Console.WriteLine("Recherche en cours des mises à jour...")
            Dim MAJ As New WebClient
            Dim Four As New WebClient
            Dim versionActuelle As String = "1.3.0.1906"
            Dim derniereVersion As String = MAJ.DownloadString("https://dl.dropboxusercontent.com/s/jpvq9slc6rw0dtj/Version.txt")
            Dim FourMaj As String = Four.DownloadString("https://dl.dropboxusercontent.com/s/hwh2sldew5nhr07/fournisseur%20de%20la%20mise%20%C3%A0%20jour.txt")
            If versionActuelle = derniereVersion Then
                Console.WriteLine("Tout est à jour !")
                Count()
            Else
                Console.WriteLine("Des mises à jour sont disponibles." & vbNewLine & "La dernière version est : " & derniereVersion & vbNewLine & "Fournit par : " & FourMaj, vbOKOnly + MsgBoxStyle.Information, "Mise à jour du logiciel")
                Dim MAJ2 As New WebClient
                Dim downloadLink As String = MAJ2.DownloadString("https://dl.dropboxusercontent.com/s/jtxrifouhkt3a7d/Download.txt")
                Process.Start(downloadLink)
            End If
        Else
            Console.WriteLine("Commande inconnue. Tapez '?' pour en savoir plus")
        End If

    End Sub
End Module
