Imports System
Imports System.Collections.Generic
Imports System.Math

Namespace LAGE
    Public Class Player
        Private position_ As Point2D
        Private direction_ As Vector2D
        Private fovAngle_ As Single
        Private fovRadius_ As Single

        Public Sub New(x As Single, y As Single, direction As Single, fovAngle As Single, fovRadius As Single)
            position_ = New Point2D()
            position_.x = x
            position_.y = y
            direction_ = New Vector2D()
            direction_.x = Cos(direction)
            direction_.y = Sin(direction)
            fovAngle_ = fovAngle
            fovRadius_ = fovRadius
        End Sub

        Public Function GetPosition() As Point2D
            Return position_
        End Function

        Public Function GetDirection() As Vector2D
            Return direction_
        End Function

        Public Sub SetPosition(x As Single, y As Single)
            position_.x = x
            position_.y = y
        End Sub

        Public Sub SetDirection(direction As Single)
            direction_.x = Cos(direction)
            direction_.y = Sin(direction)
        End Sub

        Public Sub Move(distance As Single, map As Map)
            Dim newX As Single = position_.x + direction_.x * distance
            Dim newY As Single = position_.y + direction_.y * distance

            If Not CheckCollision(newX, newY, map) Then
                position_.x = newX
                position_.y = newY
            End If
        End Sub

        Public Sub Rotate(angle As Single)
            Dim oldDirX As Single = direction_.x
            direction_.x = direction_.x * Cos(angle) - direction_.y * Sin(angle)
            direction_.y = oldDirX * Sin(angle) + direction_.y * Cos(angle)
        End Sub

        Private Function CheckCollision(x As Single, y As Single, map As Map) As Boolean
            Dim mapX As Integer = CInt(x)
            Dim mapY As Integer = CInt(y)

            If mapX < 0 OrElse mapX >= map.GetWidth() OrElse mapY < 0 OrElse mapY >= map.GetHeight() OrElse map.GetTile(mapX, mapY) <> " "c Then
                Return True  ' Collision
            End If

            Return False  ' No collision
        End Function

        Public Function CalculateFOVVertices() As List(Of Point2D)
            Dim vertices As New List(Of Point2D)()
            Dim angleIncrement As Single = fovAngle_ / 30 ' 30 segments for a smoother circle
            Dim startAngle As Single = Atan2(direction_.y, direction_.x) - (fovAngle_ / 2)

            For i As Integer = 0 To 30
                Dim angle As Single = startAngle + (i * angleIncrement)
                Dim x As Single = position_.x + fovRadius_ * Cos(angle)
                Dim y As Single = position_.y + fovRadius_ * Sin(angle)
                vertices.Add(New Point2D() With {.x = x, .y = y})
            Next

            Return vertices
        End Function

    End Class

    Public Class Point2D
        Public x As Single
        Public y As Single
    End Class

    Public Class Vector2D
        Public x As Single
        Public y As Single
    End Class
End Namespace