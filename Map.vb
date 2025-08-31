Imports System
Imports System.IO
Imports System.Collections.Generic

Namespace LAGE
    Public Class Map
        Private width_ As Integer
        Private height_ As Integer
        Private mapData_ As List(Of String)

        Public Sub New()
            width_ = 0
            height_ = 0
            mapData_ = New List(Of String)()
        End Sub

        Public Function Load(filename As String) As Boolean
            Try
                If Not File.Exists(filename) Then
                    Console.Error.WriteLine("Error: Could not open map file: " & filename)
                    Return False
                End If

                mapData_.Clear()
                Dim lines As String() = File.ReadAllLines(filename)

                For Each line As String In lines
                    mapData_.Add(line)
                Next

                If mapData_.Count > 0 Then
                    height_ = mapData_.Count
                    width_ = mapData_(0).Length

                    For Each row As String In mapData_
                        If row.Length <> width_ Then
                            Console.Error.WriteLine("Error: inconsistent map width!")
                            Return False
                        End If
                    Next
                Else
                    Console.Error.WriteLine("Error: Map file is empty")
                    Return False
                End If

                Return True

            Catch ex As Exception
                Console.Error.WriteLine("Error loading map: " & ex.Message)
                Return False
            End Try
        End Function

        Public Function GetTile(x As Integer, y As Integer) As Char
            If x >= 0 AndAlso x < width_ AndAlso y >= 0 AndAlso y < height_ Then
                Return mapData_(y)(x)
            End If
            Return "#"c 
        End Function

        Public Function IsWalkable(x As Single, y As Single) As Boolean
            ' i hate it
            Dim floorX As Integer = CInt(x)
            Dim floorY As Integer = CInt(y)
            Dim ceilX As Integer = CInt(x - 1.1F)
            Dim ceilY As Integer = CInt(y - 1.2F)
            

            If GetTile(floorX, floorY) = "#"c OrElse
               GetTile(floorX, ceilY) = "#"c OrElse
               GetTile(ceilX, floorY) = "#"c OrElse
               GetTile(ceilX, ceilY) = "#"c Then
                Return False
            End If
            
            Return True
        End Function

        Public Function GetWidth() As Integer
            Return width_
        End Function

        Public Function GetHeight() As Integer
            Return height_
        End Function
        
        Public Sub SetTile(x As Integer, y As Integer, tile As Char)
            If x >= 0 AndAlso x < width_ AndAlso y >= 0 AndAlso y < height_ Then
                Dim row As Char() = mapData_(y).ToCharArray()
                row(x) = tile
                mapData_(y) = New String(row)
            End If
        End Sub
    End Class
End Namespace