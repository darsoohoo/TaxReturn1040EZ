Imports System.Data.SqlClient
Public Class clsConnection
    Public Shared Function getConnection() As SqlConnection
        Return New SqlConnection("Data Source=TAH2077-2\TAH2077office;Initial Catalog=TaxReturn2014;User ID=MIS;Password=cba")
    End Function
End Class
