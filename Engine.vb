Imports SFML.Window

Namespace LAGE
    Public Class Engine
        Private screen_ As Screen
        Private map_ As Map
        Private player_ As Player
        Private raycaster_ As Raycaster
        Private config_ As Config
        
        Public Event OnInitialize As EventHandler
        Public Event OnUpdate As EventHandler
        Public Event OnRender As EventHandler

        Public Sub New(configPath As String)
            config_ = New Config()
            If Not config_.Load(configPath) Then
                Throw New Exception("Failed to load config file: " & configPath)
            End If
            
            Dim width = config_.GetInt("screen_width", 800)
            Dim height = config_.GetInt("screen_height", 600)
            Dim title = config_.Get("window_title", "LAGE Engine")
            
            screen_ = New Screen(width, height, title)
        End Sub

        Public Sub Initialize()
            map_ = New Map()
            If Not map_.Load(config_.Get("map_file", "map.txt")) Then
                Throw New Exception("Failed to load map file")
            End If

            Dim startX = config_.GetFloat("player_start_x", 1.5F)
            Dim startY = config_.GetFloat("player_start_y", 1.5F)
            Dim startDir = config_.GetFloat("player_start_dir", 0.0F)
            Dim fovAngle = config_.GetFloat("player_fov", 1.0472F) ' 60 
            Dim fovRadius = config_.GetFloat("player_view_distance", 10.0F)
            
            player_ = New Player(startX, startY, startDir, fovAngle, fovRadius)
            raycaster_ = New Raycaster(map_, screen_)

            RaiseEvent OnInitialize(Me, EventArgs.Empty)
        End Sub

        Public Sub Run()
            Initialize()

            While screen_.IsOpen()
                Update()
                Render()
            End While
        End Sub

        Private Sub Update()
            HandleInput()
            
            RaiseEvent OnUpdate(Me, EventArgs.Empty)
        End Sub

        Private Sub Render()
            screen_.Clear(0)
            raycaster_.CastRays(player_)
            RaiseEvent OnRender(Me, EventArgs.Empty)
            screen_.Render()
        End Sub

        Private Sub HandleInput()
            
            If Keyboard.IsKeyPressed(Keyboard.Key.W) Then
                player_.Move(0.05F, map_)
            End If
            If Keyboard.IsKeyPressed(Keyboard.Key.S) Then
                player_.Move(-0.05F, map_)
            End If
            If Keyboard.IsKeyPressed(Keyboard.Key.A) Then
                player_.Rotate(-0.05F)
            End If
            If Keyboard.IsKeyPressed(Keyboard.Key.D) Then
                player_.Rotate(0.05F)
            End If
            If Keyboard.IsKeyPressed(Keyboard.Key.Escape) Then
                screen_.Close()
            End If
        End Sub
        
        Public ReadOnly Property Screen As Screen
            Get
                Return screen_
            End Get
        End Property
        
        Public ReadOnly Property Player As Player
            Get
                Return player_
            End Get
        End Property
        
        Public ReadOnly Property Map As Map
            Get
                Return map_
            End Get
        End Property
    End Class
End Namespace