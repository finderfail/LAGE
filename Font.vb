Imports System.Collections.Generic

Public Class BitmapFont
    Public Shared ReadOnly Property FontData As Dictionary(Of Char, UShort())
        Get
            Return New Dictionary(Of Char, UShort())() From {
                {"A"c, New UShort() {&H0F0, &H1F8, &H39C, &H71E, &H71E, &H71E, &H7FE, &H7FE, &H71E, &H71E, &H71E, &H71E}},
                {"B"c, New UShort() {&H7FC, &H7FE, &H71E, &H71E, &H73C, &H7F8, &H7FC, &H71E, &H70E, &H71E, &H7FE, &H7FC}},
                {"C"c, New UShort() {&H1FC, &H3FE, &H78E, &H706, &H700, &H700, &H700, &H700, &H706, &H78E, &H3FE, &H1FC}},
                {"D"c, New UShort() {&H7F8, &H7FC, &H71E, &H70E, &H70E, &H70E, &H70E, &H70E, &H70E, &H71E, &H7FC, &H7F8}},
                {"E"c, New UShort() {&H7FE, &H7FE, &H700, &H700, &H700, &H7FC, &H7FC, &H700, &H700, &H700, &H7FE, &H7FE}},
                {"F"c, New UShort() {&H7FE, &H7FE, &H700, &H700, &H700, &H7FC, &H7FC, &H700, &H700, &H700, &H700, &H700}},
                {"G"c, New UShort() {&H1FC, &H3FE, &H78E, &H706, &H700, &H73E, &H73E, &H70E, &H70E, &H78E, &H3FE, &H1FC}},
                {"H"c, New UShort() {&H71E, &H71E, &H71E, &H71E, &H71E, &H7FE, &H7FE, &H71E, &H71E, &H71E, &H71E, &H71E}},
                {"I"c, New UShort() {&H1FE, &H1FE, &H78, &H78, &H78, &H78, &H78, &H78, &H78, &H78, &H1FE, &H1FE}},
                {"J"c, New UShort() {&HFE, &HFE, &H1E, &H1E, &H1E, &H1E, &H1E, &H1E, &H71E, &H71E, &H7FC, &H3F8}},
                {"K"c, New UShort() {&H71E, &H73C, &H778, &H770, &H7E0, &H7C0, &H7E0, &H770, &H778, &H73C, &H71E, &H70E}},
                {"L"c, New UShort() {&H700, &H700, &H700, &H700, &H700, &H700, &H700, &H700, &H700, &H700, &H7FE, &H7FE}},
                {"M"c, New UShort() {&H707, &H78F, &H7DF, &H7FF, &H777, &H777, &H707, &H707, &H707, &H707, &H707, &H707}},
                {"N"c, New UShort() {&H707, &H787, &H7C7, &H7E7, &H7F7, &H77F, &H73F, &H71F, &H70F, &H707, &H707, &H707}},
                {"O"c, New UShort() {&H1F8, &H3FC, &H79E, &H70E, &H70E, &H70E, &H70E, &H70E, &H70E, &H79E, &H3FC, &H1F8}},
                {"P"c, New UShort() {&H7FC, &H7FE, &H71E, &H71E, &H71E, &H7FE, &H7FC, &H700, &H700, &H700, &H700, &H700}},
                {"Q"c, New UShort() {&H1F8, &H3FC, &H79E, &H70E, &H70E, &H70E, &H70E, &H70E, &H77E, &H7BE, &H3FC, &H1FE}},
                {"R"c, New UShort() {&H7FC, &H7FE, &H71E, &H71E, &H71E, &H7FC, &H7F8, &H73C, &H71E, &H70E, &H70E, &H707}},
                {"S"c, New UShort() {&H3FC, &H7FE, &H70E, &H700, &H700, &H3FC, &HFE, &HE, &HE, &H70E, &H7FE, &H3FC}},
                {"T"c, New UShort() {&H7FE, &H7FE, &H78, &H78, &H78, &H78, &H78, &H78, &H78, &H78, &H78, &H78}},
                {"U"c, New UShort() {&H70E, &H70E, &H70E, &H70E, &H70E, &H70E, &H70E, &H70E, &H70E, &H79E, &H3FC, &H1F8}},
                {"V"c, New UShort() {&H70E, &H70E, &H70E, &H70E, &H71C, &H71C, &H39C, &H398, &H3B8, &H1F0, &H1F0, &HE0}},
                {"W"c, New UShort() {&H707, &H707, &H707, &H707, &H707, &H777, &H777, &H7FF, &H7DF, &H79F, &H78F, &H707}},
                {"X"c, New UShort() {&H707, &H78F, &H39C, &H3DC, &H1F8, &HF0, &HF0, &H1F8, &H3DC, &H39C, &H78F, &H707}},
                {"Y"c, New UShort() {&H707, &H78F, &H39C, &H3DC, &H1F8, &HF0, &H70, &H70, &H70, &H70, &H70, &H70}},
                {"Z"c, New UShort() {&H7FE, &H7FE, &HE, &H1C, &H38, &H70, &HE0, &H1C0, &H380, &H700, &H7FE, &H7FE}},
                {"0"c, New UShort() {&H1F8, &H3FC, &H79E, &H73E, &H77E, &H7EE, &H7CE, &H7DE, &H79E, &H79E, &H3FC, &H1F8}},
                {"1"c, New UShort() {&H78, &H1F8, &H3F8, &H78, &H78, &H78, &H78, &H78, &H78, &H78, &H7FE, &H7FE}},
                {"2"c, New UShort() {&H3FC, &H7FE, &H70E, &HE, &H1E, &H3C, &H78, &HF0, &H1E0, &H3C0, &H7FE, &H7FE}},
                {"3"c, New UShort() {&H3FC, &H7FE, &H70E, &HE, &HE, &H1FC, &H1FC, &HE, &HE, &H70E, &H7FE, &H3FC}},
                {"4"c, New UShort() {&H1C, &H3C, &H7C, &HFC, &H1DC, &H39C, &H71C, &H7FE, &H7FE, &H1C, &H1C, &H1C}},
                {"5"c, New UShort() {&H7FE, &H7FE, &H700, &H700, &H7FC, &H7FE, &HE, &HE, &HE, &H70E, &H7FE, &H3FC}},
                {"6"c, New UShort() {&H3FC, &H7FE, &H70E, &H700, &H700, &H7FC, &H7FE, &H70E, &H70E, &H70E, &H7FE, &H3FC}},
                {"7"c, New UShort() {&H7FE, &H7FE, &HE, &H1C, &H38, &H70, &HE0, &HE0, &HE0, &HE0, &HE0, &HE0}},
                {"8"c, New UShort() {&H3FC, &H7FE, &H70E, &H70E, &H70E, &H3FC, &H3FC, &H70E, &H70E, &H70E, &H7FE, &H3FC}},
                {"9"c, New UShort() {&H3FC, &H7FE, &H70E, &H70E, &H70E, &H3FE, &H1FE, &HE, &HE, &H70E, &H7FE, &H3FC}},
                {" "c, New UShort() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}},
                {"!"c, New UShort() {&H78, &H78, &H78, &H78, &H78, &H78, &H78, &H78, &H0, &H78, &H78, &H0}},
                {":"c, New UShort() {&H0, &H0, &H78, &H78, &H0, &H0, &H0, &H78, &H78, &H0, &H0, &H0}},
                {"/"c, New UShort() {&HE, &H1C, &H1C, &H38, &H38, &H70, &H70, &HE0, &HE0, &H1C0, &H1C0, &H380}},
                {"-"c, New UShort() {&H0, &H0, &H0, &H0, &H0, &H7FE, &H7FE, &H0, &H0, &H0, &H0, &H0}},
                {"@"c, New UShort() {&H1F8, &H3FC, &H79E, &H736, &H776, &H76E, &H76E, &H76E, &H77E, &H73C, &H79E, &H3FC, &H1F8}},
                {"."c, New UShort() {&H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H78, &H78, &H0}},
                {"#"c, New UShort() {&H1DC, &H1DC, &H1DC, &H7FE, &H7FE, &H1DC, &H1DC, &H7FE, &H7FE, &H1DC, &H1DC, &H1DC}},
                {"$"c, New UShort() {&H78, &H1FE, &H3FF, &H787, &H780, &H3FE, &HFF, &H87, &H787, &H7FF, &H3FE, &H78}},
                {"%"c, New UShort() {&H707, &H78F, &H39C, &H3B8, &H1F0, &H70, &HE0, &H1F8, &H3BC, &H79C, &H70E, &H707}},
                {"&"c, New UShort() {&H1F0, &H3F8, &H39C, &H39C, &H1F8, &H3F0, &H77C, &H73E, &H71E, &H78E, &H3FE, &H1F7}},
                {"("c, New UShort() {&H1E, &H3C, &H78, &H70, &HE0, &HE0, &HE0, &HE0, &H70, &H78, &H3C, &H1E}},
                {")"c, New UShort() {&H78, &H3C, &H1E, &HE, &H7, &H7, &H7, &H7, &HE, &H1E, &H3C, &H78}},
                {"["c, New UShort() {&H1FE, &H1FE, &H180, &H180, &H180, &H180, &H180, &H180, &H180, &H180, &H1FE, &H1FE}},
                {"]"c, New UShort() {&H1FE, &H1FE, &H6, &H6, &H6, &H6, &H6, &H6, &H6, &H6, &H1FE, &H1FE}},
                {"{"c, New UShort() {&HE, &H1C, &H38, &H38, &H38, &H70, &H38, &H38, &H38, &H38, &H1C, &HE}},
                {"}"c, New UShort() {&H70, &H38, &H1C, &H1C, &H1C, &HE, &H1C, &H1C, &H1C, &H1C, &H38, &H70}},
                {"<"c, New UShort() {&HE, &H1C, &H38, &H70, &HE0, &H1C0, &H1C0, &HE0, &H70, &H38, &H1C, &HE}},
                {">"c, New UShort() {&H70, &H38, &H1C, &HE, &H7, &H3, &H3, &H7, &HE, &H1C, &H38, &H70}},
                {"="c, New UShort() {&H0, &H0, &H0, &H7FE, &H7FE, &H0, &H0, &H7FE, &H7FE, &H0, &H0, &H0}},
                {"+"c, New UShort() {&H0, &H78, &H78, &H78, &H7FE, &H7FE, &H78, &H78, &H78, &H0, &H0, &H0}},
                {"_"c, New UShort() {&H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H7FE}},
                {"'"c, New UShort() {&H78, &H78, &H78, &H78, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0}},
                {""""c, New UShort() {&H1CE, &H1CE, &H1CE, &H1CE, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0}},
                {"?"c, New UShort() {&H3FC, &H7FE, &H70E, &HE, &H1C, &H38, &H70, &H70, &H0, &H70, &H70, &H0}},
                {","c, New UShort() {&H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H78, &H78, &HF0}},
                {"a"c, New UShort() {&H0, &H0, &H3FC, &H7FE, &HE, &H3FE, &H7FE, &H70E, &H70E, &H7FE, &H3FE, &H0}},
                {"b"c, New UShort() {&H700, &H700, &H7FC, &H7FE, &H70E, &H70E, &H70E, &H70E, &H70E, &H7FE, &H7FC, &H0}},
                {"c"c, New UShort() {&H0, &H0, &H3FC, &H7FE, &H70E, &H700, &H700, &H700, &H70E, &H7FE, &H3FC, &H0}},
                {"d"c, New UShort() {&HE, &HE, &H3FE, &H7FE, &H70E, &H70E, &H70E, &H70E, &H70E, &H7FE, &H3FE, &H0}},
                {"e"c, New UShort() {&H0, &H0, &H3FC, &H7FE, &H70E, &H7FE, &H7FE, &H700, &H70E, &H7FE, &H3FC, &H0}},
                {"f"c, New UShort() {&H1FC, &H3FE, &H380, &H380, &H7FC, &H7FC, &H380, &H380, &H380, &H380, &H380, &H0}},
                {"g"c, New UShort() {&H0, &H0, &H3FE, &H7FE, &H70E, &H70E, &H70E, &H7FE, &H3FE, &HE, &H7FE, &H3FC}},
                {"h"c, New UShort() {&H700, &H700, &H7FC, &H7FE, &H70E, &H70E, &H70E, &H70E, &H70E, &H70E, &H70E, &H0}},
                {"i"c, New UShort() {&H78, &H0, &H1F8, &H1F8, &H78, &H78, &H78, &H78, &H78, &H1FE, &H1FE, &H0}},
                {"j"c, New UShort() {&H1E, &H0, &H1FE, &H1FE, &H1E, &H1E, &H1E, &H1E, &H1E, &H1E, &H7FC, &H3F8}},
                {"k"c, New UShort() {&H700, &H700, &H70E, &H71C, &H738, &H770, &H7E0, &H7F0, &H738, &H71C, &H70E, &H0}},
                {"l"c, New UShort() {&H1F8, &H1F8, &H78, &H78, &H78, &H78, &H78, &H78, &H78, &H1FE, &H1FE, &H0}},
                {"m"c, New UShort() {&H0, &H0, &H777, &H7FF, &H7FF, &H7FF, &H7FF, &H777, &H707, &H707, &H707, &H0}},
                {"n"c, New UShort() {&H0, &H0, &H7FC, &H7FE, &H70E, &H70E, &H70E, &H70E, &H70E, &H70E, &H70E, &H0}},
                {"o"c, New UShort() {&H0, &H0, &H3FC, &H7FE, &H70E, &H70E, &H70E, &H70E, &H70E, &H7FE, &H3FC, &H0}},
                {"p"c, New UShort() {&H0, &H0, &H7FC, &H7FE, &H70E, &H70E, &H70E, &H7FE, &H7FC, &H700, &H700, &H700}},
                {"q"c, New UShort() {&H0, &H0, &H3FE, &H7FE, &H70E, &H70E, &H70E, &H7FE, &H3FE, &HE, &HE, &HE}},
                {"r"c, New UShort() {&H0, &H0, &H7BC, &H7FE, &H78E, &H700, &H700, &H700, &H700, &H700, &H700, &H0}},
                {"s"c, New UShort() {&H0, &H0, &H3FE, &H7FE, &H700, &H7FE, &H3FE, &HE, &H70E, &H7FE, &H3FC, &H0}},
                {"t"c, New UShort() {&H380, &H380, &H7FE, &H7FE, &H380, &H380, &H380, &H380, &H380, &H3FE, &H1FE, &H0}},
                {"u"c, New UShort() {&H0, &H0, &H70E, &H70E, &H70E, &H70E, &H70E, &H70E, &H79E, &H3FE, &H1EE, &H0}},
                {"v"c, New UShort() {&H0, &H0, &H70E, &H70E, &H70E, &H71C, &H39C, &H3B8, &H1F8, &H1F0, &HE0, &H0}},
                {"w"c, New UShort() {&H0, &H0, &H707, &H707, &H707, &H777, &H7FF, &H7FF, &H7FF, &H3BE, &H39C, &H0}},
                {"x"c, New UShort() {&H0, &H0, &H70E, &H39C, &H3B8, &H1F0, &HE0, &H1F0, &H3B8, &H39C, &H70E, &H0}},
                {"y"c, New UShort() {&H0, &H0, &H70E, &H70E, &H70E, &H70E, &H70E, &H3FE, &H1FE, &HE, &H7FE, &H3FC}},
                {"z"c, New UShort() {&H0, &H0, &H7FE, &H7FE, &H1C, &H38, &H70, &HE0, &H1C0, &H7FE, &H7FE, &H0}}
            }
        End Get
    End Property

    Public Shared Sub DrawText(screen As LAGE.Screen, x As Integer, y As Integer, text As String, color As UInteger)
        Dim chars As Char() = text.ToCharArray()
        
        For i As Integer = 0 To chars.Length - 1
            DrawChar(screen, x + i * 13, y, chars(i), color)
        Next
    End Sub

    Public Shared Sub DrawChar(screen As LAGE.Screen, x As Integer, y As Integer, c As Char, color As UInteger)
        If Not FontData.ContainsKey(c) Then
            ' Fallback для неизвестных символов
            c = "?"c
        End If

        Dim charData As UShort() = FontData(c)
        
        For row As Integer = 0 To 11
            For col As Integer = 0 To 11
                If (charData(row) And (1 << (11 - col))) <> 0 Then
                    screen.SetPixel(x + col, y + row, color)
                End If
            Next
        Next
    End Sub
End Class