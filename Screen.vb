Imports SFML.Graphics
Imports SFML.Window
Imports System
Imports System.Runtime.InteropServices
Imports SFML.System

Namespace LAGE
    Public Class Screen
        Implements IDisposable

        Private width_ As Integer
        Private height_ As Integer
        Private pixels_ As UInteger()
        
        ' SFML 
        Private window_ As RenderWindow
        Private texture_ As Texture
        Private sprite_ As Sprite
        Private image_ As Image
        
        Public Event KeyPressed As EventHandler(Of KeyEventArgs)
        Public Event KeyReleased As EventHandler(Of KeyEventArgs)
        Public Event MouseMoved As EventHandler(Of MouseMoveEventArgs)
        Public Event MousePressed As EventHandler(Of MouseButtonEventArgs)
        Public Event MouseReleased As EventHandler(Of MouseButtonEventArgs)
        Public Event Closed As EventHandler

        Public Sub New(width As Integer, height As Integer, title As String)
            width_ = width
            height_ = height
            pixels_ = New UInteger(width * height - 1) {}
            
            ' Инициализация SFML окна
            Dim mode As New VideoMode(CUInt(width), CUInt(height))
            window_ = New RenderWindow(mode, title, Styles.Close)
            texture_ = New Texture(CUInt(width), CUInt(height))
            sprite_ = New Sprite(texture_)

            AddHandler window_.KeyPressed, AddressOf OnKeyPressed
            AddHandler window_.KeyReleased, AddressOf OnKeyReleased
            AddHandler window_.MouseMoved, AddressOf OnMouseMoved
            AddHandler window_.MouseButtonPressed, AddressOf OnMousePressed
            AddHandler window_.MouseButtonReleased, AddressOf OnMouseReleased
            AddHandler window_.Closed, AddressOf OnClosed
            
            ' frame limit (engine side)
            window_.SetFramerateLimit(60)
        End Sub

        Public Function GetWidth() As Integer
            Return width_
        End Function

        Public Function GetHeight() As Integer
            Return height_
        End Function

        Public Sub Clear(color As UInteger)
            Array.Fill(pixels_, color)
        End Sub

        Public Sub SetPixel(x As Integer, y As Integer, color As UInteger)
            If x >= 0 AndAlso x < width_ AndAlso y >= 0 AndAlso y < height_ Then
                pixels_(y * width_ + x) = color
            End If
        End Sub

        ' Обработчики событий SFML
        Private Sub OnKeyPressed(sender As Object, e As KeyEventArgs)
            RaiseEvent KeyPressed(Me, e)
        End Sub

        Private Sub OnKeyReleased(sender As Object, e As KeyEventArgs)
            RaiseEvent KeyReleased(Me, e)
        End Sub

        Private Sub OnMouseMoved(sender As Object, e As MouseMoveEventArgs)
            RaiseEvent MouseMoved(Me, e)
        End Sub

        Private Sub OnMousePressed(sender As Object, e As MouseButtonEventArgs)
            RaiseEvent MousePressed(Me, e)
        End Sub

        Private Sub OnMouseReleased(sender As Object, e As MouseButtonEventArgs)
            RaiseEvent MouseReleased(Me, e)
        End Sub

        Private Sub OnClosed(sender As Object, e As EventArgs)
            RaiseEvent Closed(Me, EventArgs.Empty)
        End Sub

        Public Sub Render()
            Dim byteArray(pixels_.Length * 4 - 1) As Byte
            For i As Integer = 0 To pixels_.Length - 1
                Dim color As UInteger = pixels_(i)
                ' AARRGGBB
                Dim a As Byte = CByte((color >> 24) And &HFF)
                Dim r As Byte = CByte((color >> 16) And &HFF)
                Dim g As Byte = CByte((color >> 8) And &HFF)
                Dim b As Byte = CByte(color And &HFF)
                ' В SFML Image ожидает байты в порядке R, G, B, A
                byteArray(i * 4) = r
                byteArray(i * 4 + 1) = g
                byteArray(i * 4 + 2) = b
                byteArray(i * 4 + 3) = a
            Next

            image_ = New Image(CUInt(width_), CUInt(height_), byteArray)
            texture_.Update(image_)

            window_.Clear(Color.Black)
            window_.Draw(sprite_)
            window_.Display()

            window_.DispatchEvents()
        End Sub

        Public Function IsOpen() As Boolean
            Return window_.IsOpen
        End Function

        Public Sub Close()
            window_.Close()
        End Sub

        Public Function GetMousePosition() As Vector2i
            Return Mouse.GetPosition(window_)
        End Function

        Public Sub SetMousePosition(position As Vector2i)
            Mouse.SetPosition(position, window_)
        End Sub

        Public Sub SetMouseVisible(visible As Boolean)
            window_.SetMouseCursorVisible(visible)
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean = False

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    window_.Dispose()
                    texture_.Dispose()
                    sprite_.Dispose()
                    If image_ IsNot Nothing Then
                        image_.Dispose()
                    End If
                End If
                disposedValue = True
            End If
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
        End Sub
#End Region

    End Class
End Namespace