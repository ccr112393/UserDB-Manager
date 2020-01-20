<Serializable()> Public Class User

    Private Property Username As String
    Private Property Password As String
    Private Property Fullname As String
    Private Property Rank As String

    Public Sub New(username As String, password As String, fullname As String, rank As String)
        If username Is Nothing Then
            Throw New ArgumentNullException(NameOf(username))
        End If

        If password Is Nothing Then
            Throw New ArgumentNullException(NameOf(password))
        End If

        If fullname Is Nothing Then
            Throw New ArgumentNullException(NameOf(fullname))
        End If

        If rank Is Nothing Then
            Throw New ArgumentNullException(NameOf(rank))
        End If

        Me.Username = username
        Me.Password = Crypto.GenerateSHA512String(password)
        Me.Fullname = fullname
        Me.Rank = rank

    End Sub

    ' Get Properties/Fuctions
    Public Function getUsername() As String
        Return Username
    End Function

    Public Function getPassword() As String
        Return Password
    End Function

    Public Function getFullName() As String
        Return Fullname
    End Function

    Public Function getRank() As String
        Return Rank
    End Function

    Public Function getString() As String
        Return String.Format("{0}, {1}, {2}", getUsername, getFullName, getRank)
    End Function

    Public Function getStringPassword() As String
        Return String.Format("{0}, {1}, {2}, {3}", getUsername, getFullName, getRank, getPassword)
    End Function

    'Set Properties/Functions
    Public Sub setUsername(username As String)
        Me.Username = username
    End Sub

    Public Sub setPassword(password As String)
        Me.Password = Crypto.GenerateSHA512String(password)
    End Sub

    Public Sub setFullName(fullname As String)
        Me.Fullname = fullname
    End Sub

    Public Sub setRank(rank As String)
        Me.Rank = rank
    End Sub

End Class