Imports SFML.Window

Namespace LAGE
    Public Class Input
        Public Shared Function IsKeyPressed(key As Keyboard.Key) As Boolean
            Return Keyboard.IsKeyPressed(key)
        End Function

        Public Shared Function IsMouseButtonPressed(button As Mouse.Button) As Boolean
            Return Mouse.IsButtonPressed(button)
        End Function
    End Class
End Namespace