Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

<Serializable()> Public Class UserManager

    Private Property AllUsers As List(Of User)

    Public Sub New()
        Me.AllUsers = New List(Of User)
    End Sub

    Public Sub newUser(username As String, password As String, fullname As String, rank As String)
        'User class Hashses the password
        AllUsers.Add(New User(username, password, fullname, rank))
    End Sub

    ' Get Functions
    Public Function getUser(username As String) As User
        Return AllUsers.Find(Function(usr As User) usr.getUsername = username)
    End Function

    Public Function getListOfUsers()
        Return AllUsers
    End Function

    ' Save & Load DB

    Public Function Save(filename As String)
        If AllUsers Is Nothing Then
            Throw New ArgumentNullException(NameOf(AllUsers))
        End If

        If filename Is Nothing Then
            Throw New ArgumentNullException(NameOf(filename))
        End If

        Dim fstream As Stream = New FileStream(filename, FileMode.Create)
        Dim bformatter As BinaryFormatter = New BinaryFormatter()
        bformatter.Serialize(fstream, AllUsers)
        fstream.Close()
        Return True
    End Function

    Public Function Load(filename As String)
        If filename Is Nothing Then
            If filename Is Nothing Then
                Throw New ArgumentNullException(NameOf(filename))
            End If
        End If

        Dim fstream As Stream = New FileStream(filename, FileMode.Open)
        Dim bformatter As BinaryFormatter = New BinaryFormatter()
        AllUsers = CType(bformatter.Deserialize(fstream), List(Of User))
        Return True
    End Function

    ' External List Of Users

    'Public Function saveUserDB(allusers As List(Of User), filename As String)
    '    If allusers Is Nothing Then
    '        Throw New ArgumentNullException(NameOf(allusers))
    '    End If

    '    If filename Is Nothing Then
    '        Throw New ArgumentNullException(NameOf(filename))
    '    End If

    '    Dim fstream As Stream = New FileStream(filename, FileMode.Create)
    '    Dim bformatter As BinaryFormatter = New BinaryFormatter()
    '    bformatter.Serialize(fstream, allusers)
    '    fstream.Close()
    '    Return True

    'End Function

    'Public Function loadUserDB(filename As String) As List(Of User)
    '    If filename Is Nothing Then
    '        If filename Is Nothing Then
    '            Throw New ArgumentNullException(NameOf(filename))
    '        End If
    '    End If

    '    Dim fstream As Stream = New FileStream(filename, FileMode.Open)
    '    Dim bformatter As BinaryFormatter = New BinaryFormatter()
    '    Dim allusers As List(Of User)
    '    allusers = CType(bformatter.Deserialize(fstream), List(Of User))
    '    Return allusers
    'End Function

End Class