Imports System
Imports System.IO
Imports System.Collections.Generic

Namespace LAGE
    Public Class Config
        Private configData_ As Dictionary(Of String, String)

        Public Sub New()
            configData_ = New Dictionary(Of String, String)()
        End Sub

        Public Function Load(filename As String) As Boolean
            Try
                If Not File.Exists(filename) Then
                    Console.Error.WriteLine("Error: Could not open config file: " & filename)
                    Return False
                End If

                configData_.Clear()
                Dim lines As String() = File.ReadAllLines(filename)

                For Each line As String In lines
                    Dim parts As String() = line.Split("="c, 2)
                    If parts.Length = 2 Then
                        configData_(parts(0)) = parts(1)
                    End If
                Next

                Return True

            Catch ex As Exception
                Console.Error.WriteLine("Error loading config: " & ex.Message)
                Return False
            End Try
        End Function

        Public Function [Get](key As String) As String
            If configData_.ContainsKey(key) Then
                Return configData_(key)
            End If
            Return ""
        End Function

        Public Function GetInt(key As String) As Integer
            If configData_.ContainsKey(key) Then
                Try
                    Return Integer.Parse(configData_(key))
                Catch ex As FormatException
                    Console.Error.WriteLine("Error: Invalid integer value for key '" & key & "'")
                    Return 0
                Catch ex As OverflowException
                    Console.Error.WriteLine("Error: Invalid integer value range for key '" & key & "'")
                    Return 0
                End Try
            End If
            Return 0
        End Function

        Public Sub [Set](key As String, value As String)
            configData_(key) = value
        End Sub

        Public Sub SetInt(key As String, value As Integer)
            configData_(key) = value.ToString()
        End Sub
    End Class
End Namespace