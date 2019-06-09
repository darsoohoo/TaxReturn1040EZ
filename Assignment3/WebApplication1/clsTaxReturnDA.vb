Imports System.Data.SqlClient

Public Class clsTaxReturnDA

    Public Shared Function getTaxReturn(ByVal intTaxPayerID As Integer, ByVal strTaxYear As String) As clsTaxReturn
        Dim connection As SqlConnection = clsConnection.getConnection()
        Dim strSelectStatement As String = "SELECT * FROM [TaxReturn2014].[dbo].[tblTaxReturn] WHERE TaxPayerID =" & intTaxPayerID & " AND TaxYear = '" & strTaxYear & "'"
        Dim command As New SqlCommand(strSelectStatement, connection) '
        connection.Open()
        Dim reader As SqlDataReader = command.ExecuteReader(CommandBehavior.SingleRow)

        Dim myTaxReturn As clsTaxReturn

        If reader.Read Then
            Dim isJointTaxReturn = reader.GetBoolean(2)
            Dim intNumberOfTaxPayers = 0
            If isJointTaxReturn Then
                intNumberOfTaxPayers = 2
            Else
                intNumberOfTaxPayers = 1
            End If

            Dim strDependentTaxPayerStatus As String = reader.GetString(6)
            Dim intDependentTaxPayers As Integer

            If strDependentTaxPayerStatus.StartsWith(1) Then
                intDependentTaxPayers = 1
            End If
            If strDependentTaxPayerStatus.EndsWith(1) Then
                intDependentTaxPayers = intDependentTaxPayers + 1
            End If

            myTaxReturn = New clsTaxReturn(intTaxPayerID, strTaxYear, CDbl(reader.GetDecimal(3)), _
                             CDbl(reader.GetDecimal(4)), CDbl(reader.GetDecimal(5)), CDbl(reader.GetDecimal(7)), _
                             CDbl(reader.GetDecimal(8)), CDbl(reader.GetDecimal(9)), intNumberOfTaxPayers, intDependentTaxPayers)
        Else
            Throw New KeyNotFoundException("The Tax Return you selected does not exist in the database." & vbCrLf & vbCrLf & _
                                       "Please check your records.")
        End If
        connection.Close()
        Return myTaxReturn
    End Function
    Public Shared Function updateTaxReturn(ByRef updTaxReturn As clsTaxReturn) As Integer
        Dim connection As SqlConnection = clsConnection.getConnection()

        Dim isJointTaxReturn As Boolean = False
        If updTaxReturn.NumberOfTaxpayers = 2 Then
            isJointTaxReturn = True
        End If

        ' UPDATE tblTaxReturn SET TaxPayerID =, TaxYear =, IsJointTaxReturn =, Wages =, TaxableInterest =, UnemploymentCompensation =, DependentStatus =, IncomeTaxWithheld =, EarnedIncomeCredit =, NontaxableCompatPay =
        Dim strUpdateStatement As String = "UPDATE [TaxReturn2014].[dbo].[tblTaxReturn] SET " & _
             "TaxPayerID = " & updTaxReturn.mintTaxPayerID & ", " & _
             "TaxYear ='" & updTaxReturn.mstrTaxYear & "', " & _
             "IsJointTaxReturn ='" & isJointTaxReturn & "', " & _
             "Wages =" & updTaxReturn.Wages & ", " & _
             "TaxableInterest =" & updTaxReturn.TaxableInterest & ", " & _
             "UnemploymentCompensation =" & updTaxReturn.UnemploymentCompensation & ", " & _
             "DependentStatus ='" & updTaxReturn.NumberOfDependentTaxpayers & "', " & _
             "IncomeTaxWithheld =" & updTaxReturn.IncomeTaxWithheld & ", " & _
             "EarnedIncomeCredit =" & updTaxReturn.EIC & ", " & _
             "NontaxableCompatPay = " & updTaxReturn.CompatPay & _
             "WHERE TaxPayerID =" & updTaxReturn.mintTaxPayerID & " AND TaxYear = '" & updTaxReturn.mstrTaxYear & "'"

        Dim command As New SqlCommand(strUpdateStatement, connection)
        connection.Open()
        Return command.ExecuteNonQuery()
    End Function

    Public Shared Function insertTaxReturn(ByRef newTaxReturn As clsTaxReturn) As Integer
        'INSERT INTO [tblTaxPayer] ([TaxPayerID], [TaxPayerLastName], [TaxPayerFirstName], [TaxPayerInitial], [TaxPayerAddress], [TaxPayerCity], [TaxPayerState], [TaxPayerZip]) VALUES (@TaxPayerID, @TaxPayerLastName, @TaxPayerFirstName, @TaxPayerInitial, @TaxPayerAddress, @TaxPayerCity, @TaxPayerState, @TaxPayerZip
        Dim connection As SqlConnection = clsConnection.getConnection()

        Dim isJointTaxReturn As Boolean = False
        If newTaxReturn.NumberOfTaxpayers = 2 Then
            isJointTaxReturn = True
        End If

        Dim strInsertStatement As String = "INSERT INTO [TaxReturn2014].[dbo].[tblTaxReturn] " _
            & "(TaxPayerID, TaxYear, IsJointTaxReturn, Wages, TaxableInterest, UnemploymentCompensation, DependentStatus, IncomeTaxWithheld, EarnedIncomeCredit, NontaxableCompatPay) VALUES (" _
            & newTaxReturn.mintTaxPayerID & ", '" & newTaxReturn.mstrTaxYear & "', '" & isJointTaxReturn & "', " & newTaxReturn.Wages & ", " & newTaxReturn.TaxableInterest _
            & ", " & newTaxReturn.UnemploymentCompensation & ", '" & newTaxReturn.mstrNumberOfDependentTaxpayers & "', " & newTaxReturn.IncomeTaxWithheld & ", " & newTaxReturn.EIC _
            & ", " & newTaxReturn.CompatPay & ") "

        Dim command As New SqlCommand(strInsertStatement, connection)
        connection.Open()
        Return command.ExecuteNonQuery()
    End Function
End Class
