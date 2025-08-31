Imports System
Imports System.Math

Namespace LAGE
    Public Class Raycaster
        Private map_ As Map
        Private screen_ As Screen

        Public Sub New(map As Map, screen As Screen)
            map_ = map
            screen_ = screen
        End Sub

        Public Sub CastRays(player As Player)
            Dim screenWidth As Integer = screen_.GetWidth()
            Dim screenHeight As Integer = screen_.GetHeight()
            Dim fov As Single = PI / 3.0F

            For x As Integer = 0 To screenWidth - 1
                Dim cameraX As Single = 2.0F * x / CSng(screenWidth) - 1.0F
                Dim rayDirX As Single = player.GetDirection().x + cameraX * (-player.GetDirection().y)
                Dim rayDirY As Single = player.GetDirection().y + cameraX * (player.GetDirection().x)
                Dim rayAngle As Single = Atan2(rayDirY, rayDirX)

                Dim distance As Single = GetDistanceToWall(player.GetPosition().x, player.GetPosition().y, rayAngle)
                If distance > 0 Then
                    Dim wallHeight As Integer = CalculateWallHeight(distance)
                    DrawVerticalLine(x, wallHeight, distance)
                End If
            Next
        End Sub

        Private Function GetDistanceToWall(playerX As Single, playerY As Single, angle As Single) As Single
            Dim dirX As Single = Cos(angle)
            Dim dirY As Single = Sin(angle)

            Dim mapX As Integer = CInt(playerX)
            Dim mapY As Integer = CInt(playerY)

            Dim deltaDistX As Single = Abs(1.0F / dirX)
            Dim deltaDistY As Single = Abs(1.0F / dirY)

            Dim sideDistX As Single = 0.0F
            Dim sideDistY As Single = 0.0F

            Dim stepX As Integer = 0
            Dim stepY As Integer = 0

            If dirX < 0 Then
                stepX = -1
                sideDistX = (playerX - mapX) * deltaDistX
            Else
                stepX = 1
                sideDistX = (mapX + 1.0F - playerX) * deltaDistX
            End If

            If dirY < 0 Then
                stepY = -1
                sideDistY = (playerY - mapY) * deltaDistY
            Else
                stepY = 1
                sideDistY = (mapY + 1.0F - playerY) * deltaDistY
            End If

            Dim hit As Boolean = False
            Dim side As Integer = 0

            While Not hit
                If sideDistX < sideDistY Then
                    sideDistX += deltaDistX
                    mapX += stepX
                    side = 0
                Else
                    sideDistY += deltaDistY
                    mapY += stepY
                    side = 1
                End If

                If map_.GetTile(mapX, mapY) <> " "c Then
                    hit = True
                End If
            End While

            If side = 0 Then
                Return (mapX - playerX + (1 - stepX) / 2.0F) / dirX
            Else
                Return (mapY - playerY + (1 - stepY) / 2.0F) / dirY
            End If
        End Function

        Private Function CalculateWallHeight(distance As Single) As Single
            Dim cameraPlaneDistance As Single = screen_.GetWidth() / (2.0F * Tan(PI / 6.0F))
            Dim wallHeight As Single = cameraPlaneDistance / distance + 12.0F
            Return Min(CSng(screen_.GetHeight()), wallHeight)
        End Function

        Private Sub DrawVerticalLine(x As Integer, wallHeight As Integer, distance As Single)
            Dim startY As Integer = (screen_.GetHeight() - wallHeight) \ 2
            Dim endY As Integer = (screen_.GetHeight() + wallHeight) \ 2

            Dim baseColor As UInteger = &HFF6A5ACDUI 'fиолетовый цвет
            Dim brightness As Single = 1.0F - Math.Min(1.0F, distance / 10.0F)
            Dim r As Byte = CByte((baseColor >> 16) And &HFF)
            Dim g As Byte = CByte((baseColor >> 8) And &HFF)
            Dim b As Byte = CByte(baseColor And &HFF)
            r = CByte(r * brightness)
            g = CByte(g * brightness)
            b = CByte(b * brightness)
            Dim color As UInteger = CUInt((r << 16) Or (g << 8) Or b Or &HFF000000UI)

            For y As Integer = startY To endY - 1
                screen_.SetPixel(x, y, color)
            Next
        End Sub
    End Class
End Namespace