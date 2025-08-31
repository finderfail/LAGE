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
            position_.x = Math.Round(x, 3)
            position_.y = Math.Round(y, 3)
            direction_ = New Vector2D()
            direction_.x = Math.Round(Cos(direction), 3)
            direction_.y = Math.Round(Sin(direction), 3)
            fovAngle_ = Math.Round(fovAngle, 3)
            fovRadius_ = Math.Round(fovRadius, 3)
        End Sub

        Public Function GetPosition() As Point2D
            Return position_
        End Function

        Public Function GetDirection() As Vector2D
            Return direction_
        End Function

        Public Sub SetPosition(x As Single, y As Single)
            position_.x = Math.Round(x, 3)
            position_.y = Math.Round(y, 3)
        End Sub

        Public Sub SetDirection(direction As Single)
            direction_.x = Math.Round(Cos(direction), 3)
            direction_.y = Math.Round(Sin(direction), 3)
        End Sub

        Public Sub Move(distance As Single, map As Map)
            Dim newX As Single = Math.Round(position_.x + direction_.x * distance, 3)
            Dim newY As Single = Math.Round(position_.y + direction_.y * distance, 3)

            If Not CheckCollision(newX, newY, map) Then
                position_.x = newX
                position_.y = newY
            End If
        End Sub

        Public Sub Rotate(angle As Single)
            Dim oldDirX As Single = direction_.x
            direction_.x = Math.Round(direction_.x * Cos(angle) - direction_.y * Sin(angle), 3)
            direction_.y = Math.Round(oldDirX * Sin(angle) + direction_.y * Cos(angle), 3)
        End Sub

        Private Function CheckCollision(x As Single, y As Single, map As Map) As Boolean
            Return Not map.IsWalkable(x, y)
        End Function

        Public Function CalculateFOVVertices() As List(Of Point2D)
            Dim vertices As New List(Of Point2D)()
            Dim angleIncrement As Single = Math.Round(fovAngle_ / 30, 3) ' 30 segments for a smoother circle
            Dim startAngle As Single = Math.Round(Atan2(direction_.y, direction_.x) - (fovAngle_ / 2), 3)

            For i As Integer = 0 To 30
                Dim angle As Single = Math.Round(startAngle + (i * angleIncrement), 3)
                Dim x As Single = Math.Round(position_.x + fovRadius_ * Cos(angle), 3)
                Dim y As Single = Math.Round(position_.y + fovRadius_ * Sin(angle), 3)
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