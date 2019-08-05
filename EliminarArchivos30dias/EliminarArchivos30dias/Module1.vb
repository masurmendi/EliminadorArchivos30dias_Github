Imports System.IO

Module Module1

    Sub Main()
        Dim logger = NLog.LogManager.GetCurrentClassLogger()


        Dim carpetas(1) As DirectoryInfo

        carpetas(0) = New DirectoryInfo(My.Settings.Ruta1)
        carpetas(1) = New DirectoryInfo(My.Settings.Ruta2)

        Try
            For Each folder In carpetas
                For Each file As FileInfo In folder.GetFiles()
                    Dim fechaModificacion As Date = file.LastWriteTime()
                    Dim fechaLimite As Date = Date.Today.AddDays(My.Settings.DiasMenos)

                    If fechaLimite > fechaModificacion Then
                        logger.Info(DateTime.Now + " - " + "Se va a eliminar el archivo " + file.FullName)
                        file.Delete()
                        logger.Info(DateTime.Now + " - " + "Se ha eliminado el archivo " + file.FullName)
                    End If
                Next
            Next

        Catch ex As Exception
            logger.Info(DateTime.Now + "Ha habido un fallo: " + ex.Message)
        End Try

        NLog.LogManager.Shutdown()
    End Sub

End Module
